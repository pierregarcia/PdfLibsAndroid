using PdfForms.Controls;
using PdfForms.ViewModels;
using Xamarin.Forms;

namespace PdfForms
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();

            var pdfControl = new PdfControl() 
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var layout = new StackLayout();
            layout.Children.Add(pdfControl);

            pdfControl.SetBinding(PdfControl.PdfPathProperty, "PdfPath");

            Content = layout;
        }
    }
}
