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
    public partial class IzinleriGoruntule : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public IzinleriGoruntule()
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
            label1.ForeColor = ThemeColor.SecondaryColor;
            txtADI.ForeColor = ThemeColor.PrimaryColor;
            btnARA.IdleFillColor = ThemeColor.PrimaryColor;

        }
        public void Listele()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM IZIN", baglan);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "IZIN");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "IZIN";
            baglan.Close();
        }


        // Textboxa girilen değerin sayı olup olmadığını kontrol eden bir method tanımlıyoruz
        static bool sayiMi(string deger)
        {
            try
            {
                int.Parse(deger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void IzinleriGoruntule_Load(object sender, EventArgs e)
        {
            Listele();
        }

        //Textboxa girilen değerin sayi olup olmadığını kontrol ederek veri tabanından arama yapıyoruz
        private void btnARA_Click(object sender, EventArgs e)
        {
            if (sayiMi(txtADI.Text))
            {
                SqlCommand komut1 = new SqlCommand("SELECT * FROM IZIN WHERE TC LIKE '%' + @P1 + '%'", baglan);
                komut1.Parameters.AddWithValue("@P1", txtADI.Text);
                DataSet ds1 = new DataSet();

                SqlDataAdapter da1 = new SqlDataAdapter(komut1);
                da1.Fill(ds1, "IZIN");
                bunifuDataGridView1.DataSource = ds1;
                bunifuDataGridView1.DataMember = "IZIN";
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("SELECT * FROM IZIN WHERE ADI LIKE '%' + @P1 + '%'", baglan);
                komut2.Parameters.AddWithValue("@P1", txtADI.Text);
                DataSet ds2 = new DataSet();

                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                da2.Fill(ds2, "IZIN");
                bunifuDataGridView1.DataSource = ds2;
                bunifuDataGridView1.DataMember = "IZIN";
            }
        }

        //Textboxa girilen değerin sayi olup olmadığını kontrol ederek veri tabanından arama yapıyoruz
        private void txtADI_TextChange(object sender, EventArgs e)
        {
            if (sayiMi(txtADI.Text))
            {
                SqlCommand komut1 = new SqlCommand("SELECT * FROM IZIN WHERE TC LIKE '%' + @P1 + '%'", baglan);
                komut1.Parameters.AddWithValue("@P1", txtADI.Text);
                DataSet ds1 = new DataSet();

                SqlDataAdapter da1 = new SqlDataAdapter(komut1);
                da1.Fill(ds1, "IZIN");
                bunifuDataGridView1.DataSource = ds1;
                bunifuDataGridView1.DataMember = "IZIN";
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("SELECT * FROM IZIN WHERE ADI LIKE '%' + @P1 + '%'", baglan);
                komut2.Parameters.AddWithValue("@P1", txtADI.Text);
                DataSet ds2 = new DataSet();

                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                da2.Fill(ds2, "IZIN");
                bunifuDataGridView1.DataSource = ds2;
                bunifuDataGridView1.DataMember = "IZIN";
            }
        }


        //DataGridViewin sütunlarındaki kayıtları okuyoruz
        //Onaylandı yazıyorsa rengini Yeşil, onaylanmadı yazıyorsa rengini Kırmızı yapıyoruz
        private void bunifuDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.Equals("ONAYLANDI"))
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (e.Value.Equals("ONAYLANMADI"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        public static double TC;
        public static string ADI, SOYADI, DEPARTMANI, IZIN_TURU, IZIN_ADRESI;
        public static DateTime BASLANGIC_TARIHI, BITIS_TARIHI;

        //DataGridView üzerindeki herhangi bir satıra çift tıklandığında o satırdaki kayıtları görüntülemek için gereken kodları yazıyoruz
        private void bunifuDataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            TC = Convert.ToDouble(bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString());
            ADI = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            SOYADI = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            DEPARTMANI = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
            BASLANGIC_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[4].Value.ToString());
            BITIS_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[5].Value.ToString());
            IZIN_TURU = bunifuDataGridView1.CurrentRow.Cells[6].Value.ToString();
            IZIN_ADRESI = bunifuDataGridView1.CurrentRow.Cells[7].Value.ToString();

            IzinGoruntulePencere2 ızinGoruntulePencere = new IzinGoruntulePencere2();
            ızinGoruntulePencere.Show();
        }

        
       

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
