using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;
using Xceed.Words.NET;
namespace FinalProjectASP
{
    
    public partial class Decipe : System.Web.UI.Page
    {
       
        
        static Data data = new Data();
        
            protected void Page_Load(object sender, EventArgs e)
        {

            
            
        }

        

       

       
        

        protected void Deciper_Click(object sender, EventArgs e)
        {
            DecipeText.Text = "";
            bool Text = false;
            bool HasKey = false;
            string source = null;
            string keytext = null;
            if (DeciperFileMode.SelectedValue == "Input")
            {
                source = SourceText.Text;
                if (!string.IsNullOrEmpty(source))
                {
                    data.EnciperData = source;
                    Text = true;
                }
                else
                {
                    FileError.Text = "Вы не ввели текст!";
                }

            }
            else
            {
                if (FileUpload.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(FileUpload.FileName);
                    if (extension == ".txt" || extension == ".docx")
                    {
                        FileError.Text = "";
                        string path = Server.MapPath("Deciper\\");
                        if (File.Exists(path + FileUpload.FileName)) File.Delete(path + FileUpload.FileName);
                        FileUpload.SaveAs(path + FileUpload.FileName);
                        
                        if (extension == ".docx") source = ParseWord(path + FileUpload.FileName);
                        else
                        {
                            source = GetTXTData(path + FileUpload.FileName);
                        }
                        if (string.IsNullOrEmpty(source))
                        {
                            FileError.Text = "Длина выбранного файла = 0!";
                        }
                        else
                        {
                            
                            data.EnciperData = source;
                            Text = true;
                        }
                        if (File.Exists(path + FileUpload.FileName)) File.Delete(path + FileUpload.FileName);
                    }
                    else
                    {
                        FileError.Text = "Пожалуйста, выберите файл с расширением .txt или .docx!";
                    }
                }
                else
                {
                    FileError.Text = "Пожалуйста, выберите файл с расширением .txt или .docx!";
                }
            }

            if (DeciperKeyMode.SelectedValue == "Input")
            {
                keytext = Key.Text;
                if (!string.IsNullOrEmpty(keytext))
                {
                    data.Key = keytext;
                    HasKey = true;
                }
                else
                {
                    KeyError.Text = "Вы не ввели текст!";
                }

            }
            else
            {
                if (KeyUpload.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(KeyUpload.FileName);
                    if (extension == ".txt" || extension == ".docx")
                    {
                        KeyError.Text = "";
                        string path = Server.MapPath("Deciper\\");
                        if (File.Exists(path + KeyUpload.FileName)) File.Delete(path + KeyUpload.FileName);
                        KeyUpload.SaveAs(path + KeyUpload.FileName);

                        if (extension == ".docx") keytext = ParseWord(path + KeyUpload.FileName);
                        else
                        {
                            keytext = GetTXTData(path + KeyUpload.FileName);
                        }
                        if (string.IsNullOrEmpty(keytext))
                        {
                            KeyError.Text = "Длина выбранного файла = 0!";
                        }
                        else
                        {
                            
                            data.Key = keytext;
                            HasKey = true;
                           
                        }
                        if (File.Exists(path + KeyUpload.FileName)) File.Delete(path + KeyUpload.FileName);
                    }
                    else
                    {
                        KeyError.Text = "Пожалуйста, выберите файл с расширением .txt или .docx!";
                    }
                }
                else
                {
                    KeyError.Text = "Пожалуйста, выберите файл с расширением .txt или .docx!";
                }
            }

            if (Text && HasKey)
            {
                data.DeciperData= Crypto.Decrypt(source, keytext);
                if (data.DeciperData != null)
                {
                    DecipeText.Text = data.DeciperData;
                    SaveDOCX.Visible = true;
                    SaveDOCX.Enabled = true;
                    SaveTXT.Enabled = true;
                    SaveTXT.Visible = true;
                }
                else
                {
                    DecipeText.Text = $"К сожалению возникла ошибка. Проверьте все ли условия Вы выполнили!\n" +
                        $"Возможно:\n" +
                        $"1. Длина ключа или сообщения равна 0\n" +
                        $"2. Длина ключа больше длины сообщения\n" +
                        $"3. В ключе содержаться символы, не входящие в состав русского алфавита";
                    SaveDOCX.Visible = false;
                    SaveDOCX.Enabled = false;
                    SaveTXT.Enabled = false;
                    SaveTXT.Visible = false;
                }
            }
            
        }
        string ParseWord(string path)
        {

            DocX doc = DocX.Load(path);
            string s = "";
            foreach (var e in doc.Paragraphs)
            {
                s += e.Text + "\n";
            }
            return s;
        }

        protected void SaveTXT_Click(object sender, EventArgs e)
        {
            try
            {
                if (data.DeciperData != default && data.EnciperData != default && data.Key != default)
                {
                    string path = Server.MapPath("Deciper\\Program\\");
                    File.WriteAllText(path+"AppData.txt", data.DeciperData, Encoding.UTF8);
                    Response.Redirect(@"/Deciper/Program/" + "AppData.txt");
                }
            }
            finally
            {

            }
        }

        protected void SaveDOCX_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Server.MapPath("Deciper\\Program\\") + "AppDataDocx.docx")) File.Delete(Server.MapPath("Deciper\\Program\\") + "AppDataDocx.docx");
                string pathDocument = Server.MapPath("Deciper\\Program\\") + "AppDataDocx.docx";

                // создаём документ
                DocX document = DocX.Create(pathDocument);

                

                // вставляем параграф и передаём текст
                document.InsertParagraph(data.DeciperData).
                         // устанавливаем шрифт
                         Font("Calibri").
                         // устанавливаем размер шрифта
                         FontSize(36);

                // сохраняем документ
                document.Save();
                Response.Redirect(@"/Deciper/Program/" + "AppDataDocx.docx");
            }
            finally
            {

            }
        }
        string GetTXTData(string filename)
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