using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public class Edge
    {
        public Node FirstNode { get; set; }
        public Node SecondNode { get; set; }
        public Attributes Attributes { get; set; }

        internal Edge(Node firstNode, Node secondNode, Attributes attributes)
        {
            FirstNode = firstNode;
            SecondNode = secondNode;
            Attributes = attributes;
        }

        public string GenerateDot()
        {
            return $"{FirstNode.Name} -> {SecondNode.Name} [{Attributes.GenerateDot()}];";
        }
    }
}