using System;
using System.Windows.Forms;

public class Form1 : Form
{
    //<snippet100>
    [Serializable]
    public class Customer
    {
        private string nameValue = string.Empty;
        public Customer(String name)
        {
            nameValue = name;
        }
        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }
    }
    //</snippet100>

    public Form1()
    {
        //<snippet1>
        Clipboard.Clear();
        //</snippet1>
    }

    //<snippet3>
    // Demonstrates SetData, ContainsData, and GetData
    // using a custom format name and a business object.
    public Customer TestCustomFormat
    {
        get
        {
            Clipboard.SetData("CustomerFormat", new Customer("Customer Name"));
            if (Clipboard.ContainsData("CustomerFormat")) 
            {
                return Clipboard.GetData("CustomerFormat") as Customer;
            }
            return null;
        }
    }
    //</snippet3>

    //<snippet4>
    // Demonstrates how to use a DataObject to add
    // data to the Clipboard in multiple formats.
    public void TestClipboardMultipleFormats()
    {
        DataObject data = new DataObject();

        // Add a Customer object using the type as the format.
        data.SetData(new Customer("Customer as Customer object"));

        // Add a ListViewItem object using a custom format name.
        data.SetData("CustomFormat", 
            new ListViewItem("Customer as ListViewItem"));

        Clipboard.SetDataObject(data);
        DataObject retrievedData = (DataObject)Clipboard.GetDataObject();

        if (retrievedData.GetDataPresent("CustomFormat"))
        {
            ListViewItem item = 
                retrievedData.GetData("CustomFormat") as ListViewItem;
            if (item != null)
            {
                MessageBox.Show(item.Text);
            }
        }

        if (retrievedData.GetDataPresent(typeof(Customer)))
        {
            Customer customer = 
                retrievedData.GetData(typeof(Customer)) as Customer;
            if (customer != null)
            {
                MessageBox.Show(customer.Name);
            }
        }
    }
    //</snippet4>

    //<snippet10>
    // Demonstrates SetData, ContainsData, and GetData.
    public Object SwapClipboardFormattedData(String format, Object data)
    {
        Object returnObject = null;
        if (Clipboard.ContainsData(format))
        {
            returnObject = Clipboard.GetData(format);
            Clipboard.SetData(format, data);
        }
        return returnObject;
    }
    //</snippet10>

    //<snippet2>
    //<snippet20>
    // Demonstrates SetAudio, ContainsAudio, and GetAudioStream.
    public System.IO.Stream SwapClipboardAudio(
        System.IO.Stream replacementAudioStream)
    {
        System.IO.Stream returnAudioStream = null;
        if (Clipboard.ContainsAudio())
        {
            returnAudioStream = Clipboard.GetAudioStream();
            Clipboard.SetAudio(replacementAudioStream);
        }
        return returnAudioStream;
    }
    //</snippet20>

    //<snippet30>
    // Demonstrates SetFileDropList, ContainsFileDroList, and GetFileDropList
    public System.Collections.Specialized.StringCollection
        SwapClipboardFileDropList(
        System.Collections.Specialized.StringCollection replacementList)
    {
        System.Collections.Specialized.StringCollection returnList = null;
        if (Clipboard.ContainsFileDropList())
        {
            returnList = Clipboard.GetFileDropList();
            Clipboard.SetFileDropList(replacementList);
        }
        return returnList;
    }
    //</snippet30>

    //<snippet40>
    // Demonstrates SetImage, ContainsImage, and GetImage.
    public System.Drawing.Image SwapClipboardImage(
        System.Drawing.Image replacementImage)
    {
        System.Drawing.Image returnImage = null;
        if (Clipboard.ContainsImage())
        {
            returnImage = Clipboard.GetImage();
            Clipboard.SetImage(replacementImage);
        }
        return returnImage;
    }
    //</snippet40>

    //<snippet50>
    // Demonstrates SetText, ContainsText, and GetText.
    public String SwapClipboardHtmlText(String replacementHtmlText)
    {
        String returnHtmlText = null;
        if (Clipboard.ContainsText(TextDataFormat.Html))
        {
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html);
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html);
        }
        return returnHtmlText;
    }
    //</snippet50>
    //</snippet2>
}
