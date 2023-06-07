using Org.BouncyCastle.Ocsp;
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
    public partial class BasvuruGuncelle : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public BasvuruGuncelle()
        {
            InitializeComponent();
        }
        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            cbx_departmani.Text = "";
            txt_emailadres.Text = "";
            txt_adres.Text = "";
            txt_telno.Text = "";
        }
        public bool durum;

        public string imagepath;

        private void btnBASVURUGUNCELLE_Click(object sender, EventArgs e)
        {
            if (durum == true) 
            {
                FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                byte[] resim = binaryReader.ReadBytes((int)fileStream.Length);
                binaryReader.Close();
                fileStream.Close();
                baglan.Open();
                SqlCommand komut = new SqlCommand("UPDATE PERSONEL_BASVURU SET ADI=@p1, SOYADI=@p2, CINSIYETI=@p3, MEDENI_HALI=@p4, KAN_GRUBU=@p5, DOGUM_TARIHI=@p6, BASVURU_TARIHI = @p7, EHLIYET = @p8, ASKERLIK = @p9, DEPARTMANI=@p10, EMAIL_ADRES=@p11,  ADRES=@p12, TELEFON=@p13, CV=@p14 WHERE TC = @p15", baglan);
                komut.Parameters.AddWithValue("@p1", txt_adi.Text);
                komut.Parameters.AddWithValue("@p2", txt_soyadi.Text);
                komut.Parameters.AddWithValue("@p3", cbx_cinsiyeti.Text);
                komut.Parameters.AddWithValue("@p4", cbx_medenihali.Text);
                komut.Parameters.AddWithValue("@p5", cbx_kangrubu.Text);
                komut.Parameters.AddWithValue("@p6", Convert.ToDateTime(dtp_dogumtarihi.Text));
                komut.Parameters.AddWithValue("@p7", Convert.ToDateTime(dtp_basvurutarihi.Text));
                komut.Parameters.AddWithValue("@p8", cbx_ehliyet.Text);
                komut.Parameters.AddWithValue("@p9", cbx_askerlik.Text);
                komut.Parameters.AddWithValue("@p10", cbx_departmani.Text);
                komut.Parameters.AddWithValue("@p11", txt_emailadres.Text);
                komut.Parameters.AddWithValue("@p12", txt_adres.Text);
                komut.Parameters.AddWithValue("@p13", txt_telno.Text);
                komut.Parameters.Add("@p14", SqlDbType.Image, resim.Length).Value = resim;
                komut.Parameters.AddWithValue("@p15", txt_TC.Text);

                komut.ExecuteNonQuery();

                baglan.Close();

                MessageBox.Show("Başvuru bilgileri güncellenmiştir", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                temizle(); 
            }

            else
            {
                MessageBox.Show("Fotoğraf alanı boş geçilemez", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BasvuruGuncelle_Load(object sender, EventArgs e)
        {
            ListeleDepartman();
        }

        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = " Jpeg Dosyaları(*.jpeg)|*.jpeg| Jpg Dosyaları(*.jpg)|*.jpg| Png Dosyaları(*.png)|*.png| Gif Dosyaları(*.gif)|*.gif| Tüm Dosyalar(*.jpeg;*.jpg;*.png;*.gif)|*.jpeg;*.jpg;*.png;*.gif ";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName;
                durum = true;
            }
            MessageBox.Show("CV'niz eklendi.");
            label17.Text = "CV'niz eklendi.";
            pictureBox2.Visible = true;

        }
    }
}
