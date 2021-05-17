using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace borsauyg
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from kullanicilar where kuladi='" + Form1.goad + "'", baglanti); ;
            OleDbDataReader getir = sorgu.ExecuteReader();

            while (getir.Read())
            {
                label3.Text = Convert.ToString(getir["para"]);
                label11.Text = Convert.ToString(getir["bugday"]);
                label12.Text = Convert.ToString(getir["arpa"]);
                label13.Text = Convert.ToString(getir["yulaf"]);
                label14.Text = Convert.ToString(getir["pamuk"]);
            }
            
            OleDbCommand sorgu1 = new OleDbCommand("select kimlik,kuladi,urun,miktar,fiyat from satis", baglanti);
            DataTable tablo1 = new DataTable();
            tablo1.Load(sorgu1.ExecuteReader());
            dataGridView1.DataSource = tablo1;
            dataGridView2.DataSource = tablo1;



            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox1.Text != "0"))
            {
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("insert into onay (kuladi,urun,miktar,durum) values('" + Form1.goad + "','" + "Para" + "','" + textBox1.Text + "','" + "Beklemede" + "')", baglanti);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ekleme Başarılı. Admin Onayı Bekleniyor.", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Değer Giriniz!!!", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") && (textBox2.Text != "0") && (comboBox1.Text != "Seçiniz"))
            {
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("insert into onay (kuladi,urun,miktar,durum) values('" + Form1.goad + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + "Beklemede" + "')", baglanti);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ekleme Başarılı. Admin Onayı Bekleniyor.", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Text = "";
                comboBox1.Text = "Seçiniz";
            }
            else
            {
                MessageBox.Show("Değer Giriniz!!!", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text != "") && (textBox4.Text != "") && (comboBox2.Text != "Seçiniz") && (textBox3.Text != "0") && (textBox4.Text != "0"))
            {
                if ((comboBox2.Text == "Buğday" && (Convert.ToInt32(label11.Text) >= Convert.ToInt32(textBox3.Text))) || 
                    (comboBox2.Text == "Arpa" && (Convert.ToInt32(label12.Text) >= Convert.ToInt32(textBox3.Text))) || 
                    (comboBox2.Text == "Yulaf" && (Convert.ToInt32(label13.Text) >= Convert.ToInt32(textBox3.Text))) || 
                    (comboBox2.Text == "Pamuk" && (Convert.ToInt32(label14.Text) >= Convert.ToInt32(textBox3.Text))))                
                {
                    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("insert into satis (kuladi,urun,miktar,fiyat,durum) values('" + Form1.goad + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + "Satilik" + "')", baglanti);
                    sorgu.ExecuteNonQuery();
                    
                    MessageBox.Show("Ürün Başarıyla Satışa Çıkarıldı.", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox2.Text = "Seçiniz";

                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Elinizdeki Üründen Fazlasını Satamazsınız!!!", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Değer Giriniz!!!", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
            baglanti1.Open();
            OleDbCommand sorgu1 = new OleDbCommand("select kimlik,kuladi,urun,miktar,fiyat from satis", baglanti1);
            DataTable tablo1 = new DataTable();
            tablo1.Load(sorgu1.ExecuteReader());
            dataGridView1.DataSource = tablo1;
            dataGridView2.DataSource = tablo1;
            baglanti1.Close();





        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secim = "";
            if (comboBox3.SelectedIndex == 0)
            {
                secim = "buğday";
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                secim = "arpa";
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                secim = "yulaf";
            }
            else if (comboBox3.SelectedIndex == 3)
            {
                secim = "pamuk";
            }

            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select kimlik,kuladi,urun,miktar,fiyat from satis where urun like '%" + secim + "%'", baglanti);
            DataTable tablo1 = new DataTable();
            tablo1.Load(sorgu.ExecuteReader());
            dataGridView2.DataSource = tablo1;
            this.dataGridView2.Sort(this.dataGridView2.Columns["fiyat2"], ListSortDirection.Ascending);
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
            baglanti.Open();
            OleDbCommand sorgu1 = new OleDbCommand("update satis set miktar=miktar-'" + textBox5.Text + "' where kimlik like '%" + dataGridView2.CurrentRow.Cells["kimlik2"].Value + "%'", baglanti);
            sorgu1.ExecuteNonQuery();
            OleDbCommand sorgu2 = new OleDbCommand("select kimlik,kuladi,urun,miktar,fiyat from satis", baglanti);
            DataTable tablo1 = new DataTable();
            tablo1.Load(sorgu2.ExecuteReader());
            dataGridView1.DataSource = tablo1;
            dataGridView2.DataSource = tablo1;
            baglanti.Close();
        }
    }
}
