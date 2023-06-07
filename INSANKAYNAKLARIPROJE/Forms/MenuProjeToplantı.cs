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
    public partial class MenuProjeToplantı : Form
    {
        public MenuProjeToplantı()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
           
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TakvimProjeTarihler takvimProjeTarihler = new TakvimProjeTarihler();
            takvimProjeTarihler.Show();
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TakvimToplantiTarihler takvimToplantiTarihler = new TakvimToplantiTarihler();
            takvimToplantiTarihler.Show();
        }

        private void MenuProjeToplantı_Load(object sender, EventArgs e)
        {

        }
    }
}
