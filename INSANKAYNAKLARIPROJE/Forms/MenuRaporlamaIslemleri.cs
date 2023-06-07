using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSANKAYNAKLARIPROJE.Forms
{
    public partial class MenuRaporlamaIslemleri : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public MenuRaporlamaIslemleri()
        {
            InitializeComponent();
        }

        DateTime donemPUANTAJ;
        string date, donemMUHASEBE, puantaj;
        public static double TC;

        public static string DONEM, ADI, SOYADI;

        double SaatNormalMESAI = 0, SaatEkMESAI = 0, AylikNormalMesaiUCRET = 0, AylikEkMesaiUCRET = 0, SaatlikNormalMesaiUCRET = 0, SaatlikEkMesaiUCRET = 0, AylikCalismaSuresi = 0, AylikNormalMesaiKesintiUCRET = 0, AylikToplamGelir = 0, AylikToplamGider = 0, KalanTutar = 0, OdenenTutar = 0;

        public void Hesapla()
        {
            baglan.Open();

            SqlCommand kmtMuhasebe = new SqlCommand("SELECT * FROM MUHASEBE", baglan);
            SqlDataAdapter daMuhasebe = new SqlDataAdapter(kmtMuhasebe);
            DataTable dtMuhasebe = new DataTable();
            daMuhasebe.Fill(dtMuhasebe);

            SqlCommand kmtCalismaBilgisi = new SqlCommand("SELECT * FROM SIRKET_CALISMA_BILGILERI", baglan);
            SqlDataAdapter daCalismaBilgisi = new SqlDataAdapter(kmtCalismaBilgisi);
            DataTable dtCalismaBilgisi = new DataTable();
            daCalismaBilgisi.Fill(dtCalismaBilgisi);

            baglan.Close();

            for (int i = 0; i < dtMuhasebe.Rows.Count; i++)
            {
                TC = Convert.ToDouble(dtMuhasebe.Rows[i]["TC"].ToString());

                baglan.Open();

                SqlCommand kmtPuantaj = new SqlCommand("SELECT * FROM PUANTAJ WHERE TC = @P1", baglan);
                kmtPuantaj.Parameters.AddWithValue("@P1", TC);
                SqlDataAdapter daPuantaj = new SqlDataAdapter(kmtPuantaj);
                DataTable dtPuantaj = new DataTable();
                daPuantaj.Fill(dtPuantaj);

                baglan.Close();

                for (int j = 0; j < dtPuantaj.Rows.Count; j++)
                {
                    puantaj = dtPuantaj.Rows[j]["PUANTAJ"].ToString();

                    donemPUANTAJ = Convert.ToDateTime(dtPuantaj.Rows[j]["TARIH"].ToString());
                    donemMUHASEBE = dtMuhasebe.Rows[i]["DONEM"].ToString();
                    date = donemPUANTAJ.ToString("MMMM").ToUpper() + " " + donemPUANTAJ.ToString("yyyy");

                    if (date.ToString() == donemMUHASEBE.ToString() && puantaj == "GELDİ")
                    {
                        SaatNormalMESAI += Convert.ToDouble(dtPuantaj.Rows[j]["NORMAL_MESAI"]);
                        SaatEkMESAI += Convert.ToDouble(dtPuantaj.Rows[j]["EK_MESAI"]);
                    }
                }

                //MessageBox.Show(SaatEkMESAI.ToString());

                AylikCalismaSuresi = Convert.ToDouble(dtCalismaBilgisi.Rows[0]["GUNLUKCALISMASAATI"]) * Convert.ToDouble(dtCalismaBilgisi.Rows[0]["AYLIKCALISMAGUNU"]);

                SaatlikNormalMesaiUCRET = Convert.ToDouble(dtMuhasebe.Rows[i]["MAASI"]) / AylikCalismaSuresi;
                SaatlikEkMesaiUCRET = SaatlikNormalMesaiUCRET * Convert.ToDouble(dtCalismaBilgisi.Rows[0]["EKMESAIKATSAYI"]);

                //MessageBox.Show(SaatlikNormalMesaiUCRET.ToString());

                AylikNormalMesaiUCRET = SaatlikNormalMesaiUCRET * SaatNormalMESAI;
                AylikNormalMesaiKesintiUCRET = (AylikCalismaSuresi * SaatlikNormalMesaiUCRET) - AylikNormalMesaiUCRET;
                AylikNormalMesaiKesintiUCRET = Math.Round(AylikNormalMesaiKesintiUCRET, 2);

                AylikEkMesaiUCRET = SaatlikEkMesaiUCRET * SaatEkMESAI;
                AylikEkMesaiUCRET = Math.Round(AylikEkMesaiUCRET, 2);

                baglan.Open();
                SqlCommand komut1 = new SqlCommand("UPDATE MUHASEBE SET FAZLA_MESAI = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut1.Parameters.AddWithValue("@P1", AylikEkMesaiUCRET);
                komut1.Parameters.AddWithValue("@P2", TC);
                komut1.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut1.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("UPDATE MUHASEBE SET MESAI_KESINTI = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut2.Parameters.AddWithValue("@P1", AylikNormalMesaiKesintiUCRET);
                komut2.Parameters.AddWithValue("@P2", TC);
                komut2.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut2.ExecuteNonQuery();

                baglan.Close();

                SaatEkMESAI = 0;
                SaatNormalMESAI = 0;
            }

        }

        public void Hesapla2()
        {
            baglan.Open();

            SqlCommand kmtMuhasebe2 = new SqlCommand("SELECT * FROM MUHASEBE", baglan);
            SqlDataAdapter daMuhasebe2 = new SqlDataAdapter(kmtMuhasebe2);
            DataTable dtMuhasebe2 = new DataTable();
            daMuhasebe2.Fill(dtMuhasebe2);

            baglan.Close();

            for (int i = 0; i < dtMuhasebe2.Rows.Count; i++)
            {
                TC = Convert.ToDouble(dtMuhasebe2.Rows[i]["TC"].ToString());
                donemMUHASEBE = dtMuhasebe2.Rows[i]["DONEM"].ToString();

                baglan.Open();

                AylikToplamGelir = Convert.ToDouble(dtMuhasebe2.Rows[i]["MAASI"]) + Convert.ToDouble(dtMuhasebe2.Rows[i]["PRIM"]) + Convert.ToDouble(dtMuhasebe2.Rows[i]["YOL_YARDIMI"]) + Convert.ToDouble(dtMuhasebe2.Rows[i]["YEMEK_YARDIMI"].ToString()) + Convert.ToDouble(dtMuhasebe2.Rows[i]["FAZLA_MESAI"]);
                AylikToplamGelir = Math.Round(AylikToplamGelir, 2);

                SqlCommand komut3 = new SqlCommand("UPDATE MUHASEBE SET TOPLAM_GELIR = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut3.Parameters.AddWithValue("@P1", AylikToplamGelir);
                komut3.Parameters.AddWithValue("@P2", TC);
                komut3.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut3.ExecuteNonQuery();

                AylikToplamGider = Convert.ToDouble(dtMuhasebe2.Rows[i]["MESAI_KESINTI"].ToString());
                AylikToplamGider = Math.Round(AylikToplamGider, 2);

                SqlCommand komut4 = new SqlCommand("UPDATE MUHASEBE SET TOPLAM_GIDER = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut4.Parameters.AddWithValue("@P1", AylikToplamGider);
                komut4.Parameters.AddWithValue("@P2", TC);
                komut4.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut4.ExecuteNonQuery();

                baglan.Close();
            }
        }

        public void Hesapla3()
        {
            baglan.Open();

            SqlCommand kmtMuhasebe3 = new SqlCommand("SELECT * FROM MUHASEBE", baglan);
            SqlDataAdapter daMuhasebe3 = new SqlDataAdapter(kmtMuhasebe3);
            DataTable dtMuhasebe3 = new DataTable();
            daMuhasebe3.Fill(dtMuhasebe3);

            baglan.Close();

            for (int i = 0; i < dtMuhasebe3.Rows.Count; i++)
            {
                TC = Convert.ToDouble(dtMuhasebe3.Rows[i]["TC"].ToString());
                donemMUHASEBE = dtMuhasebe3.Rows[i]["DONEM"].ToString();
                AylikToplamGelir = Convert.ToDouble(dtMuhasebe3.Rows[i]["TOPLAM_GELIR"].ToString());
                AylikToplamGider = Convert.ToDouble(dtMuhasebe3.Rows[i]["TOPLAM_GIDER"].ToString());
                OdenenTutar = Convert.ToDouble(dtMuhasebe3.Rows[i]["ODENEN"].ToString());

                KalanTutar = AylikToplamGelir - AylikToplamGider;
                KalanTutar -= OdenenTutar;

                baglan.Open();

                SqlCommand komut = new SqlCommand("UPDATE MUHASEBE SET KALAN = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut.Parameters.AddWithValue("@P1", KalanTutar);
                komut.Parameters.AddWithValue("@P2", TC);
                komut.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut.ExecuteNonQuery();

                baglan.Close();
            }
        }

        
        private void personelPRINT_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void puantajPDF_Click(object sender, EventArgs e)
        {
            //printDocumentPuantaj.Print();
        }

        private void puantajPRINT_Click(object sender, EventArgs e)
        {
            //printPreviewDialogPuantaj.Document = printDocumentPuantaj;
            //printPreviewDialogPuantaj.ShowDialog();
        }

        private void personelPDF_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int Y = 200;
            string cizgi = "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bm = Properties.Resources.aikaltd;
            Image image = new Bitmap(bm);
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 50));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 110));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 170));
            e.Graphics.DrawString("PERSONEL BİLGİLERİ", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(300, 75));
            e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(945, 40));
            e.Graphics.DrawImage(image, 0, 0, 300, 100);
            e.Graphics.DrawString("TC Kimlik\nNumarası ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, 135));
            e.Graphics.DrawString("Adı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(150, 140));
            e.Graphics.DrawString("Soyadı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(220, 140));
            e.Graphics.DrawString("Doğum\nTarihi", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(320, 135));
            e.Graphics.DrawString("Cinsiyeti", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(430, 140));
            e.Graphics.DrawString("Telefonu", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(530, 140));
            e.Graphics.DrawString("Mail Adresi", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(630, 140));
            e.Graphics.DrawString("Departmanı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(795, 140));
            e.Graphics.DrawString("Maaşı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1000, 140));
            e.Graphics.DrawString("İşe Giriş\nTarihi", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1080, 140));


            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM PERSONEL", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
               
                DateTime bas, bit;
                bas = Convert.ToDateTime(dr[7].ToString());
                bit = Convert.ToDateTime(dr[6].ToString());
                e.Graphics.DrawString(dr[0].ToString(), new Font("Arial", 11), Brushes.Black, new Point(25, Y));
                e.Graphics.DrawString(dr[1].ToString(), new Font("Arial", 11), Brushes.Black, new Point(143, Y));
                e.Graphics.DrawString(dr[2].ToString(), new Font("Arial", 11), Brushes.Black, new Point(220, Y));  
                e.Graphics.DrawString(bit.ToShortDateString(), new Font("Arial", 11), Brushes.Black, new Point(320, Y));
                e.Graphics.DrawString(dr[3].ToString(), new Font("Arial", 11), Brushes.Black, new Point(430, Y));
                e.Graphics.DrawString(dr[15].ToString(), new Font("Arial", 11), Brushes.Black, new Point(510, Y));
                e.Graphics.DrawString(dr[13].ToString(), new Font("Arial", 11), Brushes.Black, new Point(620, Y));
                e.Graphics.DrawString(dr[10].ToString(), new Font("Arial", 11), Brushes.Black, new Point(795, Y));
                e.Graphics.DrawString(dr[11].ToString(), new Font("Arial", 11), Brushes.Black, new Point(1000, Y));
                e.Graphics.DrawString(bas.ToShortDateString(), new Font("Arial", 11), Brushes.Black, new Point(1080, Y));
                Y += 25;
            }
            //e.Graphics.DrawString("ZEHRA İSBİR", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 700));
            //e.Graphics.DrawString("FURKAN ARDIÇ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(700, 700));
            //e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(520, 740));
            //e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(730, 740));
            //e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(510, 720));
            //e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(720, 720));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1100));
            e.Graphics.DrawString("AIKA LTD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1070, 780));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 760));
            e.Graphics.DrawString("Tel: +41 725-5555-00", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 780));
            e.Graphics.DrawString("Mail: supporting@aika.com", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, 780));
            e.Graphics.DrawString("Adres: Bahnhofstrasse 5, 3920 Zermatt, Switzerland", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, 780));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 800));
            baglan.Close();

     
        }

        private void printDocumentIzin_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int Y = 200;
            string cizgi = "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bm = Properties.Resources.aikaltd;
            Image image = new Bitmap(bm);
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 50));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 110));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 170));
            e.Graphics.DrawString("PERSONEL İZİN BİLGİLERİ", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(300, 75));
            e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(945, 40));
            e.Graphics.DrawImage(image, 0, 0, 300, 100);
            e.Graphics.DrawString("TC Kimlik\nNumarası ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, 135));
            e.Graphics.DrawString("Adı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(180, 140));
            e.Graphics.DrawString("Soyadı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, 140));
            e.Graphics.DrawString("Departmanı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(360, 140));
            e.Graphics.DrawString("İzin Türü", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(585, 140));
            e.Graphics.DrawString("Başlangıç Tarihi", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(730, 140));
            e.Graphics.DrawString("Bitiş Tarihi", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(900, 140));
            e.Graphics.DrawString("Durum", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1020, 140));

            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM IZIN", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DateTime bas, bit;
                bas = Convert.ToDateTime(dr[4].ToString());
                bit = Convert.ToDateTime(dr[5].ToString());
                e.Graphics.DrawString(dr[0].ToString(), new Font("Arial", 11), Brushes.Black, new Point(25, Y));
                e.Graphics.DrawString(dr[1].ToString(), new Font("Arial", 11), Brushes.Black, new Point(175, Y));
                e.Graphics.DrawString(dr[2].ToString(), new Font("Arial", 11), Brushes.Black, new Point(250, Y));
                e.Graphics.DrawString(bas.ToShortDateString(), new Font("Arial", 11), Brushes.Black, new Point(750, Y));
                e.Graphics.DrawString(bit.ToShortDateString(), new Font("Arial", 11), Brushes.Black, new Point(900, Y));
                e.Graphics.DrawString(dr[3].ToString(), new Font("Arial", 11), Brushes.Black, new Point(360, Y));
                e.Graphics.DrawString(dr[6].ToString(), new Font("Arial", 11), Brushes.Black, new Point(585, Y));
                e.Graphics.DrawString(dr[8].ToString(), new Font("Arial", 11), Brushes.Black, new Point(1020, Y));
                Y += 25;
            }
            e.Graphics.DrawString("ZEHRA İSBİR", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 660));
            e.Graphics.DrawString("FURKAN ARDIÇ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(700, 660));
            e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(520, 700));
            e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(730, 700));
            e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(510, 680));
            e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(720, 680));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1100));
            e.Graphics.DrawString("AIKA LTD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1070, 780));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 760));
            e.Graphics.DrawString("Tel: +41 725-5555-00", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 780));
            e.Graphics.DrawString("Mail: supporting@aika.com", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, 780));
            e.Graphics.DrawString("Adres: Bahnhofstrasse 5, 3920 Zermatt, Switzerland", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, 780));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 800));
            baglan.Close();
        }

        private void izinPRINT_Click(object sender, EventArgs e)
        {
            printPreviewDialogIzin.Document = printDocumentIzin;
            printDocumentIzin.DefaultPageSettings.Landscape = true;
            printPreviewDialogIzin.ShowDialog();
        }

        private void izinPDF_Click(object sender, EventArgs e)
        {
            printDocumentIzin.Print();
        }

        private void printDocumentPuantaj_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {



            //// Belgenin her bir sayfasını yazdır
            //for (int i = 0; i < 5; i++)
            //{
            //    int Y = 200;
            //    string cizgi = "--------------------------------------------------------------------------------------------------------------------------------------";
            //    Bitmap bm = Properties.Resources.aikaltd;
            //    Image image = new Bitmap(bm);
            //    e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 50));
            //    e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 110));
            //    e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 170));
            //    e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(560, 40));
            //    e.Graphics.DrawImage(image, 0, 0, 300, 100);
            //    e.Graphics.DrawString("Tarih ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, 140));
            //    e.Graphics.DrawString("Adı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(150, 140));
            //    e.Graphics.DrawString("Soyadı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(210, 140));
            //    e.Graphics.DrawString("Puantaj", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(280, 140));
            //    e.Graphics.DrawString("Normal Mesai", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(380, 140));
            //    e.Graphics.DrawString("Ek Mesai", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(540, 140));
            //    e.Graphics.DrawString("Açıklama", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(650, 140));


            //    baglan.Open();
            //    SqlCommand komut = new SqlCommand("SELECT * FROM PUANTAJ", baglan);
            //    SqlDataReader dr = komut.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        DateTime bas;
            //        bas = Convert.ToDateTime(dr[0].ToString());
            //        e.Graphics.DrawString(bas.ToShortDateString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, Y));
            //        e.Graphics.DrawString(dr[2].ToString(), new Font("Arial", 11), Brushes.Black, new Point(140, Y));
            //        e.Graphics.DrawString(dr[3].ToString(), new Font("Arial", 11), Brushes.Black, new Point(210, Y));
            //        e.Graphics.DrawString(dr[4].ToString(), new Font("Arial", 11), Brushes.Black, new Point(280, Y));
            //        e.Graphics.DrawString(dr[5].ToString(), new Font("Arial", 11), Brushes.Black, new Point(420, Y));
            //        e.Graphics.DrawString(dr[6].ToString(), new Font("Arial", 11), Brushes.Black, new Point(570, Y));
            //        e.Graphics.DrawString(dr[7].ToString(), new Font("Arial", 11), Brushes.Black, new Point(650, Y));
            //        Y += 25;
            //    }
            //    // Bir sonraki sayfaya geç
            //    if (i != 4)
            //        e.HasMorePages = true;
            //} 
            //baglan.Close();
            // Belgenin her bir sayfasını yazdır
            //string textToPrint = "20";
            //int pages = 20;

            //for (int i = 0; i < pages; i++)
            //{
            //    e.Graphics.DrawString(textToPrint, new Font("Arial", 12), Brushes.Black, new PointF(0, i * e.MarginBounds.Height));

            //    if (i != pages - 1)
            //    {
            //        e.HasMorePages = true;
            //    }
            //}
        }

        private void basvuruPRINT_Click(object sender, EventArgs e)
        {
            printPreviewDialogBasvuru.Document = printDocumentBasvuru;   
            printDocumentBasvuru.DefaultPageSettings.Landscape = true;
            printPreviewDialogBasvuru.ShowDialog();
         
        }

        private void basvuruPDF_Click(object sender, EventArgs e)
        {
            printDocumentBasvuru.Print();
        }


        private void MenuRaporlamaIslemleri_Load(object sender, EventArgs e)
        {

        }

        private void muhasebePDF_Click(object sender, EventArgs e)
        {
            printDocumentMuhasebe.Print();
        }

        private void printDocumentMuhasebe_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            int Y = 200;
            string cizgi = "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bm = Properties.Resources.aikaltd;
            Image image = new Bitmap(bm);
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 50));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 110));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 170));
            e.Graphics.DrawString("PERSONEL GELİR/GİDER BİLGİLERİ", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(300, 75));
            e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(945, 40));
            e.Graphics.DrawImage(image, 0, 0, 300, 100);
            e.Graphics.DrawString("Dönem", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, 135));
            e.Graphics.DrawString("Adı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(115, 140));
            e.Graphics.DrawString("Soyadı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(180, 140));
            //e.Graphics.DrawString("Departmanı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(260, 140));
            e.Graphics.DrawString("Maaşı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(260, 140));
            e.Graphics.DrawString("Avans", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(340, 140));
            e.Graphics.DrawString("Prim", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(420, 140));
            e.Graphics.DrawString("Yol\nYardımı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 135));
            e.Graphics.DrawString("Yemek\nYardımı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(580, 135));
            e.Graphics.DrawString("Fazla\nMesai", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(660, 135));
            e.Graphics.DrawString("Mesai\nKesinti", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(740, 135));
            e.Graphics.DrawString("Toplam\nGelir", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(820, 135));
            e.Graphics.DrawString("Toplam\nGider", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(900, 135));
            e.Graphics.DrawString("Ödenen", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(980, 135));
            e.Graphics.DrawString("Kalan", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1060, 135));

            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM MUHASEBE", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DateTime bas;
                bas = Convert.ToDateTime(dr[0].ToString());
                e.Graphics.DrawString(dr[2].ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(115, Y));
                e.Graphics.DrawString(dr[3].ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(180, Y));
                //e.Graphics.DrawString(dr[4].ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(260, Y));
                e.Graphics.DrawString(bas.ToShortDateString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(25, Y));
                e.Graphics.DrawString(dr[5].ToString(), new Font("Arial", 10), Brushes.Black, new Point(260, Y));
                e.Graphics.DrawString(dr[6].ToString(), new Font("Arial", 10), Brushes.Black, new Point(340, Y));
                e.Graphics.DrawString(dr[7].ToString(), new Font("Arial", 10), Brushes.Black, new Point(420, Y));
                e.Graphics.DrawString(dr[8].ToString(), new Font("Arial", 10), Brushes.Black, new Point(500, Y));
                e.Graphics.DrawString(dr[9].ToString(), new Font("Arial", 10), Brushes.Black, new Point(580, Y));
                e.Graphics.DrawString(dr[10].ToString(), new Font("Arial", 10), Brushes.Black, new Point(660, Y));
                e.Graphics.DrawString(dr[11].ToString(), new Font("Arial", 10), Brushes.Black, new Point(740, Y));
                e.Graphics.DrawString(dr[10].ToString(), new Font("Arial", 10), Brushes.Black, new Point(820, Y));
                e.Graphics.DrawString(dr[13].ToString(), new Font("Arial", 10), Brushes.Black, new Point(900, Y));
                e.Graphics.DrawString(dr[14].ToString(), new Font("Arial", 10), Brushes.Black, new Point(980, Y));
                e.Graphics.DrawString(dr[15].ToString(), new Font("Arial", 10), Brushes.Black, new Point(1040, Y));
                Y += 25;
            }
            //e.Graphics.DrawString("ZEHRA İSBİR", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 660));
            //e.Graphics.DrawString("FURKAN ARDIÇ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(700, 660));
            //e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(520, 700));
            //e.Graphics.DrawString("İMZA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(730, 700));
            //e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(510, 680));
            //e.Graphics.DrawString("YÖNETİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(720, 680));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1100));
            e.Graphics.DrawString("AIKA LTD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1070, 780));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 760));
            e.Graphics.DrawString("Tel: +41 725-5555-00", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 780));
            e.Graphics.DrawString("Mail: supporting@aika.com", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, 780));
            e.Graphics.DrawString("Adres: Bahnhofstrasse 5, 3920 Zermatt, Switzerland", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, 780));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 800));
            dr.Close();
            baglan.Close();

        }

        private void muhasebePRINT_Click(object sender, EventArgs e)
        {
            Hesapla();
            Hesapla2();
            Hesapla3();
            printPreviewDialogMuhasebe.Document = printDocumentMuhasebe;
            printDocumentMuhasebe.DefaultPageSettings.Landscape = true;
            printPreviewDialogMuhasebe.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void printDocumentBasvuru_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int Y = 200;
            string cizgi = "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bm = Properties.Resources.aikaltd;
            Image image = new Bitmap(bm);
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 50));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 110));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 170));
            e.Graphics.DrawString("BAŞVURU BİLGİLERİ", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(300, 75));
            e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(945, 40));
            e.Graphics.DrawImage(image, 0, 0, 300, 100);
            e.Graphics.DrawString("TC Kimlik\nNumarası ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, 135));
            e.Graphics.DrawString("Adı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(150, 140));
            e.Graphics.DrawString("Soyadı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(220, 140));
            e.Graphics.DrawString("Doğum\nTarihi", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(320, 135));
            e.Graphics.DrawString("Cinsiyeti", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(430, 140));
            e.Graphics.DrawString("Telefonu", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(530, 140));
            e.Graphics.DrawString("Mail Adresi", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(650, 140));
            e.Graphics.DrawString("Departmanı", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(820, 140));
            e.Graphics.DrawString("Ehliyet", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(950, 140));
            e.Graphics.DrawString("Durum", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1080, 140));


            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM PERSONEL_BASVURU", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                DateTime bit;
                bit = Convert.ToDateTime(dr[6].ToString());
                e.Graphics.DrawString(dr[0].ToString(), new Font("Arial", 11), Brushes.Black, new Point(25, Y));
                e.Graphics.DrawString(dr[1].ToString(), new Font("Arial", 11), Brushes.Black, new Point(143, Y));
                e.Graphics.DrawString(dr[2].ToString(), new Font("Arial", 11), Brushes.Black, new Point(220, Y));
                e.Graphics.DrawString(bit.ToShortDateString(), new Font("Arial", 11), Brushes.Black, new Point(320, Y));
                e.Graphics.DrawString(dr[3].ToString(), new Font("Arial", 11), Brushes.Black, new Point(430, Y));
                e.Graphics.DrawString(dr[13].ToString(), new Font("Arial", 11), Brushes.Black, new Point(510, Y));
                e.Graphics.DrawString(dr[11].ToString(), new Font("Arial", 11), Brushes.Black, new Point(640, Y));
                e.Graphics.DrawString(dr[10].ToString(), new Font("Arial", 11), Brushes.Black, new Point(820, Y));
                e.Graphics.DrawString(dr[8].ToString(), new Font("Arial", 11), Brushes.Black, new Point(960, Y));
                e.Graphics.DrawString(dr[15].ToString(), new Font("Arial", 11), Brushes.Black, new Point(1030, Y));
                Y += 25;
            }
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1100));
            e.Graphics.DrawString("AIKA LTD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(1070, 780));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 760));
            e.Graphics.DrawString("Tel: +41 725-5555-00", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 780));
            e.Graphics.DrawString("Mail: supporting@aika.com", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, 780));
            e.Graphics.DrawString("Adres: Bahnhofstrasse 5, 3920 Zermatt, Switzerland", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, 780));
            e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 800));
            dr.Close();
            baglan.Close();

        }
    }
}
