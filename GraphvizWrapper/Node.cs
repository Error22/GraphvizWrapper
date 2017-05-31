using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public class Node
    {
        public string Name { get; }
        public string Label { get; set; }
        
        internal Node(string label)
        {
            Name = $"n_{Guid.NewGuid():N}";
            Label = label;
        }

        public string GenerateDot()
        {
            string generated = $"{Name} [label = \"{Label}\"];";
            return generated;
        }

    }
}
