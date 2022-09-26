using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace secimproje
{
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }
        SqlConnection bağlanti = new SqlConnection(@"Data Source=DESKTOP-0U62NCI;Initial Catalog=DbSecimProje;Integrated Security=True");
        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            //ilçe adlarını comboboxa yazdırma
            bağlanti.Open();
            SqlCommand komut = new SqlCommand("select ILCEID from TBLILCE", bağlanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            bağlanti.Close();

            //grafiğe toplam sonuçları getirme
            bağlanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(apartı),sum(bpartı),sum(cpartı),sum(dpartı),sum(epartı) from tblılce",bağlanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", dr2[4]);
            }
            bağlanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bağlanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from TBLILCE where ILCEID = @p1", bağlanti);
            komut3.Parameters.AddWithValue("@p1", comboBox1.Text);

            SqlDataReader dr = komut3.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                lbla.Text = dr[2].ToString();
                lblb.Text = dr[3].ToString();
                lblc.Text = dr[4].ToString();
                lbld.Text = dr[5].ToString();
                lble.Text = dr[6].ToString();
            }
            bağlanti.Close();
        }
    }
}
