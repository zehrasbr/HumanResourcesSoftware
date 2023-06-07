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

namespace INSANKAYNAKLARIPROJE
{
    public partial class MenuSirketBilgileri : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        public MenuSirketBilgileri()
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
            lbl_personelSayisi.ForeColor = ThemeColor.PrimaryColor;
            lbl_yasOrtalamasi.ForeColor = ThemeColor.SecondaryColor;
            lbl_erkekPersonel.ForeColor = ThemeColor.PrimaryColor;
            lbl_kadinPersonel.ForeColor = ThemeColor.SecondaryColor;
            lblİ.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            labelA.ForeColor = ThemeColor.SecondaryColor;
            labelB.ForeColor = ThemeColor.PrimaryColor;
            labelF.ForeColor = ThemeColor.SecondaryColor;
            labelD.ForeColor = ThemeColor.PrimaryColor;
            groupBox1.ForeColor = ThemeColor.SecondaryColor;
            groupBox2.ForeColor = ThemeColor.SecondaryColor;
            labelJ.ForeColor = ThemeColor.SecondaryColor;
            labelK.ForeColor = ThemeColor.PrimaryColor;
            labelL.ForeColor = ThemeColor.SecondaryColor;
            labelM.ForeColor = ThemeColor.SecondaryColor;
            label13.ForeColor = ThemeColor.SecondaryColor;
            label17.ForeColor = ThemeColor.PrimaryColor;
            label18.ForeColor = ThemeColor.SecondaryColor;
            label19.ForeColor = ThemeColor.PrimaryColor;
            labelH.ForeColor = ThemeColor.SecondaryColor;
            label15.ForeColor = ThemeColor.PrimaryColor;
            labelI.ForeColor = ThemeColor.PrimaryColor;
        }
        
        //Şirketteki personel bilgilerini veri tabanından belirli koşullara göre çekiyoruz
        //Bilgileri labellara yazdırıyoruz
        private void MenuSirketBilgileri_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT POZISYONU,COUNT(TC)as ToplamPersonel FROM PERSONEL GROUP BY POZISYONU", baglan);
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*),AVG(DATEDIFF(YEAR,DOGUM_TARIHI,GETDATE())) FROM PERSONEL", baglan);
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(CINSIYETI) FROM PERSONEL WHERE CINSIYETI = 'ERKEK'", baglan);
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(CINSIYETI) FROM PERSONEL WHERE CINSIYETI = 'KADIN'", baglan);
            
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(dt);
            
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            da1.Fill(dt1);
            
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            DataSet ds2 = new DataSet();
            da2.Fill(dt2);
            
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            DataSet ds3 = new DataSet();
            da3.Fill(dt3);
            baglan.Close();

            labelA.Text = dt.Rows[0][1].ToString();
            labelB.Text = dt.Rows[1][1].ToString();
            labelC.Text = dt.Rows[2][1].ToString();
            labelD.Text = dt.Rows[3][1].ToString();
            labelE.Text = dt.Rows[4][1].ToString();
            labelF.Text = dt.Rows[5][1].ToString();
            labelG.Text = dt.Rows[6][1].ToString();
            labelH.Text = dt.Rows[7][1].ToString();
            labelI.Text = dt.Rows[8][1].ToString();

            labelJ.Text = dt1.Rows[0][0].ToString();
            labelK.Text = dt1.Rows[0][1].ToString();
            labelL.Text = dt2.Rows[0][0].ToString();
            labelM.Text = dt3.Rows[0][0].ToString();
        }

        private void print_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printer_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string cizgi = "--------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bm = Properties.Resources.logo1;
            Image image = new Bitmap(bm);
            e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(560, 360));
            e.Graphics.DrawImage(image, 45, 45, 700, 250);
            e.Graphics.DrawString("DEPARTMAN ADI ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 400));
            e.Graphics.DrawString("PERSONEL SAYISI ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(400, 400));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 370));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 430));
            e.Graphics.DrawString("AR-GE " , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 450));
            e.Graphics.DrawString("GRAFİK TASARIM ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 475));
            e.Graphics.DrawString("GÜVENLİK ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 500));
            e.Graphics.DrawString("İNSAN KAYNAKLARI ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 525));
            e.Graphics.DrawString("MUHASEBE VE FİNANS ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 550));
            e.Graphics.DrawString("PROGRAMLAMA ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 575));
            e.Graphics.DrawString("STAJYER ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 600));
            e.Graphics.DrawString("WEB ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 625));
            e.Graphics.DrawString("YÖNETİM ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 650));
            e.Graphics.DrawString(labelA.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 450));
            e.Graphics.DrawString(labelB.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 475));
            e.Graphics.DrawString(labelC.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 500));
            e.Graphics.DrawString(labelD.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 525));
            e.Graphics.DrawString(labelE.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 550));
            e.Graphics.DrawString(labelF.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 575));
            e.Graphics.DrawString(labelG.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 600));
            e.Graphics.DrawString(labelH.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 625));
            e.Graphics.DrawString(labelI.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 650));
            e.Graphics.DrawString("PERSONEL BİLGİLERİ ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 800));
            e.Graphics.DrawString("PERSONEL RAPORLARI ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(400, 800));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 770));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 830));
            e.Graphics.DrawString("TOPLAM PERSONEL SAYISI ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 850));
            e.Graphics.DrawString("YAŞ ORTALAMASI ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 875));
            e.Graphics.DrawString("ERKEK PERSONEL SAYISI ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 900));
            e.Graphics.DrawString("KADIN PERSONEL SAYISI ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 925));
            e.Graphics.DrawString(labelJ.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 850));
            e.Graphics.DrawString(labelK.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 875));
            e.Graphics.DrawString(labelL.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 900));
            e.Graphics.DrawString(labelM.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 925));
            e.Graphics.DrawString("ZEHRA İSBİR", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(200, 1030));
            e.Graphics.DrawString("FURKAN ARDIÇ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(400, 1030));
            e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(220, 1070));
            e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(430, 1070));
            e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(210, 1050));
            e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(420, 1050));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1100));
            e.Graphics.DrawString("AIKA LTD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(695, 1120));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1140));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 990));
        }
    }
}
