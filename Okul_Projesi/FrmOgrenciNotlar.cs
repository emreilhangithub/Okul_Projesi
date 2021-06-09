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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-E9UTSVL;Initial Catalog=Okul;Integrated Security=True");
        public string numara;

        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            //this.Text = numara; //formun textini numaraya eşitledik

            SqlCommand komut = new SqlCommand("Select * from TBLNOTLAR where OGRID=@P1",baglanti);
            komut.Parameters.AddWithValue("@P1",numara);           
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }
    }
}
