using Microsoft.Win32;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocalizationFilesManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] Columns = { "Id", "en", "fr", "es", "comments" };
        DataTable Data = new DataTable();
        private void InitGrid(string[] _string)
        {
            foreach (string column in _string)
            {
                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Header = column;
                textColumn.Binding = new Binding(column);
                dataGrid.Columns.Add(textColumn);
            }
        }
        /*private void InitGrid(string[] _string)
        {

            foreach (string column in _string)
            {
                //Exemple pour ajouter une colonne à la grille
                DataGridTextColumn textColumn = new DataGridTextColumn();
                ////L'entête de la colonne


                textColumn.Header = column;

                ////le nom programmatique de la colonne
                textColumn.Binding = new Binding(column);

                ////l'ajout'
               /dataGrid.Columns.Add(textColumn);
               // Data.Columns.Add(column);
            }
            //dataGrid.ItemsSource = Data.DefaultView;
        }*/

        private void AddGrid()
        {

            Data.Rows.Add("gfd", "", "", "", "r");

            dataGrid.ItemsSource = Data.DefaultView;
        }

        public MainWindow()
        {
            InitializeComponent();

            InitGrid(Columns);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddGrid();
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ExportCSV(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.DefaultExt = ".csv";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter s = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < Columns.Length; i++)
                    {
                        s.WriteLine(Columns[i]);
                    }
                }
            }
        }
        private void ImportCSV(object sender, RoutedEventArgs e)
        {
            dataGrid.Columns.Clear();
            List<string> columns = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV file (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                string text = "";
                using (StreamReader s = new StreamReader(openFileDialog.FileName))
                {
                    while ((text = s.ReadLine()) != null)
                    {
                        columns.Add(text);
                    }

                    s.Close();
                }
                for (int i = 0; i < Columns.Length; i++)
                {
                    Columns[i] = columns[i];
                }
                InitGrid(Columns);
            }
        }
        private void ExportJSON(object sender, RoutedEventArgs e)
        {

        }
        private void ImportJSON(object sender, RoutedEventArgs e)
        {

        }
        private void ExportXML(object sender, RoutedEventArgs e)
        {

        }
        private void ImportXML(object sender, RoutedEventArgs e)
        {

        }
        private void ExportCSharp(object sender, RoutedEventArgs e)
        {

        }
        private void ExportCPlusPlus(object sender, RoutedEventArgs e)
        {

        }
    }
}