using Microsoft.Win32;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Reflection.PortableExecutable;
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
using static System.Net.Mime.MediaTypeNames;


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
        private void InitGrid()
        {
            Data.Columns.Add("id");
            Data.Columns.Add("en");
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Data.DefaultView;
        }

        int colIndex = 0;
        private void AddGrid(string text)
        {
            //  Data.Columns.Clear();
            //if (Data.Columns.Count == 0)
            //{
            //Data.Rows.Clear();
            //    InitGrid(Columns);

            //}
            Data.Columns.Add(text);
            //Data.Rows.Add();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Data.DefaultView;
        }

        private void SupLine()
        {
            if (Data.Rows.Count > 0)
            {
                Data.Rows.RemoveAt(0);
            }
        }

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
            InitGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddGrid();
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            SupLine();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddRow(string[] text)
        {
            Data.Rows.Add(text);
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
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < Data.Columns.Count; i++)
                    {
                        sb.Append(Data.Columns[i]);
                        if (i < Data.Columns.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    s.WriteLine(sb.ToString());
                    //foreach (DataRow dr in Data.Rows)
                    for (int y = 0; y < Data.Rows.Count; y++)
                    {
                        sb.Clear();
                        for (int i = 0; i < Data.Columns.Count; i++)
                        {
                            if (!Convert.IsDBNull(Data.Rows[y][i]))
                            {
                                string value = Data.Rows[y][i].ToString();
                                if (value.Contains(','))
                                {
                                    value = String.Format("\"{0}\"", value);
                                    sb.Append(value);
                                }
                                else
                                {
                                    sb.Append(Data.Rows[y][i].ToString());
                                }
                            }
                            if (i < Data.Columns.Count - 1)
                            {
                                sb.Append(",");
                            }
                        }
                        s.WriteLine(sb.ToString());
                    }
                    s.Close();
                }
            }
        }
        private void ImportCSV(object sender, RoutedEventArgs e)
        {
            Data.Rows.Clear();
            Data.Columns.Clear();
            dataGrid.Columns.Clear();
            List<string> columns = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV file (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                string text = "";
             
                using (StreamReader s = new StreamReader(openFileDialog.FileName))
                {
                    while (!s.EndOfStream)
                    {
                        string[] currentLine = s.ReadLine().Split(',');
                        if (Data.Columns.Count == currentLine.Length)
                        {
                            AddRow(currentLine);
                        }
                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            if (Data.Columns.Count < currentLine.Length)
                            {
                                AddGrid(currentLine[i]);
                            }
                        }
                        //Data.Rows.Add();
                    }
                    s.Close();
                }
            }
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|.xml";

            //Tester avec && si == pas fonctionnel
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    ds.Tables[0].WriteXml(sfd.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void ImportXML(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|.xml";

            //Tester avec && si == pas fonctionnel
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    XmlReader xmlFile = XmlReader.Create(ofd.FileName, new XmlReaderSettings());
                    ds.ReadXml(xmlFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private void ExportCSharp(object sender, RoutedEventArgs e)
        {
            ExportCS.ExportCSFunc(Data);
        }
        private void ExportCPlusPlus(object sender, RoutedEventArgs e)
        {

        }
    }
}