using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public class Graph
    {
        public string Name { get; }
        public Attributes Attributes { get; set; }
        public Attributes NodeAttributes { get; set; }
        public GraphType Type { get; }
        public IList<Graph> SubGraphs { get; }
        public IList<Node> Nodes { get; }
        public IList<Edge> Edges { get; }

        internal Graph(Attributes attributes, GraphType type)
        {
            Name = $"{(type == GraphType.Cluster ? "cluster" : "")}g_{Guid.NewGuid():N}";
            Attributes = attributes;
            NodeAttributes = Attributes.Empty();
            Type = type;
            SubGraphs = new List<Graph>();
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        public Graph CreateSubGraph(bool cluster, Attributes attributes)
        {
            Graph subGraph = new Graph(attributes, cluster ? GraphType.Cluster : GraphType.SubGraph);
            SubGraphs.Add(subGraph);
            return subGraph;
        }

        public Node CreateNode(Attributes attributes)
        {
            Node node = new Node(attributes);
            Nodes.Add(node);
            return node;
        }

        public Edge CreateEdge(Node firstNode, Node secondNode, Attributes attributes)
        {
            return CreateEdge(firstNode, null, secondNode, null, attributes);
        }

        public Edge CreateEdge(Node firstNode, string firstSection, Node secondNode, string secondSection,
            Attributes attributes)
        {
            Edge edge = new Edge(firstNode, firstSection, secondNode, secondSection, attributes);
            Edges.Add(edge);
            return edge;
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
            generated += Attributes.GenerateDot();
            generated += $"node [{NodeAttributes.GenerateDot()}]";

            foreach (Graph graph in SubGraphs)
                generated += graph.GenerateDot();

            foreach (Node node in Nodes)
                generated += node.GenerateDot();

            foreach (Edge edge in Edges)
                generated += edge.GenerateDot();


            generated += "}";
            return generated;
        }
    }
}