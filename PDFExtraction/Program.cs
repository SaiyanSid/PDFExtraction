using System;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

namespace PDFExtraction
{

    class Program
    {

        static void Main(string[] args)
        {

            StringBuilder sb = new StringBuilder();

            string file = @"C:/Users/siddhantk/Downloads/sampledatatable.pdf";
            using PdfReader reader = new PdfReader(file);
            {
                for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
                {
                    ITextExtractionStrategy stratergy = new SimpleTextExtractionStrategy();
                    string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, stratergy);
                    text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                        sb.Append(text);
                }
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
}
