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
            listAracTip.Items.Add(new AracTip
            {

                Adi = "otomobıl(1)",
                Fiyat = 1
            });
            listAracTip.Items.Add(new AracTip
            {

                Adi = "Minünüs(2)",
                Fiyat = 2
            });
            listAracTip.Items.Add(new AracTip
            {

                Adi = "Kamyon(3)",
                Fiyat = 1
            });
        }

        List<Arac> CikisYapanlar = new List<Arac>();
      

        private void lstAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {//simdi sectiim o nesneyi yanı arac tıpını gerı getırıyorum  hangı olayda eger bı lıstbox secersem

            if (lstAraclar.SelectedItem == null)
                return;

            Arac Secili = (Arac)lstAraclar.SelectedItem;//secili aracı aldim cunku buda bı lıste degerı tutuyo
            Secili.Cikis = DateTime.Now;

            lblPlaka.Text = Secili.Plaka;
            lblSure.Text = Secili.Sure.ToString();
            lblUcret.Text = Secili.Ucret.ToString("C2");


        }

        private void Cikis_yap(object sender, EventArgs e)
        {
            if (lstAraclar.SelectedItem == null)
            {
                return;

            }
            else
            {
                Arac secili = (Arac)lstAraclar.SelectedItem;
                CikisYapanlar.Add(secili);
                lstAraclar.Items.Remove(secili);//bak herseyı lıste seklınde tasıyorum sımdı onu sılıyorum

            }
        }

        private void BtnGuclukRapor_Click(object sender, EventArgs e)
        {
            RaporFrm form = new RaporFrm();
            decimal total = 0;
            foreach (Arac item in CikisYapanlar)
            {
                ListViewItem li = new ListViewItem();

                li.Text = item.Plaka;
                li.SubItems.Add(item.Tip.Adi);
                li.SubItems.Add(item.Abone ? "abone" : "Degil");
                li.SubItems.Add(item.Sure.ToString());
                li.SubItems.Add(item.Ucret.ToString("C2"));//bu c2 olayı onun tıpını provıderını yapıyoruz

                form.listView1.Items.Add(li);
                total += item.Ucret;
            }
            form.lblToplamÜcret.Text = total.ToString("C2");
            form.LblToplamArac.Text = CikisYapanlar.Count.ToString();
            form.Show();
        }
    }
}
