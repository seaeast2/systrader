using System;
using System.Diagnostics;
using System.Globalization;
using systrader.Helpers;
using systrader.Data;
using systrader.View;

namespace systrader.ValueConverters
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/>  to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Create Login page or MainPage
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.MainPage:
                    return new MainPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
