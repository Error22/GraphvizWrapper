using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphviz graphviz = new Graphviz(@"C:\Program Files (x86)\Graphviz2.38\bin");

            Graph baseGraph = graphviz.CreateGraph(Attributes.WithLabel("Example"), true);

            Attributes baseAttributes = new Attributes {Style = Styles.Filled, Color = Color.LightGray};
            Attributes baseNodeAttributes = new Attributes { Style = Styles.Filled, Color = Color.White };

            Graph sub1 = baseGraph.CreateSubGraph(true, baseAttributes.CopyWithLabel("Subgraph 1"));
            sub1.NodeAttributes = baseNodeAttributes;
            Graph sub2 = baseGraph.CreateSubGraph(true, baseAttributes.CopyWithLabel("Subgraph 2"));
            sub2.NodeAttributes = baseNodeAttributes;

            Node start = baseGraph.CreateNode(Attributes.WithLabel("Entry"));
            Node a0 = sub1.CreateNode(Attributes.WithLabel("A0"));
            Node a1 = sub1.CreateNode(Attributes.WithLabel("A1"));
            Node a2 = sub1.CreateNode(Attributes.WithLabel("A2"));
            Node a3 = sub1.CreateNode(Attributes.WithLabel("A3"));
            Node b0 = sub2.CreateNode(Attributes.WithLabel("B0"));
            Node b1 = sub2.CreateNode(Attributes.WithLabel("B1"));
            Node b2 = sub2.CreateNode(Attributes.WithLabel("B2"));
            Node end = baseGraph.CreateNode(Attributes.WithLabel("End"));

            baseGraph.CreateEdge(start, a0, Attributes.Empty());
            baseGraph.CreateEdge(a0, a1, Attributes.Empty());
            baseGraph.CreateEdge(a1, a2, Attributes.Empty());
            baseGraph.CreateEdge(a2, a3, Attributes.Empty());
            baseGraph.CreateEdge(a3, end, Attributes.Empty());
            baseGraph.CreateEdge(a3, a0, Attributes.Empty());

            baseGraph.CreateEdge(start, b0, Attributes.Empty());
            baseGraph.CreateEdge(a1, b2, Attributes.Empty());
            baseGraph.CreateEdge(b1, a3, Attributes.Empty());
            baseGraph.CreateEdge(b2, end, Attributes.Empty());

            Console.WriteLine(baseGraph.GenerateDot());
            graphviz.GenerateGraph(baseGraph, GraphRenderingEngine.Dot, GraphOuputType.Png, "example.png");

            Console.Read();
        }
    }
}