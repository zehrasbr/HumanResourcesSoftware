using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using INSANKAYNAKLARIPROJE.Forms;
using System.Configuration;

namespace INSANKAYNAKLARIPROJE
{
    public partial class TakvimToplantiEkleme : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public TakvimToplantiEkleme()
        {
            InitializeComponent();
        }
        
        private void TakvimToplantiEkleme_Load(object sender, EventArgs e)
        {
            txdate.Text = UserControlDays.static_day + "/" + TakvimToplantiTarihler.static_month + "/" + TakvimToplantiTarihler.static_year;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //DateTime simditarih = DateTime.Now;
            DateTime projetarih = Convert.ToDateTime(txdate.Text);

            //TimeSpan ts = projetarih - simditarih;

            baglan.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TAKVIM_TOPLANTI(DATE,EVENT,ZAMAN) VALUES(@P1,@P2,@P3)", baglan);
            cmd.Parameters.AddWithValue("@P1", txdate.Text);
            cmd.Parameters.AddWithValue("@P2", txtoplantilar.Text);
            cmd.Parameters.AddWithValue("@P3", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Kaydedilmiştir.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            cmd.Dispose();
            baglan.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void chkHatirlat_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if(chkHatirlat.Checked) 
            {
                dateTimePicker1.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
            }
        }
    }
}
