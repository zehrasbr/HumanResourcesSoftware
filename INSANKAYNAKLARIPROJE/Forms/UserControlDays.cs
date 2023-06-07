using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace INSANKAYNAKLARIPROJE
{
    public partial class UserControlDays : UserControl
    {
        public static string static_day;

        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public UserControlDays()
        {
            InitializeComponent();
        }
        //Veritabanından kayıtları okuyoruz eğer kayıt varsa labela yazdırıyoruz
        private void displayEvent()
        {
            if (baglan.State == ConnectionState.Closed)
            {
                baglan.Open();
            }

            SqlCommand komut = new SqlCommand("SELECT * FROM TAKVIM_TOPLANTI WHERE DATE = @p1", baglan);
            komut.Parameters.AddWithValue("@p1", lbdays.Text + "/" + TakvimToplantiTarihler.static_month + "/" + TakvimToplantiTarihler.static_year);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                lblEvent.Text = reader["EVENT"].ToString();
            }
            reader.Dispose();
            komut.Dispose();
            baglan.Close();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            displayEvent();
        }

        public void days(int numday)
        {
            lbdays.Text = numday + " ";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            //usercontroldays tıklanırsa zamanlayıcıyı başlatır. 
            timer1.Start();
            TakvimToplantiEkleme takvimToplantiEkleme = new TakvimToplantiEkleme();
            takvimToplantiEkleme.Show();
        }

        //yeni olay eklenirse otomatik görüntüleme olayı için bir zamanlayıcı oluşturuyoruz
        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }

        
    }
}
