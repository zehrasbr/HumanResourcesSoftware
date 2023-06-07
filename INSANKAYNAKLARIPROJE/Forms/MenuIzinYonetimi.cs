using INSANKAYNAKLARIPROJE.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace INSANKAYNAKLARIPROJE
{
    public partial class MenuIzinYonetimi : Form
    {
        public MenuIzinYonetimi()
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
            label1.ForeColor = ThemeColor.PrimaryColor;
        }

        private void MenuIzinYonetimi_Load(object sender, EventArgs e)
        {

        }

        private void btnIzinEkle_Click(object sender, EventArgs e)
        {
            IzinEkle MenuIzinYonetimi = new IzinEkle();
            MenuIzinYonetimi.Show();
        }

        private void btnIzinGuncelle_Click(object sender, EventArgs e)
        {
            IzinGuncelle MenuIzinYonetimi = new IzinGuncelle();
            MenuIzinYonetimi.Show();
        }

        private void btnIzinSil_Click(object sender, EventArgs e)
        {
            IzinSil MenuIzinYonetimi = new IzinSil();
            MenuIzinYonetimi.Show();
        }

        private void btnIzinleriGoruntule_Click(object sender, EventArgs e)
        {
            IzinleriGoruntule MenuIzinYonetimi = new IzinleriGoruntule();
            MenuIzinYonetimi.Show();
        }

        private void btnIzinOnaylamaIslemleri_Click(object sender, EventArgs e)
        {
            if(Giris.Yetki == 1)
            {
                IzinOnayIslemi ızinOnayIslemi = new IzinOnayIslemi();
                ızinOnayIslemi.Show();
            }
            else
            {
                MessageBox.Show("Bu pencereyi sadece 'Yönetici'ler görebilir. Pencereyi açmak için lütfen 'Yönetici' hesabınızla giriş yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
    }
}
