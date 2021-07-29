using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Level_Editor.Framework.Tools;
using System.Diagnostics;

namespace Level_Editor.Framework.Editing
{
    public class Cell
    {
        public Rectangle cell;
        public bool beenSelected { get; set; }
        public Color cellColor { get;set; }

        private Brush cellColorBrush;
        private int cellWidth;
        private int cellHeight;

        public Cell(Rectangle cell)
        {
            this.cell = cell;
            this.cellWidth = cell.Width;
            this.cellHeight = cell.Height;
            this.beenSelected = false;
            cellColorBrush = null;
        }

        public void Render(Graphics g)
        {           
            if (beenSelected && cellColorBrush != null)
            {              
                g.FillRectangle(cellColorBrush, cell);
            }
            g.DrawRectangle(Pens.Black, cell);
        }

        public void SetCellRenderColor(Color color)
        {
            cellColorBrush = ColorSelection.ConvertColorToBrush(color);
        }

    }
}
