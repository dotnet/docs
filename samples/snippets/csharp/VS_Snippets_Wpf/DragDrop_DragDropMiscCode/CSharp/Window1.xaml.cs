using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Text;

namespace DragDropMiscCode
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1() {
            InitializeComponent(); string utf8DataFormat = typeof(string).FullName;

            ClipboardMethods();
        }

        // Various ways to create a data object...
        void CreateDataObject()
        {
            // Create a new data object using simple constructor; data format is chosen automatically.
            {
                // <Snippet_DragDrop_CreateDataObject_Simple>
                string stringData = "Some string data to store...";
                DataObject dataObject = new DataObject(stringData);
                // </Snippet_DragDrop_CreateDataObject_Simple>
            }
            {
                // <Snippet_DragDrop_CreateDataObject_Simple_Condensed>
                DataObject dataObject = new DataObject("Some string data to store...");
                // </Snippet_DragDrop_CreateDataObject_Simple_Condensed>
            }

            // Create a new data object using constructor, specifying data format via string (provided by DataFormats).
            {
                // <Snippet_DragDrop_CreateDataObject_TypeString>
                string stringData = "Some string data to store...";
                string dataFormat = DataFormats.UnicodeText;
                DataObject dataObject = new DataObject(dataFormat, stringData);
                // </Snippet_DragDrop_CreateDataObject_TypeString>
            }
            {
                // <Snippet_DragDrop_CreateDataObject_TypeString_Condensed>
                DataObject dataObject = new DataObject(DataFormats.UnicodeText, "Some string data to store...");
                // </Snippet_DragDrop_CreateDataObject_TypeString_Condensed>
            }

            // Create a new data object using constructor, specifying data format via type.
            {
                // <Snippet_DragDrop_CreateDataObject_Type>
                string stringData = "Some string data to store...";
                Type dataFormat = stringData.GetType();
                DataObject dataObject = new DataObject(dataFormat, stringData);
                // </Snippet_DragDrop_CreateDataObject_Type>
            }
            {
                // <Snippet_DragDrop_CreateDataObject_Type_Condensed>
                DataObject dataObject = new DataObject("".GetType(), "Some string data to store...");
                // </Snippet_DragDrop_CreateDataObject_Type_Condensed>
            }

            // Create a new data object using constructor, no autoconvert.
            {
                // <Snippet_DragDrop_CreateDataObject_AutoConvert>
                string stringData = "Some string data to store...";
                string dataFormat = DataFormats.Text;
                bool autoConvert = false;
                DataObject dataObject = new DataObject(dataFormat, stringData, autoConvert);
                // </Snippet_DragDrop_CreateDataObject_AutoConvert>
            }
            {
                // <Snippet_DragDrop_CreateDataObject_AutoConvert_Condensed>
                DataObject dataObject = new DataObject(DataFormats.Text, "Some string data to store...", false);
                // </Snippet_DragDrop_CreateDataObject_AutoConvert_Condensed>
            }
        }

        void StoreMultipleFormats()
        {
            // Storing a few differnet text encodings in a data object...
            {
                // <Snippet_DragDrop_StoreMultipleFormats>
                DataObject dataObject = new DataObject();
                string sourceData = "Some string data to store...";

                // Encode the source string into Unicode byte arrays.
                byte[] unicodeText = Encoding.Unicode.GetBytes(sourceData); // UTF-16
                byte[] utf8Text = Encoding.UTF8.GetBytes(sourceData);
                byte[] utf32Text = Encoding.UTF32.GetBytes(sourceData);

                // The DataFormats class does not provide data format fields for denoting
                // UTF-32 and UTF-8, which are seldom used in practice; the following strings
                // will be used to identify these "custom" data formats.
                string utf32DataFormat = "UTF-32";
                string utf8DataFormat  = "UTF-8";

                // Store the text in the data object, letting the data object choose
                // the data format (which will be DataFormats.Text in this case).
                dataObject.SetData(sourceData);
                // Store the Unicode text in the data object.  Text data can be automatically
                // converted to Unicode (UTF-16 / UCS-2) format on extraction from the data object;
                // Therefore, explicitly converting the source text to Unicode is generally unnecessary, and
                // is done here as an exercise only.
                dataObject.SetData(DataFormats.UnicodeText, unicodeText);
                // Store the UTF-8 text in the data object...
                dataObject.SetData(utf8DataFormat, utf8Text);
                // Store the UTF-32 text in the data object...
                dataObject.SetData(utf32DataFormat, utf32Text);
                // </Snippet_DragDrop_StoreMultipleFormats>
            }
        }

        void QueryDataFormats()
        {
            // Querying for data formats with GetDataPresent...
            {
                // <Snippet_DragDrop_QueryDataFormats_String>
                DataObject dataObject = new DataObject("Some string data to store...");

                // Query for the presence of Text data in the data object, by a data format descriptor string.
                // In this overload of GetDataPresent, the method will return true both for native data formats
                // and when the data can automatically be converted to the specifed format.

                // In this case, string data is present natively, so GetDataPresent returns "true".
                string textData = null;
                if (dataObject.GetDataPresent(DataFormats.StringFormat))
                {
                    textData = dataObject.GetData(DataFormats.StringFormat) as string;
                }

                // In this case, the Text data in the data object can be autoconverted to
                // Unicode text, so GetDataPresent returns "true".
                byte[] unicodeData = null;
                if (dataObject.GetDataPresent(DataFormats.UnicodeText))
                {
                    unicodeData = dataObject.GetData(DataFormats.UnicodeText) as byte[];
                }
                // </Snippet_DragDrop_QueryDataFormats_String>
            }

            {
                // <Snippet_DragDrop_QueryDataFormats_Type>
                DataObject dataObject = new DataObject("Some string data to store...");

                // Query for the presence of String data in the data object, by type.  In this overload
                // of GetDataPresent, the method will return true both for native data formats
                // and when the data can automatically be converted to the specifed format.

                // In this case, the Text data present in the data object can be autoconverted
                // to type string (also represented by DataFormats.String), so GetDataPresent returns "true".
                string stringData = null;
                if (dataObject.GetDataPresent(typeof(string)))
                {
                    stringData = dataObject.GetData(DataFormats.Text) as string;
                }
                // </Snippet_DragDrop_QueryDataFormats_Type>
            }
            {
                // <Snippet_DragDrop_QueryDataFormats_Autoconvert>
                DataObject dataObject = new DataObject("Some string data to store...");

                // Query for the presence of Text data in the data object, by data format descriptor string,
                // and specifying whether auto-convertible data formats are acceptable.

                // In this case, Text data is present natively, so GetDataPresent returns "true".
                string textData = null;
                if (dataObject.GetDataPresent(DataFormats.Text, false /* Auto-convert? */))
                {
                    textData = dataObject.GetData(DataFormats.Text) as string;
                }

                // In this case, the Text data in the data object can be autoconverted to
                // Unicode text, but it is not available natively, so GetDataPresent returns "false".
                byte[] unicodeData = null;
                if (dataObject.GetDataPresent(DataFormats.UnicodeText, false /* Auto-convert? */))
                {
                    unicodeData = dataObject.GetData(DataFormats.UnicodeText) as byte[];
                }

                // In this case, the Text data in the data object can be autoconverted to
                // Unicode text, so GetDataPresent returns "true".
                if (dataObject.GetDataPresent(DataFormats.UnicodeText, true /* Auto-convert? */))
                {
                    unicodeData = dataObject.GetData(DataFormats.UnicodeText) as byte[];
                }
                // </Snippet_DragDrop_QueryDataFormats_Autoconvert>
            }
        }

        void GetAllDataFormats()
        {
            {
                // <Snippet_DragDrop_GetAllDataFormats>
                DataObject dataObject = new DataObject("Some string data to store...");

                // Get an array of strings, each string denoting a data format
                // that is available in the data object.  This overload of GetDataFormats
                // returns all available data formats, native and auto-convertible.
                string[] dataFormats = dataObject.GetFormats();

                // Get the number of data formats present in the data object, including both
                // auto-convertible and native data formats.
                int numberOfDataFormats = dataFormats.Length;

                // To enumerate the resulting array of data formats, and take some action when
                // a particular data format is found, use a code structure similar to the following.
                foreach (string dataFormat in dataFormats)
                {
                    if (dataFormat == DataFormats.Text)
                    {
                        // Take some action if/when data in the Text data format is found.
                        break;
                    }
                    else if(dataFormat == DataFormats.StringFormat)
                    {
                        // Take some action if/when data in the string data format is found.
                        break;
                    }
                }
                // </Snippet_DragDrop_GetAllDataFormats>
            }

            {
                // <Snippet_DragDrop_GetAllDataFormats_NativeOnly>
                DataObject dataObject = new DataObject("Some string data to store...");

                // Get an array of strings, each string denoting a data format
                // that is available in the data object.  This overload of GetDataFormats
                // accepts a Boolean parameter inidcating whether to include auto-convertible
                // data formats, or only return native data formats.
                string[] dataFormats = dataObject.GetFormats(false /* Include auto-convertible? */);

                // Get the number of native data formats present in the data object.
                int numberOfDataFormats = dataFormats.Length;

                // To enumerate the resulting array of data formats, and take some action when
                // a particular data format is found, use a code structure similar to the following.
                foreach (string dataFormat in dataFormats)
                {
                    if (dataFormat == DataFormats.Text)
                    {
                        // Take some action if/when data in the Text data format is found.
                        break;
                    }
                }
                // </Snippet_DragDrop_GetAllDataFormats_NativeOnly>
            }
        }

        void GetSpecificDataFormat()
        {
            {
                // <Snippet_DragDrop_GetSpecificDataFormat>
                DataObject dataObject = new DataObject("Some string data to store...");

                string desiredFormat = DataFormats.UnicodeText;
                byte[] data = null;

                // Use the GetDataPresent method to check for the presence of a desired data format.
                // This particular overload of GetDataPresent looks for both native and auto-convertible
                // data formats.
                if (dataObject.GetDataPresent(desiredFormat))
                {
                    // If the desired data format is present, use one of the GetData methods to retrieve the
                    // data from the data object.
                    data = dataObject.GetData(desiredFormat) as byte[];
                }
                // </Snippet_DragDrop_GetSpecificDataFormat>
            }

            {
                // <Snippet_DragDrop_GetSpecificDataFormat_Native>
                DataObject dataObject = new DataObject("Some string data to store...");

                string desiredFormat = DataFormats.UnicodeText;
                bool noAutoConvert = false;
                byte[] data = null;

                // Use the GetDataPresent method to check for the presence of a desired data format.
                // The autoconvert parameter is set to false to filter out auto-convertible data formats,
                // returning true only if the specified data format is available natively.
                if (dataObject.GetDataPresent(desiredFormat, noAutoConvert))
                {
                    // If the desired data format is present, use one of the GetData methods to retrieve the
                    // data from the data object.
                    data = dataObject.GetData(desiredFormat) as byte[];
                }
                // </Snippet_DragDrop_GetSpecificDataFormat_Native>
            }
        }

        private void ehDragEnter(object sender, DragEventArgs args)
        {
            // Code here will fire when the DragEnter event occurs.
        }
        private void ehDragLeave(object sender, DragEventArgs args)
        {
            // Code here will fire when the DragEnter event occurs.
        }
        private void ehDragOver(object sender, DragEventArgs args)
        {
            // Code here will fire when the DragEnter event occurs.
        }
        private void ehDrop(object sender, DragEventArgs args)
        {
            // Code here will fire when the DragEnter event occurs.
        }
        private void ehPreviewDragEnter(object sender, DragEventArgs args)
        {
            // Code here will fire when the DragEnter event occurs.
        }
        private void ehPreviewDragLeave(object sender, DragEventArgs args)
        {
            // Code here will fire when the DragEnter event occurs.
        }
        private void ehPreviewDragOver(object sender, DragEventArgs args)
        {
            // Code here will fire when the DragEnter event occurs.
        }
        private void ehPreviewDrop(object sender, DragEventArgs args)
        {
            // Code here will fire when the DragEnter event occurs.
        }

        private void ClipboardMethods()
        {
            bool persistentData = false;
            {
                // <Snippet_ContainsDataGetData>

                // After this line executes, IsHTMLDataOnClipboard will be true if
                // HTML data is available natively on the clipboard; if not, it
                // will be false.
                bool IsHTMLDataOnClipboard = Clipboard.ContainsData(DataFormats.Html);

                // If there is HTML data on the clipboard, retrieve it.
                string htmlData;
                if(IsHTMLDataOnClipboard)
                {

                    htmlData = Clipboard.GetText(TextDataFormat.Html);
                }

                // </Snippet_ContainsDataGetData>
            }

            {
                // <Snippet_SetData>

                // For this example, the data to be placed on the clipboard is a simple
                // string.
                string textData = "I want to put this string on the clipboard.";

                // After this call, the data (string) is placed on the clipboard and tagged
                // with a data format of "Text".
                Clipboard.SetData(DataFormats.Text, (Object)textData);
                // </Snippet_SetData>
            }

            {
                // <Snippet_SetDataObjectIsCurrent>

                // For this example, the data to be placed on the clipboard is a simple
                // string.
                string textData = "I want to put this string on the clipboard.";
                // The example will enable auto-conversion of data for this data object.
                bool autoConvert = true;

                // Create a new data object, specifying the data format, data to encapsulate, and enabling
                // auto-conversion services.
                DataObject data = new DataObject(DataFormats.UnicodeText, (Object)textData, autoConvert);

                // If the data to be copied is supposed to be persisted after the application ends,
                // then set the second parameter of SetDataObject to true.
                if(persistentData)
                {
                    // Place the persisted data on the clipboard.
                    Clipboard.SetDataObject(data, true);
                }
                else
                {
                    // Place the non-persisted data on the clipboard.
                    Clipboard.SetDataObject(data, false);
                }

                // If you keep a copy of the source data object, you can use the IsCurrent method to see if
                // the data object is still on the clipboard.
                bool isOriginalDataObject = Clipboard.IsCurrent(data);
                // </Snippet_SetDataObjectIsCurrent>
            }
        }
    }
}