using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSANKAYNAKLARIPROJE
{
    public partial class IsIlaniPencere : Form
    {
        public IsIlaniPencere()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            label1.ForeColor = ThemeColor.SecondaryColor;
            txt_ilannumarasi.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            txt_sirketadi.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            cbx_aranilanpozisyon.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            txt_dilbilgisi.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            txt_personelozellik.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
            dtp_ilantarihi.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.SecondaryColor;
            txt_istanimi.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
        }

        private void IsIlaniPencere_Load(object sender, EventArgs e)
        {
            txt_ilannumarasi.Text = IsIlanlariniGoruntule.ILAN_NUMARASI.ToString();
            txt_sirketadi.Text = IsIlanlariniGoruntule.SIRKET_ADI.ToString();
            cbx_aranilanpozisyon.Text = IsIlanlariniGoruntule.ARANILAN_POZISYON.ToString();
            txt_dilbilgisi.Text = IsIlanlariniGoruntule.DIL_BILGISI.ToString();
            txt_personelozellik.Text = IsIlanlariniGoruntule.PERSONEL_OZELLIKLERI.ToString();
            dtp_ilantarihi.Text = IsIlanlariniGoruntule.ILAN_TARIHI.ToString();
            txt_istanimi.Text = IsIlanlariniGoruntule.IS_TANIMI.ToString();
        }

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void printer_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void print_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string cizgi = "--------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bm = Properties.Resources.logo1;
            Image image = new Bitmap(bm);
            e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(560, 360));
            e.Graphics.DrawImage(image, 45, 45, 700, 250);
            e.Graphics.DrawString("İŞ İLANI BİLGİLERİ ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 400));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 370));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 430));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1100));
            e.Graphics.DrawString("AIKA LTD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(695, 1120));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1140));
            e.Graphics.DrawString("ZEHRA İSBİR", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(200, 960));
            e.Graphics.DrawString("FURKAN ARDIÇ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(400, 960));
            e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(220, 1010));
            e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(430, 1010));
            e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(210, 985));
            e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(420, 985));
            e.Graphics.DrawString("İlan Numarası: ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 475));
            e.Graphics.DrawString("Şirket Adı: ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 500));
            e.Graphics.DrawString("Aranılan Pozisyon: ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 525));
            e.Graphics.DrawString("Aranılan Dil Bilgisi Seviyesi: ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 550));
            e.Graphics.DrawString("Aranılan Personel Özellikleri: ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 575));
            e.Graphics.DrawString("İlan Tarihi: ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 600));
            e.Graphics.DrawString("İş Tanımı: ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 625));
            e.Graphics.DrawString(txt_ilannumarasi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 475));
            e.Graphics.DrawString(txt_sirketadi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 500));
            e.Graphics.DrawString(cbx_aranilanpozisyon.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 525));
            e.Graphics.DrawString(txt_dilbilgisi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 550));
            e.Graphics.DrawString(txt_personelozellik.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 575));
            e.Graphics.DrawString(dtp_ilantarihi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 600));
            e.Graphics.DrawString(txt_istanimi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 625));
        }
    }
}
