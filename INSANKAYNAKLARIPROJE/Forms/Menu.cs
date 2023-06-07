using INSANKAYNAKLARIPROJE.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSANKAYNAKLARIPROJE
{
    public partial class Menu : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Menu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = String.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Hide();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        public static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)

            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //butonlara her tıkladığımızda rastgele renk ataması yapar.
        //font ayarlamasını kod üzerinden yaptık.
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif; 10pt", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel1.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif; 10pt", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //Form içerisindeki paneldesktoppane paneli içinde yeni form açılmasını sağlamak için bir method tanımlıyoruz
        private void OpenChilForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }

        //Burada butonlara tıkladığımızda yukarıdaki methodu çağırıyoruz
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChilForm(new INSANKAYNAKLARIPROJE.MenuSirketHakkında(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChilForm(new INSANKAYNAKLARIPROJE.MenuPersonel(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChilForm(new INSANKAYNAKLARIPROJE.MenuIzinYonetimi(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChilForm(new INSANKAYNAKLARIPROJE.MenuProjeToplantı(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChilForm(new INSANKAYNAKLARIPROJE.MenuPuantaj(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChilForm(new INSANKAYNAKLARIPROJE.MenuDepartmanIslemleri(), sender);
        }

        bool sidebarExpand = true;
        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        //bu kodlarda menümüze tıkladıgımızda sola doğru küçülecek ve tekrar tıkladığımızda büyüyecek
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                button11.Text = "";
                panelMenu.Width -= 10;
                if (panelMenu.Width == panelMenu.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }

            else
            {
                panelMenu.Width += 10;
                button1.Text = "ŞİRKET HAKKINDA";
                button2.Text = "PERSONEL";
                button3.Text = "İZİN YÖNETİMİ";
                button4.Text = "TAKVİM";
                button5.Text = "PUANTAJ";
                button6.Text = "DEPARTMAN İŞLEMLERİ";
                button7.Text = "BAŞVURU\nİŞLEMLERİ";
                button8.Text = "MUHASEBE\nBORDRO";
                button9.Text = "ŞİRKET BİLGİLERİ";
                button11.Text = "RAPORLAMA\nİŞLEMLERİ";
                if (panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        //menudeki tıkladıklarımız kapansın
        private void Reset()
        {
            DisableButton();
            label1.Text = "HOME";
            panel1.BackColor = Color.FromArgb(215, 192, 174);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        //paneldesktoppane in içindeki formu kapatır.
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }

        

       
        private void button7_Click(object sender, EventArgs e)
        {
            OpenChilForm(new INSANKAYNAKLARIPROJE.MenuBasvuruIslemleri(), sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChilForm(new MenuMuhasebe(), sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
           OpenChilForm(new INSANKAYNAKLARIPROJE.MenuSirketBilgileri(), sender);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } 
        //Formu küçültür

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
         //Formu genişletir
        private void btnMaximize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximize.Visible = false;
            btnRestaurar.Visible = true;
        }

        //Formu simge durumuna küçültür
        private void btnRestaurar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximize.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenChilForm(new MenuRaporlamaIslemleri(), sender);
        }
    }
}
