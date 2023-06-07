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
    public partial class IsIlanlariniGoruntule : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public IsIlanlariniGoruntule()
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
            txt_ilannumarasi.ForeColor = ThemeColor.SecondaryColor;
            btnARA.IdleFillColor = ThemeColor.PrimaryColor;
            btnSIL.IdleFillColor = ThemeColor.PrimaryColor;
            btnSIL.ForeColor = ThemeColor.SecondaryColor;
            //bunifuDataGridView1. = ThemeColor.SecondaryColor;
        }

        //DataGridView da kayıtları listelemek için bir method oluşturyoruz
        public void Listele()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ILAN", baglan);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "ILAN");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "ILAN";
            baglan.Close();
        }

        private void IsIlanlariniGoruntule_Load(object sender, EventArgs e)
        {
            Listele();
        }


        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       
        private void btnSIL_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ILAN WHERE ILAN_NUMARASI=@ILAN_NUMARASI", baglan);
            cmd.Parameters.AddWithValue("@ILAN_NUMARASI", SqlDbType.Int).Value = Convert.ToInt32(txt_ilannumarasi.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("İş ilanı silinmiştir.");
            baglan.Close();

            Listele();
        }

        public static DateTime ILAN_TARIHI;
        public static double ILAN_NUMARASI;
        public static string SIRKET_ADI, ARANILAN_POZISYON, DIL_BILGISI, PERSONEL_OZELLIKLERI, IS_TANIMI;

        private void txt_ilannumarasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            //bunifuDataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            //bunifuDataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Blue;
        }

        private void btnARA_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ILAN WHERE ILAN_NUMARASI LIKE '%' + @ILAN_NUMARASI + '%'", baglan);
            komut.Parameters.AddWithValue("@ILAN_NUMARASI", Convert.ToInt32(txt_ilannumarasi.Text));
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "ILAN");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "ILAN";
            baglan.Close();
        }

        //DatagridView üzerine çift tıklandığında
        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ILAN_NUMARASI = Convert.ToDouble(bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString());
            SIRKET_ADI = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            ARANILAN_POZISYON = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            DIL_BILGISI = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
            PERSONEL_OZELLIKLERI = bunifuDataGridView1.CurrentRow.Cells[4].Value.ToString();
            ILAN_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[5].Value.ToString());
            IS_TANIMI = bunifuDataGridView1.CurrentRow.Cells[6].Value.ToString();

            IsIlaniPencere ısIlaniPencere = new IsIlaniPencere();
            ısIlaniPencere.Show();
        }
                       
    }
}
