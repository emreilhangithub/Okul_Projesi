using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Projesi
{
    public partial class FrmKlup : Form
    {
        public FrmKlup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-E9UTSVL;Initial Catalog=Okul;Integrated Security=True");

        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
            if
          (
          string.IsNullOrEmpty(TxtAd.Text)
          )
            {
                MessageBox.Show("Lütfen ad alanını eksiksiz doldurunuz");
                return;
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLKULUPLER (KULUPAD) values(@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Klüp Başarıyla Eklendi");
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if
            (
            string.IsNullOrEmpty(Txtid.Text)
            )
            {
                MessageBox.Show("Lütfen id alanını eksiksiz doldurunuz");
                return;
            }

            baglanti.Open();
            SqlCommand komutsil = new SqlCommand(
               "Delete From TBLKULUPLER where KULUPID = @k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", Txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if
           (
           string.IsNullOrEmpty(Txtid.Text) || string.IsNullOrEmpty(TxtAd.Text)
           )
            {
                MessageBox.Show("Lütfen id ve ad alanlarını eksiksiz doldurunuz");
                return;
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBLKULUPLER set KULUPAD=@p1 where KULUPID = @p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", Txtid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Klüp Başarıyla Güncellendi");
            listele();
        }

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
