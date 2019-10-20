using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BartoszKopec.WpfUtils
{
    public struct Font
    {
        public FontFamily Family { get; set; }
        public string FamilyName
        {
            get
            {
                return Family.ToString();
            }
        }

        public FontStyle Style { get; set; }
        public FontWeight Weight { get; set; }
        public textDecorationCollection TextDecorations { get; set; }
        public double Size { get; set; }
        public ConsoleColor Color { get; set; }

        public Brush Brush { get { return new SolidColorBrush(Color); } }

        public static Font Default
        {
            get
            {
                return new Font()
                {
                    Family = new FontFamily("Segoe UI"),
                    Style = FontStyles.Normal,
                    Weight = FontWeights.Normal,
                    TextDecorations = null,
                    Size = 12,
                    Color = Colors.Black
                };
            }
        }

        public static System.Drawing.Font ToSystemDrawingFont(Font font)
        {
            System.Drawing.FontStyle style = (font.Style == FontStyles.Italic) ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular;
            if (font.Weight == FontWeights.Bold) style |= System.Drawing.FontStyle.Bold;
            if (font.TextDecorations.Contain(System.Windows.TextDecorations.Underline[0]))
                style |= System.Drawing.FontStyle.Underline;
            if (font.TextDecorations.Contains(System.Windows.TextDecorations.Strikethrough[0]))
                style |= System.Drawing.FontStyle.Strikeout;
            System.Drawing.Font _font = new System.Drawing.Font(font.FamilyName, (int)font.Size, style);
            return _font;
        }

        public static Font FromSystmDrawingFont(System.Drawing.Font sdFont, System.Drawing.Color sdColor)
        {
            Font font = new Font();
            font.Family = new FontFamily(sdFont.FontFamily.Name);
            font.Style = sdFont.Italic ? FontStyles.Italic : FontStyles.Normal;
            font.Weight = sdFont.Bold ? FontWeight.Bold : FontWeights.Regular;
            font.TextDecorations = new textDecorationCollection();
            if (sdFont.Underline)
                font.TextDecorations.Add(System.Windows.TextDecorations.Underline);
            if (sdFont.Strikeout)
                font.TextDecorations.Add(System.Windows.TextDecorations.Strikethrough);
            font.Size = sdFont.Size;
            font.Color = sdColor.Convert();
            return font;
        }

        public void ApplyTo(Control control)
        {
            control.FontFamily = Family;
            control.FontStyle = Style;
            control.FontWeight = Weight;
            control.FontSize = Size;
            control.Foreground = Brush;
        }

        public void ApplyTo(TextBox textBox)
        {
            ApplyTo(textBox as Control);
            textBox.TextDecorations = TextDecorations;
        }

        public void ApplyTo(TextBlock textBlock)
        {
            textBlock.FontFamily = Family;
            textBlock.FontStyle = Style;
            textBlock.FontWeight = Weight;
            textBlock.TextDecorations = TextDecoration;
            textBlock.FontSize = Size;
            textBlock.Foreground = Brush;
        }
    }
}
