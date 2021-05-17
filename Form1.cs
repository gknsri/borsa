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
    public partial class Form1 : Form
    {
        public static string goad;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from kullanicilar where kuladi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'", baglanti);
            OleDbDataReader getir = sorgu.ExecuteReader();
            if (getir.Read())
            {
                goad = textBox1.Text;

                if (textBox1.Text == "admin")
                {
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.Show();
                }
                else
                { 
                    this.Hide();
                    Form3 form3 = new Form3();
                    form3.Show();
                }      
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!!!", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
            baglanti.Close();
        }
    }
}
