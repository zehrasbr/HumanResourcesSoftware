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
using System.Xml.Linq;

namespace INSANKAYNAKLARIPROJE
{
    public partial class PuantajGoruntulePencere : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["INSANKAYNAKLARIPROJE"].ConnectionString);

        public PuantajGoruntulePencere()
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
            label4.ForeColor = ThemeColor.SecondaryColor;
            txtTC.ForeColor = ThemeColor.PrimaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
            txtAD.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.SecondaryColor;
            txtSOYAD.ForeColor = ThemeColor.PrimaryColor;
            label11.ForeColor = ThemeColor.PrimaryColor;
            dtpTarih.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.SecondaryColor;
            cbxPUANTAJ.ForeColor = ThemeColor.PrimaryColor;
            label9.ForeColor = ThemeColor.PrimaryColor;
            txtEKMESAI.ForeColor = ThemeColor.SecondaryColor;
            label8.ForeColor = ThemeColor.SecondaryColor;
            txtNORMALMESAI.ForeColor = ThemeColor.PrimaryColor;
            label10.ForeColor = ThemeColor.PrimaryColor;
            txtACIKLAMA.ForeColor = ThemeColor.SecondaryColor;
            chkFILTRELE.ForeColor = ThemeColor.PrimaryColor;
            label1.ForeColor = ThemeColor.PrimaryColor;
            baslangic_Tarihi.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            bitis_Tarihi.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;


        }

        DataTable dt = new DataTable();

        DateTime donemPUANTAJ;
        string date, donemMUHASEBE, puantaj;
        double TC;

        double SaatNormalMESAI = 0, SaatEkMESAI = 0, AylikNormalMesaiUCRET = 0, AylikEkMesaiUCRET = 0, SaatlikNormalMesaiUCRET = 0, SaatlikEkMesaiUCRET = 0, AylikCalismaSuresi = 0, AylikNormalMesaiKesintiUCRET = 0, AylikToplamGelir = 0, AylikToplamGider = 0;

        private void btnARA_Click_1(object sender, EventArgs e)
        {

        }

        //DataGridView da kayıtları listelemek için bir method oluşturyoruz
        public void Listele()
        {
            dt.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM PUANTAJ WHERE TC = @P1", baglan);
            komut.Parameters.AddWithValue("@P1", MenuPuantaj.TC);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
            baglan.Close();
        }

        public void Hesapla()
        {
            baglan.Open();

            SqlCommand kmtMuhasebe = new SqlCommand("SELECT * FROM MUHASEBE", baglan);
            SqlDataAdapter daMuhasebe = new SqlDataAdapter(kmtMuhasebe);
            DataTable dtMuhasebe = new DataTable();
            daMuhasebe.Fill(dtMuhasebe);

            SqlCommand kmtCalismaBilgisi = new SqlCommand("SELECT * FROM SIRKET_CALISMA_BILGILERI", baglan);
            SqlDataAdapter daCalismaBilgisi = new SqlDataAdapter(kmtCalismaBilgisi);
            DataTable dtCalismaBilgisi = new DataTable();
            daCalismaBilgisi.Fill(dtCalismaBilgisi);

            baglan.Close();

            for (int i = 0; i < dtMuhasebe.Rows.Count; i++)
            {
                TC = Convert.ToDouble(dtMuhasebe.Rows[i]["TC"].ToString());

                baglan.Open();

                SqlCommand kmtPuantaj = new SqlCommand("SELECT * FROM PUANTAJ WHERE TC = @P1", baglan);
                kmtPuantaj.Parameters.AddWithValue("@P1", TC);
                SqlDataAdapter daPuantaj = new SqlDataAdapter(kmtPuantaj);
                DataTable dtPuantaj = new DataTable();
                daPuantaj.Fill(dtPuantaj);

                baglan.Close();

                for(int j = 0; j < dtPuantaj.Rows.Count; j++)
                {
                    puantaj = dtPuantaj.Rows[j]["PUANTAJ"].ToString();

                    donemPUANTAJ = Convert.ToDateTime(dtPuantaj.Rows[j]["TARIH"].ToString());
                    donemMUHASEBE = dtMuhasebe.Rows[i]["DONEM"].ToString();
                    date = donemPUANTAJ.ToString("MMMM").ToUpper() + " " + donemPUANTAJ.ToString("yyyy");

                    if(date.ToString() == donemMUHASEBE.ToString() && puantaj == "GELDİ")
                    {
                        SaatNormalMESAI += Convert.ToDouble(dtPuantaj.Rows[j]["NORMAL_MESAI"]);
                        SaatEkMESAI += Convert.ToDouble(dtPuantaj.Rows[j]["EK_MESAI"]);
                    }
                }

                //MessageBox.Show(SaatEkMESAI.ToString());

                AylikCalismaSuresi = Convert.ToDouble(dtCalismaBilgisi.Rows[0]["GUNLUKCALISMASAATI"]) * Convert.ToDouble(dtCalismaBilgisi.Rows[0]["AYLIKCALISMAGUNU"]);

                SaatlikNormalMesaiUCRET = Convert.ToDouble(dtMuhasebe.Rows[i]["MAASI"]) / AylikCalismaSuresi;
                SaatlikEkMesaiUCRET = SaatlikNormalMesaiUCRET * Convert.ToDouble(dtCalismaBilgisi.Rows[0]["EKMESAIKATSAYI"]);

                //MessageBox.Show(SaatlikNormalMesaiUCRET.ToString());

                AylikNormalMesaiUCRET = SaatlikNormalMesaiUCRET * SaatNormalMESAI;
                AylikNormalMesaiKesintiUCRET = (AylikCalismaSuresi * SaatlikNormalMesaiUCRET) - AylikNormalMesaiUCRET;
                AylikNormalMesaiKesintiUCRET = Math.Round(AylikNormalMesaiKesintiUCRET, 2);

                AylikEkMesaiUCRET = SaatlikEkMesaiUCRET * SaatEkMESAI;
                AylikEkMesaiUCRET = Math.Round(AylikEkMesaiUCRET, 2);

                baglan.Open();
                SqlCommand komut1 = new SqlCommand("UPDATE MUHASEBE SET FAZLA_MESAI = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut1.Parameters.AddWithValue("@P1", AylikEkMesaiUCRET);
                komut1.Parameters.AddWithValue("@P2", TC);
                komut1.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut1.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("UPDATE MUHASEBE SET MESAI_KESINTI = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut2.Parameters.AddWithValue("@P1", AylikNormalMesaiKesintiUCRET);
                komut2.Parameters.AddWithValue("@P2", TC);
                komut2.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut2.ExecuteNonQuery();

                baglan.Close();  

                SaatEkMESAI = 0;
                SaatNormalMESAI = 0;
            }
                       
        }

        public void Hesapla2()
        {
            baglan.Open();

            SqlCommand kmtMuhasebe2 = new SqlCommand("SELECT * FROM MUHASEBE", baglan);
            SqlDataAdapter daMuhasebe2 = new SqlDataAdapter(kmtMuhasebe2);
            DataTable dtMuhasebe2 = new DataTable();
            daMuhasebe2.Fill(dtMuhasebe2);

            baglan.Close();

            for (int i = 0; i < dtMuhasebe2.Rows.Count; i++)
            {
                TC = Convert.ToDouble(dtMuhasebe2.Rows[i]["TC"].ToString());
                donemMUHASEBE = dtMuhasebe2.Rows[i]["DONEM"].ToString();

                baglan.Open();

                AylikToplamGelir = Convert.ToDouble(dtMuhasebe2.Rows[i]["MAASI"]) + Convert.ToDouble(dtMuhasebe2.Rows[i]["PRIM"]) + Convert.ToDouble(dtMuhasebe2.Rows[i]["YOL_YARDIMI"]) + Convert.ToDouble(dtMuhasebe2.Rows[i]["YEMEK_YARDIMI"].ToString()) + Convert.ToDouble(dtMuhasebe2.Rows[i]["FAZLA_MESAI"]);
                AylikToplamGelir = Math.Round(AylikToplamGelir, 2);

                SqlCommand komut3 = new SqlCommand("UPDATE MUHASEBE SET TOPLAM_GELIR = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut3.Parameters.AddWithValue("@P1", AylikToplamGelir);
                komut3.Parameters.AddWithValue("@P2", TC);
                komut3.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut3.ExecuteNonQuery();

                AylikToplamGider = Convert.ToDouble(dtMuhasebe2.Rows[i]["MESAI_KESINTI"].ToString());
                AylikToplamGider = Math.Round(AylikToplamGider, 2);

                SqlCommand komut4 = new SqlCommand("UPDATE MUHASEBE SET TOPLAM_GIDER = @P1 WHERE TC = @P2 AND DONEM = @P3", baglan);
                komut4.Parameters.AddWithValue("@P1", AylikToplamGider);
                komut4.Parameters.AddWithValue("@P2", TC);
                komut4.Parameters.AddWithValue("@P3", donemMUHASEBE);
                komut4.ExecuteNonQuery();

                baglan.Close();
            }
        }

        public void TariheGoreListele()
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("SELECT * FROM PUANTAJ WHERE TARIH BETWEEN @P1 and @P2 AND TC = @P3", baglan);
            komut.Parameters.AddWithValue("@P1", baslangic_Tarihi.Value);
            komut.Parameters.AddWithValue("@P2", bitis_Tarihi.Value);
            komut.Parameters.AddWithValue("@P3", MenuPuantaj.TC);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "PUANTAJ");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "PUANTAJ";

            baglan.Close();
        }

        
        private void PuantajGoruntulePencere_Load(object sender, EventArgs e)
        {
            txtTC.Text = MenuPuantaj.TC.ToString();
            txtAD.Text = MenuPuantaj.AD.ToString();
            txtSOYAD.Text = MenuPuantaj.SOYAD.ToString();

            Listele();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnARA_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("SELECT * FROM PUANTAJ WHERE TARIH BETWEEN @P1 and @P2 AND TC = @P3", baglan);
            komut.Parameters.AddWithValue("@P1", baslangic_Tarihi.Value);
            komut.Parameters.AddWithValue("@P2", bitis_Tarihi.Value);
            komut.Parameters.AddWithValue("@P3", MenuPuantaj.TC);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds, "PUANTAJ");
            bunifuDataGridView1.DataSource = ds;
            bunifuDataGridView1.DataMember = "PUANTAJ";

            baglan.Close();
        }


        private void chkFILTRELE_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFILTRELE.Checked)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

        }

        private void btnEKLE_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO PUANTAJ(TARIH,TC,ADI,SOYADI,PUANTAJ,NORMAL_MESAI,EK_MESAI,ACIKLAMA) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", baglan);
            komut.Parameters.AddWithValue("@P1", Convert.ToDateTime(dtpTarih.Text));
            komut.Parameters.AddWithValue("@P2", txtTC.Text);
            komut.Parameters.AddWithValue("@P3", txtAD.Text);
            komut.Parameters.AddWithValue("@P4", txtSOYAD.Text);
            komut.Parameters.AddWithValue("@P5", cbxPUANTAJ.Text);
            komut.Parameters.AddWithValue("@P6", Convert.ToInt32(txtNORMALMESAI.Text));
            komut.Parameters.AddWithValue("@P7", Convert.ToInt32(txtEKMESAI.Text));
            komut.Parameters.AddWithValue("@P8", txtACIKLAMA.Text);
            komut.ExecuteNonQuery();
            baglan.Close();

            MessageBox.Show("Puantaj kaydı yapıldı", "İŞLEM BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
 
            Listele();

            Hesapla();
            Hesapla2();
        }
    }
}
