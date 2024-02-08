using System;
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAd.Text))
            {
                MessageBox.Show("Lütfen Ad Alanını eksiksiz doldurunuz");
                return;
            }

            ds.DersEkle(TxtAd.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txtid.Text))
            {
                MessageBox.Show("Lütfen id Alanını eksiksiz doldurunuz");
                return;
            }

            //biz string tanımladık ama bizden byte istiyor
            ds.DersSil(byte.Parse(Txtid.Text));
            MessageBox.Show("Ders Silme İşlemi Yapılmıştır");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Txtid.Text) || string.IsNullOrEmpty(TxtAd.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları eksiksiz doldurunuz");
                return;
            }

            ds.DersGuncelle(TxtAd.Text, byte.Parse(Txtid.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Yapılmıştır");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int secilen = dataGridView1.SelectedCells[0].RowIndex; assagıdaki kodu yazdık
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
