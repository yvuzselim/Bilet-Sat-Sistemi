using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace Rezervasyon
{
    public partial class Yolcu : Form
    {
        public Yolcu()
        {
            InitializeComponent();
        }
        public string kimlik;
        SqlConnection conn = new SqlConnection(@"Data Source=YavuzExcalibur\SQLEXPRESS;Initial Catalog=YolcuBilet;Integrated Security=True");

        void SeferCek()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select (KalkisYeri+'-'+VarisYeri) AS Sefer , SeferID from Sefer", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbSefer.ValueMember = "SeferID";
            CmbSefer.DisplayMember = "Sefer";
            CmbSefer.DataSource = dt;

        }
        void KisiBilgi()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanici  where  TC=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", kimlik);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LblAd.Text = reader[1].ToString();
                LblSoyad.Text = reader[2].ToString();
                LblMail.Text = reader[6].ToString();
                LblTc.Text = reader[4].ToString();
                LblTelefon.Text = reader[3].ToString();
                label1.Text = reader[0].ToString();
                label6.Text = reader[5].ToString();

            }
            conn.Close();
        }



        private void Yolcu_Load(object sender, EventArgs e)
        {
            SeferCek();
            KisiBilgi();

            label4.Text = seferID.ToString();


        }
        public int seferID;

        private void CmbSefer_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlDataAdapter da2 = new SqlDataAdapter("Select Tarih,SeferID From Sefer Where SeferID=" + CmbSefer.SelectedValue, conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            CmbTarih.ValueMember = "SeferID";
            seferID = (int)CmbSefer.SelectedValue;
            CmbTarih.DisplayMember = "Tarih";
            CmbTarih.DataSource = dt2;
            temizle();
            KONTROL();
        }

        private void CmbTarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select Saat,SeferID From Sefer Where SeferID=" + CmbSefer.SelectedValue, conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            CmbSaat.ValueMember = "SeferID";
            CmbSaat.DisplayMember = "Saat";
            CmbSaat.DataSource = dt2;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "9";

        }

        private void Btn10_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "10";

        }

        private void Btn11_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "11";

        }

        private void Btn12_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "12";

        }

        private void Btn13_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "13";

        }

        private void Btn14_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "14";

        }

        private void Btn15_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "15";

        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Rezervasyon (SeferID, KullaniciID, KoltukNo,Cinsiyet) VALUES (@seferid, @kullanici, @koltuk,@cinsiyet)", conn);
                cmd.Parameters.AddWithValue("@seferid", seferID);
                cmd.Parameters.AddWithValue("@kullanici", label1.Text);
                cmd.Parameters.AddWithValue("@koltuk", TxtKoltuk.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", label6.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Rezervasyon İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        void KONTROL()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select KoltukNo, Cinsiyet from Rezervasyon where SeferID=@sefer", conn);
                cmd.Parameters.AddWithValue("@sefer", seferID);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int koltukNo = Convert.ToInt32(reader["KoltukNo"]);
                    int cinsiyet = Convert.ToInt32(reader["Cinsiyet"]);

                    // KoltukNo ve Cinsiyet bilgilerine göre ilgili butonun rengini ayarla voidinden çekiyorum
                    AyarlaButtonRengi(koltukNo, cinsiyet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        void temizle()
        {
            for (int i = 1; i <= 30; i++)
            {
                string buttonName = "Btn" + i;
                Control[] controls = this.Controls.Find(buttonName, true);

                if (controls.Length > 0 && controls[0] is Button)
                {
                    Button button = (Button)controls[0];
                    button.BackColor = Color.FromArgb(76, 175, 80);
                    button.Enabled = true;
                    button.Text = i.ToString();
                }
            }
        }
        private void AyarlaButtonRengi(int koltukNo, int cinsiyet)
        {
            string buttonName = "Btn" + koltukNo;


            Control[] controls = this.Controls.Find(buttonName, true);

            if (controls.Length > 0 && controls[0] is Button)
            {
                Button button = (Button)controls[0];


                if (cinsiyet == 1)
                {
                    button.BackColor = Color.RoyalBlue;
                    button.Enabled = false;
                    button.Text = "E";
                }
                else if (cinsiyet == 0)
                {
                    button.BackColor = Color.HotPink;
                    button.Enabled = false;
                    button.Text = "K";

                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            YolcuMesajlar fr = new YolcuMesajlar();
            fr.id = label1.Text;
            fr.Show();
        }

        private void LblTc_Click(object sender, EventArgs e)
        {

        }

        private void LblTelefon_Click(object sender, EventArgs e)
        {

        }

        private void LblSoyad_Click(object sender, EventArgs e)
        {

        }

        private void LblMail_Click(object sender, EventArgs e)
        {

        }

        private void LblAd_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "16";

        }

        private void Btn17_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "17";

        }

        private void Btn18_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "18";
        }

        private void Btn19_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "19";

        }

        private void Btn20_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "20";
        }

        private void Btn21_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "21";

        }

        private void Btn22_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "22";

        }

        private void Btn23_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "23";

        }

        private void Btn24_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "24";

        }

        private void Btn25_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "25";

        }

        private void Btn26_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "26";

        }

        private void Btn27_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "27";

        }

        private void Btn28_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "28";

        }

        private void Btn29_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "29";

        }

        private void Btn30_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "30";
        }
    }
}
