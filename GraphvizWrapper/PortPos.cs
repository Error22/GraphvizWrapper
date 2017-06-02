using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public class PortPos
    {
        public string Port { get; set; }
        public CompassPoint? Point { get; set; }

        public PortPos(string port = null, CompassPoint? point = null)
        {
            Port = port;
            Point = point;
        }

        public string GenerateDot()
        {
            string pointText = "";
            if (Point.HasValue)
                switch (Point.Value)
                {
                    case CompassPoint.North:
                        pointText = "n";
                        break;
                    case CompassPoint.NorthEast:
                        pointText = "ne";
                        break;
                    case CompassPoint.East:
                        pointText = "e";
                        break;
                    case CompassPoint.SouthEast:
                        pointText = "se";
                        break;
                    case CompassPoint.South:
                        pointText = "s";
                        break;
                    case CompassPoint.SouthWest:
                        pointText = "sw";
                        break;
                    case CompassPoint.West:
                        pointText = "w";
                        break;
                    case CompassPoint.NorthWest:
                        pointText = "nw";
                        break;
                    case CompassPoint.Center:
                        pointText = "c";
                        break;
                    case CompassPoint.AppropriateSide:
                        pointText = "_";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return (Port ?? "") + (Port != null && Point.HasValue ? ":" : "") + pointText;
        }

        public static PortPos Of(string port) => new PortPos(port);

        public static PortPos Of(string port, CompassPoint point) => new PortPos(port, point);

        public static PortPos Of(CompassPoint point) => new PortPos(point: point);
    }
}