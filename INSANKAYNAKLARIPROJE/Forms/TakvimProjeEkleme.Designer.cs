namespace INSANKAYNAKLARIPROJE.Forms
{
    partial class TakvimProjeEkleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakvimProjeEkleme));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtprojeler = new System.Windows.Forms.TextBox();
            this.txdate = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chkHatirlat = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::INSANKAYNAKLARIPROJE.Properties.Resources.power1;
            this.pictureBox1.Location = new System.Drawing.Point(256, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.btnkaydet.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnkaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkaydet.Location = new System.Drawing.Point(189, 157);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(89, 30);
            this.btnkaydet.TabIndex = 27;
            this.btnkaydet.Text = "KAYDET";
            this.btnkaydet.UseVisualStyleBackColor = true;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Projeler:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(32, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tarih:";
            // 
            // txtprojeler
            // 
            this.txtprojeler.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtprojeler.Location = new System.Drawing.Point(85, 108);
            this.txtprojeler.Multiline = true;
            this.txtprojeler.Name = "txtprojeler";
            this.txtprojeler.Size = new System.Drawing.Size(185, 37);
            this.txtprojeler.TabIndex = 24;
            // 
            // txdate
            // 
            this.txdate.Enabled = false;
            this.txdate.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txdate.Location = new System.Drawing.Point(85, 68);
            this.txdate.Name = "txdate";
            this.txdate.Size = new System.Drawing.Size(185, 25);
            this.txdate.TabIndex = 23;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::INSANKAYNAKLARIPROJE.Properties.Resources.calendar1;
            this.pictureBox2.Location = new System.Drawing.Point(-2, -7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(81, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // chkHatirlat
            // 
            this.chkHatirlat.AllowBindingControlAnimation = true;
            this.chkHatirlat.AllowBindingControlColorChanges = false;
            this.chkHatirlat.AllowBindingControlLocation = true;
            this.chkHatirlat.AllowCheckBoxAnimation = false;
            this.chkHatirlat.AllowCheckmarkAnimation = true;
            this.chkHatirlat.AllowOnHoverStates = true;
            this.chkHatirlat.AutoCheck = true;
            this.chkHatirlat.BackColor = System.Drawing.Color.Transparent;
            this.chkHatirlat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkHatirlat.BackgroundImage")));
            this.chkHatirlat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkHatirlat.BindingControl = this.label3;
            this.chkHatirlat.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.chkHatirlat.BorderRadius = 12;
            this.chkHatirlat.Checked = false;
            this.chkHatirlat.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.chkHatirlat.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkHatirlat.CustomCheckmarkImage = null;
            this.chkHatirlat.Location = new System.Drawing.Point(14, 166);
            this.chkHatirlat.MinimumSize = new System.Drawing.Size(17, 17);
            this.chkHatirlat.Name = "chkHatirlat";
            this.chkHatirlat.OnCheck.BorderColor = System.Drawing.Color.DodgerBlue;
            this.chkHatirlat.OnCheck.BorderRadius = 12;
            this.chkHatirlat.OnCheck.BorderThickness = 2;
            this.chkHatirlat.OnCheck.CheckBoxColor = System.Drawing.Color.DodgerBlue;
            this.chkHatirlat.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.chkHatirlat.OnCheck.CheckmarkThickness = 2;
            this.chkHatirlat.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.chkHatirlat.OnDisable.BorderRadius = 12;
            this.chkHatirlat.OnDisable.BorderThickness = 2;
            this.chkHatirlat.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.chkHatirlat.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.chkHatirlat.OnDisable.CheckmarkThickness = 2;
            this.chkHatirlat.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.chkHatirlat.OnHoverChecked.BorderRadius = 12;
            this.chkHatirlat.OnHoverChecked.BorderThickness = 2;
            this.chkHatirlat.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.chkHatirlat.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.chkHatirlat.OnHoverChecked.CheckmarkThickness = 2;
            this.chkHatirlat.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.chkHatirlat.OnHoverUnchecked.BorderRadius = 12;
            this.chkHatirlat.OnHoverUnchecked.BorderThickness = 1;
            this.chkHatirlat.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.chkHatirlat.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.chkHatirlat.OnUncheck.BorderRadius = 12;
            this.chkHatirlat.OnUncheck.BorderThickness = 1;
            this.chkHatirlat.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.chkHatirlat.Size = new System.Drawing.Size(21, 21);
            this.chkHatirlat.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.chkHatirlat.TabIndex = 30;
            this.chkHatirlat.ThreeState = false;
            this.chkHatirlat.ToolTipText = null;
            this.chkHatirlat.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.chkHatirlat_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(38, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Hatırlat";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 167);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(68, 20);
            this.dateTimePicker1.TabIndex = 33;
            this.dateTimePicker1.Value = new System.DateTime(2023, 3, 31, 0, 0, 0, 0);
            this.dateTimePicker1.Visible = false;
            // 
            // TakvimProjeEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(313, 204);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkHatirlat);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtprojeler);
            this.Controls.Add(this.txdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TakvimProjeEkleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjeEkleme";
            this.Load += new System.EventHandler(this.TakvimProjeEkleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtprojeler;
        private System.Windows.Forms.TextBox txdate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.UI.WinForms.BunifuCheckBox chkHatirlat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}