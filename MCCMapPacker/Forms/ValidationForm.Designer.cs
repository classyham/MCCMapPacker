
namespace MCCMapPacker.Forms
{
    partial class ValidationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidationForm));
            this.CloseButton = new System.Windows.Forms.Button();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.ValidationProgress = new System.Windows.Forms.ProgressBar();
            this.H1CB = new System.Windows.Forms.CheckBox();
            this.H2CCB = new System.Windows.Forms.CheckBox();
            this.H2ACB = new System.Windows.Forms.CheckBox();
            this.ReachCB = new System.Windows.Forms.CheckBox();
            this.Halo3CB = new System.Windows.Forms.CheckBox();
            this.ODSTCB = new System.Windows.Forms.CheckBox();
            this.H4CB = new System.Windows.Forms.CheckBox();
            this.HashListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(236)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(93, 329);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ValidateButton
            // 
            this.ValidateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.ValidateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(236)))));
            this.ValidateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ValidateButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidateButton.ForeColor = System.Drawing.Color.White;
            this.ValidateButton.Location = new System.Drawing.Point(12, 329);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(75, 23);
            this.ValidateButton.TabIndex = 3;
            this.ValidateButton.Text = "Validate";
            this.ValidateButton.UseVisualStyleBackColor = false;
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // ValidationProgress
            // 
            this.ValidationProgress.Location = new System.Drawing.Point(174, 329);
            this.ValidationProgress.Name = "ValidationProgress";
            this.ValidationProgress.Size = new System.Drawing.Size(215, 23);
            this.ValidationProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ValidationProgress.TabIndex = 4;
            // 
            // H1CB
            // 
            this.H1CB.AutoSize = true;
            this.H1CB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H1CB.ForeColor = System.Drawing.Color.White;
            this.H1CB.Location = new System.Drawing.Point(104, 358);
            this.H1CB.Name = "H1CB";
            this.H1CB.Size = new System.Drawing.Size(66, 17);
            this.H1CB.TabIndex = 5;
            this.H1CB.Tag = "HaloCE";
            this.H1CB.Text = "Halo:CE";
            this.H1CB.UseVisualStyleBackColor = true;
            // 
            // H2CCB
            // 
            this.H2CCB.AutoSize = true;
            this.H2CCB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H2CCB.ForeColor = System.Drawing.Color.White;
            this.H2CCB.Location = new System.Drawing.Point(175, 358);
            this.H2CCB.Name = "H2CCB";
            this.H2CCB.Size = new System.Drawing.Size(96, 17);
            this.H2CCB.TabIndex = 6;
            this.H2CCB.Tag = "Halo2C";
            this.H2CCB.Text = "Halo 2 Classic";
            this.H2CCB.UseVisualStyleBackColor = true;
            // 
            // H2ACB
            // 
            this.H2ACB.AutoSize = true;
            this.H2ACB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H2ACB.ForeColor = System.Drawing.Color.White;
            this.H2ACB.Location = new System.Drawing.Point(274, 358);
            this.H2ACB.Name = "H2ACB";
            this.H2ACB.Size = new System.Drawing.Size(121, 17);
            this.H2ACB.TabIndex = 7;
            this.H2ACB.Tag = "Halo2A";
            this.H2ACB.Text = "Halo 2 Anniversary";
            this.H2ACB.UseVisualStyleBackColor = true;
            // 
            // ReachCB
            // 
            this.ReachCB.AutoSize = true;
            this.ReachCB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReachCB.ForeColor = System.Drawing.Color.White;
            this.ReachCB.Location = new System.Drawing.Point(12, 358);
            this.ReachCB.Name = "ReachCB";
            this.ReachCB.Size = new System.Drawing.Size(87, 17);
            this.ReachCB.TabIndex = 8;
            this.ReachCB.Tag = "HaloReach";
            this.ReachCB.Text = "Halo: Reach";
            this.ReachCB.UseVisualStyleBackColor = true;
            // 
            // Halo3CB
            // 
            this.Halo3CB.AutoSize = true;
            this.Halo3CB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Halo3CB.ForeColor = System.Drawing.Color.White;
            this.Halo3CB.Location = new System.Drawing.Point(12, 381);
            this.Halo3CB.Name = "Halo3CB";
            this.Halo3CB.Size = new System.Drawing.Size(59, 17);
            this.Halo3CB.TabIndex = 9;
            this.Halo3CB.Tag = "Halo3";
            this.Halo3CB.Text = "Halo 3";
            this.Halo3CB.UseVisualStyleBackColor = true;
            // 
            // ODSTCB
            // 
            this.ODSTCB.AutoSize = true;
            this.ODSTCB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ODSTCB.ForeColor = System.Drawing.Color.White;
            this.ODSTCB.Location = new System.Drawing.Point(75, 381);
            this.ODSTCB.Name = "ODSTCB";
            this.ODSTCB.Size = new System.Drawing.Size(91, 17);
            this.ODSTCB.TabIndex = 10;
            this.ODSTCB.Tag = "HaloODST";
            this.ODSTCB.Text = "Halo 3 ODST";
            this.ODSTCB.UseVisualStyleBackColor = true;
            // 
            // H4CB
            // 
            this.H4CB.AutoSize = true;
            this.H4CB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H4CB.ForeColor = System.Drawing.Color.White;
            this.H4CB.Location = new System.Drawing.Point(171, 381);
            this.H4CB.Name = "H4CB";
            this.H4CB.Size = new System.Drawing.Size(59, 17);
            this.H4CB.TabIndex = 11;
            this.H4CB.Tag = "Halo4";
            this.H4CB.Text = "Halo 4";
            this.H4CB.UseVisualStyleBackColor = true;
            // 
            // HashListView
            // 
            this.HashListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(54)))), ((int)(((byte)(148)))));
            this.HashListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HashListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.HashListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.HashListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.HashListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.HashListView.HideSelection = false;
            this.HashListView.Location = new System.Drawing.Point(12, 12);
            this.HashListView.MultiSelect = false;
            this.HashListView.Name = "HashListView";
            this.HashListView.Size = new System.Drawing.Size(376, 311);
            this.HashListView.TabIndex = 12;
            this.HashListView.UseCompatibleStateImageBehavior = false;
            this.HashListView.View = System.Windows.Forms.View.Details;
            this.HashListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HashListView_MouseMove);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 350;
            // 
            // ValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(400, 410);
            this.Controls.Add(this.HashListView);
            this.Controls.Add(this.H4CB);
            this.Controls.Add(this.ODSTCB);
            this.Controls.Add(this.Halo3CB);
            this.Controls.Add(this.ReachCB);
            this.Controls.Add(this.H2ACB);
            this.Controls.Add(this.H2CCB);
            this.Controls.Add(this.H1CB);
            this.Controls.Add(this.ValidationProgress);
            this.Controls.Add(this.ValidateButton);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ValidationForm";
            this.Text = "ValidationForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ValidationForm_FormClosed);
            this.Load += new System.EventHandler(this.ValidationForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ValidationForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ValidateButton;
        private System.Windows.Forms.ProgressBar ValidationProgress;
        private System.Windows.Forms.CheckBox H1CB;
        private System.Windows.Forms.CheckBox H2CCB;
        private System.Windows.Forms.CheckBox H2ACB;
        private System.Windows.Forms.CheckBox ReachCB;
        private System.Windows.Forms.CheckBox Halo3CB;
        private System.Windows.Forms.CheckBox ODSTCB;
        private System.Windows.Forms.CheckBox H4CB;
        private System.Windows.Forms.ListView HashListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}