using Microsoft.Win32;
using System.Data;
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

namespace LocalizationFilesManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] Columns = { "Id", "en", "fr", "es", "comments" };

        DataSet ds = new DataSet();

        public MainWindow()
        {
            InitializeComponent();

            foreach (string column in Columns)
            {
                //Exemple pour ajouter une colonne à la grille
                DataGridTextColumn textColumn = new DataGridTextColumn();
                //L'entête de la colonne


                textColumn.Header = column;

                //le nom programmatique de la colonne
                textColumn.Binding = new Binding(column);

                //l'ajout'
                dataGrid.Columns.Add(textColumn);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ExportCSV(object sender, RoutedEventArgs e)
        {

        }
        private void ImportCSV(object sender, RoutedEventArgs e)
        {

        }
        private void ExportJSON(object sender, RoutedEventArgs e)
        {

        }
        private void ImportJSON(object sender, RoutedEventArgs e)
        {

        }
        private void ExportXML(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|.xml";

            //Tester avec && si == pas fonctionnel
            //if (sfd.ShowDialog().HasValue == sfd.ShowDialog().Value)
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

        }
        private void ExportCPlusPlus(object sender, RoutedEventArgs e)
        {

        }
    }
}