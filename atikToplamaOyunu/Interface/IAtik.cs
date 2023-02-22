using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atikToplamaOyunu
{
    public interface IAtik
    {
        int Hacim { get; }
        System.Drawing.Image Image { get; }
    }
}
