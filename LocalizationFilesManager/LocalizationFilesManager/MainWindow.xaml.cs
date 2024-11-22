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

        /*private void AddGrid(string _text)
        {
            Data.Columns.Add(_text);

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Data.DefaultView;
        }
        private void AddRow(string[] _text)
        {
            //  Data.Columns.Clear();
            Data.Rows.Add(_text);

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Data.DefaultView;
        }

        private void SupLine()
        {
            if (Data.Rows.Count > 0)
            {
                Data.Rows.RemoveAt(0);
            }
        }*/

        public MainWindow()
        {
            InitializeComponent();


            /* foreach (string column in Columns)
             {
                 //Exemple pour ajouter une colonne à la grille
                 DataGridTextColumn textColumn = new DataGridTextColumn();
                 ////L'entête de la colonne


                 textColumn.Header = column;

                 ////le nom programmatique de la colonne
                 textColumn.Binding = new Binding(column);

                 ////l'ajout'
                 //dataGrid.Columns.Add(textColumn);
                 Data.Columns.Add(column);
             }*/
            //dataGrid.ItemsSource = Data.DefaultView;  
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

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            Json.ExportJSON(dataGrid);
        }
        private void ImportJSON(object sender, RoutedEventArgs e)
        {
            Json.ImportJSON(dataGrid);
        }
        private void ExportXML(object sender, RoutedEventArgs e)
        {
            XML.ExportXML(Data);
        }

        private void ImportXML(object sender, RoutedEventArgs e)
        {
            XML.ImportXML(Data, dataGrid);
            /*OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";

            List<string> IdList = new List<string>();
            List<string> enList = new List<string>();
            List<string> frList = new List<string>();
            List<string> esList = new List<string>();
            List<string> commentsList = new List<string>();

            if (ofd.ShowDialog() == true)
            {
                if (File.Exists(ofd.FileName))
                {
                    dataGrid.Columns.Clear();
                    using (XmlReader inputFile = XmlReader.Create(ofd.FileName))
                    {
                        try
                        {
                            while (inputFile.Read())
                            {
                                if (inputFile.IsStartElement())
                                {
                                    switch (inputFile.Name.ToString())
                                    {
                                        case "Id":
                                            IdList.Add(inputFile.ReadString());
                                            break;
                                        case "en":
                                            enList.Add(inputFile.ReadString());
                                            break;
                                        case "fr":
                                            frList.Add(inputFile.ReadString());
                                            break;
                                        case "es":
                                            esList.Add(inputFile.ReadString());
                                            break;
                                        case "comments":
                                            commentsList.Add(inputFile.ReadString());
                                            break;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    foreach (System.Data.DataRowView drv in dataGrid.ItemsSource)
                    {
                        foreach (string s in IdList)
                        {
                            drv[0] = s;
                        }
                        foreach (string s in enList)
                        {
                            drv[1] = s;
                        }
                        foreach (string s in frList)
                        {
                            drv[2] = s;
                        }
                        foreach (string s in esList)
                        {
                            drv[3] = s;
                        }
                        foreach (string s in commentsList)
                        {
                            drv[4] = s;
                        }
                    }
                }
            }*/
        }
        private void ExportCSharp(object sender, RoutedEventArgs e)
        {
            ExportCS.ExportCSFunc(Data);
        }
        private void ExportCPlusPlus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}