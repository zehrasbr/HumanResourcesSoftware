using INSANKAYNAKLARIPROJE.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace INSANKAYNAKLARIPROJE
{
    public partial class IzinGoruntulePencere : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public IzinGoruntulePencere()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
            label1.ForeColor = ThemeColor.SecondaryColor;
            txt_TC.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            txt_Adi.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            txt_Soyadi.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            cbx_departmani.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            txt_adres.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
            cbx_izinturu.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.SecondaryColor;
            dtp_izinbaslangic.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
            dtp_izinbitis.ForeColor = ThemeColor.SecondaryColor;
            label9.ForeColor = ThemeColor.PrimaryColor;
        }

        public void ListeleDepartman()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT DEPARTMAN FROM DEPARTMANLAR", baglan);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                cbx_departmani.Items.Add(reader.GetString(0));
            }
            baglan.Close();
        }

        private void IzinGoruntulePencere_Load(object sender, EventArgs e)
        {
            ListeleDepartman();
            txt_TC.Text = IzinOnayIslemi.TC.ToString();
            txt_Adi.Text = IzinOnayIslemi.ADI.ToString();
            txt_Soyadi.Text = IzinOnayIslemi.SOYADI.ToString();
            cbx_departmani.Text = IzinOnayIslemi.DEPARTMANI.ToString();
            txt_adres.Text = IzinOnayIslemi.IZIN_ADRESI.ToString();
            cbx_izinturu.Text = IzinOnayIslemi.IZIN_TURU.ToString();
            dtp_izinbaslangic.Text = IzinOnayIslemi.BASLANGIC_TARIHI.ToString();
            dtp_izinbitis.Text = IzinOnayIslemi.BITIS_TARIHI.ToString();

        }

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string cizgi = "--------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bm = Properties.Resources.logo1;
            Image image = new Bitmap(bm);
            e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(560, 360));
            e.Graphics.DrawImage(image, 45, 45, 700, 250);
            e.Graphics.DrawString("PERSONEL İZİN BİLGİLERİ ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 400));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 370));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 430));
            e.Graphics.DrawString("TC Kimlik Numarası: " , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 475));
            e.Graphics.DrawString("Adı: " ,new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 500));
            e.Graphics.DrawString("Soyadı: " , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 525));
            e.Graphics.DrawString("Departmanı: " , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 550));
            e.Graphics.DrawString("İzinde Bulunacağı Adres: " , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 575));
            e.Graphics.DrawString("İzin Türü: " , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 600));
            e.Graphics.DrawString("İzin Başlangıç Tarihi: " , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 625));
            e.Graphics.DrawString("İzin Bitiş Tarihi: " , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 650));
            e.Graphics.DrawString(txt_TC.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 475));
            e.Graphics.DrawString(txt_Adi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 500));
            e.Graphics.DrawString(txt_Soyadi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 525));
            e.Graphics.DrawString(txt_adres.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 575));
            e.Graphics.DrawString(cbx_izinturu.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 600));
            e.Graphics.DrawString(dtp_izinbaslangic.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 625));
            e.Graphics.DrawString(dtp_izinbitis.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 650));
            e.Graphics.DrawString(cbx_departmani.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(270, 550));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1100));
            e.Graphics.DrawString("AIKA LTD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(695, 1120));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1140));
            e.Graphics.DrawString("ZEHRA İSBİR", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(200, 960));
            e.Graphics.DrawString("FURKAN ARDIÇ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(400, 960));
            e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(220, 1010));
            e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(430, 1010));
            e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(210, 985));
            e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(420, 985));

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
    }
}
