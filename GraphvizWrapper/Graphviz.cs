using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public class Graphviz
    {
        private readonly string _binPath;

        public Graphviz(string binPath)
        {
            _binPath = binPath;
        }

        public Graph CreateGraph(string label, bool directed)
        {
            return new Graph(label, directed ? GraphType.Directed : GraphType.NonDirected);
        }

        public void GenerateGraph(Graph graph, GraphRenderingEngine engine, GraphOuputType type, string file)
        {
            GenerateGraph(graph.GenerateDot(), engine, type, file);
        }

        public void GenerateGraph(string source, GraphRenderingEngine engine, GraphOuputType type, string file)
        {
            File.WriteAllBytes(file, GenerateGraph(source, engine, type));
        }

        public byte[] GenerateGraph(string source, GraphRenderingEngine engine, GraphOuputType type)
        {
            string engineName;
            switch (engine)
            {
                case GraphRenderingEngine.Dot:
                    engineName = "dot";
                    break;
                case GraphRenderingEngine.Neato:
                    engineName = "neato";
                    break;
                case GraphRenderingEngine.Twopi:
                    engineName = "twopi";
                    break;
                case GraphRenderingEngine.Circo:
                    engineName = "circo";
                    break;
                case GraphRenderingEngine.Fdp:
                    engineName = "fdp";
                    break;
                case GraphRenderingEngine.Sfdp:
                    engineName = "sfdp";
                    break;
                case GraphRenderingEngine.Patchwork:
                    engineName = "patchwork";
                    break;
                case GraphRenderingEngine.Osage:
                    engineName = "osage";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(engine), engine, null);
            }

            string outputType;
            switch (type)
            {
                case GraphOuputType.Png:
                    outputType = "png";
                    break;
                case GraphOuputType.Pdf:
                    outputType = "pdf";
                    break;
                case GraphOuputType.Jpg:
                    outputType = "jpg";
                    break;
                case GraphOuputType.Plain:
                    outputType = "plain";
                    break;
                case GraphOuputType.PlainExt:
                    outputType = "plain-ext";
                    break;
                case GraphOuputType.Svg:
                    outputType = "svg";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            byte[] output;
            using (Process process = Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(_binPath, engineName),
                Arguments = "-v -o -T" + outputType,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }))
            {
                process.BeginErrorReadLine();
                using (StreamWriter writer = process.StandardInput)
                    writer.WriteLine(source);
                using (StreamReader reader = process.StandardOutput)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        reader.BaseStream.CopyTo(memoryStream);
                        output = memoryStream.ToArray();
                    }
                }
            }

            return output;
        }
    }
}