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
    public partial class MuhasebeOdemeYap : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        public MuhasebeOdemeYap()
        {
            InitializeComponent();
        }

        
        string donemMUHASEBE;
        double TC;

        string DONEM, ADI, SOYADI;

        double AylikToplamGelir = 0, AylikToplamGider = 0, OdenenTutar = 0, KalanTutar = 0;


        private void btnCIKIS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void Hesapla3()
        {
            baglan.Open();

            SqlCommand kmtMuhasebe3 = new SqlCommand("SELECT * FROM MUHASEBE", baglan);
            SqlDataAdapter daMuhasebe3 = new SqlDataAdapter(kmtMuhasebe3);
            DataTable dtMuhasebe3 = new DataTable();
            daMuhasebe3.Fill(dtMuhasebe3);

            baglan.Close();

            for (int i = 0; i < dtMuhasebe3.Rows.Count; i++)
            {
                TC = Convert.ToDouble(dtMuhasebe3.Rows[i]["TC"].ToString());
                donemMUHASEBE = dtMuhasebe3.Rows[i]["DONEM"].ToString();

                AylikToplamGelir = Convert.ToDouble(dtMuhasebe3.Rows[i]["TOPLAM_GELIR"].ToString());
                AylikToplamGider = Convert.ToDouble(dtMuhasebe3.Rows[i]["TOPLAM_GIDER"].ToString());
                
                OdenenTutar = Convert.ToDouble(dtMuhasebe3.Rows[i]["ODENEN"].ToString());

                KalanTutar = AylikToplamGelir - AylikToplamGider;
                KalanTutar -= OdenenTutar;

                baglan.Open();

                SqlCommand komut = new SqlCommand("UPDATE MUHASEBE SET KALAN = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut.Parameters.AddWithValue("@P1", KalanTutar);
                komut.Parameters.AddWithValue("@P2", TC);
                komut.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut.ExecuteNonQuery();

                baglan.Close();
            }
        }
        public void Listele()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM MUHASEBE_ODEMELER WHERE TC = @P1 ", baglan);
            komut.Parameters.AddWithValue("@P1", Convert.ToDouble(txtTC.Text));
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "MUHASEBE_ODEMELER");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "MUHASEBE_ODEMELER";
            baglan.Close();
        }

        private void MuhasebeOdemeYap_Load(object sender, EventArgs e)
        {
            txtTC.Text = MuhasebeGörüntüle.TC.ToString();
            txtAD.Text = MuhasebeGörüntüle.ADI.ToString().ToString();
            txtSOYAD.Text = MuhasebeGörüntüle.SOYADI.ToString();
            dtpDonem.Text = MuhasebeGörüntüle.DONEM.ToString();

            Listele();
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("UPDATE MUHASEBE SET ODENEN += @P2 WHERE TC = @P1 AND DONEM = @P3", baglan);
            komut.Parameters.AddWithValue("@P1", Convert.ToDouble(txtTC.Text));
            komut.Parameters.AddWithValue("@P2", Convert.ToInt32(txtTutar.Text));
            komut.Parameters.AddWithValue("@P3", dtpDonem.Text);
            komut.ExecuteNonQuery();

            SqlCommand komut1 = new SqlCommand("INSERT INTO MUHASEBE_ODEMELER(TC,AD,SOYAD,ODEME_TURU,ODENEN_TARIH,ODEME_DONEMI,TUTAR) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7)", baglan);
            komut1.Parameters.AddWithValue("@P1", txtTC.Text);
            komut1.Parameters.AddWithValue("@P2", txtAD.Text);
            komut1.Parameters.AddWithValue("@P3", txtSOYAD.Text);
            komut1.Parameters.AddWithValue("@P4", txtOdemeTuru.Text);
            komut1.Parameters.AddWithValue("@P5", Convert.ToDateTime(dtpTarih.Text));
            komut1.Parameters.AddWithValue("@P6", dtpDonem.Text.ToString());
            komut1.Parameters.AddWithValue("@P7", Convert.ToDouble(txtTutar.Text));
            komut1.ExecuteNonQuery();

            baglan.Close();

            Hesapla3();

            MessageBox.Show("ODEME YAPILDI.", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            Listele();
        }

    }
}
