using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Projesi
{
    public partial class FrmOgretmenDuzenle : Form
    {
        public FrmOgretmenDuzenle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-E9UTSVL;Initial Catalog=Okul;Integrated Security=True");

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void listele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT OGRTID,OGRTADSOYAD,KULUPAD FROM TBLOGRETMENLER as ogr INNER JOIN TBLKULUPLER as klp ON ogr.OGRTBRANS = klp.KULUPID",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);           
            DataTable dt = new DataTable();
            da.Fill(dt);            
            dataGridView1.DataSource = dt;           
            baglanti.Close();
        }

        void temizle()
        {
            TxtAd.Text = "";            
            Txtid.Text = "";
        }


        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();           
        }

        private void FrmOgretmenler_Load(object sender, EventArgs e)
        {
            listele();

            //burada comboxa kulupleri listeledik Ado.NET Disconnected Mimari
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbBrans.DisplayMember = "KULUPAD";  //gozukecek isim
            CmbBrans.ValueMember = "KULUPID"; //arkadagizli olan id
            CmbBrans.DataSource = dt;

            baglanti.Close();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();            
            CmbBrans.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if
            (
            string.IsNullOrEmpty(TxtAra.Text)
            )
            {
                MessageBox.Show("Lütfen Arama  textboxunu eksiksiz doldurunuz");
                return;
            }

            SqlCommand komut = new SqlCommand(
               "SELECT OGRTID,OGRTADSOYAD,KULUPAD FROM TBLOGRETMENLER as ogr INNER JOIN TBLKULUPLER as klp ON ogr.OGRTBRANS = klp.KULUPID where ogr.OGRTID = @OGRTID", baglanti);
            komut.Parameters.AddWithValue("@OGRTID", TxtAra.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if
            (
            string.IsNullOrEmpty(TxtAd.Text)
            )
            {
                MessageBox.Show("Lütfen Ad alanını eksiksiz doldurunuz");
                return;
            }

            baglanti.Open(); 
            SqlCommand komut = new SqlCommand("insert into TBLOGRETMENLER (OGRTBRANS,OGRTADSOYAD) values(@OGRTBRANS,@OGRTADSOYAD)", baglanti);
            komut.Parameters.AddWithValue("@OGRTBRANS", CmbBrans.SelectedValue);
            komut.Parameters.AddWithValue("@OGRTADSOYAD", TxtAd.Text);
            komut.ExecuteNonQuery(); 
            baglanti.Close(); 
            MessageBox.Show("Personel Başarıyla Eklendi");
            listele();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
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
               "Delete From TBLOGRETMENLER where OGRTID = @OGRTID", baglanti);
            komutsil.Parameters.AddWithValue("@OGRTID", Txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
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
            SqlCommand komut = new SqlCommand("Update TBLOGRETMENLER set OGRTBRANS=@OGRTBRANS,OGRTADSOYAD=@OGRTADSOYAD where OGRTID = @OGRTID", baglanti);
            komut.Parameters.AddWithValue("@OGRTBRANS", CmbBrans.SelectedValue);
            komut.Parameters.AddWithValue("@OGRTADSOYAD", TxtAd.Text);
            komut.Parameters.AddWithValue("@OGRTID", Txtid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Başarıyla Güncellendi");
            listele();
            temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
