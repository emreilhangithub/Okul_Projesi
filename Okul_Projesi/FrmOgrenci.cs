using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Okul_Projesi.DataAccess;

namespace Okul_Projesi
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = null;
        Connection connection = new Connection();
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void listele()
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }


        private void FrmOgrenci_Load(object sender, EventArgs e)
        {

            try
            {
                listele();
                baglanti = connection.GetConnection();
                SqlCommand komut = new SqlCommand("Select * from TBLKULUPLER", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CmbKulup.DisplayMember = "KULUPAD";  //gozukecek isim
                CmbKulup.ValueMember = "KULUPID"; //arkadagizli olan id
                CmbKulup.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close(); // Bağlantıyı kapat
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAra.Text))
            {
                MessageBox.Show("Lütfen arama textboxı alanını eksiksiz doldurunuz");
                return;
            }

            dataGridView1.DataSource = ds.OgrenciGetir(TxtAra.Text);
        }

        string c = "";//global yaptık güncellemede vs kullanmak için

        private void BtnEkle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtAd.Text) || string.IsNullOrEmpty(TxtSoyad.Text) || string.IsNullOrEmpty(TxtSifre.Text) || string.IsNullOrEmpty(CmbKulup.Text))
            {
                MessageBox.Show("Lütfen Tüm alanları eksiksiz doldurunuz");
                return;
            }

            if (rdBtnErkek.Checked == false && rdBtnKiz.Checked == false)
            {
                MessageBox.Show("Lütfen Cinsiyet Seçiniz");
                return;
            }

            var ogrenciEklemeKontrol = ds.OgrenciEklemeKontrol(TxtAd.Text,TxtSoyad.Text);
            if (ogrenciEklemeKontrol > 0)
            {
                MessageBox.Show("Zaten bu isim ve soyisim var");
                return;
            }
            else
            {
                //TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulup.Text),c
                ds.OgrenciEkle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c, TxtSifre.Text);
                MessageBox.Show("Ekleme İşlemi başarılı");
                listele();
            }           
        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Txtid.Text = CmbKulup.SelectedValue.ToString();//seçilen değer txt yazdırdık
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txtid.Text))
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
            TxtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
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
            if (string.IsNullOrEmpty(Txtid.Text) || string.IsNullOrEmpty(TxtAd.Text) || string.IsNullOrEmpty(TxtSoyad.Text) || string.IsNullOrEmpty(TxtSifre.Text) || string.IsNullOrEmpty(CmbKulup.Text))
            {
                MessageBox.Show("Lütfen Tüm ad alanını eksiksiz doldurunuz");
                return;
            }

            if (rdBtnErkek.Checked == false && rdBtnKiz.Checked == false)
            {
                MessageBox.Show("Lütfen Cinsiyet Seçiniz");
                return;
            }

            var OgrenciGuncellemeKontrol = ds.OgrenciGuncellemeKontrol(TxtAd.Text,TxtSoyad.Text,
                byte.Parse(Txtid.Text));
            if (OgrenciGuncellemeKontrol > 0)
            {
                MessageBox.Show("Zaten bu isim ve soyisim var");
                return;
            }
            else
            {
                ds.OgrenciGuncelle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c, TxtSifre.Text, int.Parse(Txtid.Text));
                MessageBox.Show("Güncelleme İşlemi başarılı");
                listele();
            }           
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
