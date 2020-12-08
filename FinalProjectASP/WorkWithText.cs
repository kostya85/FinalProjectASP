using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Xceed.Words.NET;

namespace FinalProjectASP
{
    public static class WorkWithText
    {
        public static string ParseWord(string path)
        {


            DocX doc = DocX.Load(path);
            string s = "";
            foreach (var e in doc.Paragraphs)
            {
                s += e.Text + "\n";
            }           
            return s;


        }
        public static string GetTXTData(string filename)
        {
            string result = File.ReadAllText(filename);
            foreach (var e in result)
            {
                if ((int)e == 65533)
                {
                    StreamReader reader = new StreamReader(filename, Encoding.GetEncoding(1251));
                    string str = reader.ReadToEnd();
                    reader.Dispose();
                    StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8);
                    writer.Write(str);
                    writer.Dispose();
                    break;

                }
            }
            return File.ReadAllText(filename);
        }
    }
}