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

            fileWriter.Filter = "CS|.cs";

            if (fileWriter.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(fileWriter.FileName))
                {

                    writer.WriteLine("using System.Globalization;");
                    writer.WriteLine("public class LocalizationLanguage");
                    writer.WriteLine("{");
                    for (int i = 0; i < _data.Columns.Count - 1; i++)
                    {
                        writer.WriteLine("  static Dictionary<string, List<string>> " + _data.Columns[i].ColumnName + "Word = new Dictionary<string, List<string>>();");
                    }

                    writer.WriteLine("  static public void InitDictionary()");
                    writer.WriteLine("  {");
                    writer.WriteLine("      dictionaryWord.Add(\"" + _data.Columns[1] + "\", new List<string>());");

                    writer.WriteLine("  }");



                    writer.WriteLine("}");
                }
            }
        }

    }
}
