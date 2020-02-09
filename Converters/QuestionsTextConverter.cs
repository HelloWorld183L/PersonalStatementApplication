using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace PersonalStatementTool.Presentation2.Converters
{
    public class QuestionsTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine("Value = " + value);
            Debug.WriteLine("Parameter = " + parameter);
            return new object();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine(value);
            Debug.WriteLine(parameter);
            return new object();
        }
    }
}
