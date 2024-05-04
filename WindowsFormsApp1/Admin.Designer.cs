namespace WindowsFormsApp1
{
    partial class Admin
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
            this.TxtAdminSifre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAdminKullaniciAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtAdminSifre
            // 
            this.TxtAdminSifre.Location = new System.Drawing.Point(185, 148);
            this.TxtAdminSifre.Name = "TxtAdminSifre";
            this.TxtAdminSifre.Size = new System.Drawing.Size(217, 22);
            this.TxtAdminSifre.TabIndex = 17;
            this.TxtAdminSifre.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Şifre :";
            // 
            // TxtAdminKullaniciAd
            // 
            this.TxtAdminKullaniciAd.Location = new System.Drawing.Point(185, 92);
            this.TxtAdminKullaniciAd.Name = "TxtAdminKullaniciAd";
            this.TxtAdminKullaniciAd.Size = new System.Drawing.Size(217, 22);
            this.TxtAdminKullaniciAd.TabIndex = 19;
            this.TxtAdminKullaniciAd.UseSystemPasswordChar = true;
            this.TxtAdminKullaniciAd.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Kullanıcı Adı :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 26);
            this.button2.TabIndex = 21;
            this.button2.Text = "Giriş Yap";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(521, 300);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtAdminKullaniciAd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtAdminSifre);
            this.Controls.Add(this.label2);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtAdminSifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtAdminKullaniciAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}