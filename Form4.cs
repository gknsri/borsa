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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select kimlik,kuladi,urun,miktar,durum from onay", baglanti);
            DataTable tablo1 = new DataTable();
            tablo1.Load(sorgu.ExecuteReader());
            dataGridView1.DataSource = tablo1;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
            baglanti.Open();

            OleDbCommand sorgu1 = new OleDbCommand("update kullanicilar set para=para+'" + Convert.ToInt32(dataGridView1.CurrentRow.Cells["miktar"].Value) + "' where kuladi like '%" + dataGridView1.CurrentRow.Cells["kuladi"].Value + "%'", baglanti);
            sorgu1.ExecuteNonQuery();

            OleDbCommand sorgu = new OleDbCommand("delete * from onay where kimlik=" + dataGridView1.CurrentRow.Cells["kimlik"].Value + "", baglanti);
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Ekleme İşlemi Gerçekleştirildi.", "Borsa Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            OleDbCommand sorgu2 = new OleDbCommand("select kimlik,kuladi,urun,miktar,durum from onay", baglanti);
            DataTable tablo1 = new DataTable();
            tablo1.Load(sorgu2.ExecuteReader());
            dataGridView1.DataSource = tablo1;

            baglanti.Close();
        }
    }
}
