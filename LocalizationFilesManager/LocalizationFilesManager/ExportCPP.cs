using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationFilesManager
{
    internal class ExportCPP
    {
        static public void ExportCPPFunc(DataTable _data)
        {
            SaveFileDialog fileWriter = new SaveFileDialog();

            fileWriter.Filter = "HPP|*.hpp";

            if (fileWriter.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(fileWriter.FileName))
                {
                    writer.WriteLine("# ifndef Localization_H_");
                    writer.WriteLine("#define Localization_H_");


                    writer.WriteLine("# include <iostream>");
                    writer.WriteLine("# include <string>");
                    writer.WriteLine("# include <map>");

                    writer.WriteLine("using namespace std;");
                    writer.WriteLine("enum Language");
                    writer.WriteLine("{");
                    for (int i = 1; i < _data.Columns.Count - 1; i++)
                    {
                        writer.WriteLine("    " + _data.Columns[i].ColumnName.ToUpper() + ",");
                    }
                    writer.WriteLine("};");

                    writer.WriteLine("class Localization");
                    writer.WriteLine("{");
                    writer.WriteLine("public:");

                    writer.WriteLine("    static map<std::string, map<Language, string>> mapWord;");

                    writer.WriteLine("    static void Init();");
                    writer.WriteLine("};");

                    writer.WriteLine("map < std::string, map< Language, string>> Localization::mapWord;");


                    writer.WriteLine("void Localization::Init()");
                    writer.WriteLine("{");

                    for (int i = 0; i < _data.Rows.Count; i++)
                    {
                        writer.WriteLine("        mapWord[\"" + _data.Rows[i].ItemArray[0].ToString() + "\"] = map<Language, string>();");
                        for (int j = 1; j < _data.Columns.Count - 1; j++)
                        {
                            writer.WriteLine("        mapWord[\"" + _data.Rows[i].ItemArray[0].ToString() + "\"][" + _data.Columns[j].ColumnName.ToUpper() + "] = \"" + _data.Rows[i].ItemArray[j] + "\";");
                        }
                        writer.WriteLine("");
                    }
                    writer.WriteLine("}");

                    writer.WriteLine("#endif");
                }
            }
        }
    }
}
