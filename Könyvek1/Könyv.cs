using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Könyvek1
{
    class Könyv
    {

        public int ID { get; set; }
        public string Szerzo { get; set; }
        public string Cim { get; set; }
        public string Kiado { get; set; }
        public string Kiadasiev { get; set; }
        public bool Kolcsonozheto { get; set; }
        public Könyv(string sor)
        {
            string[] resz = sor.Split(';');
            ID = Convert.ToInt32(resz[0]);
            Szerzo = resz[1];
            Cim = resz[2];
            Kiado = resz[3];
            Kiadasiev = resz[4];
            Kolcsonozheto = Convert.ToBoolean(resz[5]);


        }
        public Könyv(int ID, string Szerzo, string Cim, string Kiado, string Kiadasiev, bool Kolcsonozheto)
        {
            this.ID = ID;
            this.Szerzo = Szerzo;
            this.Cim = Cim;
            this.Kiado = Kiado;
            this.Kiadasiev = Kiadasiev;
            this.Kolcsonozheto = Kolcsonozheto;

        }
    }
}
