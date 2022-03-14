
namespace MCCMapPacker.Forms
{
    partial class CreatePackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePackForm));
            this.CloseButton = new System.Windows.Forms.Button();
            this.PackName = new System.Windows.Forms.TextBox();
            this.PackNameLabel = new System.Windows.Forms.Label();
            this.CreatePackButton = new System.Windows.Forms.Button();
            this.StockMapLabel = new System.Windows.Forms.Label();
            this.ReplacementLable = new System.Windows.Forms.Label();
            this.GameCombo = new System.Windows.Forms.ComboBox();
            this.MapCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddStockMapBtn = new System.Windows.Forms.Button();
            this.RemoveMapBtn = new System.Windows.Forms.Button();
            this.OverrideMapBtn = new System.Windows.Forms.Button();
            this.ReplaceMapListView = new System.Windows.Forms.ListView();
            this.StockMap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReplacementMap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PackCreateProgress = new System.Windows.Forms.ProgressBar();
            this.OutputFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(236)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(12, 286);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(130, 23);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PackName
            // 
            this.PackName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.PackName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackName.ForeColor = System.Drawing.Color.White;
            this.PackName.Location = new System.Drawing.Point(108, 12);
            this.PackName.Name = "PackName";
            this.PackName.Size = new System.Drawing.Size(430, 25);
            this.PackName.TabIndex = 4;
            this.PackName.TextChanged += new System.EventHandler(this.PackName_TextChanged);
            // 
            // PackNameLabel
            // 
            this.PackNameLabel.AutoSize = true;
            this.PackNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PackNameLabel.ForeColor = System.Drawing.Color.White;
            this.PackNameLabel.Location = new System.Drawing.Point(12, 12);
            this.PackNameLabel.Name = "PackNameLabel";
            this.PackNameLabel.Size = new System.Drawing.Size(90, 21);
            this.PackNameLabel.TabIndex = 5;
            this.PackNameLabel.Text = "Pack Name:";
            // 
            // CreatePackButton
            // 
            this.CreatePackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.CreatePackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(236)))));
            this.CreatePackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreatePackButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatePackButton.ForeColor = System.Drawing.Color.White;
            this.CreatePackButton.Location = new System.Drawing.Point(544, 12);
            this.CreatePackButton.Name = "CreatePackButton";
            this.CreatePackButton.Size = new System.Drawing.Size(130, 25);
            this.CreatePackButton.TabIndex = 6;
            this.CreatePackButton.Text = "Create Pack";
            this.CreatePackButton.UseVisualStyleBackColor = false;
            this.CreatePackButton.Click += new System.EventHandler(this.CreatePackButton_Click);
            // 
            // StockMapLabel
            // 
            this.StockMapLabel.AutoSize = true;
            this.StockMapLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockMapLabel.ForeColor = System.Drawing.Color.White;
            this.StockMapLabel.Location = new System.Drawing.Point(144, 44);
            this.StockMapLabel.Name = "StockMapLabel";
            this.StockMapLabel.Size = new System.Drawing.Size(88, 21);
            this.StockMapLabel.TabIndex = 8;
            this.StockMapLabel.Text = "Stock Map";
            // 
            // ReplacementLable
            // 
            this.ReplacementLable.AutoSize = true;
            this.ReplacementLable.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReplacementLable.ForeColor = System.Drawing.Color.White;
            this.ReplacementLable.Location = new System.Drawing.Point(400, 44);
            this.ReplacementLable.Name = "ReplacementLable";
            this.ReplacementLable.Size = new System.Drawing.Size(143, 21);
            this.ReplacementLable.TabIndex = 9;
            this.ReplacementLable.Text = "Replacement Map";
            this.ReplacementLable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GameCombo
            // 
            this.GameCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.GameCombo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameCombo.ForeColor = System.Drawing.Color.White;
            this.GameCombo.FormattingEnabled = true;
            this.GameCombo.Items.AddRange(new object[] {
            "Halo: Reach",
            "Halo: CE",
            "Halo 2 Classic",
            "Halo 2 Anniversary",
            "Halo 3",
            "Halo 3 ODST",
            "Halo 4"});
            this.GameCombo.Location = new System.Drawing.Point(12, 100);
            this.GameCombo.Name = "GameCombo";
            this.GameCombo.Size = new System.Drawing.Size(130, 23);
            this.GameCombo.TabIndex = 10;
            this.GameCombo.SelectedIndexChanged += new System.EventHandler(this.GameCombo_SelectedIndexChanged);
            // 
            // MapCombo
            // 
            this.MapCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.MapCombo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapCombo.ForeColor = System.Drawing.Color.White;
            this.MapCombo.FormattingEnabled = true;
            this.MapCombo.Location = new System.Drawing.Point(12, 150);
            this.MapCombo.Name = "MapCombo";
            this.MapCombo.Size = new System.Drawing.Size(130, 23);
            this.MapCombo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Map";
            // 
            // AddStockMapBtn
            // 
            this.AddStockMapBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.AddStockMapBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(236)))));
            this.AddStockMapBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddStockMapBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStockMapBtn.ForeColor = System.Drawing.Color.White;
            this.AddStockMapBtn.Location = new System.Drawing.Point(12, 179);
            this.AddStockMapBtn.Name = "AddStockMapBtn";
            this.AddStockMapBtn.Size = new System.Drawing.Size(130, 23);
            this.AddStockMapBtn.TabIndex = 14;
            this.AddStockMapBtn.Text = "Add Map";
            this.AddStockMapBtn.UseVisualStyleBackColor = false;
            this.AddStockMapBtn.Click += new System.EventHandler(this.AddStockMapBtn_Click);
            // 
            // RemoveMapBtn
            // 
            this.RemoveMapBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.RemoveMapBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(236)))));
            this.RemoveMapBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveMapBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveMapBtn.ForeColor = System.Drawing.Color.White;
            this.RemoveMapBtn.Location = new System.Drawing.Point(12, 257);
            this.RemoveMapBtn.Name = "RemoveMapBtn";
            this.RemoveMapBtn.Size = new System.Drawing.Size(130, 23);
            this.RemoveMapBtn.TabIndex = 15;
            this.RemoveMapBtn.Text = "Remove Selected Map";
            this.RemoveMapBtn.UseVisualStyleBackColor = false;
            this.RemoveMapBtn.Click += new System.EventHandler(this.RemoveMapBtn_Click);
            // 
            // OverrideMapBtn
            // 
            this.OverrideMapBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.OverrideMapBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(236)))));
            this.OverrideMapBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OverrideMapBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverrideMapBtn.ForeColor = System.Drawing.Color.White;
            this.OverrideMapBtn.Location = new System.Drawing.Point(544, 73);
            this.OverrideMapBtn.Name = "OverrideMapBtn";
            this.OverrideMapBtn.Size = new System.Drawing.Size(130, 23);
            this.OverrideMapBtn.TabIndex = 16;
            this.OverrideMapBtn.Text = "Override Selected";
            this.OverrideMapBtn.UseVisualStyleBackColor = false;
            this.OverrideMapBtn.Click += new System.EventHandler(this.OverrideMapBtn_Click);
            // 
            // ReplaceMapListView
            // 
            this.ReplaceMapListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.ReplaceMapListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReplaceMapListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StockMap,
            this.ReplacementMap});
            this.ReplaceMapListView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReplaceMapListView.ForeColor = System.Drawing.Color.White;
            this.ReplaceMapListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ReplaceMapListView.HideSelection = false;
            this.ReplaceMapListView.Location = new System.Drawing.Point(148, 73);
            this.ReplaceMapListView.MultiSelect = false;
            this.ReplaceMapListView.Name = "ReplaceMapListView";
            this.ReplaceMapListView.Size = new System.Drawing.Size(390, 236);
            this.ReplaceMapListView.TabIndex = 18;
            this.ReplaceMapListView.UseCompatibleStateImageBehavior = false;
            this.ReplaceMapListView.View = System.Windows.Forms.View.Details;
            this.ReplaceMapListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ReplaceMapListView_MouseMove);
            // 
            // StockMap
            // 
            this.StockMap.Text = "Stock Map";
            this.StockMap.Width = 195;
            // 
            // ReplacementMap
            // 
            this.ReplacementMap.Text = "Replacement Map";
            this.ReplacementMap.Width = 190;
            // 
            // PackCreateProgress
            // 
            this.PackCreateProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.PackCreateProgress.Location = new System.Drawing.Point(108, 12);
            this.PackCreateProgress.MarqueeAnimationSpeed = 10;
            this.PackCreateProgress.Maximum = 430;
            this.PackCreateProgress.Name = "PackCreateProgress";
            this.PackCreateProgress.Size = new System.Drawing.Size(430, 25);
            this.PackCreateProgress.Step = 430;
            this.PackCreateProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PackCreateProgress.TabIndex = 19;
            this.PackCreateProgress.Visible = false;
            // 
            // OutputFolderButton
            // 
            this.OutputFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.OutputFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(236)))));
            this.OutputFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputFolderButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFolderButton.ForeColor = System.Drawing.Color.White;
            this.OutputFolderButton.Location = new System.Drawing.Point(544, 286);
            this.OutputFolderButton.Name = "OutputFolderButton";
            this.OutputFolderButton.Size = new System.Drawing.Size(130, 23);
            this.OutputFolderButton.TabIndex = 20;
            this.OutputFolderButton.Text = "Open Output Folder";
            this.OutputFolderButton.UseVisualStyleBackColor = false;
            this.OutputFolderButton.Click += new System.EventHandler(this.OutputFolderButton_Click);
            // 
            // CreatePackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(686, 323);
            this.Controls.Add(this.OutputFolderButton);
            this.Controls.Add(this.PackCreateProgress);
            this.Controls.Add(this.ReplaceMapListView);
            this.Controls.Add(this.OverrideMapBtn);
            this.Controls.Add(this.RemoveMapBtn);
            this.Controls.Add(this.AddStockMapBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MapCombo);
            this.Controls.Add(this.GameCombo);
            this.Controls.Add(this.ReplacementLable);
            this.Controls.Add(this.StockMapLabel);
            this.Controls.Add(this.CreatePackButton);
            this.Controls.Add(this.PackNameLabel);
            this.Controls.Add(this.PackName);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatePackForm";
            this.Text = "CreatePackForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreatePackForm_FormClosed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CreatePackForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox PackName;
        private System.Windows.Forms.Label PackNameLabel;
        private System.Windows.Forms.Button CreatePackButton;
        private System.Windows.Forms.Label StockMapLabel;
        private System.Windows.Forms.Label ReplacementLable;
        private System.Windows.Forms.ComboBox GameCombo;
        private System.Windows.Forms.ComboBox MapCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddStockMapBtn;
        private System.Windows.Forms.Button RemoveMapBtn;
        private System.Windows.Forms.Button OverrideMapBtn;
        private System.Windows.Forms.ListView ReplaceMapListView;
        private System.Windows.Forms.ColumnHeader StockMap;
        private System.Windows.Forms.ColumnHeader ReplacementMap;
        private System.Windows.Forms.ProgressBar PackCreateProgress;
        private System.Windows.Forms.Button OutputFolderButton;
    }
}