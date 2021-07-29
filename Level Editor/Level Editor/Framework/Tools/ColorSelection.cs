using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace Level_Editor.Framework.Tools
{
    public static class ColorSelection
    {
        public static Color selectedColor { get; set; }

        public static Brush ConvertColorToBrush(Color color)
        {           
            PropertyInfo[] properties = typeof(Brushes).GetProperties();
            for(int i = 0; i < properties.Length; i++)
            {
                
                if (properties[i].Name.Equals(color.Name) && !color.IsEmpty)
                {
                    object tempBrush = properties[i].GetValue(properties);
                    return (Brush)tempBrush;
                }
            }    
            return null;
        }

        public static string[] GetListofColors()
        {
            string[] colors = null;
            int counter = 0;
            
            PropertyInfo[] properties = typeof(Brushes).GetProperties();

            colors = new string[properties.Length];

            foreach(PropertyInfo p in properties)
            {
                colors[counter] = p.Name;
                counter++;
            }

            return colors;
        }

        public static Color ConvertStringToColor(string colorName)
        {
            Color tempColor = Color.FromName(colorName);
            return tempColor;
        }
    }
}
