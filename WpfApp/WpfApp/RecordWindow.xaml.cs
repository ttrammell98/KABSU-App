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
        public RecordWindow()
        {
            InitializeComponent();
            Closing += RecordWindow_Closing;
        }

        public RecordWindow(string canNum, string code, string breed, string animalName, string regNum, string owner)
        {
            this.canNum = canNum;
            this.code = code;
            this.breed = breed;
            this.animalName = animalName;
            this.regNum = regNum;
            this.owner = owner;
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
            
        }
    }
}
