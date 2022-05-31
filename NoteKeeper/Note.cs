using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeper
{
    public class Note
    {
        public string Text { get; set; }

        public string Date { get; set; }
        public Note() { }
        public Note(string text, string date) 
        {
            Text = text;
            Date = date;
        }
    }
}
