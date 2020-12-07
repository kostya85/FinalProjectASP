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
        static bool FileVar;
        static bool KeyVar;
        static Data data;
            protected void Page_Load(object sender, EventArgs e)
        {
            FileVar = true;
            KeyVar = true;
            Download.Enabled = false;
            SourceText.ReadOnly = false;
            FileUpload.Enabled = false;
            DecipeText.Visible = false;
            SaveTXT.Enabled = false;
            SaveDOCX.Enabled = false;
            SaveTXT.Visible = false;
            SaveDOCX.Visible = false;
            KeyUpload.Enabled = false;
            Key.ReadOnly = false;
            DownloadKey.Enabled = false;
            Download.Text = "Недоступно!";
            DownloadKey.Text = "Недоступно!";
            SourceText.Text = "Введите исходный текст";
            Key.Text = "Введите ключ";
        }

        

       

        protected void FileChooser_Click(object sender, EventArgs e)
        {
            if (DeciperFileMode.SelectedValue == "Input")
            {
                SourceText.Text = "Введите исходный текст";
                Download.Enabled = false;
                Download.Text = "Недоступно!";
                SourceText.ReadOnly = false;
                FileUpload.Enabled = false;
                FileVar = true;
            }
            else
            {
                SourceText.Text = "Недоступно!";
                Download.Enabled = true;
                Download.Text = "Загрузить файл";
                SourceText.ReadOnly = true;
                FileUpload.Enabled = true;
                FileVar = false;
            }
        }

        protected void KeyChooser_Click(object sender, EventArgs e)
        {
            if (DeciperKeyMode.SelectedValue == "Input")
            {
                Key.Text = "Введите ключ";
                KeyUpload.Enabled = false;
                DownloadKey.Text = "Недоступно!";
                Key.ReadOnly = false;
                DownloadKey.Enabled = false;
                KeyVar = true;
            }
            else
            {
                Key.Text = "Недоступно!";
                DownloadKey.Enabled = true;
                DownloadKey.Text = "Загрузить файл";
                Key.ReadOnly = true;
                KeyUpload.Enabled = true;
                KeyVar = false;
            }
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                string extension = System.IO.Path.GetExtension(FileUpload.FileName);
                if (extension == ".txt" || extension == ".docx")
                {
                    FileError.Text = "";
                    string path = Server.MapPath("Deciper\\");
                    if (File.Exists(path + FileUpload.FileName)) File.Delete(path + FileUpload.FileName);
                    FileUpload.SaveAs(path+FileUpload.FileName);
                    ParseWord(path + FileUpload.FileName);
                    data = new Data();
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
        void ParseWord(string path)
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
                    DecipeText.Visible = true;
                    DecipeText.Text = MainText;
                }

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