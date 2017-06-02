using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public class Attributes
    {
        public string Label { get; set; }
        public Styles? Style { get; set; }
        public Color? Color { get; set; }
        public Color? BgColor { get; set; }
        public Color? FillColor { get; set; }
        public Shape? Shape { get; set; }
        public PortPos HeadPort { get; set; }
        public PortPos TailPort { get; set; }

        public Attributes SetLabel(string label)
        {
            Label = label;
            return this;
        }

        public Attributes CopyWithLabel(string label)
        {
            return Copy().SetLabel(label);
        }

        public Attributes Copy()
        {
            return new Attributes
            {
                Label = Label,
                Style = Style,
                Color = Color,
                BgColor = BgColor,
                FillColor = FillColor,
                Shape = Shape,
                HeadPort = HeadPort,
                TailPort = TailPort
            };
        }

        public string GenerateDot()
        {
            string generated = "";
            if (Label != null) generated += $"label = \"{Label}\" ";
            if (Style.HasValue)
                generated +=
                    $"style = \"{string.Join(",", Enum.GetValues(typeof(Styles)).Cast<Styles>().Where(style => Style.Value.Has(style)).Select(style => Enum.GetName(typeof(Styles), style)?.ToLower()))}\" ";
            if (Color.HasValue)
                generated += $"color = \"#{Color.Value.R:X2}{Color.Value.G:X2}{Color.Value.B:X2}{Color.Value.A:X2}\" ";
            if (BgColor.HasValue)
                generated +=
                    $"bgcolor = \"#{BgColor.Value.R:X2}{BgColor.Value.G:X2}{BgColor.Value.B:X2}{BgColor.Value.A:X2}\" ";
            if (FillColor.HasValue)
                generated +=
                    $"fillcolor = \"#{FillColor.Value.R:X2}{FillColor.Value.G:X2}{FillColor.Value.B:X2}{FillColor.Value.A:X2}\" ";
            if (Shape.HasValue) generated += $"shape = \"{Enum.GetName(typeof(Shape), Shape.Value)?.ToLower()}\" ";
            if (HeadPort != null)
                generated += $"headport = \"{HeadPort.GenerateDot()}\" ";
            if (TailPort != null)
                generated += $"tailport = \"{TailPort.GenerateDot()}\" ";
            return generated;
        }

        public static Attributes Empty() => new Attributes();
        public static Attributes WithLabel(string label) => new Attributes {Label = label};
    }
}