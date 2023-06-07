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
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace INSANKAYNAKLARIPROJE.Forms
{
    public partial class MenuMuhasebe : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        public MenuMuhasebe()
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
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            txtUSD.ForeColor = ThemeColor.PrimaryColor;
            txtEUR.ForeColor = ThemeColor.SecondaryColor;
            txtGBP.ForeColor = ThemeColor.PrimaryColor;
            txtCHF.ForeColor = ThemeColor.SecondaryColor;
            txtCAD.ForeColor = ThemeColor.PrimaryColor;


        }
        public void Listele()
        {
            //baglan.Open();
            //SqlCommand komut = new SqlCommand("SELECT TC, ADI, SOYADI, POZISYONU, DOGUM_TARIHI, FOTOGRAF FROM PERSONEL", baglan);
            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(komut);
            //da.Fill(ds, "PERSONEL");
            //bunifuDataGridView1.DataSource = ds;
            //bunifuDataGridView1.DataMember = "PERSONEL";
            //baglan.Close();
        }

        //Türkiye Cumhuriyeti Merkez Bankası resmi sitesinden döviz verilerini çekiyoruz

        public void DovizGetir()
        {
            string bugünKur = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(bugünKur);

            string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            txtUSD.Text = USD;

            string EUR = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            txtEUR.Text = EUR;

            string GBP = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            txtGBP.Text = GBP;

            string CHF = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteSelling").InnerXml;
            txtCHF.Text = CHF;

            string CAD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CAD']/BanknoteSelling").InnerXml;
            txtCAD.Text = CAD;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DovizGetir();
                Listele();
            }
            catch
            {
                MessageBox.Show("Döviz verileri çekilemedi");
            }

            //Datagridview e resim sütunu ekliyoruz

            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //imageColumn.Name = "imageColumn";
            //imageColumn.HeaderText = "FOTOĞRAF";
            //imageColumn.DataPropertyName = "FOTOGRAF";
            //imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            //bunifuDataGridView1.Columns.Insert(5, imageColumn);
            //bunifuDataGridView1.Columns.Remove("FOTOGRAF");
        }

        private void btnOdemeIslemleri_Click(object sender, EventArgs e)
        {
            if(Giris.Yetki == 1)
            {
                MuhasebeOdemeYap2 muhasebeOdemeYap = new MuhasebeOdemeYap2();
                muhasebeOdemeYap.Show();
            }
            else
                MessageBox.Show("Bu pencereyi sadece 'Yönetici'ler görebilir. Pencereyi açmak için lütfen 'Yönetici' hesabınızla giriş yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnPersonelMuhasebeGoruntule_Click(object sender, EventArgs e)
        {
            if(Giris.Yetki == 1)
            {
                MuhasebeGörüntüle mUHASEBE = new MuhasebeGörüntüle();
                mUHASEBE.Show();
            }
            else
                MessageBox.Show("Bu pencereyi sadece 'Yönetici'ler görebilir. Pencereyi açmak için lütfen 'Yönetici' hesabınızla giriş yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }
    }
}
