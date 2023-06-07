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

namespace INSANKAYNAKLARIPROJE
{
    public partial class PersonelGoruntule : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
       
        public PersonelGoruntule()
        {
            InitializeComponent();
        }

        //DataGridView da kayıtları listelemek için bir method oluşturuyoruz
        public void Listele()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM PERSONEL", baglan);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "PERSONEL");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "PERSONEL";
            baglan.Close();
        }

        // Textboxa girilen değerin sayı olup olmadığını kontrol eden bir method tanımlıyoruz
        static bool sayiMi(string deger)
        {
            try
            {
                int.Parse(deger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void PersonelGoruntule_Load(object sender, EventArgs e)
        {
            
            Listele();

            //Datagridview e resim sütunu ekliyoruz
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "imageColumn";
            imageColumn.HeaderText = "FOTOĞRAF";
            imageColumn.DataPropertyName = "FOTOGRAF";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            bunifuDataGridView1.Columns.Insert(12, imageColumn);
            bunifuDataGridView1.Columns.Remove("FOTOGRAF");
        }

        

        public static DateTime DOGUM_TARIHI, GIRIS_TARIHI, MEZUNIYET_TARIHI,  CIKIS_TARIHI, TARIH;
        public static string TC, ADI, SOYADI, CINSIYETI, MEDENI_HALI, KAN_GRUBU, EHLIYET, ASKERLIK, POZİSYONU, MAASI, EMAIL_ADRES, ADRES,  TELEFON, FOTOGRAF, OGRENIM_TIPI, OKUL_ADI, BOLUM, MEZUNIYET_ORTALAMASI, DEPARTMAN, IS_TANIMI, KURUM_ADI, SEHIR, AYRILIS_NEDENI, YABANCI_DIL, YAZMA, KONUSMA, OKUMA, SERTIFIKA_NO, SERTIFIKA_ADI;
        
        //DataGridView1 üzerine çift tıkladığımızda o satırdaki verileri global bir değişkene atıyoruz
        //Bunları personel görüntüleme penceresindeki textboxlara yazdırıyoruz
        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TC = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
            ADI = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            SOYADI = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            CINSIYETI = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
            MEDENI_HALI = bunifuDataGridView1.CurrentRow.Cells[4].Value.ToString();
            KAN_GRUBU = bunifuDataGridView1.CurrentRow.Cells[5].Value.ToString();
            DOGUM_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[6].Value.ToString());
            GIRIS_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[7].Value.ToString());
            EHLIYET = bunifuDataGridView1.CurrentRow.Cells[8].Value.ToString();
            ASKERLIK = bunifuDataGridView1.CurrentRow.Cells[9].Value.ToString();
            POZİSYONU = bunifuDataGridView1.CurrentRow.Cells[10].Value.ToString();                     
            MAASI = bunifuDataGridView1.CurrentRow.Cells[11].Value.ToString();
            FOTOGRAF = bunifuDataGridView1.CurrentRow.Cells[12].Value.ToString();
            EMAIL_ADRES = bunifuDataGridView1.CurrentRow.Cells[13].Value.ToString();
            ADRES = bunifuDataGridView1.CurrentRow.Cells[14].Value.ToString();
            TELEFON = bunifuDataGridView1.CurrentRow.Cells[15].Value.ToString();

            PersonelGoruntulePencere personelGoruntulePencere = new PersonelGoruntulePencere();
            personelGoruntulePencere.Show();

            this.Hide();
        }

        //Textboxa girilen değerin sayi olup olmadığını kontrol ederek veri tabanından arama yapıyoruz
        private void btnARA_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if (sayiMi(txtADI.Text))
            {
                SqlCommand komut1 = new SqlCommand("SELECT * FROM PERSONEL WHERE TC LIKE '%' + @P1 + '%'", baglan);
                komut1.Parameters.AddWithValue("@P1", txtADI.Text);
                DataSet ds1 = new DataSet();

                SqlDataAdapter da1 = new SqlDataAdapter(komut1);
                da1.Fill(ds1, "PERSONEL");
                bunifuDataGridView1.DataSource = ds1;
                bunifuDataGridView1.DataMember = "PERSONEL";
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("SELECT * FROM PERSONEL WHERE ADI LIKE '%' + @P1 + '%'", baglan);
                komut2.Parameters.AddWithValue("@P1", txtADI.Text);
                DataSet ds2 = new DataSet();

                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                da2.Fill(ds2, "PERSONEL");
                bunifuDataGridView1.DataSource = ds2;
                bunifuDataGridView1.DataMember = "PERSONEL";
            }
            baglan.Close();
        }

        //Textboxa girilen değerin sayi olup olmadığını kontrol ederek veri tabanından arama yapıyoruz
        private void txtADI_TextChange(object sender, EventArgs e)
        {
            baglan.Open();
            if (sayiMi(txtADI.Text))
            {
                SqlCommand komut1 = new SqlCommand("SELECT * FROM PERSONEL WHERE TC LIKE '%' + @P1 + '%'", baglan);
                komut1.Parameters.AddWithValue("@P1", txtADI.Text);
                DataSet ds1 = new DataSet();

                SqlDataAdapter da1 = new SqlDataAdapter(komut1);
                da1.Fill(ds1, "PERSONEL");
                bunifuDataGridView1.DataSource = ds1;
                bunifuDataGridView1.DataMember = "PERSONEL";
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("SELECT * FROM PERSONEL WHERE ADI LIKE '%' + @P1 + '%'", baglan);
                komut2.Parameters.AddWithValue("@P1", txtADI.Text);
                DataSet ds2 = new DataSet();

                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                da2.Fill(ds2, "PERSONEL");
                bunifuDataGridView1.DataSource = ds2;
                bunifuDataGridView1.DataMember = "PERSONEL";
            }
            baglan.Close();
        }

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
                                
    }
}
