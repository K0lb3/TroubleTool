using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace TroubleTool
{
    class AssetManager
    {
        internal XmlDocument indexXml;
        internal String root;
        internal String package;
        internal String data;
        internal String mods;
        internal String backup;
        internal String indexPath;
        internal String indexBackUpPath;

        public AssetManager(String gameRoot)
        {
            root = gameRoot;
            package = Path.Combine(root, "Package");
            package = Path.Combine(root, "Package");
            data = Path.Combine(root, "Data");
            mods = Path.Combine(root, "Mods");
            indexPath = Path.Combine(package, "index");
            indexBackUpPath = Path.Combine(package, "index_backup");
            //LoadIndex();
        }

        internal void LoadIndex()
        {
            // load original index
            indexXml = IndexHelper.LoadIndex(indexPath);
            // check if the index file is modded, if so, load the backup
            if (indexXml.DocumentElement.HasAttribute("mod"))
            {
                indexXml = IndexHelper.LoadIndex(indexBackUpPath);
            } else
            {
                if ((!File.Exists(indexBackUpPath)) || (new FileInfo(indexPath).Length != new FileInfo(indexBackUpPath).Length))
                    File.Copy(indexPath, indexBackUpPath, true);
            };
        }

        internal void SaveIndex()
        {
            IndexHelper.SaveIndex(indexXml, indexPath);
        }

        internal XmlNodeList GetEntries()
        {
            XmlElement root = indexXml.DocumentElement;
            return root.ChildNodes;
        }

        internal List<XmlElement> FindUnExtractedAndUpdatedEntries()
        {
            List<XmlElement> toExtract = new List<XmlElement>();
            foreach (XmlElement entry in GetEntries())
            {
                String src = Path.Combine(package, entry.GetAttribute("pack"));
                String dst = Path.Combine(data, entry.GetAttribute("original"));

                if (((!File.Exists(dst)) || (Int32.Parse(entry.GetAttribute("size")) != new FileInfo(dst).Length)) && (Int32.Parse(entry.GetAttribute("csize")) == new FileInfo(src).Length))
                {
                    toExtract.Add(entry);
                }
            }
            return toExtract;
        }

        internal List<XmlElement> BackUpPackageFiles(List<String> files)
        {
            List<XmlElement> toBackUp = new List<XmlElement>();
            foreach (String file in files)
            {
                XmlElement entry = indexXml.DocumentElement;
                String src = Path.Combine(package, entry.GetAttribute("pack"));
                String dst = Path.Combine(data, entry.GetAttribute("original"));

                if (((!File.Exists(dst)) || (Int32.Parse(entry.GetAttribute("size")) != new FileInfo(dst).Length)) && (Int32.Parse(entry.GetAttribute("csize")) == new FileInfo(src).Length))
                {
                    toBackUp.Add(entry);
                }
            }
            return toBackUp;
        }

        internal void ExtractAllEntries()
        {
            foreach (XmlElement entry in GetEntries())
            {
                String src = Path.Combine(package, entry.GetAttribute("pack"));
                String dst = Path.Combine(data, entry.GetAttribute("original"));
                // TODO - check if it really has to be extracted
                Console.WriteLine($"Extracting {src} to {dst}!");
                Extract(src, dst, entry);
            }
        }

        internal void ExtractEntry(XmlElement entry)
        {
            String src = Path.Combine(package, entry.GetAttribute("pack"));
            String dst = Path.Combine(data, entry.GetAttribute("original"));
            Extract(src, dst, entry);
        }

        public static void Extract(string src, String dst, XmlElement entry)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dst));
            String method = entry.GetAttribute("method");
            switch (method)
            {
                case "raw":
                    File.Copy(src, dst, true);
                    break;

                case "zip":
                    using (ZipArchive z = ZipFile.OpenRead(src))
                    {
                        z.GetEntry((String)entry.GetAttribute("virtual")).ExtractToFile(dst);
                    }
                    break;

                case "encrypted_zip":
                    byte[] data = File.ReadAllBytes(src);
                    Crypt.decrypt(data, data.Length);
                    using (var stream = new MemoryStream(data))
                    {
                        using (ZipArchive z = new ZipArchive(stream))
                        {
                            z.GetEntry((String)entry.GetAttribute("virtual")).ExtractToFile(dst);
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        public static void Pack(string src, String dst, XmlElement entry)
        {
            String method = entry.GetAttribute("method");
            switch (method)
            {
                case "raw":
                    File.Copy(src, dst, true);
                    break;

                case "zip":
                    using (ZipArchive z = ZipFile.Open(dst, ZipArchiveMode.Create))
                    {
                        z.CreateEntryFromFile(src, (String)entry.GetAttribute("virtual"));
                    }
                    break;

                case "encrypted_zip":
                    byte[] data;
                    using (var stream = new MemoryStream())
                    {
                        using (ZipArchive z = new ZipArchive(stream))
                        {
                            z.CreateEntryFromFile(src, (String)entry.GetAttribute("virtual"));
                        }

                        int pad = (int)(16 - (stream.Length % 16));
                        if (pad != 16)
                        {
                            stream.Write(new byte[pad], 0, pad);
                        }
                        data = stream.ToArray();
                    }
                    Crypt.encrypt(data, data.Length);
                    File.WriteAllBytes(dst, data);
                    break;

                default:
                    break;
            }
        }
    }
}