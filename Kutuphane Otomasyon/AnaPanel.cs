using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Kutuphane_Otomasyon
{
    public partial class AnaPanel : Form
    {
        public AnaPanel()
        {
            InitializeComponent();
            tabControl1.TabPages.Clear();
        }

        private void AnaPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Ana panel kapandı.");
            Application.OpenForms["Form1"].Show();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DatabaseConnector.UyeGoster();
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(UyelerSayfasi);


        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(UyeEkle);

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int no,string cadde,int postakodu,string il,string mahalle,int daire,int kat,int sokak
            string adres = DatabaseConnector.AdresEkle(Convert.ToInt32(numericUpDown1.Value), textBox5.Text, Convert.ToInt32(textBox7.Text), textBox8.Text, textBox4.Text, Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown2.Value), textBox6.Text);
            if (adres == "Adres bilgileri girildi.")
            {
                adres += " " + DatabaseConnector.UyeEkle(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text);
            }
            toolStripStatusLabel1.Text = adres;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(UyeSil);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                toolStripStatusLabel1.Text = DatabaseConnector.UyeSil(Convert.ToInt32(txtBxUyeId.Text), true);
            }
            else
            {
                toolStripStatusLabel1.Text = DatabaseConnector.UyeSil(Convert.ToInt32(txtBxUyeId.Text), false);
            }

        }

        private void gösterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dtGrdwYazar.DataSource = DatabaseConnector.YazarGoster();
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabPgYazarGoster);

        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPgYazarEkleGuncelleSil);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                toolStripStatusLabel1.Text = DatabaseConnector.YazarEkle(txtBoxYazarAd.Text, txtBoxYazarSoyad.Text, 3);
            }else if (radioButton2.Checked == true)
            {
                toolStripStatusLabel1.Text = DatabaseConnector.YazarGuncelle(txtBoxYazarAd.Text, txtBoxYazarSoyad.Text, Convert.ToInt32(txtBoxKitapId.Text), Convert.ToInt32(txtBoxYazarId.Text));
            }
            else if (radioButton3.Checked == true)
            {
                toolStripStatusLabel1.Text = DatabaseConnector.YazarSil(Convert.ToInt32(txtBoxYazarId.Text));
            }
            else
            {
                toolStripStatusLabel1.Text = "Beklenmedik bir problemle karşılandı.";
            }
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPageKitaplar);
            dtGrdVwKitaplar.DataSource = DatabaseConnector.KitapGoster();
            toolStripStatusLabel1.Text = "Kitaplar listelendi!";

        }
        private void KategorileriSirala()
        {
            DataTable kategoriler = DatabaseConnector.KategoriGetir();
            //var kul = new Dictionary<int, string>();
            for (int i = 0; i < kategoriler.Rows.Count; i++)
            {
                //kul.Add(Convert.ToInt32(kategoriler.Rows[i][0].ToString()), kategoriler.Rows[i][0].ToString());
                //comboBox1.Items.Add(new DictionaryEntry(Convert.ToInt32(kategoriler.Rows[i][0].ToString()), kategoriler.Rows[i][0].ToString()));
                //cmBoxKategoriId.Items.Add(kategoriler.Rows[i][1].ToString());
                //cmBoxKategoriId.Items.Insert(Convert.ToInt32(kategoriler.Rows[i][0].ToString()),kategoriler.Rows[i][1].ToString());
                cmBoxKategoriId.Items.Add(Convert.ToInt32(kategoriler.Rows[i][0].ToString())+":"+kategoriler.Rows[i][1].ToString());
            }

            //cmBoxKategoriId.DisplayMember = "Key";
            //cmBoxKategoriId.ValueMember = "Value";
            //cmBoxKategoriId.DataSource = cmBoxKategoriId.Items;

        }

        private void gösterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPageKitapEkleSil);
            KategorileriSirala();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Kategori_id,RafNo,Yayimyili,Basim,Stok,SayfaSayisi,Tur,Adi,ISBN
            //toolStripStatusLabel1.Text = DatabaseConnector.KitapEkle();
            string a = cmBoxKategoriId.SelectedItem.ToString();
            string[] dizi = a.Split(':');
            string b = cmBoxKitapStok.SelectedItem.ToString();
            string[] dizi2 = b.Split(':');
            toolStripStatusLabel1.Text = DatabaseConnector.KitapEkle(Convert.ToInt32(dizi[0].ToString()),Convert.ToInt32(nmrcUpDownRafNo.Value),dateTimePicker1.Value.Year.ToString()+"-"+ dateTimePicker1.Value.Month.ToString()+"-"+ dateTimePicker1.Value.Day.ToString(), txtBoxKitapYayimEvi.Text,Convert.ToInt32(dizi2[0].ToString()),Convert.ToInt32(nmrcUpDownSayfaSayisi.Value.ToString()),txtBoxKitapTur.Text,txtBoxKitapAd.Text,txtBoxIsbn.Text);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DatabaseConnector.KitapSil(Convert.ToInt32(txtBoxSilinecekKitapId.Text));

        }

        private void gösterToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPgCevirmenler);
            dtGrdwCevirmenler.DataSource = DatabaseConnector.CevirmenGoster();
            toolStripStatusLabel1.Text = "Çevirmenler listelendi!";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DatabaseConnector.CevirmenEkle(txBoxCevirmenAd.Text, txBoxCevirmenSoyad.Text, txBoxCevirdigiDil.Text, Convert.ToInt32(nmrcUpDownKitapId.Value.ToString()));
        }

        private void ekleToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPgCevirmenEkleSil);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DatabaseConnector.CevirmenSil(Convert.ToInt32(nmrcUpDownKitapId.Value.ToString()));
        }

        private void gösterToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPageKategoriler);
            dtGrwKategoriler.DataSource = DatabaseConnector.KategoriGetir();
            toolStripStatusLabel1.Text = "Kategoriler listelendi!";
        }

        private void ekleToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPageKategoriEkleSil);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DatabaseConnector.KategoriEkle(txBoxKategoriAdi.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DatabaseConnector.KategoriSil(Convert.ToInt32(nmrcUpDownKategoriId.Value.ToString()));
        }

        private void gösterToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPageYayimEvleri);
            dtGrdwYayimevleri.DataSource = DatabaseConnector.YayimEvleriGoster();
            toolStripStatusLabel1.Text = "Yayımevleri listelendi!";
        }

        private void ekleToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tbPageYayimEviEkle);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string adres = DatabaseConnector.AdresEkle(Convert.ToInt32(nmrUpDownNo.Value), txBoxCadde.Text, Convert.ToInt32(txBoxPostaKodu.Text),txBoxIl.Text, txBoxMahalle.Text, Convert.ToInt32(nmrUpDownDaire.Value), Convert.ToInt32(nmrUpDownKat.Value), txBoxSokak.Text);
            toolStripStatusLabel1.Text = adres;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txBoxAdresId.Text = DatabaseConnector.SonAdresiGetir().ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DatabaseConnector.YayimeviEkle(txBoxYayimEviAdi.Text, txBoxAdresId.Text, txBoxKitapId2.Text);
        }
    }
}
