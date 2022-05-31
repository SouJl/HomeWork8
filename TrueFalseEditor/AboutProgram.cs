﻿using System.Windows.Forms;

namespace TrueFalseEditor
{
    public partial class AboutProgram : Form
    {
        public AboutProgram()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            fioLabel.Text = "Мельников Александр";
            versionLabel.Text = Application.ProductVersion;
            programInfoLabel.Text = "Программа TrueFalseEditor выполнена в рамках 8 практической работы по курсу C# GeekBrains";
        }
    }
}
