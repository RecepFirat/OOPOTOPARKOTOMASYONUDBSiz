using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPOTOPARKOTOMASYONUDBSiz
{ //32.dakıkadayım 
    public partial class Form1 : Form
    {//oop nın temel mantıgı temel bır yerden cıkıyosun onun ozellıgınden eger gene bırden fazla bılgı kendı ıcerısınde saklıyosa farklı bı claass tanımlıyorsun
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Arac arc = new Arac();
            arc.Plaka = TxtPlaka.Text;
            arc.Tip = (AracTip)listAracTip.SelectedItem;//object tipinde geliyo ya onu cast edıyorum
            arc.Kontak = checkedKontakVar.Checked;
            arc.Abone = chkAbone.Checked;

            lstAraclar.Items.Add(arc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listAracTip.Items.Add(new AracTip {

                Adi = "otomobıl(1)",
                Fiyat = 1
            });
            listAracTip.Items.Add(new AracTip {

                Adi = "Minünüs(2)",
                Fiyat = 2
            });
            listAracTip.Items.Add(new AracTip {

                Adi = "Kamyon(3)",
                Fiyat = 1
            });
        }

        private void lstAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {//simdi sectiim o nesneyi yanı arac tıpını gerı getırıyorum  hangı olayda eger bı lıstbox secersem

            if (lstAraclar.SelectedItem == null)
                return;

            Arac Secili = (Arac)lstAraclar.SelectedItem;//secili aracı aldim cunku buda bı lıste degerı tutuyo
            lblPlaka.Text = Secili.Plaka;
            lblSure.Text = Secili.Sure.ToString();
            lblUcret.Text = Secili.Ucret.ToString("C2");


        }
    }
}
