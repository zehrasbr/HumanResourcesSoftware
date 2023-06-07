using Bunifu.UI.WinForms;
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

namespace INSANKAYNAKLARIPROJE.Forms
{
    public partial class PersonelEkle : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public PersonelEkle()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
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
            label42.ForeColor = ThemeColor.PrimaryColor;
            txt_sertifikaadi.ForeColor = ThemeColor.SecondaryColor;
            label30.ForeColor = ThemeColor.SecondaryColor;
            txt_kurumadi.ForeColor = ThemeColor.PrimaryColor;
            label29.ForeColor = ThemeColor.PrimaryColor;
            txt_sertifikanumarasi.ForeColor = ThemeColor.SecondaryColor;
            label56.ForeColor = ThemeColor.SecondaryColor;
            dtp_alinantarih.ForeColor = ThemeColor.PrimaryColor;

        }
        public void temizle()
        {
            txt_TC.Text = "";
            txt_adi.Text = "";
            txt_soyadi.Text = "";
            cbx_departmani.Text = "";
            cbx_cinsiyeti.Text = "";
            cbx_medenihali.Text = "";
            cbx_kangrubu.Text = "";
            dtp_dogumtarihi.Text = "";
            cbx_ehliyet.Text = "";
            cbx_askerlik.Text = "";            
            txt_maas.Text = "";
            txt_emailadres.Clear();
            txt_adres.Text = "";
            txt_telno.Text = "";
            btnRESIM.Image = INSANKAYNAKLARIPROJE.Properties.Resources.add_image;
        }

        public void ListeleDepartman()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT DEPARTMAN FROM DEPARTMANLAR", baglan);
            SqlDataReader reader = komut.ExecuteReader();
            while(reader.Read())
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


        public bool durum;
        public string imagepath;

        public static double TC;

        private void txt_emailadres_Enter(object sender, EventArgs e)
        {
            if (txt_emailadres.Text == "Email adres giriniz")
            {
                txt_emailadres.Text = "";
                txt_emailadres.ForeColor = Color.Black;
            }
        }

        private void txt_emailadres_Leave(object sender, EventArgs e)
        {
            if (txt_emailadres.Text == "")
            {
                txt_emailadres.Text = "Email adres giriniz";
                txt_emailadres.ForeColor = Color.LightGray;
            }
        }

        private void btnEKLE_Click(object sender, EventArgs e)
        {
            TC = Convert.ToDouble(txt_TC.Text);
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_emailadres.Text,@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                if (durum == true)
                {
                    FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    byte[] resim = binaryReader.ReadBytes((int)fileStream.Length);
                    binaryReader.Close();
                    fileStream.Close();

                    baglan.Open();
                    SqlCommand komut = new SqlCommand("INSERT INTO PERSONEL(TC,ADI,SOYADI,CINSIYETI,MEDENI_HALI,KAN_GRUBU,DOGUM_TARIHI,GIRIS_TARIHI,EHLIYET,ASKERLIK,POZISYONU,MAASI,FOTOGRAF,EMAIL_ADRES,ADRES,TELEFON) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16)", baglan);
                    komut.Parameters.AddWithValue("@P1", txt_TC.Text);
                    komut.Parameters.AddWithValue("@P2", txt_adi.Text);
                    komut.Parameters.AddWithValue("@P3", txt_soyadi.Text);
                    komut.Parameters.AddWithValue("@P4", cbx_cinsiyeti.Text);
                    komut.Parameters.AddWithValue("@P5", cbx_medenihali.Text);
                    komut.Parameters.AddWithValue("@P6", cbx_kangrubu.Text);
                    komut.Parameters.AddWithValue("@P7", Convert.ToDateTime(dtp_dogumtarihi.Text));
                    komut.Parameters.AddWithValue("@P8", Convert.ToDateTime(dtp_isegiristarihi.Text));
                    komut.Parameters.AddWithValue("@P9", cbx_ehliyet.Text);
                    komut.Parameters.AddWithValue("@P10", cbx_askerlik.Text);
                    komut.Parameters.AddWithValue("@P11", cbx_departmani.Text);
                    komut.Parameters.AddWithValue("@P12", txt_maas.Text);
                    komut.Parameters.Add("@p13", SqlDbType.Image, resim.Length).Value = resim;
                    komut.Parameters.AddWithValue("@P14", txt_emailadres.Text);
                    komut.Parameters.AddWithValue("@P15", txt_adres.Text);
                    komut.Parameters.AddWithValue("@P16", txt_telno.Text);

                    komut.ExecuteNonQuery();
                    baglan.Close();

                    MessageBox.Show("Personel kaydı gerçekleştirilmiştir.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    temizle();

                    ListeleEgitim();
                    ListeleIsTecrube();
                    ListeleYabancıDil();
                    ListeleSertifika();
                    
                }
                else
                {
                    MessageBox.Show("Fotoğraf alanı boş geçilemez", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                lbluyarı.Visible = true;
                txt_emailadres.BorderColorActive = Color.Red;
            }
            
        }

        //Resim seçmek için openfiledialog aracından yararlanıyoruz
        private void btnRESIM_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = " Jpeg Dosyaları(*.jpeg)|*.jpeg| Jpg Dosyaları(*.jpg)|*.jpg| Png Dosyaları(*.png)|*.png| Gif Dosyaları(*.gif)|*.gif| Tüm Dosyalar(*.jpeg;*.jpg;*.png;*.gif)|*.jpeg;*.jpg;*.png;*.gif ";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                btnRESIM.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName;
                durum = true;
            }
        }

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PersonelEkle_Load(object sender, EventArgs e)
        {
            ListeleDepartman();
           
        }

        // E-posta nın doğru girilip girilnediğini kontrol ediyoruz
        private void txt_emailadres_TextChange(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_emailadres.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txt_emailadres.BorderColorIdle = Color.Silver;
                txt_emailadres.BorderColorActive = Color.DodgerBlue;
                lbluyarı.Visible = false;
            }
            else
            {
                txt_emailadres.BorderColorActive = Color.Red;                
            }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
