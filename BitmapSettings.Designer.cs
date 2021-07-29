namespace Level_Editor
{
    partial class BitmapSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.defaultRadioBtn = new System.Windows.Forms.RadioButton();
            this.largeRadioBtn = new System.Windows.Forms.RadioButton();
            this.expandedRadioBtn = new System.Windows.Forms.RadioButton();
            this.applyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // defaultRadioBtn
            // 
            this.defaultRadioBtn.AutoSize = true;
            this.defaultRadioBtn.Location = new System.Drawing.Point(13, 25);
            this.defaultRadioBtn.Name = "defaultRadioBtn";
            this.defaultRadioBtn.Size = new System.Drawing.Size(102, 17);
            this.defaultRadioBtn.TabIndex = 0;
            this.defaultRadioBtn.TabStop = true;
            this.defaultRadioBtn.Text = "Default Size 5x5";
            this.defaultRadioBtn.UseVisualStyleBackColor = true;
            this.defaultRadioBtn.CheckedChanged += new System.EventHandler(this.defaultRadioBtn_CheckedChanged);
            // 
            // largeRadioBtn
            // 
            this.largeRadioBtn.AutoSize = true;
            this.largeRadioBtn.Location = new System.Drawing.Point(13, 66);
            this.largeRadioBtn.Name = "largeRadioBtn";
            this.largeRadioBtn.Size = new System.Drawing.Size(107, 17);
            this.largeRadioBtn.TabIndex = 1;
            this.largeRadioBtn.TabStop = true;
            this.largeRadioBtn.Text = "Large Size 10x10";
            this.largeRadioBtn.UseVisualStyleBackColor = true;
            this.largeRadioBtn.CheckedChanged += new System.EventHandler(this.largeRadioBtn_CheckedChanged);
            // 
            // expandedRadioBtn
            // 
            this.expandedRadioBtn.AutoSize = true;
            this.expandedRadioBtn.Location = new System.Drawing.Point(12, 107);
            this.expandedRadioBtn.Name = "expandedRadioBtn";
            this.expandedRadioBtn.Size = new System.Drawing.Size(128, 17);
            this.expandedRadioBtn.TabIndex = 2;
            this.expandedRadioBtn.TabStop = true;
            this.expandedRadioBtn.Text = "Expanded Size 20x20";
            this.expandedRadioBtn.UseVisualStyleBackColor = true;
            this.expandedRadioBtn.CheckedChanged += new System.EventHandler(this.expandedRadioBtn_CheckedChanged);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(52, 147);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 3;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // BitmapSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 182);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.expandedRadioBtn);
            this.Controls.Add(this.largeRadioBtn);
            this.Controls.Add(this.defaultRadioBtn);
            this.Name = "BitmapSettings";
            this.Text = "BitmapSettings";
            this.Load += new System.EventHandler(this.BitmapSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton defaultRadioBtn;
        private System.Windows.Forms.RadioButton largeRadioBtn;
        private System.Windows.Forms.RadioButton expandedRadioBtn;
        private System.Windows.Forms.Button applyBtn;
    }
}