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
using GridState;
using System.Windows.Shapes;

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

        static public void ImportXML(DataTable _data, DataGrid _grid)
        {
            _data.Rows.Clear();
            _data.Columns.Clear();
            _grid.Columns.Clear();

            List<string> listValueRead = new List<string>();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";

            if (ofd.ShowDialog() == true)
            {
                if (File.Exists(ofd.FileName))
                {
                    List<string> column = new List<string>();
                    using (XmlReader inputFile = XmlReader.Create(ofd.FileName))
                    {
                        bool newWord = false;
                        int tempi = 0;
                        int temp = -1;
                        while (inputFile.Read())
                        {




                            if (inputFile.Depth == 1)
                            {
                                newWord = true;

                            }
                            else if (inputFile.Depth == 2)
                            {
                                string languagetext = inputFile.Name;
                                string valuetext = inputFile.ReadString();
                                /* if (!column.Contains(languagetext))
                                 {

                                         column.Add(languagetext);

                                 }*/

                                GridClass.AddGrid(_data, _grid, languagetext);

                                listValueRead.Add(valuetext);

                                if (newWord)
                                {
                                    GridClass.AddRow(_data, _grid, valuetext);
                                    
                                    temp++;
                                    newWord = false;

                                }
                            }

                        }
                        /*for (int i = 0; i < column.Count; i++)
                        {
                            GridClass.AddGrid(_data, _grid, column[i]);
                        }*/


                    }
                }
            }
            int index = 0;
            for (int i = 0; i < _data.Rows.Count; i++)
            {
                for (int y = 0; y < _data.Columns.Count; y++)
                {
                    _data.Rows[i][y] = listValueRead[index];
                    index++;
                }
            }

            _grid.ItemsSource = null;
            _grid.ItemsSource = _data.DefaultView;
        }
    }
}
