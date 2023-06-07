namespace INSANKAYNAKLARIPROJE.Forms
{
    partial class UserControlDays2
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbdays = new System.Windows.Forms.Label();
            this.lbevent = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblEvent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbdays
            // 
            this.lbdays.AutoSize = true;
            this.lbdays.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbdays.Location = new System.Drawing.Point(13, 11);
            this.lbdays.Name = "lbdays";
            this.lbdays.Size = new System.Drawing.Size(28, 21);
            this.lbdays.TabIndex = 1;
            this.lbdays.Text = "00";
            // 
            // lbevent
            // 
            this.lbevent.Location = new System.Drawing.Point(0, 62);
            this.lbevent.Name = "lbevent";
            this.lbevent.Size = new System.Drawing.Size(150, 46);
            this.lbevent.TabIndex = 2;
            this.lbevent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblEvent
            // 
            this.lblEvent.ForeColor = System.Drawing.Color.Red;
            this.lblEvent.Location = new System.Drawing.Point(14, 62);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(121, 35);
            this.lblEvent.TabIndex = 3;
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlDays2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lbevent);
            this.Controls.Add(this.lbdays);
            this.Name = "UserControlDays2";
            this.Size = new System.Drawing.Size(150, 108);
            this.Load += new System.EventHandler(this.UserControlDays2_Load);
            this.Click += new System.EventHandler(this.UserControlDays2_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbevent;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Label lbdays;
        private System.Windows.Forms.Label lblEvent;
    }
}
