using System.IO;
using System.Net;
using Foundation;
using PdfForms.Controls;
using PdfForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PdfControl), typeof(PdfControlRenderer))]
namespace PdfForms.iOS.Renderers
{
    public class PdfControlRenderer : ViewRenderer<PdfControl, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<PdfControl> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null)
            {
                // Cleanup
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
            string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(Element.PdfPath)));
            Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
            Control.ScalesPageToFit = true;
        }
    }
}
