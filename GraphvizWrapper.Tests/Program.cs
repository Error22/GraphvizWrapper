using System;
using System.Collections.Generic;
using System.IO;
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

            Graph baseGraph = graphviz.CreateGraph("Example", true);

            Node a = baseGraph.CreateNode("Test");
            Node b = baseGraph.CreateNode("Some other");
            baseGraph.CreateArrow(a, b);

            Console.WriteLine(baseGraph.GenerateDot());
            graphviz.GenerateGraph(baseGraph, GraphRenderingEngine.Dot, GraphOuputType.Png, "example.png");
            
            Console.Read();
        }
    }
}