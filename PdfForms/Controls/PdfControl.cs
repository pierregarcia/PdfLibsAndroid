using System;
using Xamarin.Forms;

namespace PdfForms.Controls
{
    public class PdfControl : View
    {
        public static readonly BindableProperty PdfPathProperty = BindableProperty.Create(propertyName: nameof(PdfPath),
                returnType: typeof(string),
                declaringType: typeof(PdfControl),
                defaultValue: default(string));

        public string PdfPath
        {
            get { return (string)GetValue(PdfPathProperty); }
            set { SetValue(PdfPathProperty, value); }
        }
    }
}
