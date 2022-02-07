using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DatabaseConnector.girisYap(textBox1.Text, textBox2.Text) == 1)
            {
                MessageBox.Show("Giriş Başarılı!");
                AnaPanel ana = new AnaPanel();
                ana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!");
            }
        }
    }
}
