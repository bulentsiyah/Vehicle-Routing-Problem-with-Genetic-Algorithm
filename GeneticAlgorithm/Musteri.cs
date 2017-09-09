using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class Musteri
    {
        public Musteri(String Adi, Double Enlem, Double Boylam, int SiparisMiktari, Double Uzaklik)
        {
            this.Adi = Adi;
            this.Enlem = Enlem;
            this.Boylam = Boylam;
            this.SiparisMiktari = SiparisMiktari;
            this.Uzaklik = Uzaklik;
        }

        public String Adi { get; set; }
        public Double Enlem { get; set; }
        public Double Boylam { get; set; }
        public int SiparisMiktari { get; set; }
        public Double Uzaklik { get; set; }
    }
}
