using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace INSANKAYNAKLARIPROJE
{
    public partial class IsIlaniVer : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public IsIlaniVer()
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
            txt_ilannumarasi.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            txt_sirketadi.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            cbx_aranilanpozisyon.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            txt_dilbilgisi.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            txt_personelozellik.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
            dtp_ilantarihi.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.SecondaryColor;
            txt_istanimi.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
            btnEKLE.IdleFillColor = ThemeColor.PrimaryColor;
        }

        public void temizle()
        {
            txt_ilannumarasi.Text = "";
            txt_sirketadi.Text = "";
            cbx_aranilanpozisyon.Text = "";
            txt_dilbilgisi.Text = "";
            txt_personelozellik.Text = "";
            dtp_ilantarihi.Text = "";
            txt_istanimi.Text = "";

            txt_ilannumarasi.Enabled = false;
            txt_sirketadi.Enabled = false;
            cbx_aranilanpozisyon.Enabled = false;
            txt_dilbilgisi.Enabled = false;
            txt_personelozellik.Enabled = false;
            dtp_ilantarihi.Enabled = false;
            txt_istanimi.Enabled = false;
        }
        public void ListeleDepartman()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT DEPARTMAN FROM DEPARTMANLAR", baglan);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                cbx_aranilanpozisyon.Items.Add(reader.GetString(0));
            }
            baglan.Close();
        }
        private void btnEKLE_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO ILAN(ILAN_NUMARASI,SIRKET_ADI,ARANILAN_POZISYON,DIL_BILGISI,PERSONEL_OZELLIKLERI,ILAN_TARIHI,IS_TANIMI) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7)", baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@P1", txt_ilannumarasi.Text);
            komut.Parameters.AddWithValue("@P2", txt_sirketadi.Text);
            komut.Parameters.AddWithValue("@P3", cbx_aranilanpozisyon.Text);
            komut.Parameters.AddWithValue("@P4", txt_dilbilgisi.Text);
            komut.Parameters.AddWithValue("@P5", txt_personelozellik.Text);
            komut.Parameters.AddWithValue("@P6", Convert.ToDateTime(dtp_ilantarihi.Text));
            komut.Parameters.AddWithValue("@P7", txt_istanimi.Text);
      
            komut.ExecuteNonQuery();
            baglan.Close();

            MessageBox.Show("İş ilanı verilmiştir.", "İŞLEM BAŞARILI",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

            temizle();
        }

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void IsIlaniVer_Load(object sender, EventArgs e)
        {
            ListeleDepartman();
        }
    }
}
