using Microsoft.Win32;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Net.Mail;
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
using System.Xml;
using CSVSTATE;
using GridState;


namespace LocalizationFilesManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] Columns = { "Id", "en", "fr", "es", "comments" };

        DataSet ds = new DataSet();
        DataTable Data = new DataTable();
        private void InitGrid(string[] _string)
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
                // dataGrid.Columns.Add(textColumn);
                Data.Columns.Add(column);
            }
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Data.DefaultView;
        }

        public MainWindow()
        {
            InitializeComponent();
            InitGrid(Columns);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (InputText.LineCount > 0)
            {
                GridClass.AddGrid(Data, dataGrid, InputText.Text);
            }
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            GridState.GridClass.SupLine(Data);
        }
        private void ExportCSV(object sender, RoutedEventArgs e)
        {
            CSV.ExportCSV(Data);
        }
        private void ImportCSV(object sender, RoutedEventArgs e)
        {
            CSV.ImportCSV(Data, dataGrid);
        }
        private void ExportJSON(object sender, RoutedEventArgs e)
        {
            Json.ExportJSON(Data);
        }
        private void ImportJSON(object sender, RoutedEventArgs e)
        {
            Json.ImportJSON(dataGrid, Data);
        }
        private void ExportXML(object sender, RoutedEventArgs e)
        {
            XML.ExportXML(Data);
        }

        private void ImportXML(object sender, RoutedEventArgs e)
        {
            XML.ImportXML(Data, dataGrid);
        }
        private void ExportCSharp(object sender, RoutedEventArgs e)
        {
            ExportCS.ExportCSFunc(Data);
        }
        private void ExportCPlusPlus(object sender, RoutedEventArgs e)
        {
            ExportCPP.ExportCPPFunc(Data);
        }
    }
}