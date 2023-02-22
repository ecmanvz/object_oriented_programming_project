using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atikToplamaOyunu.Class
{
    public class CamAtik : IAtikKutusu
    {
        public int SkorTemizle => 600;

        public int Buyukluk => 2200;         //cam atık kapasitesi

        public int bosKisim { get; set; }

        public int FullRate { get; set; }

        public bool Ekle(Atik atik)    
        {
            if (atik.Hacim + bosKisim <= Buyukluk)   //atığın hacmi büyüklükten küçük olduğu sürece yeni ekle
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
