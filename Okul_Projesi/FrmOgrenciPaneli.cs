using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Okul_Projesi.DataAccess;
using System.Drawing;

namespace Okul_Projesi
{
    public partial class FrmOgrenciPaneli : Form
    {
        public FrmOgrenciPaneli()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = null;
        Connection connection = new Connection();
        public string numara;

        private void FrmOgrenciPaneli_Load(object sender, EventArgs e)
        {
            try
            {
                //this.Text = numara; //formun textini numaraya eşitledik
                baglanti = connection.GetConnection();
                SqlCommand komut = new SqlCommand("SELECT NOTID,DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", numara);
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
                baglanti.Close(); // Hata olsa da olmasa da bağlantıyı kapat
            }
        }

        private void FrmOgrenciPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Kapatmak İstediginizden Emin Misiniz ?", "Ögrenci Notları",
         MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
