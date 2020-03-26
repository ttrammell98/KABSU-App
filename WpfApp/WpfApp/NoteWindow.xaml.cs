using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for NoteWindow.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {
        public event Action<string> Check;
        private string notes;
        public NoteWindow()
        {
            notes = "";
            InitializeComponent();
        }

        public NoteWindow(string notes)
        {
            this.notes = notes;
            InitializeComponent();
        }

        private void NoteWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Check != null)
                Check(uxNotesText.Text);
        }

        private void NoteWindow_Loaded(object sender, RoutedEventArgs e)
        {
            uxNotesText.Text = notes;
        }
    }
}
