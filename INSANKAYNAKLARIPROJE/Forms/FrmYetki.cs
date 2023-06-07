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
    public partial class FrmYetki : Form
    {
        public FrmYetki()
        {
            InitializeComponent();
        }

        private void Yetki_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bu pencereyi sadece 'Yönetici'ler görebilir. Pencereyi açmak için lütfen 'Yönetici' hesabınızla giriş yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
