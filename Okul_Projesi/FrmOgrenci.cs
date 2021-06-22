using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Projesi
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-E9UTSVL;Initial Catalog=Okul;Integrated Security=True");

        public void listele()
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }


        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            listele();
            
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * from TBLKULUPLER",baglanti);          
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "KULUPAD";  //gozukecek isim
            CmbKulup.ValueMember = "KULUPID"; //arkadagizli olan id
            CmbKulup.DataSource = dt;

            baglanti.Close(); //sql data adapterde baglantıyı acıp kapatmaya gerek yok

            
           
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if
                (
                string.IsNullOrEmpty(TxtAra.Text)
                )
            {
                MessageBox.Show("Lütfen arama textboxı alanını eksiksiz doldurunuz");
                return;
            }

            dataGridView1.DataSource =  ds.OgrenciGetir(TxtAra.Text);
        }

        string c = "";//global yaptık güncellemede vs kullanmak için

        private void BtnEkle_Click(object sender, EventArgs e)
        {

            if
                (
                string.IsNullOrEmpty(TxtAd.Text)
                )
            {
                MessageBox.Show("Lütfen Tüm ad alanını eksiksiz doldurunuz");
                return;
            }

            //TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulup.Text),c
            ds.OgrenciEkle(TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulup.SelectedValue.ToString()),c);
            MessageBox.Show("Ekleme İşlemi başarılı");
            listele();
        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Txtid.Text = CmbKulup.SelectedValue.ToString();//seçilen değer txt yazdırdık
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if
                (
                string.IsNullOrEmpty(Txtid.Text)
                )
            {
                MessageBox.Show("Lütfen Tüm id alanını eksiksiz doldurunuz");
                return;
            }

            ds.OgrenciSil(int.Parse(Txtid.Text));
            MessageBox.Show("Silme İşlemi başarılı");
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Kız")
            {
                rdBtnKiz.Checked = true;
            }

            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Erkek")
            {
                rdBtnErkek.Checked = true;
            }

            

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            if
                (
                string.IsNullOrEmpty(Txtid.Text) || string.IsNullOrEmpty(TxtAd.Text)
                )
            {
                MessageBox.Show("Lütfen ad ve id alanlarını eksiksiz doldurunuz");
                return;
            }

            ds.OgrenciGuncelle(TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulup.SelectedValue.ToString()),c,int.Parse(Txtid.Text));
            MessageBox.Show("Güncelleme İşlemi başarılı");
            listele();
        }

        private void rdBtnKiz_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnKiz.Checked == true)
            {
                c = "Kız";
            }
           
        }

        private void rdBtnErkek_CheckedChanged(object sender, EventArgs e)
        {            
            if (rdBtnErkek.Checked == true)
            {
                c = "Erkek";
            }
        }
    }
}
