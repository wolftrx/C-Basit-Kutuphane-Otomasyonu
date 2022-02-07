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
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int no,string cadde,int postakodu,string il,string mahalle,int daire,int kat,int sokak
            string adres = DatabaseConnector.AdresEkle(Convert.ToInt32(numericUpDown1.Value), textBox5.Text, Convert.ToInt32(textBox7.Text), textBox8.Text, textBox4.Text, Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown2.Value), textBox6.Text);
            if (adres == "Adres bilgileri girildi.")
            {
                adres += " " + DatabaseConnector.UyeEkle(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text);
            }
            
        }
    }
}
