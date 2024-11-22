using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml;
using System.IO;
using System.Data;

namespace LocalizationFilesManager
{
    internal class XML
    {
        static public void ExportXML(DataTable _table)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";

            if (sfd.ShowDialog() == true)
            {
                using (XmlWriter outputFile = XmlWriter.Create(sfd.FileName))
                {
                    outputFile.WriteStartDocument();


                    outputFile.WriteStartElement("Localization");
                    foreach (System.Data.DataRow drv in _table.Rows)
                    {
                        outputFile.WriteStartElement("Word");
                        for (int i = 0; i < _table.Columns.Count; i++)
                        {
                            outputFile.WriteElementString(_table.Columns[i].ColumnName, drv[i].ToString());
                        }
                        outputFile.WriteEndElement(); //all paths
                    }
                    outputFile.WriteEndElement(); //all paths

                }
            }
        }

        //static public void ImportXML(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "XML|*.xml";

        //    List<string> IdList = new List<string>();
        //    List<string> enList = new List<string>();
        //    List<string> frList = new List<string>();
        //    List<string> esList = new List<string>();
        //    List<string> commentsList = new List<string>();

        //    if (ofd.ShowDialog() == true)
        //    {
        //        if (File.Exists(ofd.FileName))
        //        {
        //            //dataGrid.Columns.Clear();
        //            using (XmlReader inputFile = XmlReader.Create(ofd.FileName))
        //            {
        //                try
        //                {
        //                    while (inputFile.Read())
        //                    {
        //                        if (inputFile.IsStartElement())
        //                        {
        //                            switch (inputFile.Name.ToString())
        //                            {
        //                                case "Id":
        //                                    IdList.Add(inputFile.ReadString());
        //                                    break;
        //                                case "en":
        //                                    enList.Add(inputFile.ReadString());
        //                                    break;
        //                                case "fr":
        //                                    frList.Add(inputFile.ReadString());
        //                                    break;
        //                                case "es":
        //                                    esList.Add(inputFile.ReadString());
        //                                    break;
        //                                case "comments":
        //                                    commentsList.Add(inputFile.ReadString());
        //                                    break;
        //                            }
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message);
        //                }
        //            }
        //            foreach (System.Data.DataRowView drv in dataGrid.ItemsSource)
        //            {
        //                foreach (string s in IdList)
        //                {
        //                    drv[0] = s;
        //                }
        //                foreach (string s in enList)
        //                {
        //                    drv[1] = s;
        //                }
        //                foreach (string s in frList)
        //                {
        //                    drv[2] = s;
        //                }
        //                foreach (string s in esList)
        //                {
        //                    drv[3] = s;
        //                }
        //                foreach (string s in commentsList)
        //                {
        //                    drv[4] = s;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
