using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSANKAYNAKLARIPROJE
{
    public partial class IzinSil : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public IzinSil()
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
            txt_Adi.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            txt_Soyadi.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            cbx_departmani.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            txt_adres.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
            cbx_izinturu.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.SecondaryColor;
            dtp_izinbaslangic.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
            dtp_izinbitis.ForeColor = ThemeColor.SecondaryColor;
            label9.ForeColor = ThemeColor.PrimaryColor;
            btnSIL.IdleFillColor = ThemeColor.PrimaryColor;

        }

        public void temizle()
        {
            txt_TC.Text = "";
            txt_Adi.Text = "";
            txt_Soyadi.Text = "";
            cbx_departmani.Text = "";
            txt_adres.Text = "";
            cbx_izinturu.Text = "";
            dtp_izinbaslangic.Text = "";
            dtp_izinbitis.Text = "";

            txt_TC.Enabled = false;
            txt_Adi.Enabled = false;
            txt_Soyadi.Enabled = false;
            cbx_departmani.Enabled = false;
            txt_adres.Enabled = false;
            cbx_izinturu.Enabled = false;
            dtp_izinbaslangic.Enabled = false;
            dtp_izinbitis.Enabled = false;
        }

        

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSIL_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM IZIN WHERE TC=@P1", baglan);
            komut.Parameters.AddWithValue("@P1", txt_TC.Text);
            komut.ExecuteNonQuery();
            baglan.Close();

            MessageBox.Show("Personel izin silme işleminiz gerçekleşmiştir.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            temizle();
        }
    }
}
