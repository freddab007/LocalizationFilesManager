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
        static public void ExportCSFunc(DataTable _data)
        {
            SaveFileDialog fileWriter = new SaveFileDialog();

            fileWriter.Filter = "CS|*.cs";

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
                    writer.WriteLine("    EN,");
                    writer.WriteLine("    FR,");
                    writer.WriteLine("};");

                    writer.WriteLine("class Localization");
                    writer.WriteLine("{");
                    writer.WriteLine("public:");

                    writer.WriteLine("    static map<std::string, map<Language, string>> mapWord;");

                    writer.WriteLine("    static void Init();");
                    writer.WriteLine("};");

                    writer.WriteLine("#endif");

                    writer.WriteLine("map < std::string, map< Language, string>> Localization::mapWord;");


                    writer.WriteLine("void Localization::Init()");
                    writer.WriteLine("{");

                    writer.WriteLine("    mapWord[\"en\"] = map<Language, string>();");
                    writer.WriteLine("    mapWord[\"en\"][EN] = \"test\";");
                    writer.WriteLine("}");
                }
            }
        }
    }
}
