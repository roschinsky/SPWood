namespace TRoschinsky.App.SPWood
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtBoxWebUrl = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblWebUrl = new System.Windows.Forms.Label();
            this.lblEntities = new System.Windows.Forms.Label();
            this.btnGetWood = new System.Windows.Forms.Button();
            this.richTextBoxCode = new System.Windows.Forms.RichTextBox();
            this.listViewEntities = new System.Windows.Forms.ListView();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.checkBoxIncludeHidden = new System.Windows.Forms.CheckBox();
            this.btnSaveCode = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.linkLabelAbout = new System.Windows.Forms.LinkLabel();
            this.lblCode = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxWebUrl
            // 
            this.txtBoxWebUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxWebUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBoxWebUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.txtBoxWebUrl.Location = new System.Drawing.Point(76, 13);
            this.txtBoxWebUrl.Name = "txtBoxWebUrl";
            this.txtBoxWebUrl.Size = new System.Drawing.Size(281, 20);
            this.txtBoxWebUrl.TabIndex = 0;
            this.txtBoxWebUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxWebUrl_KeyUp);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(363, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(89, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblWebUrl
            // 
            this.lblWebUrl.AutoSize = true;
            this.lblWebUrl.Location = new System.Drawing.Point(12, 17);
            this.lblWebUrl.Name = "lblWebUrl";
            this.lblWebUrl.Size = new System.Drawing.Size(47, 13);
            this.lblWebUrl.TabIndex = 3;
            this.lblWebUrl.Text = "SP Web";
            // 
            // lblEntities
            // 
            this.lblEntities.AutoSize = true;
            this.lblEntities.Location = new System.Drawing.Point(12, 42);
            this.lblEntities.Name = "lblEntities";
            this.lblEntities.Size = new System.Drawing.Size(42, 13);
            this.lblEntities.TabIndex = 3;
            this.lblEntities.Text = "List/Lib";
            // 
            // btnGetWood
            // 
            this.btnGetWood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetWood.Enabled = false;
            this.btnGetWood.Location = new System.Drawing.Point(363, 101);
            this.btnGetWood.Name = "btnGetWood";
            this.btnGetWood.Size = new System.Drawing.Size(89, 23);
            this.btnGetWood.TabIndex = 5;
            this.btnGetWood.Text = "Generate Code";
            this.btnGetWood.UseVisualStyleBackColor = true;
            this.btnGetWood.Click += new System.EventHandler(this.btnGetWood_Click);
            // 
            // richTextBoxCode
            // 
            this.richTextBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxCode.Font = new System.Drawing.Font("Courier New", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxCode.Location = new System.Drawing.Point(76, 130);
            this.richTextBoxCode.Name = "richTextBoxCode";
            this.richTextBoxCode.ReadOnly = true;
            this.richTextBoxCode.Size = new System.Drawing.Size(376, 84);
            this.richTextBoxCode.TabIndex = 6;
            this.richTextBoxCode.Text = "";
            this.richTextBoxCode.WordWrap = false;
            // 
            // listViewEntities
            // 
            this.listViewEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEntities.Enabled = false;
            this.listViewEntities.HideSelection = false;
            this.listViewEntities.Location = new System.Drawing.Point(76, 42);
            this.listViewEntities.Name = "listViewEntities";
            this.listViewEntities.Size = new System.Drawing.Size(281, 82);
            this.listViewEntities.SmallImageList = this.imageListIcons;
            this.listViewEntities.TabIndex = 7;
            this.listViewEntities.UseCompatibleStateImageBehavior = false;
            this.listViewEntities.View = System.Windows.Forms.View.List;
            this.listViewEntities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewEntities_MouseDoubleClick);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcons.Images.SetKeyName(0, "list_16.png");
            this.imageListIcons.Images.SetKeyName(1, "lib_16.png");
            // 
            // checkBoxIncludeHidden
            // 
            this.checkBoxIncludeHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxIncludeHidden.AutoSize = true;
            this.checkBoxIncludeHidden.Location = new System.Drawing.Point(363, 78);
            this.checkBoxIncludeHidden.Name = "checkBoxIncludeHidden";
            this.checkBoxIncludeHidden.Size = new System.Drawing.Size(81, 17);
            this.checkBoxIncludeHidden.TabIndex = 8;
            this.checkBoxIncludeHidden.Text = "Incl. hidden";
            this.checkBoxIncludeHidden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIncludeHidden.UseVisualStyleBackColor = true;
            // 
            // btnSaveCode
            // 
            this.btnSaveCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCode.Location = new System.Drawing.Point(363, 220);
            this.btnSaveCode.Name = "btnSaveCode";
            this.btnSaveCode.Size = new System.Drawing.Size(89, 23);
            this.btnSaveCode.TabIndex = 9;
            this.btnSaveCode.Text = "Save Code";
            this.btnSaveCode.UseVisualStyleBackColor = true;
            this.btnSaveCode.Click += new System.EventHandler(this.btnSaveCode_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "cs";
            this.saveFileDialog.Filter = "C#-Files|*.cs|All files|*.*";
            this.saveFileDialog.InitialDirectory = "%HOMEPATH%";
            this.saveFileDialog.Title = "Save generated code to file...";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 259);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(464, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // linkLabelAbout
            // 
            this.linkLabelAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelAbout.AutoSize = true;
            this.linkLabelAbout.Location = new System.Drawing.Point(13, 228);
            this.linkLabelAbout.Name = "linkLabelAbout";
            this.linkLabelAbout.Size = new System.Drawing.Size(144, 13);
            this.linkLabelAbout.TabIndex = 11;
            this.linkLabelAbout.TabStop = true;
            this.linkLabelAbout.Text = "Read more about SPWood...";
            this.linkLabelAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAbout_LinkClicked);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 140);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Code";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.linkLabelAbout);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSaveCode);
            this.Controls.Add(this.checkBoxIncludeHidden);
            this.Controls.Add(this.listViewEntities);
            this.Controls.Add(this.richTextBoxCode);
            this.Controls.Add(this.btnGetWood);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblEntities);
            this.Controls.Add(this.lblWebUrl);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtBoxWebUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "MainForm";
            this.Text = "SPWood";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxWebUrl;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblWebUrl;
        private System.Windows.Forms.Label lblEntities;
        private System.Windows.Forms.Button btnGetWood;
        private System.Windows.Forms.RichTextBox richTextBoxCode;
        private System.Windows.Forms.ListView listViewEntities;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.CheckBox checkBoxIncludeHidden;
        private System.Windows.Forms.Button btnSaveCode;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.LinkLabel linkLabelAbout;
        private System.Windows.Forms.Label lblCode;
    }
}

