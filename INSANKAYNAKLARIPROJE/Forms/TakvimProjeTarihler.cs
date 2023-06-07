using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSANKAYNAKLARIPROJE.Forms
{
    public partial class TakvimProjeTarihler : Form
    {
        int month, year;
        //ay ve yıl için başka bir forma geçirebileceğimiz statik bir değişken oluşturalım
        public static int static_month, static_year;
        public TakvimProjeTarihler()
        {
            InitializeComponent();
            LoadTheme();
            displaDays();
            
        }

        //renk temamızı ayarlıyoruz
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
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.PrimaryColor;
            lbldate.ForeColor = ThemeColor.SecondaryColor;
        }

        private void displaDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbldate.Text = monthname + " " + year;

            static_month = month;
            static_year = year;

            //ayın ilk gününü alıyoruz burada
            DateTime startofthemonth = new DateTime(year, month, 1);

            //ayın toplam gün sayısını alıyoruz 
            int days = DateTime.DaysInMonth(year, month);

            //startofthemonthu tamsayıya çeviriyoruz
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            //usercontrolblank oluşturuyoruz
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank2 ucblank = new UserControlBlank2();
                daycontainer.Controls.Add(ucblank);
            }

            //günler için usercontroldays oluşturuyoruz
            for (int i = 1; i <= days; i++)
            {
                UserControlDays2 ucdays = new UserControlDays2();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            month--;

            if(month == 0)
            {
                month = 12;
                year--;
            }

            static_month = month;
            static_year = year;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbldate.Text = monthname + " " + year;

            //ayın ilk gününü alıyoruz burada
            DateTime startofthemonth = new DateTime(year, month, 1);

            //ayın toplam gün sayısını alıyoruz 
            int days = DateTime.DaysInMonth(year, month);

            //startofthemonthu tamsayıya çeviriyoruz
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            //usercontrolblank oluşturuyoruz
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank2 ucblank = new UserControlBlank2();
                daycontainer.Controls.Add(ucblank);
            }

            //günler için usercontroldays oluşturuyoruz
            for (int i = 1; i <= days; i++)
            {
                UserControlDays2 ucdays = new UserControlDays2();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void TakvimProjeTarihler_Load(object sender, EventArgs e)
        {

        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            month++;

            if(month == 13)
            {
                year++;
                month = 1;
            }

            static_month = month;
            static_year = year;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbldate.Text = monthname + " " + year;

            //ayın ilk gününü alıyoruz burada
            DateTime startofthemonth = new DateTime(year, month, 1);

            //ayın toplam gün sayısını alıyoruz 
            int days = DateTime.DaysInMonth(year, month);

            //startofthemonthu tamsayıya çeviriyoruz
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;


            //usercontrolblank oluşturuyoruz
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank2 ucblank = new UserControlBlank2();
                daycontainer.Controls.Add(ucblank);
            }

            //günler için usercontroldays oluşturuyoruz
            for (int i = 1; i <= days; i++)
            {
                UserControlDays2 ucdays = new UserControlDays2();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

