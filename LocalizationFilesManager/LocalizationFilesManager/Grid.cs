using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GridState
{
    internal class GridClass
    {
        static public void AddGrid(DataTable _data, DataGrid _grid, string _text)
        {
            List<string> strings = new List<string>();

            for (int i = 0; i < _data.Columns.Count; i++)
            {
                strings.Add(_data.Columns[i].ColumnName);
            }
            bool index = false;
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i].ToString() == _text)
                {
                    index = true;
                }
            }

            if (index == false)
            {
                _data.Columns.Add(_text);

                _grid.ItemsSource = null;
                _grid.ItemsSource = _data.DefaultView;
            }
        }
       static public void AddRow(DataTable _data, DataGrid _grid, string[] _text)
        {
            //  Data.Columns.Clear();
            _data.Rows.Add(_text);

            _grid.ItemsSource = null;
            _grid.ItemsSource = _data.DefaultView;
        }

        static public void AddRow(DataTable _data, DataGrid _grid, string _text)
        {
            //  Data.Columns.Clear();
            _data.Rows.Add(_text);

            _grid.ItemsSource = null;
            _grid.ItemsSource = _data.DefaultView;
        }

        static public void SupLine(DataTable _data)
        {
            if (_data.Rows.Count > 0)
            {
                _data.Rows.RemoveAt(0);
            }
        }
    }
}
