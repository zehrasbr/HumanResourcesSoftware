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

namespace INSANKAYNAKLARIPROJE.Forms
{
    public partial class TakvimProjeEkleme : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public TakvimProjeEkleme()
        {
            InitializeComponent();
        }
       
        private void TakvimProjeEkleme_Load(object sender, EventArgs e)
        {
            //bildirdiğimiz statik değişkenleri çağıralım
            txdate.Text =  UserControlDays2.static_day + "/" + TakvimProjeTarihler.static_month + "/" + TakvimProjeTarihler.static_year;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm:ss";
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            
            DateTime projetarih = Convert.ToDateTime(txdate.Text);
            
            
            baglan.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TAKVIM_PROJE(DATE,EVENT,ZAMAN) VALUES(@P1,@P2,@P3)", baglan);
            cmd.Parameters.AddWithValue("@P1", txdate.Text);
            cmd.Parameters.AddWithValue("@P2", txtprojeler.Text);
            cmd.Parameters.AddWithValue("@P3", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Proje Kaydedilmiştir.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            cmd.Dispose();
            baglan.Close();

            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void chkHatirlat_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkHatirlat.Checked)
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
