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
    public partial class UserControlDays2 : UserControl
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        public static string static_day;
        public UserControlDays2()
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

            SqlCommand komut = new SqlCommand("SELECT * FROM TAKVIM_PROJE WHERE DATE = @p1", baglan);
            komut.Parameters.AddWithValue("@p1", lbdays.Text + "/" + TakvimProjeTarihler.static_month + "/" + TakvimProjeTarihler.static_year);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                lblEvent.Text = reader["EVENT"].ToString();
            }
            reader.Dispose();
            komut.Dispose();
            baglan.Close();
        }

        private void UserControlDays2_Load(object sender, EventArgs e)
        {
            displayEvent();
        }

        public void days(int numday)
        {
            lbdays.Text = numday + " ";
        }

        private void UserControlDays2_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            //usercontroldays tıklanırsa zamanlayıcıyı başlatır. 
            timer2.Start();

            TakvimProjeEkleme takvimProjeEkleme = new TakvimProjeEkleme();
            takvimProjeEkleme.Show();
        }

        //yeni olay eklenirse otomatik görüntüleme olayı için bir zamanlayıcı oluşturuyorz
        private void timer2_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }
    }
}
