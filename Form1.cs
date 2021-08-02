using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TroubleTool
{
    public partial class Form1 : Form
    {
        private Logger.Logger _log = new Logger.Logger(100u);
        private AssetManager am = null;

        public Form1()
        {
            InitializeComponent();
            _log.AddToLog("Start");
            FindTroubleshooter();
        }

        private void AddToLog(string text, Color entryColor)
        {
            _log.AddToLog(text, entryColor);
            richTextBoxLog.Rtf = _log.GetLogAsRichText(true);
            richTextBoxLog.ScrollToBottom();
        }

        private void FindTroubleshooter()
        {
            String steamPath = "";
            List<String> libPaths = new List<string>();

            // 1. try to find Steam via regex
            //opening the subkey
            AddToLog($"Trying to find Steam path via registry", Color.White);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WOW6432Node\Valve\Steam");
            if (key == null)
                key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam");
            //if it does exist, retrieve the stored values  
            if (key != null)
            {
                steamPath = (String)key.GetValue("SteamPath");
                key.Close();
            }
            else
            {
                AddToLog($"Couldn't find the path of Steam", Color.Red);
                return;
                // 1. iterate over all drives, try to find Steam
                // TODO Path.Combine(drive, "Program Files (x86)", "Steam", "steamapps")
            }
            AddToLog($"Steam found {steamPath}", Color.Green);
            libPaths.Add(Path.Combine(steamPath, "steamapps"));

            // TODO add all lib paths from steamapps\libraryfolders.vdf

            // 2. try to find "appmanifest_470310.acf" in the paths
            AddToLog($"Searching through the Steam libraries", Color.White);
            foreach (String libPath in libPaths)
            {
                AddToLog(libPath, Color.White);
                if (File.Exists(Path.Combine(libPath, "appmanifest_470310.acf")))
                {
                    textBoxTroubleshooterPath.Text = Path.Combine(libPath, "common", "Troubleshooter");
                    AddToLog($"Troubleshooter found {textBoxTroubleshooterPath.Text}", Color.Green);
                    return;
                }
            }
            AddToLog($"Troubleshooter not found", Color.Red);
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            am.LoadIndex();
            AddToLog("Preparing Extraction", Color.White);
            AddToLog($"Package Path: {am.package}", Color.White);
            AddToLog($"Data Path: {am.data}", Color.White);
            AddToLog("Checking which files haven't been extracted yet or have been updated", Color.White);
            List<XmlElement> entries = am.FindUnExtractedAndUpdatedEntries();
            int count = entries.Count;
            AddToLog($"{count} assets have to be extracted or updated", Color.White);
            int i = 1;
            foreach (XmlElement entry in entries)
            {
                AddToLog(String.Format("{0}/{1}\t{2}", i++, count, entry.GetAttribute("original")), Color.White);
                am.ExtractEntry(entry);
            }
            am.indexXml.Save(Path.Combine(am.data, "index.xml"));
            AddToLog("Done", Color.White);

            radioButtonData.Enabled = true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            am.LoadIndex();
            AddToLog("Preparing Setup", Color.White);
            AddToLog($"Package Path: {am.package}", Color.White);

            if (radioButtonData.Enabled)
            {
                AddToLog($"Data Path: {am.data}", Color.White);
                AddToLog("Rewriting entries to use /Data", Color.White);
                foreach (XmlElement entry in am.GetEntries())
                {
                    entry.SetAttribute("method", "raw");
                    String original = entry.GetAttribute("original");
                    entry.SetAttribute("pack", "../Data/" + original.Replace("\\", "/"));
                    entry.SetAttribute("virtual", original.Substring(original.LastIndexOf('\\') + 1));
                    entry.SetAttribute("csize", entry.GetAttribute("size"));
                }
            }
            if (radioButtonModsYes.Enabled)
            {
                AddToLog($"Mods Path: {am.mods}", Color.White);
                AddToLog("Adding Mods", Color.White);

                Dictionary<String, XmlElement> indexDict = new Dictionary<String, XmlElement>();
                foreach (XmlElement entry in am.GetEntries())
                {
                    indexDict.Add(entry.GetAttribute("original").ToLower().Replace("\\","/"), entry);
                }

                foreach (FileInfo file in new DirectoryInfo(am.mods).GetFiles())
                {
                    AddToLog(file.Name, Color.White);
                    using (ZipArchive z = ZipFile.OpenRead(file.FullName))
                    {
                        String pack = $"../Mods/{file.Name}";
                        foreach (var zentry in z.Entries)
                        {
                            if (zentry.Length == 0)
                                continue;
                            String key = zentry.FullName.ToLower();
                            XmlElement entry = null;
                            if (indexDict.TryGetValue(key, out entry))
                            {
                                entry.SetAttribute("virtual", zentry.FullName);
                                entry.SetAttribute("pack", pack);
                                entry.SetAttribute("method", "zip");
                                AddToLog(zentry.FullName, Color.White);
                            }
                        }
                    }
                }
            }
            am.SaveIndex();
            AddToLog("Done", Color.White);
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            AddToLog("Restoring the data to vanilla state", Color.White);
            File.Copy(am.indexBackUpPath, am.indexPath, true);
            AddToLog("Done", Color.White);
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            // 1. patch exe
            String exe_ori = Path.Combine(textBoxTroubleshooterPath.Text, "Release\\bin\\ProtoLion.exe");
            /*String exe_mod = Path.Combine(textBoxTroubleshooterPath.Text, "Release\\bin\\ProtoLion_mod.exe");
            if (!File.Exists(exe_mod))
            {
                byte[] index_pattern = Encoding.ASCII.GetBytes("\x00index\x00");
                byte[] replacement = Encoding.ASCII.GetBytes("\x00ind_m\x00");
                ExePatcher.PatchExe(exe_ori, exe_mod, index_pattern, replacement);
            }
            // 2. save modified index - TODO
            String index_ori = Path.Combine(textBoxTroubleshooterPath.Text, "Package\\index");
            String index_mod = Path.Combine(textBoxTroubleshooterPath.Text, "Package\\ind_m");
            File.Copy(index_ori, index_mod, true);
            */
            // 3. launch exe
            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = "--pack --usedic" + ((radioButtonConsoleYes.Checked) ? (" --console") : "");
            // Enter the executable to run, including the complete path
            start.FileName = exe_ori;
            start.Environment.Add("SteamAPPID", "470310");
            start.WorkingDirectory = Path.Combine(textBoxTroubleshooterPath.Text, "Release\\bin");
            start.UseShellExecute = false;
            // Do you want to show a console window?
            //start.WindowStyle = ProcessWindowStyle.Hidden;
            //start.CreateNoWindow = true;

            /*
            int exitCode;


            // Run the external process & wait for it to finish
            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }
            */

            // Launch Detached
            Process proc = Process.Start(start);
        }

        private void textBoxTroubleshooterPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxTroubleshooterPath.Text))
            {
                if (am == null)
                {
                    AddToLog("Initializing AssetManager", Color.White);
                    String troubleshooterPath = textBoxTroubleshooterPath.Text;
                    if ((troubleshooterPath.Length == 0) || !Directory.Exists(troubleshooterPath))
                    {
                        AddToLog($"Invalid path! {troubleshooterPath}", Color.Red);
                        return;
                    }
                    am = new AssetManager(textBoxTroubleshooterPath.Text);

                    AddToLog("Done", Color.White);

                    // enable elements
                    buttonApply.Enabled = true;
                    buttonExtract.Enabled = true;
                    buttonLaunch.Enabled = true;
                    buttonImagesets.Enabled = true;
                    buttonUninstall.Enabled = true;
                    buttonOpenGameFolder.Enabled = true;
                    if (Directory.Exists(am.data))
                    {
                        radioButtonData.Enabled = true;
                    }
                }
            }
            else
            {
                // disable elements
                buttonApply.Enabled = false;
                buttonExtract.Enabled = false;
                buttonLaunch.Enabled = false;
                buttonImagesets.Enabled = false;
                buttonUninstall.Enabled = false;
                radioButtonData.Enabled = false;
                buttonOpenGameFolder.Enabled = false;
                am = null;
            }
        }

        private void buttonImageSets_Click(object sender, EventArgs e)
        {
            String path = Path.Combine(am.data, "CEGUI", "datafiles", "imagesets");
            if (!Directory.Exists(path))
                return;
            foreach(FileInfo file in new DirectoryInfo(path).GetFiles())
            {
                if (!file.Name.EndsWith(".imageset"))
                    continue;
                XmlDataDocument imageset = new XmlDataDocument();
                imageset.Load(file.FullName);

                XmlElement root = imageset.DocumentElement;

                String imagePath = Path.Combine(file.DirectoryName, (String)root.GetAttribute("imagefile"));
                if (!File.Exists(imagePath))
                {
                    AddToLog($"Can't find imageset: {imagePath}", Color.Red);
                    continue;
                }
                Bitmap src = Image.FromFile(imagePath) as Bitmap;

                String outPath = Path.Combine(file.DirectoryName, (String)root.GetAttribute("name"));
                Directory.CreateDirectory(outPath);

                AddToLog($"Extracting imageset: {imagePath}", Color.White);
                foreach (XmlElement entry in root.ChildNodes)
                {
                    AddToLog(entry.GetAttribute("name"), Color.White);
                    Rectangle cropRect = new Rectangle(
                        int.Parse(entry.GetAttribute("xPos")), 
                        int.Parse(entry.GetAttribute("yPos")),
                        int.Parse(entry.GetAttribute("width")),
                        int.Parse(entry.GetAttribute("height"))
                    );
                    
                    Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

                    using (Graphics g = Graphics.FromImage(target))
                    {
                        g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                         cropRect,
                                         GraphicsUnit.Pixel);
                    }
                    target.Save(Path.Combine(outPath, entry.GetAttribute("name")+".png"));
                }
            }
            AddToLog("Done", Color.White);
        }

        private void buttonOpenGameFolder_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = textBoxTroubleshooterPath.Text,
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
