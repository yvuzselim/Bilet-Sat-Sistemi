using Rezervasyon;
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

namespace WindowsFormsApp1
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=YavuzExcalibur\SQLEXPRESS;Initial Catalog=YolcuBilet;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Eğer her iki metin kutusu dolu değilse (yani her iki alan da girilmemişse) işlem yapma
            if (string.IsNullOrWhiteSpace(TxtAdminKullaniciAd.Text) || string.IsNullOrWhiteSpace(TxtAdminSifre.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Eğer kullanıcı adı ve şifre "admin" ise Form3'e yönlendirme yapma
            if (TxtAdminKullaniciAd.Text == "admin" && TxtAdminSifre.Text == "admin")
            {
                MessageBox.Show("Yönetici girişi başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 form3 = new Form3();
                form3.Show();
                this.Visible = false;
                return; // Bu noktada fonksiyondan çıkıyoruz, geri kalan kodu çalıştırmıyoruz
            }

            // Bağlantıyı aç
            conn.Open();

            // SQL sorgusunu hazırla
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanici WHERE TC = @Ad AND Sifre = @Sifre", conn);
            cmd.Parameters.AddWithValue("@Ad", TxtAdminKullaniciAd.Text);
            cmd.Parameters.AddWithValue("@Sifre", TxtAdminSifre.Text);

            // Sorguyu çalıştır ve sonuçları oku
            SqlDataReader dr = cmd.ExecuteReader();

            // Eğer en az bir sonuç varsa, giriş başarılıdır
            if (dr.Read())
            {
                // Giriş başarılı uyarısı ver
                MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Form3'ü oluştur ve göster
                Form3 form3 = new Form3();
                form3.Show();
                // Mevcut formun görünürlüğünü kapat
                this.Visible = false;
            }
            else
            {
                // Eğer buraya kadar geldiysek, giriş bilgileri yanlıştır
                // Kullanıcıya bir hata mesajı göster
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Bağlantıyı kapat
            conn.Close();
        }


    }
}
