using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalseEditor
{
    public partial class Main : Form
    {
        TrueFalseDatabase database;
        string filterType = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

        public Main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        #region MenuItemClick

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = filterType;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
                database.Add("#1", true);
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                ShowInTextBox(database[0].Text);
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = filterType;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                ShowInTextBox(database[0].Text);
            }

        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Save();
            }
            else
            {
                MessageBox.Show("Отсутствуют данные для сохранения!", "TrueFalseEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = filterType;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    database.Save(dlg.FileName);
                }
            }
            else
            {
                MessageBox.Show("Отсутствуют данные для сохранения!", "TrueFalseEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ButtonClick

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Add($"#{database.Count + 1}", true);
                nudNumber.Maximum = database.Count;
                nudNumber.Value = database.Count;
            }
            else
            {
                MessageBox.Show("Не задан файл!", "TrueFalseEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database != null && database.Any())
            {
                database.Remove((int)nudNumber.Value - 1);
                if (nudNumber.Value > 1)
                    nudNumber.Value--;
                else
                    ShowInTextBox(database[(int)nudNumber.Value - 1].Text);
                nudNumber.Maximum = database.Count;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(database != null && database.Any()) 
            {
                database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = TrueFalseComboBox.SelectedIndex == 0 ? true : false;
            }
        }

        #endregion

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if(database!=null && database.Any()) 
            {
                switch (database[(int)nudNumber.Value - 1].TrueFalse)
                {
                    case true:
                        TrueFalseComboBox.SelectedIndex = 0;
                        break;
                    case false:
                        TrueFalseComboBox.SelectedIndex = 1;
                        break;
                }
                ShowInTextBox(database[(int)nudNumber.Value - 1].Text);
            }
            else 
            {
                nudNumber.Value = 0;
            }
        }
       
        private void AboutProgram_Click(object sender, EventArgs e)
        {
            AboutProgram frm = new AboutProgram();
            frm.ShowDialog();
        }

        private void ShowInTextBox(string txt) => tbQuestion.Text = txt;
    }
}
