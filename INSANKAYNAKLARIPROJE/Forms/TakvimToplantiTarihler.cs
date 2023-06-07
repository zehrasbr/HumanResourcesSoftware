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
using System.Globalization;

namespace INSANKAYNAKLARIPROJE
{
    public partial class TakvimToplantiTarihler : Form
    {
        int month, year;
        public static int static_month, static_year;
        public TakvimToplantiTarihler()
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

        private void TakvimToplantiTarihler_Load(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            month--;

            if (month == 0)
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
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            //günler için usercontroldays oluşturuyoruz
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            month++;

            if (month == 13)
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
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            //günler için usercontroldays oluşturuyoruz
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        public void displaDays()
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
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            //günler için usercontroldays oluşturuyoruz
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
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

