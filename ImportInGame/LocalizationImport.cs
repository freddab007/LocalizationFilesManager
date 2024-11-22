using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace LocalizationWord
{
    public class LocalizationImport
    {
        public static Dictionary<string, Dictionary<string, string>> dictionaryWord = new Dictionary<string, Dictionary<string, string>>();
        public static List<string> language = new List<string>();
        public static void InitDictionaryCSV(string _path)
        {
            
            if (!_path.Contains(".csv"))
            {
                _path += ".csv";
            }
            using (StreamReader reader = new StreamReader(_path))
            {
                string[] languageText = reader.ReadLine().Split(";");
                for (int i = 1; i < languageText.Length; i++)
                {
                    language.Add(languageText[i]);
                }
                while (!reader.EndOfStream)
                {
                    string[] wordText = reader.ReadLine().Split(";");

                    dictionaryWord.Add(wordText[0], new Dictionary<string, string>());

                    for (int i = 1; i < wordText.Length; i++)
                    {
                        dictionaryWord[wordText[0]].Add(language[i - 1], wordText[i]);
                    }
                }
            }
        }
        public static void InitDictionaryXML(string _path)
        {
            if (!_path.Contains(".xml"))
            {
                _path += ".xml";
            }
            using (XmlReader inputFile = XmlReader.Create(_path))
            {
                bool newWord = false;
                string idText = "";
                while (inputFile.Read())
                {
                    string languagetext = inputFile.Name;
                    string valuetext = inputFile.ReadString();
                    if (inputFile.Depth == 1)
                    {
                        newWord = true;
                    }
                    else if (inputFile.Depth == 2)
                    {
                        if (valuetext.Length > 0)
                        {
                            if (newWord)
                            {
                                idText = valuetext;
                                dictionaryWord.Add(valuetext, new Dictionary<string, string>());
                                newWord = false;
                            }
                            else
                            {
                                if (!language.Contains(languagetext))
                                {
                                    language.Add(languagetext);
                                }
                                dictionaryWord[idText].Add(languagetext, valuetext);

                            }
                        }
                    }
                }
            }
        }
    }
}
