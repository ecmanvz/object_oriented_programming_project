using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atikToplamaOyunu
{
    public interface IAtikKutusu : IDolabilen
    {
       
        int SkorTemizle { get; }            
       
        bool Ekle(Atik atik);
        
        bool Temizle();
    }
}
