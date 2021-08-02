
namespace TroubleTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTroubleshooterPath = new System.Windows.Forms.TextBox();
            this.labelTroubleshooterPath = new System.Windows.Forms.Label();
            this.buttonExtract = new System.Windows.Forms.Button();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.richTextBoxLog = new Logger.ScrollingRichTextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonUninstall = new System.Windows.Forms.Button();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonModsYes = new System.Windows.Forms.RadioButton();
            this.radioButtonModsNo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonPack = new System.Windows.Forms.RadioButton();
            this.radioButtonData = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonImagesets = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonConsoleYes = new System.Windows.Forms.RadioButton();
            this.radioButtonConsoleNo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOpenGameFolder = new System.Windows.Forms.Button();
            this.groupBoxLog.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTroubleshooterPath
            // 
            this.textBoxTroubleshooterPath.Location = new System.Drawing.Point(88, 3);
            this.textBoxTroubleshooterPath.Multiline = true;
            this.textBoxTroubleshooterPath.Name = "textBoxTroubleshooterPath";
            this.textBoxTroubleshooterPath.Size = new System.Drawing.Size(264, 43);
            this.textBoxTroubleshooterPath.TabIndex = 0;
            this.textBoxTroubleshooterPath.TextChanged += new System.EventHandler(this.textBoxTroubleshooterPath_TextChanged);
            // 
            // labelTroubleshooterPath
            // 
            this.labelTroubleshooterPath.AutoSize = true;
            this.labelTroubleshooterPath.Location = new System.Drawing.Point(3, 0);
            this.labelTroubleshooterPath.Name = "labelTroubleshooterPath";
            this.labelTroubleshooterPath.Size = new System.Drawing.Size(78, 26);
            this.labelTroubleshooterPath.TabIndex = 1;
            this.labelTroubleshooterPath.Text = "Troubleshooter Path";
            // 
            // buttonExtract
            // 
            this.buttonExtract.Enabled = false;
            this.buttonExtract.Location = new System.Drawing.Point(12, 57);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(147, 23);
            this.buttonExtract.TabIndex = 2;
            this.buttonExtract.Text = "Extract Pack To Data";
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.richTextBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(12, 214);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(520, 266);
            this.groupBoxLog.TabIndex = 3;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBoxLog.Location = new System.Drawing.Point(7, 19);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(507, 237);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // buttonApply
            // 
            this.buttonApply.Enabled = false;
            this.buttonApply.Location = new System.Drawing.Point(12, 115);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(147, 23);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply Settings";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonUninstall
            // 
            this.buttonUninstall.Enabled = false;
            this.buttonUninstall.Location = new System.Drawing.Point(12, 173);
            this.buttonUninstall.Name = "buttonUninstall";
            this.buttonUninstall.Size = new System.Drawing.Size(147, 23);
            this.buttonUninstall.TabIndex = 5;
            this.buttonUninstall.Text = "Uninstall Mod";
            this.buttonUninstall.UseVisualStyleBackColor = true;
            this.buttonUninstall.Click += new System.EventHandler(this.buttonUninstall_Click);
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Enabled = false;
            this.buttonLaunch.Location = new System.Drawing.Point(12, 144);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(147, 23);
            this.buttonLaunch.TabIndex = 6;
            this.buttonLaunch.Text = "Launch Game";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxSettings.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxSettings.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxSettings.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxSettings.Location = new System.Drawing.Point(165, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(367, 196);
            this.groupBoxSettings.TabIndex = 8;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.94366F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.05634F));
            this.tableLayoutPanel3.Controls.Add(this.textBoxTroubleshooterPath, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelTroubleshooterPath, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(355, 49);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel2.Controls.Add(this.radioButtonModsYes, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonModsNo, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 112);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(355, 35);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // radioButtonModsYes
            // 
            this.radioButtonModsYes.AutoSize = true;
            this.radioButtonModsYes.Location = new System.Drawing.Point(91, 3);
            this.radioButtonModsYes.Name = "radioButtonModsYes";
            this.radioButtonModsYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonModsYes.TabIndex = 1;
            this.radioButtonModsYes.Text = "Yes";
            this.radioButtonModsYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonModsNo
            // 
            this.radioButtonModsNo.AutoSize = true;
            this.radioButtonModsNo.Checked = true;
            this.radioButtonModsNo.Location = new System.Drawing.Point(219, 3);
            this.radioButtonModsNo.Name = "radioButtonModsNo";
            this.radioButtonModsNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonModsNo.TabIndex = 2;
            this.radioButtonModsNo.TabStop = true;
            this.radioButtonModsNo.Text = "No";
            this.radioButtonModsNo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Use Mods";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonPack, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonData, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 71);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 35);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // radioButtonPack
            // 
            this.radioButtonPack.AutoSize = true;
            this.radioButtonPack.Checked = true;
            this.radioButtonPack.Location = new System.Drawing.Point(90, 3);
            this.radioButtonPack.Name = "radioButtonPack";
            this.radioButtonPack.Size = new System.Drawing.Size(50, 17);
            this.radioButtonPack.TabIndex = 1;
            this.radioButtonPack.TabStop = true;
            this.radioButtonPack.Text = "Pack";
            this.radioButtonPack.UseVisualStyleBackColor = true;
            // 
            // radioButtonData
            // 
            this.radioButtonData.AutoSize = true;
            this.radioButtonData.Enabled = false;
            this.radioButtonData.Location = new System.Drawing.Point(218, 3);
            this.radioButtonData.Name = "radioButtonData";
            this.radioButtonData.Size = new System.Drawing.Size(48, 17);
            this.radioButtonData.TabIndex = 2;
            this.radioButtonData.Text = "Data";
            this.radioButtonData.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Data Source";
            // 
            // buttonImagesets
            // 
            this.buttonImagesets.Location = new System.Drawing.Point(12, 86);
            this.buttonImagesets.Name = "buttonImagesets";
            this.buttonImagesets.Size = new System.Drawing.Size(147, 23);
            this.buttonImagesets.TabIndex = 9;
            this.buttonImagesets.Text = "Extract Imagesets";
            this.buttonImagesets.UseVisualStyleBackColor = true;
            this.buttonImagesets.Click += new System.EventHandler(this.buttonImageSets_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel4.Controls.Add(this.radioButtonConsoleYes, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonConsoleNo, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(7, 153);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(355, 35);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // radioButtonConsoleYes
            // 
            this.radioButtonConsoleYes.AutoSize = true;
            this.radioButtonConsoleYes.Location = new System.Drawing.Point(91, 3);
            this.radioButtonConsoleYes.Name = "radioButtonConsoleYes";
            this.radioButtonConsoleYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonConsoleYes.TabIndex = 1;
            this.radioButtonConsoleYes.Text = "Yes";
            this.radioButtonConsoleYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonConsoleNo
            // 
            this.radioButtonConsoleNo.AutoSize = true;
            this.radioButtonConsoleNo.Checked = true;
            this.radioButtonConsoleNo.Location = new System.Drawing.Point(219, 3);
            this.radioButtonConsoleNo.Name = "radioButtonConsoleNo";
            this.radioButtonConsoleNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonConsoleNo.TabIndex = 2;
            this.radioButtonConsoleNo.TabStop = true;
            this.radioButtonConsoleNo.Text = "No";
            this.radioButtonConsoleNo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Launch with Console";
            // 
            // buttonOpenGameFolder
            // 
            this.buttonOpenGameFolder.Enabled = false;
            this.buttonOpenGameFolder.Location = new System.Drawing.Point(12, 28);
            this.buttonOpenGameFolder.Name = "buttonOpenGameFolder";
            this.buttonOpenGameFolder.Size = new System.Drawing.Size(147, 23);
            this.buttonOpenGameFolder.TabIndex = 10;
            this.buttonOpenGameFolder.Text = "Open Game Folder";
            this.buttonOpenGameFolder.UseVisualStyleBackColor = true;
            this.buttonOpenGameFolder.Click += new System.EventHandler(this.buttonOpenGameFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 485);
            this.Controls.Add(this.buttonOpenGameFolder);
            this.Controls.Add(this.buttonImagesets);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.buttonUninstall);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.buttonExtract);
            this.Name = "Form1";
            this.Text = "Troubleshooter Mod-Toolkit";
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTroubleshooterPath;
        private System.Windows.Forms.Label labelTroubleshooterPath;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private Logger.ScrollingRichTextBox richTextBoxLog;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonUninstall;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButtonModsYes;
        private System.Windows.Forms.RadioButton radioButtonModsNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonPack;
        private System.Windows.Forms.RadioButton radioButtonData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonImagesets;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton radioButtonConsoleYes;
        private System.Windows.Forms.RadioButton radioButtonConsoleNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOpenGameFolder;
    }
}

