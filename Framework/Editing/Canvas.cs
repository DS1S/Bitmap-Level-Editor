using Level_Editor.Framework.File_Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Level_Editor.Framework.Tools;

namespace Level_Editor.Framework.Editing
{
    public class Canvas
    {
        protected Rectangle canvasBox;
        protected Cell[,] cells;
        private int cellNumberX;
        private int cellNumberY;
    
        public Canvas(int cellCount, int cellWidth, int cellHeight, bool loadCanvas, Rectangle canvasBox)
        {
            int scale = 0;

            this.cellNumberX = cellWidth;
            this.cellNumberY = cellHeight;
            this.canvasBox = canvasBox;

            scale = canvasBox.Width / (cellWidth * cellHeight);
            Debug.WriteLine(scale);
            SetupCanvas(cellCount, scale, cellWidth, cellHeight);
            if (loadCanvas)
            {
                this.loadCanvas();
            }
        }

        public void Render(Graphics canvasGraphics)
        {
            for(int i = 0; i < cellNumberY; i++)
            {
                for(int j = 0; j < cellNumberX; j++)
                {
                    cells[i,j].Render(canvasGraphics);
                }
            }
            canvasGraphics.DrawRectangle(Pens.Black, canvasBox);
        }

        public void CellClicked(int mouseX, int mouseY)
        {
            Rectangle mouseRect = new Rectangle(mouseX, mouseY, 1, 1);
            for (int i = 0; i < cellNumberY; i++)
            {
                for (int j = 0; j < cellNumberX; j++)
                {
                    if (mouseRect.IntersectsWith(cells[i, j].cell))
                    {
                        if (cells[i, j].beenSelected)
                        {                            
                            if(ColorSelection.selectedColor != null)
                            {
                                ChangeCellColor(i,j);
                                FileResource.currentBitmap.SetPixel(i, j, cells[i,j].cellColor);
                            }
                            else
                            {
                                FileResource.currentBitmap.SetPixel(i, j, Color.Empty);
                                cells[i, j].beenSelected = false;
                            }
                        }
                        else
                        {
                            ChangeCellColor(i,j);
                            cells[i, j].beenSelected = true;
                            FileResource.currentBitmap.SetPixel(i, j, cells[i,j].cellColor);
                        }
                    }
                }
            }
        }

        public void ResetCanvas()
        {
            for(int i = 0; i < cellNumberY; i++)
            {
                for(int j = 0; j < cellNumberX; j++)
                {
                    FileResource.currentBitmap.SetPixel(i, j, Color.Empty);
                    cells[i, j].beenSelected = false;
                }
            }
        }

        private void loadCanvas()
        {
            for(int i = 0; i < cellNumberY; i++)
            {
                for(int j = 0; j < cellNumberX; j++)
                {                   
                    if (FileResource.currentBitmap.GetPixel(i,j).ToArgb() != 0)
                    {
                        ColorConverter s = new ColorConverter();
                        object tempColor = s.ConvertFromString("#" + FileResource.currentBitmap.GetPixel(i, j).Name);
                        cells[i, j].cellColor = (Color)tempColor;
                        cells[i, j].SetCellRenderColor((Color)tempColor);
                        cells[i, j].beenSelected = true;
                    }
                }
            }
        }

        private void SetupCanvas(int cellCount, int scale, int width, int height)
        {
            int moveX = 0;
            int moveY = 0;

            cells = new Cell[width,height];


            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    cells[i,j] = (new Cell(new Rectangle(new Point(canvasBox.X + moveX, canvasBox.Y + moveY), new Size(width * scale, height * scale))));
                    moveX += width * scale;
                }
                moveX = 0;
                moveY += height * scale;
            }
        }

        private void ChangeCellColor(int row, int col)
        {
            cells[row, col].cellColor = ColorSelection.selectedColor;
            cells[row, col].SetCellRenderColor(ColorSelection.selectedColor);
        }
    }
}
