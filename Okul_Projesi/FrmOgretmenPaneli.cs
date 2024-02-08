using System;
using System.Windows.Forms;

namespace Okul_Projesi
{
    public partial class FrmOgretmenPaneli : Form
    {
        public FrmOgretmenPaneli()
        {
            InitializeComponent();
        }

        private void btnKulubIslemleri_Click(object sender, EventArgs e)
        {
            FrmKlup fr = new FrmKlup();
            fr.Show();
            this.Hide();
        }

        private void btnDersIslemleri_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
            this.Hide();
        }

        private void btnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr = new FrmOgrenci();
            fr.Show();
            this.Hide();
        }

        private void btnSinavNotlari_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar fr = new FrmSinavNotlar();
            fr.Show();
            this.Hide();
        }

        private void btnOgretmenler_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmOgretmenPaneli_Load(object sender, EventArgs e)
        {

        }
    }
}
