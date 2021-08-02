using System;
using System.IO;
using System.Text;
using System.Xml;

namespace TroubleTool
{
    static class IndexHelper
    {
        public static XmlDocument LoadIndex (String path)
        {
            byte[] data = File.ReadAllBytes(path);
            Crypt.decrypt(data, data.Length);
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
            Crypt.encrypt(data_enc, data_enc.Length);
            File.WriteAllBytes(path, data_enc);
        }
    }
}
