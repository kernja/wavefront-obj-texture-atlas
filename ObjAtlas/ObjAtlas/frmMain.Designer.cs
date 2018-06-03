namespace ObjAtlas
{
    partial class frmMain
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
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileChooseObj = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileOpenConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lstOutputSummary = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackCompressionRatio = new System.Windows.Forms.TrackBar();
            this.lblCompressionRatioPercentage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkCompress = new System.Windows.Forms.CheckBox();
            this.chkCopyNonAtlas = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOutputFilename = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSelectDestinationFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.tabMaterial = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUVScaleVPercentage = new System.Windows.Forms.Label();
            this.trackScaleV = new System.Windows.Forms.TrackBar();
            this.lblUVScaleUPercentage = new System.Windows.Forms.Label();
            this.trackScaleU = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAtlasRename = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDeleteAtlas = new System.Windows.Forms.Button();
            this.btnAddNewAtlas = new System.Windows.Forms.Button();
            this.txtAtlasName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMoveMaterialDown = new System.Windows.Forms.Button();
            this.btnMoveMaterialUp = new System.Windows.Forms.Button();
            this.picMaterialPreview = new System.Windows.Forms.PictureBox();
            this.treeMaterialAtlas = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.lstMaterialProperties = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMoveToIgnored = new System.Windows.Forms.Button();
            this.btnMoveToAtlas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstMaterialIgnored = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUVScaleU = new System.Windows.Forms.Label();
            this.lblUVScaleV = new System.Windows.Forms.Label();
            this.grpTextureless = new System.Windows.Forms.GroupBox();
            this.lstMaterialTextureless = new System.Windows.Forms.ListBox();
            this.lblInfoTextureless = new System.Windows.Forms.Label();
            this.openObjDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveObjDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.MenuStrip1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackCompressionRatio)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabMaterial.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackScaleV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackScaleU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaterialPreview)).BeginInit();
            this.grpTextureless.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1032, 28);
            this.MenuStrip1.TabIndex = 14;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileChooseObj,
            this.ToolStripMenuItem1,
            this.mnuFileOpenConfig,
            this.mnuFileSaveConfig,
            this.ToolStripMenuItem2,
            this.mnuFileExit});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileChooseObj
            // 
            this.mnuFileChooseObj.Name = "mnuFileChooseObj";
            this.mnuFileChooseObj.Size = new System.Drawing.Size(224, 26);
            this.mnuFileChooseObj.Text = "&Choose OBJ File...";
            this.mnuFileChooseObj.Click += new System.EventHandler(this.mnuFileChooseObj_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuFileOpenConfig
            // 
            this.mnuFileOpenConfig.Name = "mnuFileOpenConfig";
            this.mnuFileOpenConfig.Size = new System.Drawing.Size(224, 26);
            this.mnuFileOpenConfig.Text = "&Open Configuration...";
            // 
            // mnuFileSaveConfig
            // 
            this.mnuFileSaveConfig.Name = "mnuFileSaveConfig";
            this.mnuFileSaveConfig.Size = new System.Drawing.Size(224, 26);
            this.mnuFileSaveConfig.Text = "&Save Configuration...";
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(224, 26);
            this.mnuFileExit.Text = "&Exit";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.HelpToolStripMenuItem.Text = "&Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.AboutToolStripMenuItem.Text = "&About";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tabGeneral);
            this.TabControl1.Controls.Add(this.tabMaterial);
            this.TabControl1.Location = new System.Drawing.Point(12, 31);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1013, 444);
            this.TabControl1.TabIndex = 15;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBox4);
            this.tabGeneral.Controls.Add(this.groupBox3);
            this.tabGeneral.Controls.Add(this.groupBox2);
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(1005, 415);
            this.tabGeneral.TabIndex = 4;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            this.tabGeneral.Click += new System.EventHandler(this.tabGeneral_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGenerate);
            this.groupBox4.Controls.Add(this.lstOutputSummary);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(432, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(552, 385);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Summary";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 311);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(517, 68);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lstOutputSummary
            // 
            this.lstOutputSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOutputSummary.FormattingEnabled = true;
            this.lstOutputSummary.ItemHeight = 16;
            this.lstOutputSummary.Location = new System.Drawing.Point(15, 29);
            this.lstOutputSummary.Name = "lstOutputSummary";
            this.lstOutputSummary.Size = new System.Drawing.Size(517, 276);
            this.lstOutputSummary.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.trackCompressionRatio);
            this.groupBox3.Controls.Add(this.lblCompressionRatioPercentage);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.chkCompress);
            this.groupBox3.Controls.Add(this.chkCopyNonAtlas);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(15, 163);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 237);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Settings";
            // 
            // trackCompressionRatio
            // 
            this.trackCompressionRatio.AutoSize = false;
            this.trackCompressionRatio.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackCompressionRatio.LargeChange = 25;
            this.trackCompressionRatio.Location = new System.Drawing.Point(199, 122);
            this.trackCompressionRatio.Maximum = 100;
            this.trackCompressionRatio.Minimum = 5;
            this.trackCompressionRatio.Name = "trackCompressionRatio";
            this.trackCompressionRatio.Size = new System.Drawing.Size(149, 39);
            this.trackCompressionRatio.SmallChange = 5;
            this.trackCompressionRatio.TabIndex = 29;
            this.trackCompressionRatio.TickFrequency = 5;
            this.trackCompressionRatio.Value = 100;
            this.trackCompressionRatio.Scroll += new System.EventHandler(this.trackCompressionRatio_Scroll);
            // 
            // lblCompressionRatioPercentage
            // 
            this.lblCompressionRatioPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompressionRatioPercentage.Location = new System.Drawing.Point(336, 122);
            this.lblCompressionRatioPercentage.Name = "lblCompressionRatioPercentage";
            this.lblCompressionRatioPercentage.Size = new System.Drawing.Size(49, 25);
            this.lblCompressionRatioPercentage.TabIndex = 30;
            this.lblCompressionRatioPercentage.Text = "100%";
            this.lblCompressionRatioPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(57, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 19);
            this.label11.TabIndex = 28;
            this.label11.Text = "Compression Ratio";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCompress
            // 
            this.chkCompress.AutoSize = true;
            this.chkCompress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompress.Location = new System.Drawing.Point(18, 98);
            this.chkCompress.Name = "chkCompress";
            this.chkCompress.Size = new System.Drawing.Size(187, 21);
            this.chkCompress.TabIndex = 2;
            this.chkCompress.Text = "Compress Atlas Textures";
            this.chkCompress.UseVisualStyleBackColor = true;
            // 
            // chkCopyNonAtlas
            // 
            this.chkCopyNonAtlas.AutoSize = true;
            this.chkCopyNonAtlas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopyNonAtlas.Location = new System.Drawing.Point(18, 71);
            this.chkCopyNonAtlas.Name = "chkCopyNonAtlas";
            this.chkCopyNonAtlas.Size = new System.Drawing.Size(203, 21);
            this.chkCopyNonAtlas.TabIndex = 1;
            this.chkCopyNonAtlas.Text = "Copy Non-Atlased Textures";
            this.chkCopyNonAtlas.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtOutputFilename);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnSelectDestinationFolder);
            this.groupBox2.Controls.Add(this.txtOutputFolder);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 142);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Location";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Filename";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtOutputFilename
            // 
            this.txtOutputFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputFilename.Location = new System.Drawing.Point(18, 49);
            this.txtOutputFilename.Name = "txtOutputFilename";
            this.txtOutputFilename.Size = new System.Drawing.Size(330, 22);
            this.txtOutputFilename.TabIndex = 3;
            this.txtOutputFilename.Leave += new System.EventHandler(this.txtOutputFilename_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Destination Folder";
            // 
            // btnSelectDestinationFolder
            // 
            this.btnSelectDestinationFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDestinationFolder.Location = new System.Drawing.Point(354, 94);
            this.btnSelectDestinationFolder.Name = "btnSelectDestinationFolder";
            this.btnSelectDestinationFolder.Size = new System.Drawing.Size(41, 28);
            this.btnSelectDestinationFolder.TabIndex = 1;
            this.btnSelectDestinationFolder.Text = "...";
            this.btnSelectDestinationFolder.UseVisualStyleBackColor = true;
            this.btnSelectDestinationFolder.Click += new System.EventHandler(this.btnSelectDestinationFolder_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputFolder.Location = new System.Drawing.Point(18, 94);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(330, 22);
            this.txtOutputFolder.TabIndex = 0;
            // 
            // tabMaterial
            // 
            this.tabMaterial.Controls.Add(this.groupBox1);
            this.tabMaterial.Controls.Add(this.grpTextureless);
            this.tabMaterial.Location = new System.Drawing.Point(4, 25);
            this.tabMaterial.Name = "tabMaterial";
            this.tabMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaterial.Size = new System.Drawing.Size(1005, 415);
            this.tabMaterial.TabIndex = 1;
            this.tabMaterial.Text = "Materials";
            this.tabMaterial.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUVScaleVPercentage);
            this.groupBox1.Controls.Add(this.trackScaleV);
            this.groupBox1.Controls.Add(this.lblUVScaleUPercentage);
            this.groupBox1.Controls.Add(this.trackScaleU);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnAtlasRename);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnDeleteAtlas);
            this.groupBox1.Controls.Add(this.btnAddNewAtlas);
            this.groupBox1.Controls.Add(this.txtAtlasName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnMoveMaterialDown);
            this.groupBox1.Controls.Add(this.btnMoveMaterialUp);
            this.groupBox1.Controls.Add(this.picMaterialPreview);
            this.groupBox1.Controls.Add(this.treeMaterialAtlas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lstMaterialProperties);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnMoveToIgnored);
            this.groupBox1.Controls.Add(this.btnMoveToAtlas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstMaterialIgnored);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblUVScaleU);
            this.groupBox1.Controls.Add(this.lblUVScaleV);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(235, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 384);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Textured Materials";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblUVScaleVPercentage
            // 
            this.lblUVScaleVPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUVScaleVPercentage.Location = new System.Drawing.Point(697, 329);
            this.lblUVScaleVPercentage.Name = "lblUVScaleVPercentage";
            this.lblUVScaleVPercentage.Size = new System.Drawing.Size(49, 25);
            this.lblUVScaleVPercentage.TabIndex = 30;
            this.lblUVScaleVPercentage.Text = "100%";
            this.lblUVScaleVPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackScaleV
            // 
            this.trackScaleV.AutoSize = false;
            this.trackScaleV.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackScaleV.LargeChange = 25;
            this.trackScaleV.Location = new System.Drawing.Point(571, 329);
            this.trackScaleV.Maximum = 100;
            this.trackScaleV.Minimum = 5;
            this.trackScaleV.Name = "trackScaleV";
            this.trackScaleV.Size = new System.Drawing.Size(128, 39);
            this.trackScaleV.SmallChange = 5;
            this.trackScaleV.TabIndex = 29;
            this.trackScaleV.TickFrequency = 5;
            this.trackScaleV.Value = 100;
            this.trackScaleV.Scroll += new System.EventHandler(this.trackScaleV_Scroll);
            this.trackScaleV.ValueChanged += new System.EventHandler(this.trackScaleV_ValueChanged);
            // 
            // lblUVScaleUPercentage
            // 
            this.lblUVScaleUPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUVScaleUPercentage.Location = new System.Drawing.Point(697, 298);
            this.lblUVScaleUPercentage.Name = "lblUVScaleUPercentage";
            this.lblUVScaleUPercentage.Size = new System.Drawing.Size(49, 25);
            this.lblUVScaleUPercentage.TabIndex = 27;
            this.lblUVScaleUPercentage.Text = "100%";
            this.lblUVScaleUPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackScaleU
            // 
            this.trackScaleU.AutoSize = false;
            this.trackScaleU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackScaleU.LargeChange = 25;
            this.trackScaleU.Location = new System.Drawing.Point(571, 298);
            this.trackScaleU.Maximum = 100;
            this.trackScaleU.Minimum = 5;
            this.trackScaleU.Name = "trackScaleU";
            this.trackScaleU.Size = new System.Drawing.Size(128, 39);
            this.trackScaleU.SmallChange = 5;
            this.trackScaleU.TabIndex = 26;
            this.trackScaleU.TickFrequency = 5;
            this.trackScaleU.Value = 100;
            this.trackScaleU.Scroll += new System.EventHandler(this.trackScaleU_Scroll);
            this.trackScaleU.ValueChanged += new System.EventHandler(this.trackScaleU_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(621, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 34);
            this.button1.TabIndex = 25;
            this.button1.Text = "Make Test Atlas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAtlasRename
            // 
            this.btnAtlasRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtlasRename.Location = new System.Drawing.Point(664, 44);
            this.btnAtlasRename.Name = "btnAtlasRename";
            this.btnAtlasRename.Size = new System.Drawing.Size(79, 22);
            this.btnAtlasRename.TabIndex = 24;
            this.btnAtlasRename.Text = "Rename";
            this.btnAtlasRename.UseVisualStyleBackColor = true;
            this.btnAtlasRename.Click += new System.EventHandler(this.btnAtlasRename_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(881, 460);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(552, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 22);
            this.label7.TabIndex = 19;
            this.label7.Text = "Texture scale";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(452, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "Change atlas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeleteAtlas
            // 
            this.btnDeleteAtlas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAtlas.Location = new System.Drawing.Point(621, 72);
            this.btnDeleteAtlas.Name = "btnDeleteAtlas";
            this.btnDeleteAtlas.Size = new System.Drawing.Size(122, 34);
            this.btnDeleteAtlas.TabIndex = 17;
            this.btnDeleteAtlas.Text = "Delete Atlas...";
            this.btnDeleteAtlas.UseVisualStyleBackColor = true;
            this.btnDeleteAtlas.Click += new System.EventHandler(this.btnDeleteAtlas_Click);
            // 
            // btnAddNewAtlas
            // 
            this.btnAddNewAtlas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewAtlas.Location = new System.Drawing.Point(452, 72);
            this.btnAddNewAtlas.Name = "btnAddNewAtlas";
            this.btnAddNewAtlas.Size = new System.Drawing.Size(148, 34);
            this.btnAddNewAtlas.TabIndex = 16;
            this.btnAddNewAtlas.Text = "Add New Atlas...";
            this.btnAddNewAtlas.UseVisualStyleBackColor = true;
            this.btnAddNewAtlas.Click += new System.EventHandler(this.btnAddNewAtlas_Click);
            // 
            // txtAtlasName
            // 
            this.txtAtlasName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAtlasName.Location = new System.Drawing.Point(452, 44);
            this.txtAtlasName.Name = "txtAtlasName";
            this.txtAtlasName.Size = new System.Drawing.Size(206, 22);
            this.txtAtlasName.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(449, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "Atlas Name";
            // 
            // btnMoveMaterialDown
            // 
            this.btnMoveMaterialDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveMaterialDown.Location = new System.Drawing.Point(452, 335);
            this.btnMoveMaterialDown.Name = "btnMoveMaterialDown";
            this.btnMoveMaterialDown.Size = new System.Drawing.Size(100, 33);
            this.btnMoveMaterialDown.TabIndex = 12;
            this.btnMoveMaterialDown.Text = "Move Down";
            this.btnMoveMaterialDown.UseVisualStyleBackColor = true;
            this.btnMoveMaterialDown.Click += new System.EventHandler(this.btnMoveMaterialDown_Click);
            // 
            // btnMoveMaterialUp
            // 
            this.btnMoveMaterialUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveMaterialUp.Location = new System.Drawing.Point(452, 298);
            this.btnMoveMaterialUp.Name = "btnMoveMaterialUp";
            this.btnMoveMaterialUp.Size = new System.Drawing.Size(100, 31);
            this.btnMoveMaterialUp.TabIndex = 11;
            this.btnMoveMaterialUp.Text = "Move Up";
            this.btnMoveMaterialUp.UseVisualStyleBackColor = true;
            this.btnMoveMaterialUp.Click += new System.EventHandler(this.btnMoveMaterialUp_Click);
            // 
            // picMaterialPreview
            // 
            this.picMaterialPreview.Location = new System.Drawing.Point(643, 167);
            this.picMaterialPreview.Name = "picMaterialPreview";
            this.picMaterialPreview.Size = new System.Drawing.Size(100, 100);
            this.picMaterialPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMaterialPreview.TabIndex = 10;
            this.picMaterialPreview.TabStop = false;
            // 
            // treeMaterialAtlas
            // 
            this.treeMaterialAtlas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeMaterialAtlas.Location = new System.Drawing.Point(250, 44);
            this.treeMaterialAtlas.Name = "treeMaterialAtlas";
            this.treeMaterialAtlas.Size = new System.Drawing.Size(196, 285);
            this.treeMaterialAtlas.TabIndex = 9;
            this.treeMaterialAtlas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMaterialAtlas_AfterSelect);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 39);
            this.label3.TabIndex = 8;
            this.label3.Text = "Put materials you want atlased in this list.";
            // 
            // lstMaterialProperties
            // 
            this.lstMaterialProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMaterialProperties.FormattingEnabled = true;
            this.lstMaterialProperties.ItemHeight = 16;
            this.lstMaterialProperties.Location = new System.Drawing.Point(452, 167);
            this.lstMaterialProperties.Name = "lstMaterialProperties";
            this.lstMaterialProperties.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstMaterialProperties.Size = new System.Drawing.Size(185, 100);
            this.lstMaterialProperties.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Atlas List";
            // 
            // btnMoveToIgnored
            // 
            this.btnMoveToIgnored.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveToIgnored.Location = new System.Drawing.Point(211, 182);
            this.btnMoveToIgnored.Name = "btnMoveToIgnored";
            this.btnMoveToIgnored.Size = new System.Drawing.Size(33, 34);
            this.btnMoveToIgnored.TabIndex = 5;
            this.btnMoveToIgnored.Text = "<<";
            this.btnMoveToIgnored.UseVisualStyleBackColor = true;
            this.btnMoveToIgnored.Click += new System.EventHandler(this.btnMoveToIgnored_Click);
            // 
            // btnMoveToAtlas
            // 
            this.btnMoveToAtlas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveToAtlas.Location = new System.Drawing.Point(211, 142);
            this.btnMoveToAtlas.Name = "btnMoveToAtlas";
            this.btnMoveToAtlas.Size = new System.Drawing.Size(33, 34);
            this.btnMoveToAtlas.TabIndex = 4;
            this.btnMoveToAtlas.Text = ">>";
            this.btnMoveToAtlas.UseVisualStyleBackColor = true;
            this.btnMoveToAtlas.Click += new System.EventHandler(this.btnMoveToAtlas_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Put materials you do not want atlased in this list.";
            // 
            // lstMaterialIgnored
            // 
            this.lstMaterialIgnored.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMaterialIgnored.FormattingEnabled = true;
            this.lstMaterialIgnored.ItemHeight = 16;
            this.lstMaterialIgnored.Location = new System.Drawing.Point(6, 44);
            this.lstMaterialIgnored.Name = "lstMaterialIgnored";
            this.lstMaterialIgnored.Size = new System.Drawing.Size(196, 292);
            this.lstMaterialIgnored.TabIndex = 2;
            this.lstMaterialIgnored.SelectedIndexChanged += new System.EventHandler(this.lstMaterialIgnored_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ignore List";
            // 
            // lblUVScaleU
            // 
            this.lblUVScaleU.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUVScaleU.Location = new System.Drawing.Point(549, 304);
            this.lblUVScaleU.Name = "lblUVScaleU";
            this.lblUVScaleU.Size = new System.Drawing.Size(22, 19);
            this.lblUVScaleU.TabIndex = 23;
            this.lblUVScaleU.Text = "U";
            this.lblUVScaleU.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUVScaleV
            // 
            this.lblUVScaleV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUVScaleV.Location = new System.Drawing.Point(549, 335);
            this.lblUVScaleV.Name = "lblUVScaleV";
            this.lblUVScaleV.Size = new System.Drawing.Size(22, 19);
            this.lblUVScaleV.TabIndex = 28;
            this.lblUVScaleV.Text = "V";
            this.lblUVScaleV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpTextureless
            // 
            this.grpTextureless.Controls.Add(this.lstMaterialTextureless);
            this.grpTextureless.Controls.Add(this.lblInfoTextureless);
            this.grpTextureless.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTextureless.Location = new System.Drawing.Point(19, 17);
            this.grpTextureless.Name = "grpTextureless";
            this.grpTextureless.Size = new System.Drawing.Size(210, 384);
            this.grpTextureless.TabIndex = 0;
            this.grpTextureless.TabStop = false;
            this.grpTextureless.Text = "Textureless Materials";
            // 
            // lstMaterialTextureless
            // 
            this.lstMaterialTextureless.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMaterialTextureless.FormattingEnabled = true;
            this.lstMaterialTextureless.ItemHeight = 16;
            this.lstMaterialTextureless.Location = new System.Drawing.Point(9, 21);
            this.lstMaterialTextureless.Name = "lstMaterialTextureless";
            this.lstMaterialTextureless.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstMaterialTextureless.Size = new System.Drawing.Size(193, 276);
            this.lstMaterialTextureless.TabIndex = 1;
            // 
            // lblInfoTextureless
            // 
            this.lblInfoTextureless.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoTextureless.Location = new System.Drawing.Point(6, 304);
            this.lblInfoTextureless.Name = "lblInfoTextureless";
            this.lblInfoTextureless.Size = new System.Drawing.Size(196, 72);
            this.lblInfoTextureless.TabIndex = 0;
            this.lblInfoTextureless.Text = "These textures do not have materials assigned to them, and will be ignored during" +
    " the atlas process.";
            // 
            // openObjDialog
            // 
            this.openObjDialog.Filter = ".OBJ|*.obj";
            this.openObjDialog.Multiselect = true;
            // 
            // saveObjDialog
            // 
            this.saveObjDialog.Filter = ".PNG|*.png";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(18, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(212, 21);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Flip Atlas Output Horizontally";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(18, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(195, 21);
            this.checkBox2.TabIndex = 32;
            this.checkBox2.Text = "Flip Atlas Output Vertically";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 482);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.MenuStrip1);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "WaveFront OBJ Atlas";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackCompressionRatio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabMaterial.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackScaleV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackScaleU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaterialPreview)).EndInit();
            this.grpTextureless.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileChooseObj;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileOpenConfig;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileSaveConfig;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        internal System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage tabGeneral;
        internal System.Windows.Forms.TabPage tabMaterial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteAtlas;
        private System.Windows.Forms.Button btnAddNewAtlas;
        private System.Windows.Forms.TextBox txtAtlasName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMoveMaterialDown;
        private System.Windows.Forms.Button btnMoveMaterialUp;
        private System.Windows.Forms.PictureBox picMaterialPreview;
        private System.Windows.Forms.TreeView treeMaterialAtlas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstMaterialProperties;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMoveToIgnored;
        private System.Windows.Forms.Button btnMoveToAtlas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstMaterialIgnored;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTextureless;
        private System.Windows.Forms.ListBox lstMaterialTextureless;
        private System.Windows.Forms.Label lblInfoTextureless;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUVScaleU;
        internal System.Windows.Forms.OpenFileDialog openObjDialog;
        internal System.Windows.Forms.SaveFileDialog saveObjDialog;
        private System.Windows.Forms.Button btnAtlasRename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackScaleU;
        private System.Windows.Forms.Label lblUVScaleVPercentage;
        private System.Windows.Forms.Label lblUVScaleV;
        private System.Windows.Forms.TrackBar trackScaleV;
        private System.Windows.Forms.Label lblUVScaleUPercentage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkCompress;
        private System.Windows.Forms.CheckBox chkCopyNonAtlas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOutputFilename;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSelectDestinationFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstOutputSummary;
        private System.Windows.Forms.TrackBar trackCompressionRatio;
        private System.Windows.Forms.Label lblCompressionRatioPercentage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

