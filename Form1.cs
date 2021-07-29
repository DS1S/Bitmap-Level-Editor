using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Level_Editor.Framework.File_Management;
using Level_Editor.Framework.Tools;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace Level_Editor
{
    public partial class EditForm : Form
    {

        private BitmapSettings bitmapSettings;
        private Timer canvasTimer;
        private Timer mouseTimer;
        private int mouseX;
        private int mouseY;

        public EditForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            this.Paint += EditForm_Paint;
            this.MouseUp += EditForm_MouseUp;
            this.MouseDown += EditForm_MouseDown;
            this.MouseMove += EditForm_MouseMove;
            this.MouseClick += EditForm_MouseClick;

            colorComboBox.Items.Add("None");
            colorComboBox.Items.AddRange(ColorSelection.GetListofColors());

            canvasTimer = new Timer();
            canvasTimer.Interval = 1000 / 60;
            canvasTimer.Tick += CanvasTimer_Tick;
            canvasTimer.Start();

            mouseTimer = new Timer();
            mouseTimer.Interval = 1000 / 60;
            mouseTimer.Enabled = false;
            mouseTimer.Tick += MouseTimer_Tick;
        }

        private void EditForm_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void MouseTimer_Tick(object sender, EventArgs e)
        {
            FileResource.level.CellClicked(mouseX, mouseY);
        }

        private void EditForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseTimer.Enabled = false;
        }

        private void EditForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseTimer.Enabled = true;
        }

        private void EditForm_MouseClick(object sender, MouseEventArgs e)
        {
            if(FileResource.level != null)
            {
                FileResource.level.CellClicked(e.X, e.Y);
            }
        }

        private void EditForm_Paint(object sender, PaintEventArgs e)
        {
            if(FileResource.level != null)
            {
                FileResource.level.Render(e.Graphics);
            }
        }

        private void CanvasTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileResource.SaveFile();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(bitmapSettings == null || bitmapSettings.IsDisposed)
            {
                bitmapSettings = new BitmapSettings();
                if (!bitmapSettings.Visible && bitmapSettings != null)
                {
                    bitmapSettings.Owner = this;
                    bitmapSettings.Show();
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileResource.LoadFile();
        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.SelectedText.Equals("None"))
            {
                ColorSelection.selectedColor = Color.Empty;
            }
            else
            {
                ColorSelection.selectedColor = ColorSelection.ConvertStringToColor(colorComboBox.SelectedItem.ToString());
            }

            RGBLabel.Text = "[R =" +
                            ColorSelection.selectedColor.R + " " +
                            ", G =" +
                            ColorSelection.selectedColor.G + " " +
                            ", B =" +
                            ColorSelection.selectedColor.B + " " +
                            "]";
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            FileResource.level.ResetCanvas();
        }
    }
}
