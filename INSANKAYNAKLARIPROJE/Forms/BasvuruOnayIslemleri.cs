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

namespace INSANKAYNAKLARIPROJE
{
    public partial class BasvuruOnayIslemleri : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public BasvuruOnayIslemleri()
        {
            InitializeComponent();
        }
    

        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void Listele()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM PERSONEL_BASVURU", baglan);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "PERSONEL_BASVURU");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "PERSONEL_BASVURU";
            baglan.Close();
        }
        public DataGridViewCheckBoxColumn Chk;
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
                    SqlCommand komut = new SqlCommand("UPDATE PERSONEL_BASVURU SET DURUM = 'ONAYLANDI' WHERE TC = @P1", baglan);
                    komut.Parameters.AddWithValue("@P1", TC);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                {
                    //check edilmemiş
                    TC = Convert.ToDouble(row.Cells["TC_COLUMN"].Value.ToString());
                    baglan.Open();
                    SqlCommand komut1 = new SqlCommand("UPDATE PERSONEL_BASVURU SET DURUM = 'ONAYLANMADI' WHERE TC = @P1", baglan);
                    komut1.Parameters.AddWithValue("@P1", TC);
                    komut1.ExecuteNonQuery();
                    baglan.Close();
                }
            }

            Listele();
            MessageBox.Show("Personel başvurusu onaylanmıştır.");
        }

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

        private void BasvuruOnayIslemleri_Load(object sender, EventArgs e)
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

        private void btnSIL_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM PERSONEL_BASVURU WHERE TC=@TC", baglan);
            cmd.Parameters.AddWithValue("@TC", SqlDbType.Int).Value = Convert.ToInt32(txt_basvuranadi.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Başvuru silinmiştir.");
            baglan.Close();

            Listele();
        }
    }
}
