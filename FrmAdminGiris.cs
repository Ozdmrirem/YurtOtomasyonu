using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if(txtKullaniciAd.Text=="admin34" && txtSifre.Text=="1234")
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
        }
    }
}
