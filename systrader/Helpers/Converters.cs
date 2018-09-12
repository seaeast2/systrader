using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Globalization;

namespace systrader.Helpers
{
    // A Base value converter that allows direct XAML usage.
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private members
        /// <summary>
        /// A single static instance of this value converter.
        /// </summary>
        private static T mConverter = null;
        #endregion

        #region Markup Extension method
        /// <summary>
        /// Provide static instance of value converter
        /// </summary>
        /// <param name="serviceProvider"> The service provider </param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }
        #endregion

        #region Value Converter Methods
        /// <summary>
        /// The method to convert one type to another.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        /// <summary>
        /// The method to convert a value back to it's source type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        #endregion
    }
}
