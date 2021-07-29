using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Level_Editor.Framework.File_Management;

namespace Level_Editor
{
    public partial class BitmapSettings : Form
    {
        public int width;
        public int height;
        private bool sizeSelected;

        public BitmapSettings()
        {
            InitializeComponent();
        }

        private void BitmapSettings_Load(object sender, EventArgs e)
        {
            this.Focus();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CenterToParent();
            this.defaultRadioBtn.Checked = false;

            sizeSelected = false;
        }

        private void defaultRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            SetBitMapSize(5, 5, defaultRadioBtn);
        }

        private void largeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            SetBitMapSize(10, 10, largeRadioBtn);
        }

        private void expandedRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            SetBitMapSize(20, 20, expandedRadioBtn);
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            if (!sizeSelected)
            {
                MessageBox.Show("Please select a size");
            }
            else
            {
                FileResource.CreateFile(width, height);
                Debug.WriteLine(FileResource.currentBitmap.Size);
                this.Close();
            }               
        }

        private void SetBitMapSize(int _width, int _height, RadioButton tempRadioBtn)
        {
            if (tempRadioBtn.Checked)
            {
                width = _width;
                height = _height;
                sizeSelected = true;
            }
        }
    }
}
