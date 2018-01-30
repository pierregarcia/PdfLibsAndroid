using System;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace PdfForms.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private string _pdfFilePath;
        private string _pdfFileName = "thePDFDocument.pdf";
        private WebClient _webClient = new WebClient();

        public MainViewModel()
        {
            DownloadPDFDocument("https://transittracker.nellc.com/schedules/PE2_PE5.pdf");
        }

        private string _pdfPath;
        public string PdfPath
        {
            get { return _pdfPath; }
            set
            {
                _pdfPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PdfPath)));
            }
        }

        private void DownloadPDFDocument(string pdfUrl)
        {
            var path = _documentsPath + "/PDF";
            _pdfFilePath = Path.Combine(path, _pdfFileName);

            // Check if the PDFDirectory Exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            _webClient.DownloadDataCompleted += OnPDFDownloadCompleted;
            var url = new Uri(pdfUrl);
            _webClient.DownloadDataAsync(url);
        }

        private void OnPDFDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error);
                return;
            }

            var pdfBytes = e.Result;
            File.WriteAllBytes(_pdfFilePath, pdfBytes);

            if (File.Exists(_pdfFilePath))
            {
                PdfPath = _pdfFilePath;
            }
        }
    }
}
