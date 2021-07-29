using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Level_Editor.Framework.Editing;
using System.IO;

namespace Level_Editor.Framework.File_Management
{
    public static class FileResource
    {
        public static Bitmap currentBitmap { get; private set; }
        public static Canvas level { get; private set; }

        private static string fileName;

        public static void LoadFile()
        {
            DialogSettings(2);
            if(currentBitmap != null)
            {
                level = new Canvas(currentBitmap.Width * currentBitmap.Height, currentBitmap.Width, currentBitmap.Height, true, new Rectangle(50, 50, 400, 400));
            }        
        }

        public static void SaveFile()
        {
            if(currentBitmap != null)
            {
                DialogSettings(1);
                DialogSettings(0);
            }
            else
            {
                MessageBox.Show("Cannot save an empty level");
            }
        }

        public static void CreateFile(int width, int height)
        {
            currentBitmap = new Bitmap(width, height);
            level = new Canvas(currentBitmap.Width * currentBitmap.Height,currentBitmap.Width, currentBitmap.Height, false, new Rectangle(50, 50, 400, 400));
        }

        private static void DialogSettings(int actionNumber)
        {
            SaveFileDialog bmpSaveDialog = new SaveFileDialog();
            OpenFileDialog bmpOpenDialog = new OpenFileDialog();

            bmpSaveDialog.InitialDirectory = Application.StartupPath;
            bmpSaveDialog.Title = "Save BMP Files";
            bmpSaveDialog.DefaultExt = "bmp";
            bmpSaveDialog.Filter = "Bitmap files (*.bmp)|*.bmp";
            bmpSaveDialog.FilterIndex = 2;
            bmpSaveDialog.RestoreDirectory = true;
            bmpSaveDialog.OverwritePrompt = false;

            bmpOpenDialog.InitialDirectory = Application.StartupPath;
            bmpOpenDialog.Title = "Open BMP Files";
            bmpOpenDialog.DefaultExt = "bmp";
            bmpOpenDialog.Filter = "Bitmap files (*.bmp)|*.bmp";
            bmpOpenDialog.FilterIndex = 2;
            bmpOpenDialog.RestoreDirectory = true;

            FileDialogActions(actionNumber, bmpSaveDialog, bmpOpenDialog);
            
        }

        private static void SaveTxtFileRGBVals(SaveFileDialog bmpSaveDialog)
        {
            StreamWriter fileWriter = null;

            try
            {
                fileWriter = new StreamWriter(Application.StartupPath +@"\" + fileName + " RGBTextValues");
                for(int i = 0; i < currentBitmap.Height; i++)
                {
                    for(int j = 0; j < currentBitmap.Width; j++)
                    {
                        fileWriter.WriteLine(
                            "[Row: " + i + " Column: " + j +"] & [ R =" +
                            currentBitmap.GetPixel(i, j).R + " " +
                            ", G =" +
                            currentBitmap.GetPixel(i, j).G + " " +
                            ", B =" +
                            currentBitmap.GetPixel(i, j).B + " " +
                            "]");
                    }
                }
            }
            finally
            {
                fileWriter.FlushAsync();
            }
        }

        private static void FileDialogActions(int actionNumber, SaveFileDialog bmpSaveDialog, OpenFileDialog bmpOpenDialog)
        {
            if (actionNumber == 1)
            {
                if (bmpSaveDialog.ShowDialog() == DialogResult.OK)
                {
                    currentBitmap.Save(bmpSaveDialog.FileName);
                    fileName = Path.GetFileNameWithoutExtension(bmpSaveDialog.FileName);                        
                }
            }
            else if (actionNumber == 2)
            {
                if (bmpOpenDialog.ShowDialog() == DialogResult.OK)
                {
                    currentBitmap = new Bitmap(bmpOpenDialog.FileName);
                }
            }
            else if (actionNumber == 0)
            {
                SaveTxtFileRGBVals(bmpSaveDialog);
            }

        }
    }
}
