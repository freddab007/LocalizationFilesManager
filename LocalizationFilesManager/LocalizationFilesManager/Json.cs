using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows;
using System.Data;
using System.Diagnostics;

namespace LocalizationFilesManager
{
    public class DataJson
    {
        public string Id { get; set; }
        public string en { get; set; }
        public string fr { get; set; }
        public string es { get; set; }
        public string comments { get; set; }
    }


    internal class Json
    {
        static public void ExportJSON(DataTable _data)
        {
            var data = _data;
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }

                File.WriteAllText(saveFileDialog.FileName, jsonString);
            }
        }

        static public void ImportJSON(DataGrid dataGrid, DataTable _data)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (!File.Exists(openFileDialog.FileName))
                {
                    Console.WriteLine(openFileDialog.FileName + "is not valide");
                    return;
                }

                var json = File.ReadAllText(openFileDialog.FileName);
               _data = JsonConvert.DeserializeObject<DataTable>(json);

               
                dataGrid.ItemsSource = null;


                if (_data != null)
                {
                    dataGrid.ItemsSource = _data.DefaultView;
                }
            }
        }
    }
}
