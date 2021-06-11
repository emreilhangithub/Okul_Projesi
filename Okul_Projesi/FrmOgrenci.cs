using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Projesi
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        public void listele()
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }


        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string c = "";
            if(radioButton1.Checked == true)
            {
                c = "Kız";
            }
            if(radioButton2.Checked == true)
            {
                c = "Erkek";
            }
            //TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulup.Text),c
            ds.OgrenciEkle(TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulup.Text),c);
            MessageBox.Show("Ekleme İşlemi başarılı");
            listele();
        }
    }
}
