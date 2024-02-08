
namespace Okul_Projesi
{
    partial class FrmGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiris));
            this.btnOgretmenGirisi = new System.Windows.Forms.Button();
            this.btnOgrenciGirisi = new System.Windows.Forms.Button();
            this.pctKapat = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKullaniciId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKullaniciSifre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctKapat)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOgretmenGirisi
            // 
            this.btnOgretmenGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOgretmenGirisi.BackgroundImage")));
            this.btnOgretmenGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOgretmenGirisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOgretmenGirisi.Location = new System.Drawing.Point(39, 213);
            this.btnOgretmenGirisi.Margin = new System.Windows.Forms.Padding(5);
            this.btnOgretmenGirisi.Name = "btnOgretmenGirisi";
            this.btnOgretmenGirisi.Size = new System.Drawing.Size(231, 220);
            this.btnOgretmenGirisi.TabIndex = 0;
            this.btnOgretmenGirisi.UseVisualStyleBackColor = true;
            this.btnOgretmenGirisi.Click += new System.EventHandler(this.btnOgretmenGirisi_Click);
            // 
            // btnOgrenciGirisi
            // 
            this.btnOgrenciGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOgrenciGirisi.BackgroundImage")));
            this.btnOgrenciGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOgrenciGirisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOgrenciGirisi.Location = new System.Drawing.Point(347, 213);
            this.btnOgrenciGirisi.Margin = new System.Windows.Forms.Padding(5);
            this.btnOgrenciGirisi.Name = "btnOgrenciGirisi";
            this.btnOgrenciGirisi.Size = new System.Drawing.Size(260, 220);
            this.btnOgrenciGirisi.TabIndex = 1;
            this.btnOgrenciGirisi.UseVisualStyleBackColor = true;
            this.btnOgrenciGirisi.Click += new System.EventHandler(this.btnOgrenciGirisi_Click);
            // 
            // pctKapat
            // 
            this.pctKapat.Image = ((System.Drawing.Image)(resources.GetObject("pctKapat.Image")));
            this.pctKapat.Location = new System.Drawing.Point(604, 1);
            this.pctKapat.Name = "pctKapat";
            this.pctKapat.Size = new System.Drawing.Size(36, 23);
            this.pctKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctKapat.TabIndex = 74;
            this.pctKapat.TabStop = false;
            this.pctKapat.Click += new System.EventHandler(this.pctKapat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 23);
            this.label2.TabIndex = 78;
            this.label2.Text = "Kullanıcı Id:";
            // 
            // txtKullaniciId
            // 
            this.txtKullaniciId.BackColor = System.Drawing.SystemColors.Info;
            this.txtKullaniciId.Location = new System.Drawing.Point(225, 38);
            this.txtKullaniciId.Margin = new System.Windows.Forms.Padding(5);
            this.txtKullaniciId.Name = "txtKullaniciId";
            this.txtKullaniciId.Size = new System.Drawing.Size(396, 30);
            this.txtKullaniciId.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 80;
            this.label1.Text = "Kullanici Sifre:";
            // 
            // txtKullaniciSifre
            // 
            this.txtKullaniciSifre.BackColor = System.Drawing.SystemColors.Info;
            this.txtKullaniciSifre.Location = new System.Drawing.Point(225, 117);
            this.txtKullaniciSifre.Margin = new System.Windows.Forms.Padding(5);
            this.txtKullaniciSifre.Name = "txtKullaniciSifre";
            this.txtKullaniciSifre.Size = new System.Drawing.Size(396, 30);
            this.txtKullaniciSifre.TabIndex = 79;
            this.txtKullaniciSifre.UseSystemPasswordChar = true;
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(643, 465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKullaniciSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKullaniciId);
            this.Controls.Add(this.pctKapat);
            this.Controls.Add(this.btnOgrenciGirisi);
            this.Controls.Add(this.btnOgretmenGirisi);
            this.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pctKapat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOgretmenGirisi;
        private System.Windows.Forms.Button btnOgrenciGirisi;
        private System.Windows.Forms.PictureBox pctKapat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullaniciId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKullaniciSifre;
    }
}

