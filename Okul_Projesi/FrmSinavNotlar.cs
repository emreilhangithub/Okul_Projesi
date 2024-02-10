﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Okul_Projesi.DataAccess;

namespace Okul_Projesi
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        DataSet1.TBLNOTLARDataTable dt = new DataSet1.TBLNOTLARDataTable(); // DataTable nesnesini oluşturun ve gerekli verileri ekleyin
        SqlConnection baglanti = null;
        Connection connection = new Connection();
        int notid;
        int sinav1, sinav2, sinav3, proje;
        double ortlama;

        void temizle()
        {
            Txtid.Text = "";
            TxtSinav1.Text = "";
            TxtSinav2.Text = "";
            TxtSinav3.Text = "";
            TxtProje.Text = "";
            TxtOrtalama.Text = "";
            TxtDurum.Text = "";
        }

        void aramaTemzile()
        {
            TxtSinav1.Text = "";
            TxtSinav2.Text = "";
            TxtSinav3.Text = "";
            TxtProje.Text = "";
            TxtOrtalama.Text = "";
            TxtDurum.Text = "";
        }

        void aramaYap()
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(Txtid.Text));
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txtid.Text))
            {
                MessageBox.Show("Lütfen id alanını eksiksiz doldurunuz");
                return;
            }

            aramaTemzile();
            aramaYap();

        }

        private void pctKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {

            try
            {
                baglanti = connection.GetConnection();
                SqlCommand komut = new SqlCommand("Select * from TBLDERSLER", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CmbDers.DisplayMember = "DERSAD";  //gozukecek isim
                CmbDers.ValueMember = "DERSID"; //arkadagizli olan id
                CmbDers.DataSource = dt;
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

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txtid.Text) || string.IsNullOrEmpty(TxtSinav1.Text) || string.IsNullOrEmpty(TxtSinav2.Text) || string.IsNullOrEmpty(TxtSinav3.Text) || string.IsNullOrEmpty(TxtProje.Text) || string.IsNullOrEmpty(TxtOrtalama.Text) || string.IsNullOrEmpty(TxtDurum.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları eksiksiz doldurunuz");
                return;
            }


            //burada güncellemede hile yapılmaması için bunu yaptık
            sinav1 = Convert.ToInt16(TxtSinav1.Text);
            sinav2 = Convert.ToInt16(TxtSinav2.Text);
            sinav3 = Convert.ToInt16(TxtSinav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortlama = Convert.ToDouble(TxtOrtalama.Text);

            if (sinav1 < 0 || sinav1 > 100 || sinav2 < 0 || sinav2 > 100 || sinav3 < 0 || sinav3 > 100 || proje < 0 || proje > 100)
            {
                MessageBox.Show("Lütfen sınav notunu  ve proje notunu 1-100 arasında giriniz");
                return;
            }

            if (ortlama < 0 || ortlama > 100)
            {
                MessageBox.Show("Lütfen 0-100 arasında bir ortalama alınız");
                return;
            }

            var NotDersKontrol = ds.NotDersKontrol(int.Parse(Txtid.Text), byte.Parse(CmbDers.SelectedValue.ToString()));
            // Eğer kayıtSayisi 0 ise, kayıt bulunmuyor demektir.
            int kayitSayisi = Convert.ToInt32(NotDersKontrol);
            if (kayitSayisi > 0)
            {
                MessageBox.Show("Ekleme yapılamadı Bu ders ile bu ögrenciye zaten daha önce not eklenmiş lütfen kayıtlı olmayan bir ders giriniz !!!");
                return;
            }

            ds.NotEkleme(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(Txtid.Text), byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text));

            //güncelledikten sonra tekrdan arama yapıp sayfayı yenilemesi lazım ve textboxları silmesi gerekiyor
            aramaTemzile();
            aramaYap();

            MessageBox.Show("Güncelleme İşlemi Başarıyla Yapıldı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            CmbDers.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSinav1.Text) || string.IsNullOrEmpty(TxtSinav2.Text) || string.IsNullOrEmpty(TxtSinav3.Text) || string.IsNullOrEmpty(TxtProje.Text))
            {
                MessageBox.Show("Lütfen Sınav notu ve proje alanları eksiksiz doldurunuz");
                return;
            }


            //string durum;

            sinav1 = Convert.ToInt16(TxtSinav1.Text);
            sinav2 = Convert.ToInt16(TxtSinav2.Text);
            sinav3 = Convert.ToInt16(TxtSinav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);

            if (sinav1 < 0 || sinav1 > 100 || sinav2 < 0 || sinav2 > 100 || sinav3 < 0 || sinav3 > 100 || proje < 0 || proje > 100)
            {
                MessageBox.Show("Lütfen sınav notunu  ve proje notunu 1-100 arasında giriniz");
                return;
            }


            ortlama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            TxtOrtalama.Text = ortlama.ToString();
            if (ortlama >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txtid.Text) || string.IsNullOrEmpty(TxtSinav1.Text) || string.IsNullOrEmpty(TxtSinav2.Text) || string.IsNullOrEmpty(TxtSinav3.Text) || string.IsNullOrEmpty(TxtProje.Text) || string.IsNullOrEmpty(TxtOrtalama.Text) || string.IsNullOrEmpty(TxtDurum.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları eksiksiz doldurunuz");
                return;
            }


            //burada güncellemede hile yapılmaması için bunu yaptık
            sinav1 = Convert.ToInt16(TxtSinav1.Text);
            sinav2 = Convert.ToInt16(TxtSinav2.Text);
            sinav3 = Convert.ToInt16(TxtSinav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortlama = Convert.ToDouble(TxtOrtalama.Text);

            if (sinav1 < 0 || sinav1 > 100 || sinav2 < 0 || sinav2 > 100 || sinav3 < 0 || sinav3 > 100 || proje < 0 || proje > 100)
            {
                MessageBox.Show("Lütfen sınav notunu  ve proje notunu 1-100 arasında giriniz");
                return;
            }

            if (ortlama < 0 || ortlama > 100)
            {
                MessageBox.Show("Lütfen 0-100 arasında bir ortalama alınız");
                return;
            }

            var NotDersKontrolGuncelleme = ds.NotDersKontrolGuncelleme(dt,int.Parse(Txtid.Text), byte.Parse(CmbDers.SelectedValue.ToString()));
            if (NotDersKontrolGuncelleme > 0)
            {
                // dt içindeki verilere erişme
                foreach (DataRow row in dt.Rows)
                {
                    // Her bir sütunun ismini kullanarak verilere erişin
                    //NOTID, DERSID, OGRID, SINAV1, SINAV2, SINAV3, PROJE, ORTALAMA, DURUM
                    var notID = row["NOTID"].ToString();
                    ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(Txtid.Text), byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text), Convert.ToInt16(notID));
                }
            } 
            
            else
            {
                ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(Txtid.Text), byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text), notid);
            }          

            //güncelledikten sonra tekrdan arama yapıp sayfayı yenilemesi lazım ve textboxları silmesi gerekiyor
            aramaTemzile();
            aramaYap();

            MessageBox.Show("Güncelleme İşlemi Başarıyla Yapıldı");
        }
    }
}
