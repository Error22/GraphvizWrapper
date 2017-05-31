using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public class Graph
    {
        public string Name { get; }
        public string Label { get; set; }
        public GraphType Type { get; }
        public IList<Node> Nodes { get; }
        public IList<NodeArrow> NodeArrows { get; }

        internal Graph(string label, GraphType type)
        {
            Name = $"{(Type == GraphType.Cluster ? "cluster" : "")}g_{Guid.NewGuid():N}";
            Label = label;
            Type = type;
            Nodes = new List<Node>();
            NodeArrows = new List<NodeArrow>();
        }

        public Node CreateNode(string label)
        {
            Node node = new Node(label);
            Nodes.Add(node);
            return node;
        }

        public NodeArrow CreateArrow(Node firstNode, Node secondNode)
        {
            NodeArrow arrow = new NodeArrow(firstNode, secondNode);
            NodeArrows.Add(arrow);
            return arrow;
        }

        public string GenerateDot()
        {
            string generated;

            switch (Type)
            {
                case GraphType.Directed:
                    generated = "digraph";
                    break;
                case GraphType.NonDirected:
                    generated = "graph";
                    break;
                case GraphType.SubGraph:
                case GraphType.Cluster:
                    generated = "subgraph";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            generated += $" {Name} {{";

            foreach (Node node in Nodes)
                generated += node.GenerateDot();

            foreach (NodeArrow arrow in NodeArrows)
                generated += arrow.GenerateDot();


            generated += "}";
            return generated;
        }
    }
}