using Okul_Projesi.DataAccess;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Okul_Projesi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = null;
        Connection connection = new Connection();
        private void btnOgrenciGirisi_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(txtKullaniciId.Text) || string.IsNullOrEmpty(txtKullaniciSifre.Text))
                {
                    MessageBox.Show("Lütfen Kullanıcı Id veya Şifre Giriniz");
                    return;
                }
                string query = "SELECT COUNT(*) FROM TBLOGRENCILER WHERE OGRID = @OGRID AND OGRSIFRE = @OGRSIFRE";
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@OGRID", txtKullaniciId.Text);
                komut.Parameters.AddWithValue("@OGRSIFRE", txtKullaniciSifre.Text);
                int count = (int)komut.ExecuteScalar();
                if (count == 0 || count < 0)
                {
                    MessageBox.Show("Ögrenci Kullanıcı Id veya Kullanıcı Şifresini kontrol ediniz");
                    return;
                }
                FrmOgrenciPaneli fr = new FrmOgrenciPaneli();
                fr.numara = txtKullaniciId.Text;
                fr.Show();
                this.Hide();
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

        private void btnOgretmenGirisi_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti = connection.GetConnection();
                if (string.IsNullOrEmpty(txtKullaniciId.Text) || string.IsNullOrEmpty(txtKullaniciSifre.Text))
                {
                    MessageBox.Show("Lütfen Kullanıcı Id veya Şifre Giriniz");
                    return;
                }
                string query = "SELECT COUNT(*) FROM TBLOGRETMENLER WHERE OGRTID = @OGRTID AND OGRTSIFRE = @OGRTSIFRE";
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@OGRTID", txtKullaniciId.Text);
                komut.Parameters.AddWithValue("@OGRTSIFRE", txtKullaniciSifre.Text);
                int count = (int)komut.ExecuteScalar();
                if (count == 0 || count < 0)
                {
                    MessageBox.Show("Öğretmen Kullanıcı Id veya Kullanıcı Şifresini kontrol ediniz");
                    return;
                }
                FrmOgretmenPaneli fr = new FrmOgretmenPaneli();
                fr.Show();
                this.Hide();
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
