using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSANKAYNAKLARIPROJE
{
    internal class ThemeColor2
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }
        public static List<string> ColorList = new List<string>()
        {
                "#E1D7C6",
            "#A6BB8D",
            "#CEEDC7",
            "#DFD3C3",
            "#FFE5F1",
            "#F3CCFF",
            "#DAE2B6",
            "#678983",
            "#DBA39A",
            "#C7BCA1",
            "#8B7E74",
            "#5F8D4E",
            "#7F669D",
            "#7D8F69",
            "#3A8891",
            "#9ED5C5",
            "#9F73AB",
            "#50577A",
            "#9BA17B",
            "#AA8B56",
            "#B2B2B2",
            "#815B5B",
            "#C8DBBE",
            "#D0B8A8",
            "#7895B2",
            "#3D8361"};
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }

            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
