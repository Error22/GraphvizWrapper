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
        public Attributes Attributes { get; set; }

        internal Node(Attributes attributes)
        {
            Name = $"n_{Guid.NewGuid():N}";
            Attributes = attributes;
        }

        public string GenerateDot()
        {
            return $"{Name} [{Attributes.GenerateDot()}];";
        }

    }
}
