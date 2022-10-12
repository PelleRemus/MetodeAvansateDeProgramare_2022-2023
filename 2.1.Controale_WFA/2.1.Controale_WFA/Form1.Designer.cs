
namespace _2._1.Controale_WFA
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainDisplay = new System.Windows.Forms.PictureBox();
            this.mainButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDisplay
            // 
            this.mainDisplay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainDisplay.Image = ((System.Drawing.Image)(resources.GetObject("mainDisplay.Image")));
            this.mainDisplay.Location = new System.Drawing.Point(0, 0);
            this.mainDisplay.Name = "mainDisplay";
            this.mainDisplay.Size = new System.Drawing.Size(542, 400);
            this.mainDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainDisplay.TabIndex = 0;
            this.mainDisplay.TabStop = false;
            // 
            // mainButton
            // 
            this.mainButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.mainButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainButton.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainButton.ForeColor = System.Drawing.Color.White;
            this.mainButton.Location = new System.Drawing.Point(548, 169);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(222, 61);
            this.mainButton.TabIndex = 1;
            this.mainButton.Text = "New Game";
            this.mainButton.UseVisualStyleBackColor = false;
            this.mainButton.Click += new System.EventHandler(this.mainButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.mainButton);
            this.Controls.Add(this.mainDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainDisplay;
        private System.Windows.Forms.Button mainButton;
    }
}

