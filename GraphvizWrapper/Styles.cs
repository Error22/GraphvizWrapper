using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    [Flags]
    public enum Styles
    {
        Solid = 1 << 0,
        Dashed = 1 << 1,
        Dotted = 1 << 2,
        Bold = 1 << 3,
        Rounded = 1 << 4,
        Diagonals = 1 << 5,
        Filled = 1 << 6,
        Stripped = 1 << 7,
        Wedged = 1 << 8,
        Radial = 1 << 9,
        Invis = 1 << 10,
        Tapered = 1 << 11,
    }
}