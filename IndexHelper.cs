using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace TroubleTool
{
    static class IndexHelper
    {
        public static XmlDocument LoadIndex(String path)
        {
            byte[] data = File.ReadAllBytes(path);
            data = Crypt.Decrypt(data);
            // check if the file is a zip file
            if ((data[0] == 0x50) && (data[1] == 0x4b))
            {
                byte[] tempData;
                using (var stream = new MemoryStream(data))
                {
                    using (ZipArchive z = new ZipArchive(stream))
                    {
                        ZipArchiveEntry entry = z.GetEntry("index");
                        tempData = new byte[entry.Length];
                        using (var entryStream = entry.Open())
                        {
                            entryStream.Read(tempData, 0, (int)entry.Length);
                        }
                    }
                }
                data = tempData;
            }

            int i = data.Length - 1;
            while (data[i] == 0)
            {
                data[i] = (byte)' ';
                i--;
            }
            String datax = Encoding.UTF8.GetString(data);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(datax);
            return doc;
        }

        public static void SaveIndex(XmlDocument doc, String path)
        {
            // make sure that that index file is flagged as modded
            doc.DocumentElement.SetAttribute("mod", "true");

            byte[] data_enc = null;
            using (var stream = new MemoryStream())
            {
                doc.Save(stream);
                int pad = (int)(16 - (stream.Length % 16));
                if (pad != 16)
                {
                    stream.Write(new byte[pad], 0, pad);
                }
                data_enc = stream.ToArray();
            }
            data_enc = Crypt.Encrypt(data_enc);
            File.WriteAllBytes(path, data_enc);
        }
    }
}
