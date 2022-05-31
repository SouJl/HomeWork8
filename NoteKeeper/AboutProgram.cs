using System.Windows.Forms;

namespace NoteKeeper
{
    public partial class AboutProgram : Form
    {
        public AboutProgram()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            fioLabel.Text = "Мельников Александр";
            versionLabel.Text = Application.ProductVersion;
            programInfoLabel.Text = "Программа NoteKeeper выполнена в рамках 8 практической работы 4 задания по курсу C# GeekBrains";
        }
    }
}
