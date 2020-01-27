
using SuOtomasyonu.ENTITY;
using SuOtomasyonu.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int silOrDuzenle = 0;
        int fiyat = 0;
        int siparisID = 0;
        string siparisAd;
        string siparisSoyad;


        private void Form1_Load(object sender, EventArgs e)
        {
           

            panel1.Visible = false;
            panel2.Visible = false;


            List<MusteriModel> musteriListe = HELPER.HelperMusteri.MusteriAsList();
            foreach (var item in musteriListe)
            {
                dataGridView1.Rows.Add(item.musteriID, item.musteriAdi, item.musteriSoyadi, item.Telefon, item.Adres);
            }
            dataGridView1.ClearSelection();

            dataGridView2.Rows.Clear();
            List<MusteriModel> siparisListe = HELPER.HelperSiparis.SiparisAsList();
            foreach (var item in siparisListe)
            {
                dataGridView2.Rows.Add(item.siparis.siparisID, item.siparis.musAdi, item.siparis.musSoyadi,
                                        item.siparis.Durum, item.siparis.musAdres, item.siparis.Tutar);
            }

            dataGridView2.ClearSelection();

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnMusteriAra_Click(object sender, EventArgs e)
        {
            string ad = txtGirisAramaAdi.Text.Trim();
            string soyad = txtGirisAramaSoyadi.Text.Trim();


         var musteri= HELPER.HelperMusteri.ReturnMusteri(ad,soyad);
            dataGridView1.Rows.Clear();
            foreach (var item in musteri)
            {
                dataGridView1.Rows.Add(item.musteriID,item.musteriAdi,item.musteriSoyadi,item.Telefon,item.Adres);
            }
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            MusteriEkle mEkle = new MusteriEkle();
            mEkle.Show();
        }

        private void btnMusteriYenile_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
          var musteriList=  HELPER.HelperMusteri.MusteriAsList();
            foreach (var item in musteriList)
            {
                dataGridView1.Rows.Add(item.musteriID,item.musteriAdi,item.musteriSoyadi,item.Telefon,item.Adres);
            }
        }

     

       
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            MusteriModel mm = new MusteriModel();
            mm.musteriID = silOrDuzenle;

            mm.musteriAdi = textBox1.Text;
            mm.musteriSoyadi = textBox2.Text;
            mm.Telefon = textBox3.Text;
            mm.Adres = textBox4.Text;
            HELPER.HelperMusteri.UpdateMusteri(mm);
            panel1.Visible = false;
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
         
            HELPER.HelperMusteri.RemoveMusteri(silOrDuzenle);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        siparisAd = dataGridView1.CurrentRow.Cells[1].Value.ToString();
         siparisSoyad = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            silOrDuzenle = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
          
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            silOrDuzenle = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            siparisID= Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnSiparisYenile_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            List<MusteriModel> siparisListe = HELPER.HelperSiparis.SiparisAsList();
            foreach (var item in siparisListe)
            {
                dataGridView2.Rows.Add(item.siparis.siparisID, item.siparis.musAdi, item.siparis.musSoyadi,
                                        item.siparis.Durum, item.siparis.musAdres,item.siparis.Tutar);
            }
        }

        private void btnSiparisSil_Click(object sender, EventArgs e)
        {
            bool silindiMi = HELPER.HelperSiparis.SiparisSil(silOrDuzenle);
            if (silindiMi)
            {
                MessageBox.Show("Başarıyla silindi!");
            }
            else
                MessageBox.Show("Bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz.");
        }

        private void btnSipariTumunuSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bütün siparişleri silmek istediğinize emin misiniz?", "Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<int> silinecekler = HELPER.HelperSiparis.SiparisIDListele();
                bool silinmeDurumu = HELPER.HelperSiparis.TumSiparisTablosunuSil(silinecekler);
                if (silinmeDurumu)
                {
                    MessageBox.Show("Başarıyla silindiler!");
                }
                else
                    MessageBox.Show("Silinemediler");
            }
            else
            {
                MessageBox.Show("Silinemediler");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

           
            panel2.Visible = true;
            fiyat = Convert.ToInt32(textBox5.Text);
            var list = HELPER.HelperMusteri.ReturnMusteri(siparisAd,siparisSoyad);

            foreach (var item in list)
            {
                MusteriModel mm = new MusteriModel();

                mm.siparis.musAdi = item.musteriAdi;
                mm.siparis.musSoyadi = item.musteriSoyadi;
                mm.siparis.Durum = "Hazırlanıyor";
                mm.siparis.musAdres = item.Adres;
                mm.siparis.Tutar = fiyat;
                HELPER.HelperSiparis.SiparisEkle(mm);
               

            }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnYolaCikti_Click(object sender, EventArgs e)
        {
            var obj = HELPER.HelperSiparis.SiparisBul(siparisID);
            MusteriModel mm = new MusteriModel();
            mm.siparis.siparisID = obj.siparisID;
            mm.siparis.musAdi = obj.musAdi;
            mm.siparis.musSoyadi = obj.musSoyadi;
            mm.siparis.Tutar = obj.Tutar;
            mm.siparis.musAdres = obj.musAdres;
            mm.siparis.Durum = "Yolda";

            HELPER.HelperSiparis.DurumDegistir(mm);

        }

        private void btnTeslimEdildi_Click(object sender, EventArgs e)
        {

            var obj = HELPER.HelperSiparis.SiparisBul(siparisID);
            MusteriModel mm = new MusteriModel();
            mm.siparis.siparisID = obj.siparisID;
            mm.siparis.musAdi = obj.musAdi;
            mm.siparis.musSoyadi = obj.musSoyadi;
            mm.siparis.Tutar = obj.Tutar;
            mm.siparis.musAdres = obj.musAdres;
            mm.siparis.Durum ="Teslim";
            HELPER.HelperSiparis.DurumDegistir(mm);
           
        }

        private void btnGununSiparisiniSil_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            var siparisListesi = HELPER.HelperSiparis.SiparisDepends();
            foreach (var item in siparisListesi)
            {
                dataGridView2.Rows.Add(item.siparis.siparisID, item.siparis.musAdi, item.siparis.musSoyadi, item.siparis.Durum, item.siparis.musAdres,item.siparis.Tutar);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
