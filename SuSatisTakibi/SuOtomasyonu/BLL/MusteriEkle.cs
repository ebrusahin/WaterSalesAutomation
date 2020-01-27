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
    public partial class MusteriEkle : Form
    {
        public MusteriEkle()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MusteriModel yeniMusteri = new MusteriModel();
            yeniMusteri.musteriAdi = textBox1.Text;
            yeniMusteri.musteriSoyadi = textBox2.Text;
            yeniMusteri.Telefon = textBox3.Text;
            yeniMusteri.Adres = textBox4.Text;
            HELPER.HelperMusteri.AddMusteri(yeniMusteri);
          
        }
    }
}
