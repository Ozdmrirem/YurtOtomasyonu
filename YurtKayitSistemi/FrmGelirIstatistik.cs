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

namespace YurtKayitSistemi
{
    public partial class FrmGelirIstatistik : Form
    {
        public FrmGelirIstatistik()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmGelirIstatistik_Load(object sender, EventArgs e)
        {
            //Kasadaki Toplam Tutar
            SqlCommand komut = new SqlCommand("Select Sum(OdemeMiktar) from Kasa", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
               LblPara.Text = oku[0].ToString()+ " TL " ;
            }
            bgl.baglanti().Close();

            //Tekrarsız Olarak Ayları Listeleme
            SqlCommand komut2 = new SqlCommand("Select Distinct (OdemeAy) from Kasa", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbAy.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select Sum(OdemeMiktar) from Kasa where OdemeAy=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAy.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblAyKazanc.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
