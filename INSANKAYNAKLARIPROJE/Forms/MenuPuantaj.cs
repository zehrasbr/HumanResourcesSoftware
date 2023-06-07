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
    public partial class MenuPuantaj : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        public MenuPuantaj()
        {
            InitializeComponent();
        }

        public static double TC;
        public static string AD, SOYAD;
        
        //DataGridView da kayıtları listelemek için bir method oluşturyoruz
        public void Listele()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT TC, ADI, SOYADI, TELEFON, POZISYONU, FOTOGRAF FROM PERSONEL", baglan);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "PERSONEL");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "PERSONEL";
            baglan.Close();
        }
        
        private void MenuPuantaj_Load(object sender, EventArgs e)
        {
            Listele();

            //Datagridview e resim sütunu ekliyoruz
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "imageColumn";
            imageColumn.HeaderText = "FOTOĞRAF";
            imageColumn.DataPropertyName = "FOTOGRAF";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            bunifuDataGridView1.Columns.Insert(5, imageColumn);
            bunifuDataGridView1.Columns.Remove("FOTOGRAF");
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TC = Convert.ToDouble(bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString());
            AD = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            SOYAD = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();

            PuantajGoruntulePencere puantajGoruntulePencere = new PuantajGoruntulePencere();
            puantajGoruntulePencere.Show();
        }
    }
}
