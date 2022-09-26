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

namespace secimproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bağlanti = new SqlConnection(@"Data Source=DESKTOP-0U62NCI;Initial Catalog=DbSecimProje;Integrated Security=True");

        private void btnoy_Click(object sender, EventArgs e)
        {
            bağlanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLILCE (ILCEID,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values (@a1,@a2,@a3,@a4,@a5,@a6)", bağlanti);
            komut.Parameters.AddWithValue("@a1",txtilce.Text);
            komut.Parameters.AddWithValue("@a2",txta.Text);
            komut.Parameters.AddWithValue("@a3",txtb.Text);
            komut.Parameters.AddWithValue("@a4",txtc.Text);
            komut.Parameters.AddWithValue("@a5",txtd.Text);
            komut.Parameters.AddWithValue("@a6",txte.Text);
            komut.ExecuteNonQuery();
            bağlanti.Close();
            MessageBox.Show("Kayıt İşlemi Tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            frmgrafikler fr = new frmgrafikler();
            fr.Show();
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
