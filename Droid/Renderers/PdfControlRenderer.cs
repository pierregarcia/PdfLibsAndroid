using Android.Content;
using Com.Github.Barteksc.Pdfviewer;
using Com.Github.Barteksc.Pdfviewer.Util;
using PdfForms.Controls;
using PdfForms.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PdfControl), typeof(PdfControlRenderer))]
namespace PdfForms.Droid.Renderers
{
    public class PdfControlRenderer : ViewRenderer<PdfControl, PDFView>
    {
        PDFView _pdfView;
        public PdfControlRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<PdfControl> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                _pdfView = new PDFView(Context, null);
                SetNativeControl(_pdfView);
            }
            if (e.NewElement != null)
            {
                LoadPdf();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(PdfControl.PdfPath)) 
            {
                LoadPdf();
            }
        }

        private void LoadPdf() 
        {
            if (string.IsNullOrEmpty(Element.PdfPath)) 
            {
                return;
            }
            Control.FromFile(new Java.IO.File(Element.PdfPath)).DefaultPage(0).PageFitPolicy(FitPolicy.Both).Load();
        }
    }
}
