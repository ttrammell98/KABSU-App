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
    /// Interaction logic for SearchWindowResults.xaml
    /// </summary>
    public partial class SearchWindowResults : Window
    {
        private string owner = "*";
        private string breed = "*";
        private string animalName = "*";
        private string code = "*";
        private string canNum = "*";
        private string town = "*";
        private string state = "*";
        public SearchWindowResults(String term1, String term2, String term3, String term4, String type1, String type2, String type3, String type4)
        {

            setTerm(type1, term1);
            setTerm(type2, term2);
            setTerm(type3, term3);
            setTerm(type4, term4);

            SearchTerm st = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            SearchResults sr = new SearchResults();
            InitializeComponent();
            List<SearchResult> results = sr.retrieveData(st);
            uxSearchResults.ItemsSource = results;
            //uxSearchResults.Columns[0].Header = "TEST";
        }

        void setTerm(string type, string term)
        {
            switch (type)
            {
                case "Owner":
                    owner = term;
                    break;
                case "Breed":
                    breed = term;
                    break;
                case "Animal Name":
                    animalName = term;
                    break;
                case "Code":
                    code = term;
                    break;
                case "Can #":
                    canNum = term;
                    break;
                case "Town":
                    town = term;
                    break;
                case "State":
                    state = term;
                    break;
            }
        }

    }
}
