﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationFilesManager
{
    internal class ExportCS
    {

        static public void ExportCSFunc(DataTable _data)
        {
            Stream myStream;
            SaveFileDialog fileWriter = new SaveFileDialog();

            fileWriter.Filter = "CS|.cs";

            if (fileWriter.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(fileWriter.FileName))
                {

                    writer.WriteLine("int test = 0;");

                    writer.Close();
                }
            }
        }

    }
}
