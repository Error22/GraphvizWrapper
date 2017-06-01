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
        public Shape? Shape { get; set; }

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
                Shape = Shape
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
            if (Shape.HasValue) generated += $"shape = \"{Enum.GetName(typeof(Shape), Shape.Value)?.ToLower()}\" ";
            return generated;
        }

        public static Attributes Empty() => new Attributes();
        public static Attributes WithLabel(string label) => new Attributes {Label = label};
    }
}