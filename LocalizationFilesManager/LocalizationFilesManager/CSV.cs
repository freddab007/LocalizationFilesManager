using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data;
using GridState;

namespace CSVSTATE
{
    internal class CSV
    {
        static public void ExportCSV(DataTable _data)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.DefaultExt = ".csv";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter s = new StreamWriter(saveFileDialog.FileName))
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < _data.Columns.Count; i++)
                    {
                        sb.Append(_data.Columns[i]);
                        if (i < _data.Columns.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    s.WriteLine(sb.ToString());
                    //foreach (DataRow dr in Data.Rows)
                    for (int y = 0; y < _data.Rows.Count; y++)
                    {
                        sb.Clear();
                        for (int i = 0; i < _data.Columns.Count; i++)
                        {
                            if (!Convert.IsDBNull(_data.Rows[y][i]))
                            {
                                string value = _data.Rows[y][i].ToString();
                                if (value.Contains(','))
                                {
                                    value = String.Format("\"{0}\"", value);
                                    sb.Append(value);
                                }
                                else
                                {
                                    sb.Append(_data.Rows[y][i].ToString());
                                }
                            }
                            if (i < _data.Columns.Count - 1)
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
        static public void ImportCSV(DataTable _data, DataGrid _grid)
        {
            _data.Rows.Clear();
            _data.Columns.Clear();
            _grid.Columns.Clear();
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
                        if (_data.Columns.Count == currentLine.Length)
                        {
                            GridClass.AddRow(_data, _grid, currentLine);
                        }
                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            if (_data.Columns.Count < currentLine.Length)
                            {
                                GridClass.AddGrid(_data, _grid, currentLine[i]);
                            }
                        }
                        //Data.Rows.Add();
                    }
                    s.Close();
                }
            }
        }//
    }
}

