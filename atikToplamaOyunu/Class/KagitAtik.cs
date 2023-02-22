using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atikToplamaOyunu.Class
{
    public class KagitAtik : IAtikKutusu
    {
        public int SkorTemizle => 1000;

        public int Buyukluk => 1200;    //kağıt atık kapasitesi

        public int bosKisim { get; set; }

        public int FullRate { get; set; }

        public bool Ekle(Atik atik)
        {
            if (atik.Hacim + bosKisim <= Buyukluk)
            {
                bosKisim += atik.Hacim;
                FullRate = Convert.ToInt32(Convert.ToDouble(bosKisim) / Convert.ToDouble(Buyukluk) * 100);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Temizle()
        {
            if (FullRate >= 75)
            {
                bosKisim = 0;
                FullRate = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
