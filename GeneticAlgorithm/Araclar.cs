using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class Arac : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Arac()
        {

        }
        public Arac(String Adi, Double Kapasite,Boolean Kullanildimi)
        {
            this.Adi = Adi;
            this.Kapasite = Kapasite;
            this.Kullanildimi = Kullanildimi;
        }

        public String Adi { get; set; }
        public Double Kapasite { get; set; }
        public Boolean Kullanildimi { get; set; }
    }
}
