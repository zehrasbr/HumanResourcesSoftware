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
    public partial class BasvuruYap : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public BasvuruYap()
        {
            InitializeComponent();
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

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public bool durum;
        public string imagepath;
        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {
            //int size = -1;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //DialogResult result = openFileDialog1.ShowDialog(); 
            //if (result == DialogResult.OK) 
            //{
            //    string file = openFileDialog1.FileName;
            //    try
            //    {
            //        string text = File.ReadAllText(file);
            //        size = text.Length;
            //    }
            //    catch (IOException)
            //    {
            //    }
            //}

            //Console.WriteLine(size);
            //Console.WriteLine(result);
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Png Dosyaları | *.png"; // yüklenmesine izin verilecek dosya türleri
            //dialog.Multiselect = false; // kullanıcının aynı anda birden fazla dosya yüklemesine izin verir
            //if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            //{
            //    String path = openFileDialog1.FileName;
            //    using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
            //    {

            //    }
            //    MessageBox.Show("CV'niz eklendi.");
            //    label17.Text = "CV'niz eklendi.";
            //    pictureBox2.Visible = true;
            //}
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
            txt_emailadres.Clear();
            txt_adres.Text = "";
            txt_telno.Text = "";            
            label17.Text = "";
        }

        private void btnBASVURUYAP_Click(object sender, EventArgs e)
        {
            
            if (durum == true)
            {
                FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                byte[] resim = binaryReader.ReadBytes((int)fileStream.Length);
                binaryReader.Close();
                fileStream.Close();

                baglan.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO PERSONEL_BASVURU(TC,ADI,SOYADI,CINSIYETI,MEDENI_HALI,KAN_GRUBU,DOGUM_TARIHI,BASVURU_TARIHI,EHLIYET,ASKERLIK,DEPARTMANI,EMAIL_ADRES,ADRES,TELEFON,CV) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15)", baglan);
                komut.Parameters.AddWithValue("@P1", txt_TC.Text);
                komut.Parameters.AddWithValue("@P2", txt_adi.Text);
                komut.Parameters.AddWithValue("@P3", txt_soyadi.Text);
                komut.Parameters.AddWithValue("@P4", cbx_cinsiyeti.Text);
                komut.Parameters.AddWithValue("@P5", cbx_medenihali.Text);
                komut.Parameters.AddWithValue("@P6", cbx_kangrubu.Text);
                komut.Parameters.AddWithValue("@P7", Convert.ToDateTime(dtp_dogumtarihi.Text));
                komut.Parameters.AddWithValue("@P8", Convert.ToDateTime(dtp_basvurutarihi.Text));
                komut.Parameters.AddWithValue("@P9", cbx_ehliyet.Text);
                komut.Parameters.AddWithValue("@P10", cbx_askerlik.Text);
                komut.Parameters.AddWithValue("@P11", cbx_departmani.Text);
                komut.Parameters.AddWithValue("@P12", txt_emailadres.Text);
                komut.Parameters.AddWithValue("@P13", txt_adres.Text);
                komut.Parameters.AddWithValue("@P14", txt_telno.Text);
                komut.Parameters.Add("@p15", SqlDbType.Image, resim.Length).Value = resim;
                komut.ExecuteNonQuery();
                MessageBox.Show("Başvuru işlemi gerçekleştirilmiştir.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                temizle();
            }
        }

        private void BasvuruYap_Load(object sender, EventArgs e)
        {
            ListeleDepartman();
        }
    }
}
