using Microsoft.Win32;
using System.Data;
using System.IO;

namespace LocalizationFilesManager
{
    internal class ExportCS
    {

        static public void ExportCSFunc(DataTable _data)
        {
            SaveFileDialog fileWriter = new SaveFileDialog();

            fileWriter.Filter = "CS|*.cs";

            if (fileWriter.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(fileWriter.FileName))
                {

                    writer.WriteLine("using System.Globalization;\n");

                    writer.WriteLine("public enum Language");
                    writer.WriteLine("{");
                    for (int i = 1; i < _data.Columns.Count - 1; i++)
                    {
                        writer.WriteLine("    " + _data.Columns[i].ColumnName.ToUpper() + ",");
                    }
                    writer.WriteLine("}\n\n");

                    writer.WriteLine("public class LocalizationLanguage");
                    writer.WriteLine("{");
                    writer.WriteLine("    static Dictionary<string, Dictionary<Enum, string>> dictionaryWord = new Dictionary<string, Dictionary<Enum, string>>();\n");


                    writer.WriteLine("    static public void InitDictionary()");
                    writer.WriteLine("    {");



                    for (int i = 0; i < _data.Rows.Count; i++)
                    {
                        writer.WriteLine("        dictionaryWord.Add(\"" + _data.Rows[i].ItemArray[0].ToString() + "\", new Dictionary<Enum, string>);");
                        for (int j = 1; j < _data.Columns.Count - 1; j++)
                        {
                            writer.WriteLine("        dictionaryWord[\"" + _data.Rows[i].ItemArray[0].ToString() + "\"].Add( Language." + _data.Columns[j].ColumnName.ToUpper() + ", \"" + _data.Rows[i].ItemArray[j] +"\");");
                        }
                        writer.WriteLine("");
                    }

                    writer.WriteLine("    }");



                    writer.WriteLine("}");
                }
            }
        }

    }
}
