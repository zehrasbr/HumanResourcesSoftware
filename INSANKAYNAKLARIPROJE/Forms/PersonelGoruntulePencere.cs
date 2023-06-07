using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace INSANKAYNAKLARIPROJE
{
    public partial class PersonelGoruntulePencere : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        public PersonelGoruntulePencere()
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
            txt_TC.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            txt_adi.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            txt_soyadi.ForeColor = ThemeColor.PrimaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            cbx_cinsiyeti.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.SecondaryColor;
            cbx_medenihali.ForeColor = ThemeColor.PrimaryColor;
            label7.ForeColor = ThemeColor.PrimaryColor;
            cbx_kangrubu.ForeColor = ThemeColor.SecondaryColor;
            label8.ForeColor = ThemeColor.SecondaryColor;
            dtp_dogumtarihi.ForeColor = ThemeColor.PrimaryColor;
            label12.ForeColor = ThemeColor.PrimaryColor;
            dtp_isegiristarihi.ForeColor = ThemeColor.SecondaryColor;
            label31.ForeColor = ThemeColor.PrimaryColor;
            cbx_ehliyet.ForeColor = ThemeColor.SecondaryColor;
            label22.ForeColor = ThemeColor.SecondaryColor;
            cbx_askerlik.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            cbx_departmani.ForeColor = ThemeColor.SecondaryColor;
            label23.ForeColor = ThemeColor.SecondaryColor;
            txt_maas.ForeColor = ThemeColor.PrimaryColor;
            label9.ForeColor = ThemeColor.PrimaryColor;
            txt_emailadres.ForeColor = ThemeColor.SecondaryColor;
            label10.ForeColor = ThemeColor.SecondaryColor;
            txt_telno.ForeColor = ThemeColor.PrimaryColor;
            label11.ForeColor = ThemeColor.PrimaryColor;
            txt_adres.ForeColor = ThemeColor.SecondaryColor;
            label28.ForeColor = ThemeColor.SecondaryColor;
            cbx_ogrenimtipi.ForeColor = ThemeColor.PrimaryColor;
            label17.ForeColor = ThemeColor.PrimaryColor;
            txt_okuladi.ForeColor = ThemeColor.SecondaryColor;
            label18.ForeColor = ThemeColor.SecondaryColor;
            txt_bolum.ForeColor = ThemeColor.PrimaryColor;
            label20.ForeColor = ThemeColor.PrimaryColor;
            txt_mezuniyetnotu.ForeColor = ThemeColor.SecondaryColor;
            label19.ForeColor = ThemeColor.SecondaryColor;
            dtp_mezuniyettarihi.ForeColor = ThemeColor.PrimaryColor;
            label34.ForeColor = ThemeColor.PrimaryColor;
            txt_departmanadi.ForeColor = ThemeColor.SecondaryColor;
            label35.ForeColor = ThemeColor.SecondaryColor;
            txt_istanimi.ForeColor = ThemeColor.PrimaryColor;
            label38.ForeColor = ThemeColor.PrimaryColor;
            txt_istanimi.ForeColor = ThemeColor.SecondaryColor;
            label36.ForeColor = ThemeColor.SecondaryColor;
            txt_sehir.ForeColor = ThemeColor.PrimaryColor;
            label37.ForeColor = ThemeColor.PrimaryColor;
            txt_kurumadi.ForeColor = ThemeColor.SecondaryColor;
            label39.ForeColor = ThemeColor.SecondaryColor;
            dtp_baslangic.ForeColor = ThemeColor.PrimaryColor;
            label40.ForeColor = ThemeColor.PrimaryColor;
            dtp_bitis.ForeColor = ThemeColor.SecondaryColor;
            label27.ForeColor = ThemeColor.SecondaryColor;
            txt_yabancidil.ForeColor = ThemeColor.PrimaryColor;
            label26.ForeColor = ThemeColor.PrimaryColor;
            cbx_yazma.ForeColor = ThemeColor.SecondaryColor;
            label25.ForeColor = ThemeColor.SecondaryColor;
            cbx_konusma.ForeColor = ThemeColor.PrimaryColor;
            label24.ForeColor = ThemeColor.PrimaryColor;
            cbx_okuma.ForeColor = ThemeColor.SecondaryColor;
            label54.ForeColor = ThemeColor.SecondaryColor;
            dtp_alindigitarih.ForeColor = ThemeColor.PrimaryColor;
            label42.ForeColor = ThemeColor.PrimaryColor;
            txt_sertifikaadi.ForeColor = ThemeColor.SecondaryColor;
            label30.ForeColor = ThemeColor.SecondaryColor;
            txt_kurumadi.ForeColor = ThemeColor.PrimaryColor;
            label29.ForeColor = ThemeColor.PrimaryColor;
            txt_sertifikanumarasi.ForeColor = ThemeColor.SecondaryColor;
            label56.ForeColor = ThemeColor.SecondaryColor;
            dtp_alinantarih.ForeColor = ThemeColor.PrimaryColor;
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

        public void ListeleEgitim()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM EGITIM WHERE TC = @P1", baglan);
            komut.Parameters.AddWithValue("@P1", TC);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "EGITIM");
            gridEGITIM.DataSource = ds;
            gridEGITIM.DataMember = "EGITIM";
            baglan.Close();
        }
        public void ListeleIsTecrube()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM IS_TECRUBESI WHERE TC = @P1", baglan);
            komut.Parameters.AddWithValue("@P1", TC);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "IS_TECRUBESI");
            gridISTECRUBE.DataSource = ds;
            gridISTECRUBE.DataMember = "IS_TECRUBESI";
            baglan.Close();
        }
        public void ListeleYabancıDil()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM YABANCI_DIL WHERE TC = @P1", baglan);
            komut.Parameters.AddWithValue("@P1", TC);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "YABANCI_DIL");
            gridYABANCIDIL.DataSource = ds;
            gridYABANCIDIL.DataMember = "YABANCI_DIL";
            baglan.Close();
        }
        public void ListeleSertifika()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM SERTIFIKA WHERE TC = @P1", baglan);
            komut.Parameters.AddWithValue("@P1", TC);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "SERTIFIKA");
            gridSERTIFIKA.DataSource = ds;
            gridSERTIFIKA.DataMember = "SERTIFIKA";
            baglan.Close();
        }

        public static double TC;
        public bool durum = false;
        // Personelin TC sine göre bilgilerini görüntülüyoruz
        private void PersonelGoruntulePencere_Load(object sender, EventArgs e)
        {           

            TC = Convert.ToDouble(PersonelGoruntule.TC);
            ListeleDepartman(); 
            ListeleEgitim();
            ListeleIsTecrube();
            ListeleSertifika();
            ListeleYabancıDil();
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM PERSONEL WHERE TC= @p1", baglan);
            komut.Parameters.AddWithValue("p1", TC);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                if (dr["FOTOGRAF"] != null)
                {
                    byte[] resim = new byte[0];
                    resim = (byte[])dr["FOTOGRAF"];
                    MemoryStream memoryStream = new MemoryStream(resim);
                    btnRESIM.Image = Image.FromStream(memoryStream);
                    dr.Close();
                    komut.Dispose();
                    baglan.Close();
                    
                }
                else
                {
                    MessageBox.Show("Gösterilecek resim yok", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            baglan.Close();

            txt_TC.Text = PersonelGoruntule.TC.ToString();
            txt_adi.Text = PersonelGoruntule.ADI.ToString();
            txt_soyadi.Text = PersonelGoruntule.SOYADI.ToString();
            cbx_departmani.Text = PersonelGoruntule.POZİSYONU.ToString();
            cbx_cinsiyeti.Text = PersonelGoruntule.CINSIYETI.ToString();
            cbx_medenihali.Text = PersonelGoruntule.MEDENI_HALI.ToString();
            cbx_kangrubu.Text = PersonelGoruntule.KAN_GRUBU.ToString();
            txt_emailadres.Text = PersonelGoruntule.EMAIL_ADRES.ToString();
            txt_telno.Text = PersonelGoruntule.TELEFON.ToString();
            txt_adres.Text = PersonelGoruntule.ADRES.ToString();                    
            txt_maas.Text = PersonelGoruntule.MAASI.ToString();
            cbx_askerlik.Text = PersonelGoruntule.ASKERLIK.ToString();
            cbx_ehliyet.Text = PersonelGoruntule.EHLIYET.ToString();
            
        }                    

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Close();

            PersonelGoruntule personelGoruntule = new PersonelGoruntule();
            personelGoruntule.Show();
        }

        public string imagepath;

        //Resim seçmek için openfiledialog aracından yararlanıyoruz
        private void btnRESIM_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = " Jpeg Dosyaları(*.jpeg)|*.jpeg| Jpg Dosyaları(*.jpg)|*.jpg| Png Dosyaları(*.png)|*.png| Gif Dosyaları(*.gif)|*.gif| Tüm Dosyalar(*.jpeg;*.jpg;*.png;*.gif)|*.jpeg;*.jpg;*.png;*.gif ";
            openFileDialog1.Multiselect = false;
            openFileDialog1.FilterIndex = 5;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                btnRESIM.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName;
                durum = true;
            }
        }

        private void btnSIL_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM PERSONEL WHERE TC=@P1", baglan);
            komut.Parameters.AddWithValue("@P1", txt_TC.Text);
            komut.ExecuteNonQuery();
            baglan.Close();

            MessageBox.Show("Personel kaydı silinmiştir.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        // Farklı bir seçilip seçilmediğini kontrol ederek kayıtları güncelliyoruz
        private void btnGUNCELLE_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_emailadres.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                if(durum == true)
                {
                    FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    byte[] resim = binaryReader.ReadBytes((int)fileStream.Length);
                    binaryReader.Close();
                    fileStream.Close();

                    baglan.Open();
                    SqlCommand komut = new SqlCommand("UPDATE PERSONEL SET ADI=@p1, SOYADI=@p2, CINSIYETI=@p3, MEDENI_HALI=@p4, KAN_GRUBU=@p5, DOGUM_TARIHI=@p6, GIRIS_TARIHI = @p7, EHLIYET = @p8, ASKERLIK = @p9, POZISYONU=@p10, MAASI=@p11, FOTOGRAF=@p12, EMAIL_ADRES=@p13,  ADRES=@p14, TELEFON=@p15 WHERE TC = @p16", baglan);
                    komut.Parameters.AddWithValue("@p1", txt_adi.Text);
                    komut.Parameters.AddWithValue("@p2", txt_soyadi.Text);
                    komut.Parameters.AddWithValue("@p3", cbx_cinsiyeti.Text);
                    komut.Parameters.AddWithValue("@p4", cbx_medenihali.Text);
                    komut.Parameters.AddWithValue("@p5", cbx_kangrubu.Text);
                    komut.Parameters.AddWithValue("@p6", Convert.ToDateTime(dtp_dogumtarihi.Text));
                    komut.Parameters.AddWithValue("@p7", Convert.ToDateTime(dtp_isegiristarihi.Text));
                    komut.Parameters.AddWithValue("@p8", cbx_ehliyet.Text);
                    komut.Parameters.AddWithValue("@p9", cbx_askerlik.Text);
                    komut.Parameters.AddWithValue("@p10", cbx_departmani.Text);
                    komut.Parameters.AddWithValue("@p11", txt_maas.Text);
                    komut.Parameters.Add("@p12", SqlDbType.Image, resim.Length).Value = resim;
                    komut.Parameters.AddWithValue("@p13", txt_emailadres.Text);
                    komut.Parameters.AddWithValue("@p14", txt_adres.Text);
                    komut.Parameters.AddWithValue("@p15", txt_telno.Text);
                    komut.Parameters.AddWithValue("@p16", txt_TC.Text);

                    komut.ExecuteNonQuery();

                    baglan.Close();

                    MessageBox.Show("Personel bilgileri güncellenmiştir", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("UPDATE PERSONEL SET ADI=@p1, SOYADI=@p2, CINSIYETI=@p3, MEDENI_HALI=@p4, KAN_GRUBU=@p5, DOGUM_TARIHI=@p6, GIRIS_TARIHI = @p7, EHLIYET = @p8, ASKERLIK = @p9, POZISYONU=@p10, MAASI=@p11, EMAIL_ADRES=@p12,  ADRES=@p13, TELEFON=@p14 WHERE TC = @P15", baglan);
                    komut.Parameters.AddWithValue("@p1", txt_adi.Text);
                    komut.Parameters.AddWithValue("@p2", txt_soyadi.Text);
                    komut.Parameters.AddWithValue("@p3", cbx_cinsiyeti.Text);
                    komut.Parameters.AddWithValue("@p4", cbx_medenihali.Text);
                    komut.Parameters.AddWithValue("@p5", cbx_kangrubu.Text);
                    komut.Parameters.AddWithValue("@p6", Convert.ToDateTime(dtp_dogumtarihi.Text));
                    komut.Parameters.AddWithValue("@p7", Convert.ToDateTime(dtp_isegiristarihi.Text));
                    komut.Parameters.AddWithValue("@p8", cbx_ehliyet.Text);
                    komut.Parameters.AddWithValue("@p9", cbx_askerlik.Text);
                    komut.Parameters.AddWithValue("@p10", cbx_departmani.Text);
                    komut.Parameters.AddWithValue("@p11", txt_maas.Text);
                    komut.Parameters.AddWithValue("@p12", txt_emailadres.Text);
                    komut.Parameters.AddWithValue("@p13", txt_adres.Text);
                    komut.Parameters.AddWithValue("@p14", txt_telno.Text);
                    komut.Parameters.AddWithValue("@p15", txt_TC.Text);

                    komut.ExecuteNonQuery();

                    baglan.Close();

                    MessageBox.Show("Personel bilgileri güncellenmiştir", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                lbluyarı.Visible = true;
                txt_emailadres.BorderColorActive = Color.Red;
            }

        }

        private void print_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //string cizgi = "--------------------------------------------------------------------------------------------------------------------------------------";
            //Bitmap bm = Properties.Resources.logo1;
            //Image image = new Bitmap(bm);
            //e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(560, 300));
            //e.Graphics.DrawImage(image, 45, 45, 700,250);
            //e.Graphics.DrawString("PERSONEL BİLGİLERİ " , new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(25, 350));
            //e.Graphics.DrawString("TC Kimlik Numarası: " + txt_TC.Text, new Font("Arial",12,FontStyle.Bold),Brushes.Black, new Point(25,450));
            //e.Graphics.DrawString("Adı: " + txt_adi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 475));
            //e.Graphics.DrawString("Soyadı: " + txt_soyadi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 500));
            //e.Graphics.DrawString("Cinsiyeti: " + cbx_cinsiyeti.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 525));
            //e.Graphics.DrawString("Medeni Hali: " + cbx_medenihali.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 550));
            //e.Graphics.DrawString("Kan Grubu: " + cbx_kangrubu.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 575));
            //e.Graphics.DrawString("Ehliyet: " + cbx_ehliyet.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 450));
            //e.Graphics.DrawString("Askerlik Durumu: " + cbx_askerlik.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 475));
            //e.Graphics.DrawString("Doğum Tarihi: " + dtp_dogumtarihi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 500));
            //e.Graphics.DrawString("İşe Giriş Tarihi: " + dtp_isegiristarihi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 525));
            //e.Graphics.DrawString("Departmanı: " + txt_departmanadi.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 550));
            //e.Graphics.DrawString("Maaşı: " + txt_maas.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 575));
            //e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 380));
            //e.Graphics.DrawString(cizgi, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 320));

            int Y = 450;
            string cizgi = "--------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bm = Properties.Resources.logo1;
            Image image = new Bitmap(bm);
            e.Graphics.DrawString("Tarih: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(560, 300));
            e.Graphics.DrawImage(image, 45, 45, 700, 250);
            e.Graphics.DrawString("PERSONEL BİLGİLERİ ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(25, 350));
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM PERSONEL", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                e.Graphics.DrawString("TC Kimlik Numarası: " + dr[0].ToString(), new Font("Arial",12,FontStyle.Bold),Brushes.Black, new Point(25,Y));
                Y += 25;
            }

        }

        private void printer_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_egitimekle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO EGITIM(TC, OGRENIM_TIPI, OKUL_ADI, BOLUM, MEZUNIYET_ORTALAMASI, MEZUNIYET_TARIHI) VALUES(@P1,@P2,@P3,@P4,@P5,@P6)", baglan);
            komut.Parameters.AddWithValue("@P1", TC);
            komut.Parameters.AddWithValue("@P2", cbx_ogrenimtipi.Text);
            komut.Parameters.AddWithValue("@P3", txt_okuladi.Text);
            komut.Parameters.AddWithValue("@P4", txt_bolum.Text);
            komut.Parameters.AddWithValue("@P5", txt_mezuniyetnotu.Text);
            komut.Parameters.AddWithValue("@P6", Convert.ToDateTime(dtp_mezuniyettarihi.Text));
            komut.ExecuteNonQuery();
            baglan.Close();

            ListeleEgitim();
        }

        private void btn_istecrubesiekle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO IS_TECRUBESI(TC, DEPARTMAN, IS_TANIMI, KURUM_ADI, SEHIR, GIRIS_TARIHI, CIKIS_TARIHI, AYRILIS_NEDENI) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", baglan);
            komut.Parameters.AddWithValue("@P1", TC);
            komut.Parameters.AddWithValue("@P2", txt_departmanadi.Text);
            komut.Parameters.AddWithValue("@P3", txt_istanimi.Text);
            komut.Parameters.AddWithValue("@P4", txt_kurumadi.Text);
            komut.Parameters.AddWithValue("@P5", txt_sehir.Text);
            komut.Parameters.AddWithValue("@P6", Convert.ToDateTime(dtp_baslangic.Text));
            komut.Parameters.AddWithValue("@P7", Convert.ToDateTime(dtp_bitis.Text));
            komut.Parameters.AddWithValue("@P8", txt_ayrilisnedeni.Text);
            komut.ExecuteNonQuery();
            baglan.Close();

            ListeleIsTecrube();
        }

        private void btn_yabancidilekle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO YABANCI_DIL(TC, YABANCI_DIL, YAZMA, KONUSMA, OKUMA) VALUES(@P1,@P2,@P3,@P4,@P5)", baglan);
            komut.Parameters.AddWithValue("@P1", TC);
            komut.Parameters.AddWithValue("@P2", txt_yabancidil.Text);
            komut.Parameters.AddWithValue("@P3", cbx_yazma.Text);
            komut.Parameters.AddWithValue("@P4", cbx_konusma.Text);
            komut.Parameters.AddWithValue("@P5", cbx_okuma.Text);
            komut.ExecuteNonQuery();
            baglan.Close();

            ListeleYabancıDil();
        }

        private void btn_sertifikaekle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO SERTIFIKA(TC, SERTIFIKA_NO, SERTIFIKA_ADI, KURUM_ADI, TARIH) VALUES(@P1,@P2,@P3,@P4,@P5)", baglan);
            komut.Parameters.AddWithValue("@P1", TC);
            komut.Parameters.AddWithValue("@P2", txt_sertifikanumarasi.Text);
            komut.Parameters.AddWithValue("@P3", txt_sertifikaadi.Text);
            komut.Parameters.AddWithValue("@P4", txt_sertifikakurumadi.Text);
            komut.Parameters.AddWithValue("@P5", Convert.ToDateTime(dtp_alinantarih.Text));
            komut.ExecuteNonQuery();
            baglan.Close();

            ListeleSertifika();
        }
    }
}
