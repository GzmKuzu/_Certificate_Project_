using Microsoft.Data.SqlClient;
using System.Data;

namespace İşyeri_Çalişan_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-QSQ9CGJ2;Initial Catalog=VeriTabani;Integrated Security=True;Trust Server Certificate=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personel(AdiSoyadi,Telefon,Maas,Adres) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text +
                "','" + textBox4.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarıyla Eklendi.");
            Listele();
            Temizle();
        }

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from Personel", baglanti);

            //Kayıtları önce datatable aktarıldı sonra veriler datagridviewe aktarıldı.
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Personel Set AdiSoyadi='" + textBox2.Text + "',Telefon='" + textBox3.Text + "'" +
                ",Maas='" + textBox5.Text + "',Adres='" + textBox4.Text + "'Where ID='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarıyla Düzenlendi.");
            Listele();
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["AdSoyad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Maas"].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kayıt Silinsin İstiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                { 
               baglanti.Open();
                SqlCommand komut = new SqlCommand("Delete from Personel Where ID='"+ dataGridView1.CurrentRow.Cells["ID"].Value.ToString() +"'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi.");
                Listele();
                Temizle(); 
            }

            
        }
    }
}
