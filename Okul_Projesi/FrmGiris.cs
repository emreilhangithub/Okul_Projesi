using System;
using System.Windows.Forms;

namespace Okul_Projesi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnOgrenciGirisi_Click(object sender, EventArgs e)
        {
            if
                (
                string.IsNullOrEmpty(txtOgrenciNumarasi.Text)
                )
            {
                MessageBox.Show("Lütfen Ögrenci Numarasını Giriniz");
                return;
            }
            FrmOgrenciPaneli fr = new FrmOgrenciPaneli();
            fr.numara = txtOgrenciNumarasi.Text;
            fr.Show();
            this.Hide();
        }

        private void btnOgretmenGirisi_Click(object sender, EventArgs e)
        {            
            FrmOgretmenPaneli fr = new FrmOgretmenPaneli();
            fr.Show();
            this.Hide();

        }

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
