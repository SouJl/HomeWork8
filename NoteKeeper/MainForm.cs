using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteKeeper
{
    
    public partial class MainForm : Form
    {
        NoteKeeperDatabase database;
        string filterType = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoteKeeper";
        }

        #region MenuItemClick

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = filterType;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new NoteKeeperDatabase(dlg.FileName);
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = filterType;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new NoteKeeperDatabase(dlg.FileName);
                database.Load();
                DataToListBox(database.GetList().Where(d => DateTime.Parse(d.Date).Date == dateTimeSelector.Value.Date).Select(n => n.Text).ToList());
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


        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            AboutProgram frm = new AboutProgram();
            frm.ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region MouseEnter/MouseLeave

        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.DarkSlateGray;
        }

        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.Teal;
        }

        private void buttonRemove_MouseEnter(object sender, EventArgs e)
        {
            buttonRemove.BackColor = Color.DarkSlateGray;
        }

        private void buttonRemove_MouseLeave(object sender, EventArgs e)
        {
            buttonRemove.BackColor = Color.Teal;
        }

        private void buttonClear_MouseEnter(object sender, EventArgs e)
        {
            buttonClear.BackColor = Color.DarkSlateGray;
        }

        private void buttonClear_MouseLeave(object sender, EventArgs e)
        {
            buttonClear.BackColor = Color.Teal;
        }

        #endregion

        #region ButtonClick

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                AddNoteForm frm = new AddNoteForm();
                Hide();
                frm.ShowDialog();
                Show();
                if (frm.NoteInfo != null)
                {
                    if (frm.NoteInfo != "")
                    {
                        database.Add(frm.NoteInfo, frm.DateInfo.Date.ToString());
                        DataToListBox(database.GetList().Where(d => DateTime.Parse(d.Date).Date == dateTimeSelector.Value.Date).Select(n => n.Text).ToList());
                    }
                    else
                    {
                        MessageBox.Show("Задайте текст заметки!", "NoteKeeper", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не задан файл!", "TrueFalseEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (database != null && database.Any())
            {
                if (notesListBox.SelectedItem != null)
                {
                    database.Remove(new Note
                    {
                        Text = notesListBox.SelectedItem.ToString(),
                        Date = dateTimeSelector.Value.Date.ToString()
                    });
                    DataToListBox(database.GetList().Where(d => DateTime.Parse(d.Date).Date == dateTimeSelector.Value.Date).Select(n => n.Text).ToList());
                }
                else
                {
                    MessageBox.Show("Не выбран элемент из списка", "NoteKeeper", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                notesListBox.Items.Clear();
                database.Clear();
            }
        }

        #endregion

        private void dateTimeSelector_ValueChanged(object sender, EventArgs e)
        {
            if (database != null && database.Any()) 
            {
                DataToListBox(database.GetList().Where(d => DateTime.Parse(d.Date).Date == dateTimeSelector.Value.Date).Select(n => n.Text).ToList());
            }                
        }
 
        void DataToListBox(List<string> notesText)
        {
            notesListBox.Items.Clear();
            int i = 1;
            foreach(var note in notesText) 
            {
                notesListBox.Items.Add($"{i++}) {note}");
            }
                
        }
    }
}
