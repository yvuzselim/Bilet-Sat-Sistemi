using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rezervasyon
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=YavuzExcalibur\SQLEXPRESS;Initial Catalog=YolcuBilet;Integrated Security=True");

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtSeferKodu.Text == "" || TxtKalis.Text == "" || TxtSeferKodu.Text == String.Empty ||
                TxtKalis.Text == String.Empty)
            {
                TxtSeferKodu.ForeColor = Color.Red;
                TxtKalis.ForeColor = Color.Red;
                var result = MessageBox.Show("Kırmızı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    TxtSeferKodu.ForeColor = Color.Black;
                    TxtKalis.ForeColor = Color.Black;
                }
            }
            else
            {
                conn.Open();
                SqlCommand com =
                    new SqlCommand(
                        "insert into Sefer (SeferID,KalkisYeri,VarisYeri,Tarih,Fiyat, Saat) values(@p1,@p2,@p3,@p4,@p5,@p6)",
                        conn);
                com.Parameters.AddWithValue("@p1", TxtSeferKodu.Text);
                com.Parameters.AddWithValue("@p2", TxtKalis.Text);
                com.Parameters.AddWithValue("@p3", TxtVaris.Text);
                com.Parameters.AddWithValue("@p4", DtpTarih.Text);
                com.Parameters.AddWithValue("@p5", TxtFiyat.Text);
                com.Parameters.AddWithValue("@p6", TxtSaat.Text);

                com.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(TxtSeferKodu.Text + " Kodlu sefer başarılı bir şekilde eklendi.", "Bigi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand com =
                new SqlCommand(
                    "Update Sefer SET SeferID = @p1, KalkisYeri = @p2, VarisYeri = @p3, Tarih = @p4, Fiyat = @p5, Saat = @p6 where SeferID = @p1",
                    conn);
            com.Parameters.AddWithValue("@p1", TxtSeferKoduDuzenle.Text);
            com.Parameters.AddWithValue("@p2", TxtKalkisDuzenle.Text);
            com.Parameters.AddWithValue("@p3", TxtVarisDuzenle.Text);
            com.Parameters.AddWithValue("@p4", DtpTarihDuzenle.Text);
            com.Parameters.AddWithValue("@p5", TxtFiyatDuzenle.Text);
            com.Parameters.AddWithValue("@p6", TxtSaatDuzenle.Text);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(TxtSeferKoduDuzenle.Text + " Kodlu sefer başarılı bir şekilde güncelendi.", "Bigi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DatGridList("Sefer", dataGridView1);
            DatGridList("Rezervasyon", dataGridView2);
        }

        private void DatGridList(string tabloadi, DataGridView dataismi)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from " + tabloadi + "", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataismi.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string secilenSeferID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            string sorgu = "SELECT * FROM Rezervasyon WHERE SeferID = @SeferID";

            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@SeferID", secilenSeferID);

            DataTable yolcuTablosu = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(yolcuTablosu);
            dataGridView2.DataSource = yolcuTablosu;
        }


        private void TxtFiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}