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
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        public string id,ad,soyad,TC,telefon,dogum,bolum;
        public string mail, odaNo, veliAdSoyad, veliTelefon, adres;

        SqlBaglantim bgl = new SqlBaglantim();

        //Öğrenci Silme 
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Ogrenci where Ogrid=@k1", bgl.baglanti());
            komut.Parameters.AddWithValue("@k1", TxtOgrId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");

            //Odanın Aktif Öğrenci Sayısını Azaltma
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@oda", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda", CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            TxtOgrId.Text = id;
            txtOgrAd.Text = ad;
            txtOgrSoyad.Text = soyad;
            MskTC.Text = TC;
            MskOgrTelefon.Text = telefon;
            MskDogum.Text = dogum;
            CmbBolum.Text = bolum;
            TxtMail.Text = mail;
            CmbOdaNo.Text = odaNo;
            TxtVeliAdSoyad.Text = veliAdSoyad;
            MskVeliTelefon.Text = veliTelefon;
            RchAdres.Text = adres;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Update Ogrenci set OgrAd=@2,OgrSoyad=@3,OgrTC=@4,OgrTelefon=@5,OgrDogum=@6,OgrBolum=@7," +
                "OgrMail=@8,OgrOdaNo=@9,OgrVeliAdSoyad=@10,OgrVeliTelefon=@11,OgrVeliAdres=@12 where Ogrid=@1", bgl.baglanti());
                komut.Parameters.AddWithValue("@1", TxtOgrId.Text);
                komut.Parameters.AddWithValue("@2", txtOgrAd.Text);
                komut.Parameters.AddWithValue("@3", txtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@4", MskTC.Text);
                komut.Parameters.AddWithValue("@5", MskOgrTelefon.Text);
                komut.Parameters.AddWithValue("@6", MskDogum.Text);
                komut.Parameters.AddWithValue("@7", CmbBolum.Text);
                komut.Parameters.AddWithValue("@8", TxtMail.Text);
                komut.Parameters.AddWithValue("@9", CmbOdaNo.Text);
                komut.Parameters.AddWithValue("@10", TxtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@11", MskVeliTelefon.Text);
                komut.Parameters.AddWithValue("@12", RchAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Kayıt Güncellenemedi.");
            }
        }
    }
}
