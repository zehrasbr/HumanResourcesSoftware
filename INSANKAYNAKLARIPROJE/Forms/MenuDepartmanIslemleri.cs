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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace INSANKAYNAKLARIPROJE
{
    public partial class MenuDepartmanIslemleri : Form
    {
        public MenuDepartmanIslemleri()
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
            txtDEPARTMAN_ID.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            txtDEPARTMAN.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            txt_ACIKLAMA.ForeColor = ThemeColor.PrimaryColor;
        }
        private void MenuDepartmanIslemleri_Load(object sender, EventArgs e)
        {
            Departmanlar.DepartmanGetir(listView1);
        }

        //Veritabanından kayıtları datareader ile okutup listview içerisine yazdırıyouz
        class Departmanlar
        {
            //yeni bir class oluşturduk
            private int _DepartmanID;
            private string _Departman;
            private string _Aciklama;

            public int DepartmanID { get => _DepartmanID; set => _DepartmanID = value; }
            public string Departman { get => _Departman; set => _Departman = value; }
            public string Aciklama { get => _Aciklama; set => _Aciklama = value; }

            public static SqlDataReader DepartmanGetir(ListView lst)
            {
                //kayıtları her seferinde temizlesin
                lst.Items.Clear();
                Veritabani.baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM DEPARTMANLAR", Veritabani.baglan);
                SqlDataReader dr = komut.ExecuteReader();
                while(dr.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = dr[0].ToString();
                    ekle.SubItems.Add(dr[1].ToString());
                    ekle.SubItems.Add(dr[2].ToString());
                    lst.Items.Add(ekle);
                }
                Veritabani.baglan.Close();
                return dr;
            }
        }

        class Veritabani
        {                                                           
            public static SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

            public static void ESG(SqlCommand cmd,string sql)
            {
                baglan.Open();
                cmd.Connection = baglan;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                baglan.Close();
            }
            
            public static DataTable Listele_Ara(DataGridView gridView,string sql)
            {
                baglan.Open();
                DataTable tbl = new DataTable();
                SqlDataAdapter adtr = new SqlDataAdapter(sql, baglan);
                adtr.Fill(tbl);
                gridView.DataSource = tbl;
                baglan.Close();
                return tbl;
            }

        }

        //Ekle butonumuzla yeni bir departman ve açıklama satırı ekliyoruz listview'a
        private void btnEKLE_Click(object sender, EventArgs e)
        {
            Departmanlar departmanlar = new Departmanlar();
            departmanlar.DepartmanID = int.Parse(txtDEPARTMAN_ID.Text);
            departmanlar.Departman = txtDEPARTMAN.Text;
            departmanlar.Aciklama = txt_ACIKLAMA.Text;
            string sorgu = "INSERT INTO DEPARTMANLAR(DEPARTMAN_ID,DEPARTMAN,ACIKLAMA) VALUES('" + departmanlar.DepartmanID + "','" + departmanlar.Departman + "','" + departmanlar.Aciklama + "')";
            SqlCommand komut = new SqlCommand();
            Veritabani.ESG(komut, sorgu);
            MessageBox.Show("İşlem başarılı.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Departmanlar.DepartmanGetir(listView1);
        }

        //Departman silme işlemi
        private void btnSIL_Click(object sender, EventArgs e)
        {
            Departmanlar departmanlar = new Departmanlar();
            departmanlar.DepartmanID = int.Parse(txtDEPARTMAN_ID.Text);
            departmanlar.Departman = txtDEPARTMAN.Text;
            departmanlar.Aciklama = txt_ACIKLAMA.Text;
            string sorgu = "DELETE FROM DEPARTMANLAR WHERE DEPARTMAN_ID = '" + departmanlar.DepartmanID + "'";
            SqlCommand komut = new SqlCommand();
            Veritabani.ESG(komut, sorgu);
            MessageBox.Show("İşlem başarılı.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Departmanlar.DepartmanGetir(listView1);
        }

        //Departman güncelleme işlemi
        private void btnGUNCELLE_Click(object sender, EventArgs e)
        {
            Departmanlar departmanlar = new Departmanlar();
            departmanlar.DepartmanID = int.Parse(txtDEPARTMAN_ID.Text);
            departmanlar.Departman = txtDEPARTMAN.Text;
            departmanlar.Aciklama = txt_ACIKLAMA.Text;
            string sorgu = "UPDATE DEPARTMANLAR SET DEPARTMAN = ' " + departmanlar.Departman + " ', ACIKLAMA = ' " + departmanlar.Aciklama + "' WHERE DEPARTMAN_ID='" + departmanlar.DepartmanID + "'";
            SqlCommand komut = new SqlCommand();
            Veritabani.ESG(komut, sorgu);
            MessageBox.Show("İşlem başarılı.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Departmanlar.DepartmanGetir(listView1);
        }
    }
}
