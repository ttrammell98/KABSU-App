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
        String term1;
        String term2;
        String term3;
        String term4;
        String termType1;
        String termType2;
        String termType3;
        String termType4;
        public SearchWindowResults(String term1, String term2, String term3, String term4, String type1, String type2, String type3, String type4)
        {
            this.term1 = term1;
            this.term2 = term2;
            this.term3 = term3;
            this.term4 = term4;
            termType1 = type1;
            termType2 = type2;
            termType3 = type3;
            termType4 = type4;
            InitializeComponent();
        }

    }
}
