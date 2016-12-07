using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
// for adding click to  open external files 
using System.Diagnostics;
using System.Net;
//for creating pdf document 
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.IO;
using iTextSharp.text.pdf.parser;



namespace B_type2
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://lukeyscore.blogspot.in/?m=1");
            webBrowser2.Navigate("https://m.facebook.com/pg/lingayas2k1/");
            webBrowser3.Navigate("https://m.facebook.com/lingayasuni/");
            webBrowser4.Navigate("https://m.twitter.com/lingayasunivers");
           
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Process yourProcess = new Process();
            yourProcess.StartInfo.FileName = @"C:\Users\Harshit Yadav\Documents\buddy\build-Buddy-Desktop_Qt_5_6_0_MSVC2015_64bit-Debug\debug\Buddy.exe";

            yourProcess.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser4_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("front.pdf", FileMode.Create));
            doc.Open();
            Paragraph para = new Paragraph("This is the new pdf file");
            // code for inserting image  

            iTextSharp.text.Image logo =  iTextSharp.text.Image.GetInstance("im.png");
            logo.ScalePercent(50f);
            logo.SetAbsolutePosition(doc.PageSize.Width - 36f - 385f, doc.PageSize.Height - 36 - 400f);
          //  logo.ScaleToFit(50f, 100f);

            doc.Add(logo);

            //iTextSharp.text.Font fontTable = FontFactory.GetFont("Arial", 50, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            BaseFont bf = BaseFont.CreateFont(
                         BaseFont.TIMES_ROMAN,
                         BaseFont.CP1252,
                         BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 19.0f);

            para.Font = font;


            doc.Add(para);
            doc.Close();
            MetroFramework.MetroMessageBox.Show(this, "Your Front Page has been Successfully been generated", "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("C:\\Users\\Harshit Yadav\\Documents\\GitHub\\Buddy prototype\\B-type2\\B-type2\\bin\\Debug\\front.pdf");

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
           
            string filePath= "H:\\Harshit\\Harshit\\Studies\\College Studies\\Syllabus Second Year.pdf";
            string strtext = string.Empty;

            try
            {
                PdfReader reader = new PdfReader(filePath);
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                    String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                    s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                    strtext = strtext + s;
                    richTextBox1.Text = strtext;
                }
                reader.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error");
            }

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
