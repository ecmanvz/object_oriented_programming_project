﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atikToplamaOyunu.Class
{
    public class OrganikAtik : IAtikKutusu
    {
        public int SkorTemizle => 0;

        public int Buyukluk => 700;           //organik atik kapasitesi

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
