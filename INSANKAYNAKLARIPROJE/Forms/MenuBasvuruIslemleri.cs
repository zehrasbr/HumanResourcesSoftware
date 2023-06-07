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
    public partial class MenuBasvuruIslemleri : Form
    {
        public MenuBasvuruIslemleri()
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
            label2.ForeColor = ThemeColor.SecondaryColor;
        }

        private void btnBasvuruSil_Click(object sender, EventArgs e)
        {
            //BasvuruSil MenuBasvuruIslemleri = new BasvuruSil();
            //MenuBasvuruIslemleri.Show();
        }

        private void btnBasvuruGuncelleme_Click(object sender, EventArgs e)
        {
            BasvuruYap MenuBasvuruIslemleri = new BasvuruYap();
            MenuBasvuruIslemleri.Show();
        }

        private void btnOnayIslemleri_Click(object sender, EventArgs e)
        {
            if(Giris.Yetki == 1)
            {
                BasvuruOnayIslemleri MenuBasvuruIslemleri = new BasvuruOnayIslemleri();
                MenuBasvuruIslemleri.Show();
            }
            else
            {
                MessageBox.Show("Bu pencereyi sadece 'Yönetici'ler görebilir. Pencereyi açmak için lütfen 'Yönetici' hesabınızla giriş yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnBasvurulariGoruntule_Click(object sender, EventArgs e)
        {
            BasvurulariGoruntule MenuBasvuruIslemleri = new BasvurulariGoruntule();
            MenuBasvuruIslemleri.Show();
        }

        private void btnIsIlaniVer_Click(object sender, EventArgs e)
        {
            IsIlaniVer MenuBasvuruIslemleri = new IsIlaniVer();
            MenuBasvuruIslemleri.Show();
        }

        private void MenuBasvuruIslemleri_Load(object sender, EventArgs e)
        {

        }

        private void btnIsIlanlariniGoruntule_Click(object sender, EventArgs e)
        {
            IsIlanlariniGoruntule MenuBasvuruIslemleri = new IsIlanlariniGoruntule();
            MenuBasvuruIslemleri.Show();
        }

        private void btnBasvuruGuncelle_Click(object sender, EventArgs e)
        {
            BasvuruGuncelle MenuBasvuruIslemleri = new BasvuruGuncelle();
            MenuBasvuruIslemleri.Show();
        }
    }
}
