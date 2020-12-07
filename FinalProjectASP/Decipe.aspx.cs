using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;
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
                            source = File.ReadAllText(path + FileUpload.FileName);
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
                        FileUpload.SaveAs(path + KeyUpload.FileName);

                        if (extension == ".docx") keytext = ParseWord(path + KeyUpload.FileName);
                        else
                        {
                            keytext = File.ReadAllText(path + KeyUpload.FileName);
                        }
                        if (string.IsNullOrEmpty(source))
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
                DecipeText.Text = Crypto.Decrypt(source, keytext);
            }
            
        }
        string ParseWord(string path)
        {
            object FileName = path;
            object rOnly = true;
            object SaveChanges = false;
            object MissingObj = System.Reflection.Missing.Value;

            Word.Application app = new Word.Application();
            Word.Document doc = null;
            Word.Range range = null;
            try
            {
                doc = app.Documents.Open(ref FileName, ref MissingObj, ref rOnly, ref MissingObj,
                ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj,
                ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj,
                ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj);

                object StartPosition = 0;
                object EndPositiojn = doc.Characters.Count;
                range = doc.Range(ref StartPosition, ref EndPositiojn);

                // Получение основного текста со страниц (без учёта сносок и колонтитулов)
                string MainText = (range == null || range.Text == null) ? null : range.Text;
                if (MainText != null)
                {
                    /* Обработка основного текста документа*/
                    return MainText;
                }
                return null;
                // Получение текста из нижних и верхних колонтитулов
                //foreach (Word.Section section in doc.Sections)
                //{
                //    // Нижние колонтитулы
                //    foreach (Word.HeaderFooter footer in section.Footers)
                //    {
                //        string FooterText = (footer.Range == null || footer.Range.Text == null) ? null : footer.Range.Text;
                //        if (FooterText != null)
                //        {
                //            /* Обработка текста */
                //        }
                //    }

                    // Верхние колонтитулы
                    //foreach (Word.HeaderFooter header in section.Headers)
                    //{
                    //    string HeaderText = (header.Range == null || header.Range.Text == null) ? null : header.Range.Text;
                    //    if (HeaderText != null)
                    //    {
                    //        /* Обработка текста */
                    //    }
                    //}
                //}
                // Получение текста сносок
                //if (doc.Footnotes.Count != 0)
                //{
                //    foreach (Word.Footnote footnote in doc.Footnotes)
                //    {
                //        string FooteNoteText = (footnote.Range == null || footnote.Range.Text == null) ? null : footnote.Range.Text;
                //        if (FooteNoteText != null)
                //        {
                //            /* Обработка текста */
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                /* Обработка исключений */
                return null;
            }
            finally
            {
                /* Очистка неуправляемых ресурсов */
                if (doc != null)
                {
                    doc.Close(ref SaveChanges);
                }
                if (range != null)
                {
                    Marshal.ReleaseComObject(range);
                    range = null;
                }
                if (app != null)
                {
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                    app = null;
                }
                
            }
        }
    }
}