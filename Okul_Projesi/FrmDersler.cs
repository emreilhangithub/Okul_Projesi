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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = ds.DersListesi();
                //datagrid viewin veri kaynagını dsden gelen ders nesnesini verdik
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtAd.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //biz string tanımladık ama bizden byte istiyor
            ds.DersSil(byte.Parse(Txtid.Text));
            MessageBox.Show("Ders Silme İşlemi Yapılmıştır");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtAd.Text,byte.Parse(Txtid.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Yapılmıştır");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int secilen = dataGridView1.SelectedCells[0].RowIndex; assagıdaki kodu yazdık
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
