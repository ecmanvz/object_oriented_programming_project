using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atikToplamaOyunu
{
    public interface IDolabilen
    {
        int Buyukluk { get; }
        int bosKisim { get; set; }
        int FullRate { get; set; }
    }
}
