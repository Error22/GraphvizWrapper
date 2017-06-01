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
        public string FirstNodeSection { get; set; }
        public Node SecondNode { get; set; }
        public string SecondNodeSection { get; set; }
        public Attributes Attributes { get; set; }

        internal Edge(Node firstNode, string firstNodeSection, Node secondNode, string secondNodeSection,
            Attributes attributes)
        {
            FirstNode = firstNode;
            FirstNodeSection = firstNodeSection;
            SecondNode = secondNode;
            SecondNodeSection = secondNodeSection;
            Attributes = attributes;
        }

        public string GenerateDot()
        {
            return
                $"{FirstNode.Name}{(FirstNodeSection != null ? ":" + FirstNodeSection : "")} -> {SecondNode.Name}{(SecondNodeSection != null ? ":" + SecondNodeSection : "")} [{Attributes.GenerateDot()}];";
        }
    }
}