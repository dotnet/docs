using System.Windows.Controls;
using System.Windows.Data;
using SDKSample;

namespace bindings
{
    class ManualBinding
    {
        public TextBox myText;

        public void BindTextBox()
        {
            // <CodeOnlyBinding>
            // Make a new source
            var myDataObject = new MyData();
            var myBinding = new Binding("ColorName")
            {
                Source = myDataObject
            };

            // Bind the data source to the TextBox control's Text dependency property
            myText.SetBinding(TextBlock.TextProperty, myBinding);
            // </CodeOnlyBinding>
        }
    }
}
