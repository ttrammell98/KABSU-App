using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {
        private string canNum;
        private string code;
        private string breed;
        private string animalName;
        private string regNum;
        private string owner;
        private string id;
        private static int ROW_SPACING = 32;
        public RecordWindow()
        {
            InitializeComponent();
            Closing += RecordWindow_Closing;
        }

        public RecordWindow(string canNum, string code, string breed, string animalName, string regNum, string owner, string id)
        {
            this.canNum = canNum;
            this.code = code;
            this.breed = breed;
            this.animalName = animalName;
            this.regNum = regNum;
            this.owner = owner;
            this.id = id;
            InitializeComponent();
            uxCode.Text = code;
            uxBreed.Text = breed;
            uxAnimalName.Text = animalName;
            uxRegNum.Text = regNum;
            uxOwner.Text = owner;
            uxCanNum.Text = canNum;
            Closing += RecordWindow_Closing;
        }

        private void RecordWindow_Closing(object sender, CancelEventArgs e)
        {
            List<string> list = new List<string>();
            int textCount = 0;
            foreach(TextBox tb in FindVisualChildren<TextBox>(this))
            {
                list.Add(tb.Text);
                if (tb.Text != "" && tb.Parent != uxBottomGrid)
                    textCount++;
            }
            List<Record> recordList = new List<Record>();
            for(int i = 0; textCount > 0; i++)
            {
                if (list[i] != "" || list[i + ROW_SPACING] != "" || list[i + (ROW_SPACING * 2)] != "" || list[i + (ROW_SPACING * 3)] != "" || list[i + (ROW_SPACING * 4)] != "")
                {
                    recordList.Add(new Record(list[i], list[i + ROW_SPACING], list[i + (ROW_SPACING * 2)], list[i + (ROW_SPACING * 3)], list[i + (ROW_SPACING * 4)], id));
                    if (list[i] != "")
                        textCount--;
                    if (list[i + ROW_SPACING] != "")
                        textCount--;
                    if (list[i + (ROW_SPACING * 2)] != "")
                        textCount--;
                    if (list[i + (ROW_SPACING * 3)] != "")
                        textCount--;
                    if (list[i + (ROW_SPACING * 4)] != "")
                        textCount--;
                }
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
