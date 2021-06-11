using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void pictureBox6_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string c = "";
            if(radioButton1.Checked == true)
            {
                c = "Kız";
            }
            if(radioButton2.Checked == true)
            {
                c = "Erkek";
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
    }
}
