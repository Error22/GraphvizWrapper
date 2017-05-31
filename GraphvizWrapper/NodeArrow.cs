using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public class NodeArrow
    {
        public Node FirstNode { get; set; }
        public Node SecondNode { get; set; }

        internal NodeArrow(Node firstNode, Node secondNode)
        {
            FirstNode = firstNode;
            SecondNode = secondNode;
        }

        public string GenerateDot()
        {
            string generated = $"{FirstNode.Name} -> {SecondNode.Name};";
            return generated;
        }

    }
}
