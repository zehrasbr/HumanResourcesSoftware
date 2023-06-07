using INSANKAYNAKLARIPROJE.Forms;
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
    public partial class BasvurulariGoruntule : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);
        public BasvurulariGoruntule()
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
        public static DateTime DOGUM_TARIHI, BASVURU_TARIHI;
        public static string TC, ADI, SOYADI, CINSIYETI, MEDENI_HALI, KAN_GRUBU, EHLIYET, ASKERLIK, DEPARTMANI, EMAIL_ADRES, ADRES, TELEFON, CV;

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

        private void BasvurularıGoruntule_Load(object sender, EventArgs e)
        {
            Listele();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "imageColumn";
            imageColumn.HeaderText = "CV";
            imageColumn.DataPropertyName = "CV";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            bunifuDataGridView1.Columns.Insert(12, imageColumn);
            bunifuDataGridView1.Columns.Remove("CV");
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TC = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
            ADI = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            SOYADI = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            CINSIYETI = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
            MEDENI_HALI = bunifuDataGridView1.CurrentRow.Cells[4].Value.ToString();
            KAN_GRUBU = bunifuDataGridView1.CurrentRow.Cells[5].Value.ToString();
            DOGUM_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[6].Value.ToString());
            BASVURU_TARIHI = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[7].Value.ToString());
            EHLIYET = bunifuDataGridView1.CurrentRow.Cells[8].Value.ToString();
            ASKERLIK = bunifuDataGridView1.CurrentRow.Cells[9].Value.ToString();
            DEPARTMANI = bunifuDataGridView1.CurrentRow.Cells[10].Value.ToString();
            EMAIL_ADRES = bunifuDataGridView1.CurrentRow.Cells[11].Value.ToString();
            ADRES = bunifuDataGridView1.CurrentRow.Cells[13].Value.ToString();
            TELEFON = bunifuDataGridView1.CurrentRow.Cells[14].Value.ToString();
            CV = bunifuDataGridView1.CurrentRow.Cells[14].Value.ToString();
            BasvuruGoruntulePencere basvurularıGoruntule = new BasvuruGoruntulePencere();
            basvurularıGoruntule.Show();
        }
    }
}
