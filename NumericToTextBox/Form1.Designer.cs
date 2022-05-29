
namespace NumericToTextBox
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
            this.OnReadTextBox = new System.Windows.Forms.TextBox();
            this.InNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.InNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // OnReadTextBox
            // 
            this.OnReadTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.OnReadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OnReadTextBox.ForeColor = System.Drawing.Color.Teal;
            this.OnReadTextBox.Location = new System.Drawing.Point(12, 32);
            this.OnReadTextBox.Name = "OnReadTextBox";
            this.OnReadTextBox.ReadOnly = true;
            this.OnReadTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.OnReadTextBox.Size = new System.Drawing.Size(168, 38);
            this.OnReadTextBox.TabIndex = 0;
            // 
            // InNumber
            // 
            this.InNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InNumber.ForeColor = System.Drawing.Color.Teal;
            this.InNumber.Location = new System.Drawing.Point(12, 101);
            this.InNumber.Name = "InNumber";
            this.InNumber.Size = new System.Drawing.Size(168, 38);
            this.InNumber.TabIndex = 1;
            this.InNumber.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 166);
            this.Controls.Add(this.InNumber);
            this.Controls.Add(this.OnReadTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(208, 205);
            this.MinimumSize = new System.Drawing.Size(208, 205);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.InNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OnReadTextBox;
        private System.Windows.Forms.NumericUpDown InNumber;
    }
}

