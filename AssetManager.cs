using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Drawing;

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
            }
            else
            {
                if ((!File.Exists(indexBackUpPath)) || (new FileInfo(indexPath).Length != new FileInfo(indexBackUpPath).Length))
                    File.Copy(indexPath, indexBackUpPath, true);
            };
        }

        internal void SaveIndex()
        {
            IndexHelper.SaveIndex(indexXml, indexPath);
        }

        internal void SaveIndex(XmlDocument modIndexXml)
        {
            IndexHelper.SaveIndex(modIndexXml, indexPath);
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
            return (from String file in files
                    let entry = indexXml.DocumentElement
                    let src = Path.Combine(package, entry.GetAttribute("pack"))
                    let dst = Path.Combine(data, entry.GetAttribute("original"))
                    where ((!File.Exists(dst)) || (Int32.Parse(entry.GetAttribute("size")) != new FileInfo(dst).Length)) && (Int32.Parse(entry.GetAttribute("csize")) == new FileInfo(src).Length)
                    select entry).ToList();
        }

        internal void ExtractAllEntries()
        {
            foreach (XmlElement entry in GetEntries())
            {
                ExtractEntry(entry);
            }
        }

        internal void ExtractEntry(XmlElement entry)
        {
            String src = Path.Combine(package, entry.GetAttribute("pack"));
            String dst = Path.Combine(data, entry.GetAttribute("original").Trim('\n'));
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
                        z.GetEntry((String)entry.GetAttribute("virtual")).ExtractToFile(dst, true);
                    }
                    break;

                case "encrypted_zip":
                    byte[] data = File.ReadAllBytes(src);
                    data = Crypt.Decrypt(data);
                    using (var stream = new MemoryStream(data))
                    {
                        using (ZipArchive z = new ZipArchive(stream))
                        {
                            z.GetEntry((String)entry.GetAttribute("virtual")).ExtractToFile(dst, true);
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
                    data = Crypt.Encrypt(data);
                    File.WriteAllBytes(dst, data);
                    break;

                default:
                    break;
            }
        }
    }
}