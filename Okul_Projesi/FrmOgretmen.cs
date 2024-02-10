using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Okul_Projesi.DataAccess;

namespace Okul_Projesi
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = null;
        Connection connection = new Connection();

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void listele()
        {
            try
            {
                baglanti = connection.GetConnection();
                SqlCommand komut = new SqlCommand("SELECT OGRTID,OGRTADSOYAD,KULUPAD,OGRTSIFRE FROM TBLOGRETMENLER as ogr INNER JOIN TBLKULUPLER as klp ON ogr.OGRTBRANS = klp.KULUPID", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        void temizle()
        {
            TxtAd.Text = "";
            Txtid.Text = "";
            TxtSifre.Text = "";
        }


        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void FrmOgretmenler_Load(object sender, EventArgs e)
        {

            try
            {
                listele();
                baglanti = connection.GetConnection();
                //burada comboxa kulupleri listeledik Ado.NET Disconnected Mimari                
                SqlCommand komut = new SqlCommand("Select * from TBLKULUPLER", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CmbBrans.DisplayMember = "KULUPAD";  //gozukecek isim
                CmbBrans.ValueMember = "KULUPID"; //arkadagizli olan id
                CmbBrans.DataSource = dt;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(TxtAra.Text))
                {
                    MessageBox.Show("Lütfen Arama  textboxunu eksiksiz doldurunuz");
                    return;
                }

                SqlCommand komut = new SqlCommand(
                   "SELECT OGRTID,OGRTADSOYAD,KULUPAD,OGRTSIFRE FROM TBLOGRETMENLER as ogr INNER JOIN TBLKULUPLER as klp ON ogr.OGRTBRANS = klp.KULUPID where ogr.OGRTID = @OGRTID", baglanti);
                komut.Parameters.AddWithValue("@OGRTID", TxtAra.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(TxtAd.Text) ||string.IsNullOrEmpty(TxtSifre.Text) || string.IsNullOrEmpty(CmbBrans.Text))
                {
                    MessageBox.Show("Lütfen Tüm alanları eksiksiz doldurunuz");
                    return;
                }

                string sql = "SELECT COUNT(*) FROM TBLOGRETMENLER WHERE OGRTADSOYAD = @OGRTADSOYAD";
                SqlCommand kontrolKomut = new SqlCommand(sql, baglanti);
                kontrolKomut.Parameters.AddWithValue("@OGRTADSOYAD", TxtAd.Text);
                int count = (int)kontrolKomut.ExecuteScalar();
                // Eğer kulüp adı mevcutsa hata döndür
                if (count > 0)
                {
                    MessageBox.Show("Hata: Bu öğretmen adı ve soyadı zaten mevcut.");
                    return;
                }
                SqlCommand komut = new SqlCommand("insert into TBLOGRETMENLER (OGRTBRANS,OGRTADSOYAD,OGRTSIFRE) values(@OGRTBRANS,@OGRTADSOYAD,@OGRTSIFRE)", baglanti);
                komut.Parameters.AddWithValue("@OGRTBRANS", CmbBrans.SelectedValue);
                komut.Parameters.AddWithValue("@OGRTADSOYAD", TxtAd.Text);
                komut.Parameters.AddWithValue("@OGRTSIFRE", TxtSifre.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Personel Başarıyla Eklendi");
                listele();
                temizle();
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

        private void BtnSil_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(Txtid.Text))
                {
                    MessageBox.Show("Lütfen id alanını eksiksiz doldurunuz");
                    return;
                }

                baglanti.Open();
                SqlCommand komutsil = new SqlCommand(
                   "Delete From TBLOGRETMENLER where OGRTID = @OGRTID", baglanti);
                komutsil.Parameters.AddWithValue("@OGRTID", Txtid.Text);
                komutsil.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi");
                listele();
                temizle();
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(Txtid.Text) || string.IsNullOrEmpty(TxtAd.Text) || string.IsNullOrEmpty(TxtSifre.Text) || string.IsNullOrEmpty(CmbBrans.Text))
                {
                    MessageBox.Show("Lütfen Tüm ad alanını eksiksiz doldurunuz");
                    return;
                }

                string sql = "SELECT COUNT(*) FROM TBLOGRETMENLER WHERE OGRTADSOYAD = @OGRTADSOYAD AND OGRTID <> @OGRTID";
                SqlCommand kontrolKomut = new SqlCommand(sql, baglanti);
                kontrolKomut.Parameters.AddWithValue("@OGRTADSOYAD", TxtAd.Text);
                kontrolKomut.Parameters.AddWithValue("@OGRTID", Txtid.Text);
                int count = (int)kontrolKomut.ExecuteScalar();
                // Eğer kulüp adı mevcutsa hata döndür
                if (count > 0)
                {
                    MessageBox.Show("Hata: Bu öğretmen adı ve soyadı zaten mevcut.");
                    return;
                }

               
                SqlCommand komut = new SqlCommand("Update TBLOGRETMENLER set OGRTBRANS=@OGRTBRANS,OGRTADSOYAD=@OGRTADSOYAD,OGRTSIFRE=@OGRTSIFRE where OGRTID = @OGRTID", baglanti);
                komut.Parameters.AddWithValue("@OGRTBRANS", CmbBrans.SelectedValue);
                komut.Parameters.AddWithValue("@OGRTADSOYAD", TxtAd.Text);
                komut.Parameters.AddWithValue("@OGRTID", Txtid.Text);
                komut.Parameters.AddWithValue("@OGRTSIFRE", TxtSifre.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Personel Başarıyla Güncellendi");
                listele();
                temizle();
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
