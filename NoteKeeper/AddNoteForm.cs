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
    public partial class AddNoteForm : Form
    {
        public string NoteInfo { get; set; }

        public DateTime DateInfo { get; set; }

        public AddNoteForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            NoteInfo = noteInfo.Text;
            DateInfo = dateInfo.Value;
            Close();
        }

        private void buttonAddNew_MouseEnter(object sender, EventArgs e)
        {
            buttonAddNew.BackColor = Color.DarkSlateGray;
        }

        private void buttonAddNew_MouseLeave(object sender, EventArgs e)
        {
            buttonAddNew.BackColor = Color.Teal;
        }
    }
}
