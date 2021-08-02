using System;
using System.Windows.Forms;


namespace TroubleTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            AssetManager.package = "E:\\Program Files (x86)\\Steam\\steamapps\\common\\Troubleshooter\\Package";
            AssetManager.data = "D:\\TroubleTest";
            AssetManager.LoadIndex();
            AssetManager.ExtractAllEntries();
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
