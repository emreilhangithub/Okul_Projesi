using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Okul_Projesi.DataAccess;

namespace Okul_Projesi
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = null;
        Connection connection = new Connection();

        public void listele()
        {
            try
            {
                baglanti = connection.GetConnection();
                SqlDataAdapter da = new SqlDataAdapter("select * from TBLKULUPLER", baglanti);
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

        private void FrmKlup_Load(object sender, EventArgs e)
        {
            listele();
        }


        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(TxtAd.Text))
                {
                    MessageBox.Show("Lütfen ad alanını eksiksiz doldurunuz");
                    return;
                }

                string sql = "SELECT COUNT(*) FROM TBLKULUPLER WHERE KULUPAD = @KulupAdi";
                SqlCommand kontrolKomut = new SqlCommand(sql, baglanti);
                kontrolKomut.Parameters.AddWithValue("@KulupAdi", TxtAd.Text);
                int count = (int)kontrolKomut.ExecuteScalar();
                // Eğer kulüp adı mevcutsa hata döndür
                if (count > 0)
                {
                    MessageBox.Show("Hata: Bu kulüp adı zaten mevcut.");
                    return;
                }

                SqlCommand komut = new SqlCommand("insert into TBLKULUPLER (KULUPAD) values(@p1)", baglanti);
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.ExecuteNonQuery();
                //baglanti.Close();
                MessageBox.Show("Klüp Başarıyla Eklendi");
                listele();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(Txtid.Text))
                {
                    MessageBox.Show("Lütfen id alanını eksiksiz doldurunuz");
                    return;
                }
                SqlCommand komutsil = new SqlCommand("Delete From TBLKULUPLER where KULUPID = @k1", baglanti);
                komutsil.Parameters.AddWithValue("@k1", Txtid.Text);
                komutsil.ExecuteNonQuery();
                //baglanti.Close();
                MessageBox.Show("Kayıt Silindi");
                listele();
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(Txtid.Text) || string.IsNullOrEmpty(TxtAd.Text))
                {
                    MessageBox.Show("Lütfen id ve ad alanlarını eksiksiz doldurunuz");
                    return;
                }

                string sql = "SELECT COUNT(*) FROM TBLKULUPLER WHERE KULUPAD = @KULUPAD AND KULUPID <> @KULUPID";
                SqlCommand kontrolKomut = new SqlCommand(sql, baglanti);
                kontrolKomut.Parameters.AddWithValue("@KULUPAD", TxtAd.Text);
                kontrolKomut.Parameters.AddWithValue("@KULUPID", Txtid.Text);
                int count = (int)kontrolKomut.ExecuteScalar();
                // Eğer kulüp adı mevcutsa hata döndür
                if (count > 0)
                {
                    MessageBox.Show("Hata: Bu kulüp adı zaten mevcut.");
                    return;
                }

                SqlCommand komut = new SqlCommand("Update TBLKULUPLER set KULUPAD=@p1 where KULUPID = @p2", baglanti);
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", Txtid.Text);
                komut.ExecuteNonQuery();
                //baglanti.Close();
                MessageBox.Show("Klüp Başarıyla Güncellendi");
                listele();
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

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
