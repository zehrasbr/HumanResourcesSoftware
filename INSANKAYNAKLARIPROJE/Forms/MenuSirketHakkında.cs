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

namespace INSANKAYNAKLARIPROJE
{
    public partial class MenuSirketHakkında : Form
    {
        public MenuSirketHakkında()
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
  
            label9.ForeColor = ThemeColor.SecondaryColor;
            groupBox3.ForeColor = ThemeColor.SecondaryColor;
            label11.ForeColor = ThemeColor.SecondaryColor;
            label12.ForeColor = ThemeColor.PrimaryColor;
            label13.ForeColor = ThemeColor.SecondaryColor;
        }

        private void MenuSirketHakkında_Load(object sender, EventArgs e)
        {

        }
    }
}
