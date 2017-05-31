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
                Color = Color
            };
        }

        public string GenerateDot()
        {
            string generated = "";
            if (Label != null) generated += $"label = \"{Label}\" ";
            if (Style.HasValue)
            {
                string styleText = "";
                if (Style.Value.Has(Styles.Solid))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}solid";
                if (Style.Value.Has(Styles.Dashed))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}dashed";
                if (Style.Value.Has(Styles.Dotted))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}dotted";
                if (Style.Value.Has(Styles.Bold))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}bold";
                if (Style.Value.Has(Styles.Rounded))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}rounded";
                if (Style.Value.Has(Styles.Diagonals))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}diagonals";
                if (Style.Value.Has(Styles.Filled))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}filled";
                if (Style.Value.Has(Styles.Stripped))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}striped";
                if (Style.Value.Has(Styles.Wedged))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}wedged";
                if(Style.Value.Has(Styles.Radial))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}radial";
                if(Style.Value.Has(Styles.Invis))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}invis";
                if(Style.Value.Has(Styles.Tapered))
                    styleText += $"{(styleText.Length > 0 ? "," : "")}tapared";
                generated += $"style = \"{styleText}\" ";
            }
            if (Color.HasValue) generated += $"color = \"#{Color.Value.R:X2}{Color.Value.G:X2}{Color.Value.B:X2}{Color.Value.A:X2}\" "; 
            return generated;
        }

        public static Attributes Empty() => new Attributes();
        public static Attributes WithLabel(string label) => new Attributes {Label = label};
    }
}