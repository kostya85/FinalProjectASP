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

    public partial class Encipe : System.Web.UI.Page
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
                    DataError();
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
                        string path = Server.MapPath("Enciper\\");
                        if (File.Exists(path + FileUpload.FileName)) File.Delete(path + FileUpload.FileName);
                        FileUpload.SaveAs(path + FileUpload.FileName);

                        if (extension != ".txt") source = WorkWithText.ParseWord(path + FileUpload.FileName);
                        else
                        {
                            source = WorkWithText.GetTXTData(path + FileUpload.FileName);
                        }
                        if (string.IsNullOrEmpty(source))
                        {
                            FileError.Text = "Длина выбранного файла = 0!";
                            DataError();
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
                        DataError();
                    }
                }
                else
                {
                    FileError.Text = "Пожалуйста, выберите файл с расширением .txt или .docx!";
                    DataError();
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
                    DataError();
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
                        string path = Server.MapPath("Enciper\\");
                        if (File.Exists(path + KeyUpload.FileName)) File.Delete(path + KeyUpload.FileName);
                        KeyUpload.SaveAs(path + KeyUpload.FileName);

                        if (extension != ".txt") keytext = WorkWithText.ParseWord(path + KeyUpload.FileName);
                        else
                        {
                            keytext = WorkWithText.GetTXTData(path + KeyUpload.FileName);
                        }
                        if (string.IsNullOrEmpty(keytext))
                        {
                            KeyError.Text = "Длина выбранного файла = 0!";
                            DataError();
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
                        DataError();
                    }
                }
                else
                {
                    KeyError.Text = "Пожалуйста, выберите файл с расширением .txt или .docx!";
                    DataError();
                }
            }

            if (Text && HasKey)
            {
                data.DeciperData = Crypto.Encrypt(source, keytext);
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
                    DataError();
                }
            }

        }
       

        protected void SaveTXT_Click(object sender, EventArgs e)
        {
            try
            {
                if (data.DeciperData != default && data.EnciperData != default && data.Key != default)
                {
                    string path = Server.MapPath("Enciper\\Program\\");
                    File.WriteAllText(path + "AppData.txt", data.DeciperData, Encoding.UTF8);
                    Response.Redirect(@"/Enciper/Program/" + "AppData.txt");
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
                if (File.Exists(Server.MapPath("Enciper\\Program\\") + "AppDataDocx.docx")) File.Delete(Server.MapPath("Enciper\\Program\\") + "AppDataDocx.docx");
                string pathDocument = Server.MapPath("Enciper\\Program\\") + "AppDataDocx.docx";

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
                Response.Redirect(@"/Enciper/Program/" + "AppDataDocx.docx");
            }
            finally
            {

            }
        }

        protected void DeciperFileMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DeciperFileMode.SelectedIndex == 0)
            {
                SourceText.Visible = true;
                SourceText.ReadOnly = false;
                FileUpload.Visible = false;
                FileUpload.Enabled = false;
            }
            else
            {
                SourceText.Visible = false;
                SourceText.ReadOnly = true;
                FileUpload.Visible = true;
                FileUpload.Enabled = true;
            }
        }

        protected void DeciperKeyMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DeciperKeyMode.SelectedIndex == 0)
            {
                Key.Visible = true;
                Key.ReadOnly = false;
                KeyUpload.Visible = false;
                KeyUpload.Enabled = false;
            }
            else
            {
                Key.Visible = false;
                Key.ReadOnly = true;
                KeyUpload.Visible = true;
                KeyUpload.Enabled = true;
            }
        }
        public void DataError()
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