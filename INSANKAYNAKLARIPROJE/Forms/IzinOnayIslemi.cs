using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace INSANKAYNAKLARIPROJE
{
    public partial class IzinOnayIslemi : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        public IzinOnayIslemi()
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
            btnKAYDET.IdleFillColor = ThemeColor.PrimaryColor;
            btnARA.IdleFillColor = ThemeColor.PrimaryColor;

        }

        //DataGridView da kayıtları listelemek için bir method oluşturyoruz
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

        public DataGridViewCheckBoxColumn Chk;
        private void IzinGoruntule_Load(object sender, EventArgs e)
        {
            Listele();
            
            //DataGridView e CheckBox türünde kolon ekliyoruz
            Chk = new DataGridViewCheckBoxColumn(); 
            Chk.ValueType = typeof(bool);
            Chk.Name = "Chk_COLUMN";
            Chk.HeaderText = "ONAY";
            Chk.Width = 45;
           
            //Durum sütunundaki kayıtları kontrol ediyoruz
            //Eğer Onaylandı yazıyorsa CheckBox seçili olarak geliyor
            //Eğer Onaylanmadı yazıyorsa CheckBox seçili olmadan geliyor
            Chk.DataPropertyName = "DURUM";
            Chk.TrueValue = "ONAYLANDI";
            Chk.FalseValue = "ONAYLANMADI";

            bunifuDataGridView1.Columns.Insert(0, Chk);
            bunifuDataGridView1.RowHeadersVisible = false;
        }
                                   
        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        //Butona tıklandığında izin onay durumlarını CheckBoxların seçili olup olmama durumuna göre kaydediyoruz
        //CheckBox seçili ise onaylandı seçili değilse onaylanmadı olarak veritabanını güncelliyoruz
        private void btnKAYDET_Click(object sender, EventArgs e)
        {
            double TC;
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Chk_COLUMN"].FormattedValue) == true)
                {
                    // check edilmiş
                    TC = Convert.ToDouble(row.Cells["TC_COLUMN"].Value.ToString());
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("UPDATE IZIN SET DURUM = 'ONAYLANDI' WHERE TC = @P1", baglan);
                    komut.Parameters.AddWithValue("@P1", TC);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                {
                    //check edilmemiş
                    TC = Convert.ToDouble(row.Cells["TC_COLUMN"].Value.ToString());
                    baglan.Open();
                    SqlCommand komut1 = new SqlCommand("UPDATE IZIN SET DURUM = 'ONAYLANMADI' WHERE TC = @P1", baglan);
                    komut1.Parameters.AddWithValue("@P1", TC);
                    komut1.ExecuteNonQuery();
                    baglan.Close();
                }
            }

            Listele();
            MessageBox.Show("Personel izin onaylama işleminiz gerçekleşmiştir.");
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
        public static string ADI, SOYADI, DEPARTMANI,IZIN_TURU,IZIN_ADRESI;
        public static DateTime BASLANGIC_TARIHI, BITIS_TARIHI;

        //DataGridView üzerindeki herhangi bir satıra çift tıklandığında o satırdaki kayıtları görüntülemek için gereken kodları yazıyoruz
        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TC = Convert.ToDouble(bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString());
            ADI = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            SOYADI = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
            DEPARTMANI = bunifuDataGridView1.CurrentRow.Cells[4].Value.ToString();
            BASLANGIC_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[5].Value.ToString());
            BITIS_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[6].Value.ToString());
            IZIN_TURU = bunifuDataGridView1.CurrentRow.Cells[7].Value.ToString();
            IZIN_ADRESI = bunifuDataGridView1.CurrentRow.Cells[8].Value.ToString();

            IzinGoruntulePencere ızinGoruntulePencere = new IzinGoruntulePencere();
            ızinGoruntulePencere.Show();
        }
                
    }
}
