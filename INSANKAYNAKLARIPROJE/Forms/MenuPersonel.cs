using INSANKAYNAKLARIPROJE.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSANKAYNAKLARIPROJE
{
    public partial class MenuPersonel : Form
    {
        public MenuPersonel()
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
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            PersonelEkle personelEkleSilGuncelle = new PersonelEkle();
            personelEkleSilGuncelle.Show();
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            PersonelGuncelle MenuPersonel = new PersonelGuncelle();
            MenuPersonel.Show();
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            PersonelSil MenuPersonel = new PersonelSil();
            MenuPersonel.Show();
        }

        private void btnPersonelGoruntule_Click(object sender, EventArgs e)
        {
            PersonelGoruntule MenuPersonel = new PersonelGoruntule();
            MenuPersonel.Show();
        }
    }
}
