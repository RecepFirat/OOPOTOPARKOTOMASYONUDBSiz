using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPOTOPARKOTOMASYONUDBSiz
{
    class Arac
    {
        public Arac()
        {
            Giris = DateTime.Now;//artık her cagırıldıgında gırısı dırek pc zamanından ceker;
        }
        public string Plaka { get; set; }
        public AracTip Tip { get; set; }//tip birden fazla deger alıyor o zaman pat baska bı class
        public bool Kontak { get; set; }
        public bool Abone { get; set; }
        public DateTime Giris { get; set; }
        public DateTime Cikis { get; set; }


        public int Sure
        {
            get
            {
                //2 sure farkını alır
                TimeSpan Fark = (Cikis - Giris);
                if (Fark - TimeSpan.FromHours(Fark.TotalHours) > TimeSpan.Zero)
                {
                    Fark.Add(TimeSpan.FromHours(1));//1 saat eklenmis oluyo
                }
                return (int)Fark.TotalHours;
            }
        }

        public Decimal Ucret
        {
            get
            {

                decimal toplam = Tip.Fiyat * Sure;
                if (Abone)
                {

                    toplam *= 0.80M;
                }
                return toplam;
            }
        }



        public override string ToString()
        {
            string metinAbone = Abone ? "Abone" : "Abone Degil";
            string MetinKontakt = Kontak ? "Kontak Var" : "Kontak Yok";
            return string.Format("{0}--{1}--{2}--{3} ", Plaka, Tip.Adi, metinAbone, MetinKontakt);
        }
    }


    class AracTip
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }

        public override string ToString()
        {
            return Adi;
        }

    }
}
