
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
            this.txtOgrenciNumarasi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pctKapat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctKapat)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOgretmenGirisi
            // 
            this.btnOgretmenGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOgretmenGirisi.BackgroundImage")));
            this.btnOgretmenGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOgretmenGirisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOgretmenGirisi.Location = new System.Drawing.Point(43, 32);
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
            this.btnOgrenciGirisi.Location = new System.Drawing.Point(351, 32);
            this.btnOgrenciGirisi.Margin = new System.Windows.Forms.Padding(5);
            this.btnOgrenciGirisi.Name = "btnOgrenciGirisi";
            this.btnOgrenciGirisi.Size = new System.Drawing.Size(260, 220);
            this.btnOgrenciGirisi.TabIndex = 1;
            this.btnOgrenciGirisi.UseVisualStyleBackColor = true;
            this.btnOgrenciGirisi.Click += new System.EventHandler(this.btnOgrenciGirisi_Click);
            // 
            // txtOgrenciNumarasi
            // 
            this.txtOgrenciNumarasi.BackColor = System.Drawing.SystemColors.Info;
            this.txtOgrenciNumarasi.Location = new System.Drawing.Point(210, 293);
            this.txtOgrenciNumarasi.Margin = new System.Windows.Forms.Padding(5);
            this.txtOgrenciNumarasi.Name = "txtOgrenciNumarasi";
            this.txtOgrenciNumarasi.Size = new System.Drawing.Size(362, 30);
            this.txtOgrenciNumarasi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 293);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numara:";
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
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(643, 348);
            this.Controls.Add(this.pctKapat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOgrenciNumarasi);
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
        private System.Windows.Forms.TextBox txtOgrenciNumarasi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pctKapat;
    }
}

