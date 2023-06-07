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
    public partial class BasvuruGoruntulePencere : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public BasvuruGoruntulePencere()
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
        public static double TC;
        public bool durum = false;
        private void BasvuruGoruntulePencere_Load(object sender, EventArgs e)
        {
        
            ListeleDepartman();
            TC = Convert.ToDouble(BasvurulariGoruntule.TC);
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM PERSONEL_BASVURU WHERE TC= @p1", baglan);
            komut.Parameters.AddWithValue("p1", TC);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                if (dr["CV"] != null)
                {
                    byte[] resim = new byte[0];
                    resim = (byte[])dr["CV"];
                    MemoryStream memoryStream = new MemoryStream(resim);
                    pictureBox3.Image = Image.FromStream(memoryStream);
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
            txt_TC.Text = BasvurulariGoruntule.TC.ToString();
            txt_adi.Text = BasvurulariGoruntule.ADI.ToString();
            txt_soyadi.Text = BasvurulariGoruntule.SOYADI.ToString();
            cbx_departmani.Text = BasvurulariGoruntule.DEPARTMANI.ToString();
            cbx_cinsiyeti.Text = BasvurulariGoruntule.CINSIYETI.ToString();
            cbx_medenihali.Text = BasvurulariGoruntule.MEDENI_HALI.ToString();
            cbx_kangrubu.Text = BasvurulariGoruntule.KAN_GRUBU.ToString();
            dtp_dogumtarihi.Text = BasvurulariGoruntule.DOGUM_TARIHI.ToString();
            dtp_basvurutarihi.Text = BasvurulariGoruntule.BASVURU_TARIHI.ToString();
            txt_emailadres.Text = BasvurulariGoruntule.EMAIL_ADRES.ToString();
            txt_telno.Text = BasvurulariGoruntule.TELEFON.ToString();
            txt_adres.Text = BasvurulariGoruntule.ADRES.ToString();
            cbx_askerlik.Text = BasvurulariGoruntule.ASKERLIK.ToString();
            cbx_ehliyet.Text = BasvurulariGoruntule.EHLIYET.ToString();
            pictureBox3.Text = BasvurulariGoruntule.CV.ToString();
        }

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
