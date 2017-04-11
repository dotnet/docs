using System; // Type
using System.Globalization; // CultureInfo
using System.IO; // MemoryStream
using System.Windows.Data; // IValueConverter
using System.Windows.Documents; // Section, TextRange
using System.Windows.Markup; // XamlReader

namespace FlowDocumentAnnotatedReader
{
    public class AnnotationDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert 64 bit binary data into an 8 bit byte array and load
            // it into a memory buffer
            byte[] data = System.Convert.FromBase64String(value as string);
            using (MemoryStream buffer = new MemoryStream(data))
            {
                // Convert memory buffer to object and return text
                Section section = (Section)XamlReader.Load(buffer);
                TextRange range = new TextRange(section.ContentStart, section.ContentEnd);
                return range.Text;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}