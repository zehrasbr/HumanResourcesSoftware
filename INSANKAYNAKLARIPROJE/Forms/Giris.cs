using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Win32;

namespace INSANKAYNAKLARIPROJE
{

    public partial class Giris : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        //mouse hareketi için tanımladım
        bool isThere;
        int id = 1;
        public static int Yetki;
        //public static bool durum = false;

        string ProgramAdi = "INSAN KAYNAKLARI PROJE";

        public Giris()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Minimized;

            //ShowInTaskbar = true;

            //if(durum == true)
            //{
            //    ShowInTaskbar = true;
            //    this.WindowState = FormWindowState.Normal;
            //}
            //else
            //{
            //    ShowInTaskbar = false;
            //}
        }

        //Butona tıkladığımızda veritabanından kayıtları kontrol edip giriş yapıyoruz
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string kullaniciadi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            baglan.Open();
            SqlCommand command = new SqlCommand("Select * from GIRIS", baglan);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (kullaniciadi == reader["kullanici_adi"].ToString().TrimEnd() && sifre == reader["sifre"].ToString().TrimEnd())
                {
                    Yetki =Convert.ToInt32(reader["yetki"]);
                    isThere = true;
                    break;
                }
                else
                {
                    isThere = false;
                }
            }
            baglan.Close();

            if (isThere)
            {
                MessageBox.Show("Başarıyla giriş yaptınız!", "İŞLEM BAŞARILI",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                Menu Menu = new INSANKAYNAKLARIPROJE.Menu();
                Menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Giriş yapılamadı!", "İŞLEM BAŞARISIZ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            // girişten menümüze gideriz

        }

        //tc kimlik yazısının sonradan basıldıgındaki rengi verdik
        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "TC Kimlik Numarası")
            {
                txtKullaniciAdi.Text = "";
                txtKullaniciAdi.ForeColor = Color.Black;
            }
        }

        //tc kimlik yazısının ilk görünen rengi tanımladık
        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "")
            {
                txtKullaniciAdi.Text = "TC Kimlik Numarası";
                txtKullaniciAdi.ForeColor = Color.LightGray;
            }
        }

        //şifre yazısının sonradan basıldıgındaki rengi verdik
        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
            {
                txtSifre.Text = "";
                txtSifre.ForeColor = Color.Black;
                txtSifre.PasswordChar = '*';
            }
        }

        //şifre yazısının ilk görünen rengi tanımladık
        char? none = null;
        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (txtSifre.Text == "")
            {
                txtSifre.Text = "Şifre";
                txtSifre.ForeColor = Color.LightGray;
                //şifremizin yıldız olarak görünmesini istediğimden none yaptım
                txtSifre.PasswordChar = Convert.ToChar(none);
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            //RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            //key.SetValue(ProgramAdi, "\"" + Application.ExecutablePath + "\"");

            timer1.Interval = 1000;
            timer1.Start();
        }

        // Her saniye veri tabanındaki kayıtları kontrol edip zaman uyuşuyorsa bildirim gönderiyoruz
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime simdiTarih = DateTime.Now;
            DateTime tarih;
            string aciklama;
            DateTime zaman;

            baglan.Open();

            SqlCommand komut = new SqlCommand("SELECT * FROM TAKVIM_PROJE", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                tarih = Convert.ToDateTime(dr[0].ToString());
                aciklama = dr[1].ToString();
                zaman = Convert.ToDateTime(dr[2].ToString());
                if (tarih.ToShortDateString() == simdiTarih.ToShortDateString() && zaman.ToLongTimeString() == simdiTarih.ToLongTimeString())
                {
                    notifyIcon1.ShowBalloonTip(1, tarih.ToString("d") + "  Tarihli Proje", aciklama, ToolTipIcon.Info);
                }
            }
            dr.Close();

            SqlCommand komut1 = new SqlCommand("SELECT * FROM TAKVIM_TOPLANTI", baglan);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                tarih = Convert.ToDateTime(dr1[0].ToString());
                aciklama = dr1[1].ToString();
                zaman = Convert.ToDateTime(dr1[2].ToString());
                if (tarih.ToShortDateString() == simdiTarih.ToShortDateString() && zaman.ToLongTimeString() == simdiTarih.ToLongTimeString())
                {
                    notifyIcon1.ShowBalloonTip(1, tarih.ToString("d") + "  Tarihli Toplantı", aciklama, ToolTipIcon.Info);
                }
            }
            dr1.Close();

            baglan.Close();

        }
        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
