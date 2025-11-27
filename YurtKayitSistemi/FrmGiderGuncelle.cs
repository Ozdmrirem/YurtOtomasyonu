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
    public partial class FrmGiderGuncelle : Form
    {
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }
        public string elektrik,su,dogalgaz,gida,diger,internet,personel,id;

        SqlBaglantim bgl = new SqlBaglantim();
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("Update Giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,internet=@p4,Gida=@p5,Personel=@p6,Diger=@p7 where Giderid=@p1",bgl.baglanti()); 
        }

        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            txtGiderid.Text = id;
            txtElektrik.Text = elektrik;
            txtGida.Text = gida;
            txtSu.Text = su;
            txtPersonel.Text = personel;
            txtInternet.Text = internet;
            txtDogalgaz.Text = dogalgaz;
            txtDiger.Text = diger;
        }
    }
}
