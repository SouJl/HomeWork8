using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteKeeper
{
    [Serializable]
    public class NoteKeeperDatabase
    {
        private string fileName;
        private List<Note> list;

        public int Count
        {
            get { return list.Count; }
        }

        public Note this[int index]
        {
            get { return list[index]; }
        }

        public NoteKeeperDatabase(string fileName)
        {
            this.fileName = fileName;
            list = new List<Note>();
        }

        public void Add(string text, string date)
        {
            list.Add(new Note(text, date));
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
            }
        }

        public void Remove(Note item)
        {
            if (item != null) 
            {
                list.Remove(list.Single(i => i.Date == item.Date && i.Text == item.Text));
            }
        }

        public bool Any() => list.Any();

        public List<Note> GetList() => list;

        public void Clear() => list.Clear();

        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Note>));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Note>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Note>));
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, list);
            fileStream.Close();
        }

        public void Save(string fileName)
        {
            this.fileName = fileName;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Note>));
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, list);
            fileStream.Close();
        }
    }
}
