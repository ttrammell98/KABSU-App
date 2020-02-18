using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using MySql.Data.MySqlClient;

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
        private static int ID_INDEX = 321;
        private static int ROW_SPACING = 32;
        private List<Record> recordList;
        private int oldRecordCount;
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
            oldRecordCount = 0;
            InitializeComponent();
            uxCode.Text = code;
            uxBreed.Text = breed;
            uxAnimalName.Text = animalName;
            uxRegNum.Text = regNum;
            uxOwner.Text = owner;
            uxCanNum.Text = canNum;
            Closing += RecordWindow_Closing;
            recordList = RetrieveRecords(code);
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
            recordList = new List<Record>();
            for(int i = 0; textCount > 0; i++)
            {
                if (list[i] != "" || list[i + ROW_SPACING] != "" || list[i + (ROW_SPACING * 2)] != "" || list[i + (ROW_SPACING * 3)] != "" || list[i + (ROW_SPACING * 4)] != "")
                {
                    recordList.Add(new Record(list[i], list[i + ROW_SPACING], list[i + (ROW_SPACING * 2)], list[i + (ROW_SPACING * 3)], list[i + (ROW_SPACING * 4)], list[ID_INDEX]));
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
            StoreRecords();
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
        private void StoreRecords()
        {
            string connectionString = "Server=localhost;Database=kabsu; User ID = appuser; Password = test; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    foreach(Record r in recordList)
                    {
                        if (oldRecordCount > 0)
                            oldRecordCount--;
                        else
                        {
                            using (var command = new MySqlCommand("kabsu.StoreData", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@ToFrom", r.ToFrom);
                                command.Parameters.AddWithValue("@Date", r.Date);
                                command.Parameters.AddWithValue("@Received", Convert.ToInt32(r.Rec));
                                command.Parameters.AddWithValue("@Shipped", Convert.ToInt32(r.Ship));
                                command.Parameters.AddWithValue("@Balance", Convert.ToInt32(r.Balance));
                                command.Parameters.AddWithValue("@AnimalID", r.AnimalId);

                                connection.Open();
                                int k = command.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to database.");
            }
        }

        private List<Record> RetrieveRecords(string id)
        {
            string connectionString = "Server=localhost;Database=kabsu; User ID = appuser; Password = test; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.RetrieveRecords", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AnimalID", id);
                        connection.Open();

                        var reader = command.ExecuteReader();

                        recordList = new List<Record>();
                        Record record;
                        while (reader.Read())
                        {
                            record = new Record(
                               reader.GetString(reader.GetOrdinal("ToFrom")),
                               reader.GetString(reader.GetOrdinal("Date")),
                               reader.GetInt32(reader.GetOrdinal("NumReceived")).ToString(),
                               reader.GetInt32(reader.GetOrdinal("NumShipped")).ToString(),
                               reader.GetInt32(reader.GetOrdinal("Balance")).ToString(), id);
                            recordList.Add(record);
                            oldRecordCount++;
                        }
                        return recordList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to database.");
                return new List<Record>();
            }
        }

        private void RecordWindow_Load(object sender, RoutedEventArgs e)
        {
            int textCount = 0;

            IEnumerable<TextBox> textBoxEnum = (IEnumerable<TextBox>)FindVisualChildren<TextBox>(this);
            List<TextBox> textBoxes = textBoxEnum.ToList<TextBox>();

            foreach (Record r in recordList)
            {
                textBoxes[textCount].Text = r.ToFrom;
                textBoxes[textCount + ROW_SPACING].Text = r.Date;
                textBoxes[textCount + (ROW_SPACING * 2)].Text = r.Rec;
                textBoxes[textCount + (ROW_SPACING * 3)].Text = r.Ship;
                textBoxes[textCount + (ROW_SPACING * 4)].Text = r.Balance;

                textCount++;

                if (textCount == 32)
                    textCount += 128;
            }
        }
    }
}
