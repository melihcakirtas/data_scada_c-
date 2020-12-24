using System;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
namespace Al_Ba
{
    public partial class log : UserControl
    {
        int a = 0;
        public log()
        {
            InitializeComponent();
            progressBar1.Visible = false;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            int i = 1;
            int i2 = 2;
            ws.Columns[1].ColumnWidth = 25;
            ws.Columns[2].ColumnWidth = 100;
            ws.Cells[1, 1] = "Time";
            ws.Cells[1, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 1].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkOrange;
            ws.Cells[1, 2] = "Log";
            ws.Cells[1, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 2].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkOrange;
            progressBar1.Visible = true;
            foreach (ListViewItem lvi in listView1.Items)
            {
                i = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[i2, i] = lvs.Text.ToString();
                    ws.Cells[i2, i].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    if (i == 1)
                        ws.Cells[i2, i].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbAzure;
                    if (i == 2)
                        ws.Cells[i2, i].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbAqua;
                    i++;
                }
                i2++;
                progressBar1.Value = (i2 / listView1.Items.Count) * 100;
            }
            progressBar1.Visible = false;
            app.Visible = true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string file = "log_file.txt";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filepath = path + "\\" + file;
            int i = 1, i2 = 1;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, file)))
            {
                outputFile.WriteLine("\tTime \t\t\t Log");
                foreach (ListViewItem lvi in listView1.Items)
                {
                    string write = null;
                    i = 1;
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        write += lvs.Text.ToString();
                        if (i == 1)
                            write += "\t|\t";
                        i++;
                    }
                    write = write.Replace("\n", String.Empty);
                    write = write.Replace("\r", String.Empty);
                    outputFile.WriteLine(write);
                    i2++;
                }
            }
            process1.StartInfo.FileName = filepath;
            process1.Start();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            int i = 1, i2 = 1;
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Log";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 8, XFontStyle.Bold);
            graph.DrawString("Time", font, XBrushes.Black,
            new XRect(50, 50, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString("Log", font, XBrushes.Black,
            new XRect(200, 50, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            foreach (ListViewItem lvi in listView1.Items)
            {
                string write = null;
                i = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    write = lvs.Text.ToString();
                    write = write.Replace("\n", String.Empty);
                    write = write.Replace("\r", String.Empty);
                    if (i == 1)
                        graph.DrawString(write, font, XBrushes.Black,
                        new XRect(25, 50 + i2 * 11, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    if (i == 2)
                        graph.DrawString(write, font, XBrushes.Black,
                        new XRect(150, 50 + i2 * 11, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    i++;
                }
                i2++;
                progressBar1.Value = (i2 / listView1.Items.Count) * 100;
            }
            string pdfFilename = "Logs.pdf";
            bool saved = false;
        resave:
            try
            {
                if (!saved)
                {
                    pdf.Save(pdfFilename);
                    Process.Start(pdfFilename);
                }
                else
                {
                    pdfFilename = "Logs(" + a + ").pdf";
                    pdf.Save(pdfFilename);
                    Process.Start(pdfFilename);
                }
            }
            catch (Exception)
            {
                a++;
                saved = true;
                goto resave;
            }
        }
    }
}