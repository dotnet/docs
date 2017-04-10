//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyValueUIServiceExample
{
    // This component obtains the IPropertyValueUIService and adds a
    // PropertyValueUIHandler that provides PropertyValueUIItem objects
    // which provide an image, ToolTip, and invoke event handler to
    // any properties named HorizontalMargin and VerticalMargin, 
    // such as the example integer properties on this component.    
    public class PropertyUIComponent : System.ComponentModel.Component
    {
        // Example property for which to provide a PropertyValueUIItem.
        public int HorizontalMargin 
        {
            get
            {
                return hMargin;
            }
            set
            {
                hMargin = value;
            }
        }
        // Example property for which to provide a PropertyValueUIItem.
        public int VerticalMargin
        {
            get
            {
                return vMargin;
            }
            set
            {
                vMargin = value;
            }
        }

        // Field storing the value of the HorizontalMargin property.
        private int hMargin;

        // Field storing the value of the VerticalMargin property.
        private int vMargin;        

        // Base64-encoded serialized image data for image icon.
        private string imageBlob1 = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9gAAAAJCTfYAAAAAAAAANgAAACgAAAAIAAAACAAAAAEAGAAAAAAAAAAAAMQOAADEDgAAAAAAAAAAAAD///////////////////////////////////8AAAD///////////////8AAAD///////8AAAD///////////////8AAAD///////8AAAD///8AAAAAAAD///8AAAD///////8AAAD///8AAAAAAAD///8AAAD///////8AAAD///////////////8AAAD///////8AAAD///////////////8AAAD///////////////////////////////////8L";
                
        // Constructor.
        public PropertyUIComponent(System.ComponentModel.IContainer container)
        {
            if( container != null )
                container.Add(this);
            hMargin = 0;		
            vMargin = 0;
        }

        // Default component constructor that specifies no container.
        public PropertyUIComponent() : this(null)
        {}

//<Snippet2>
        // PropertyValueUIHandler delegate that provides PropertyValueUIItem
        // objects to any properties named HorizontalMargin or VerticalMargin.
        private void marginPropertyValueUIHandler(System.ComponentModel.ITypeDescriptorContext context, System.ComponentModel.PropertyDescriptor propDesc, ArrayList itemList)
        {
            // A PropertyValueUIHandler added to the IPropertyValueUIService
            // is queried once for each property of a component and passed
            // a PropertyDescriptor that represents the characteristics of 
            // the property when the Properties window is set to a new 
            // component. A PropertyValueUIHandler can determine whether 
            // to add a PropertyValueUIItem for the object to its ValueUIItem 
            // list depending on the values of the PropertyDescriptor.
            if( propDesc.DisplayName.Equals( "HorizontalMargin" ) )
            {
                Image img = DeserializeFromBase64Text(imageBlob1);
                itemList.Add( new PropertyValueUIItem( img, new PropertyValueUIItemInvokeHandler(this.marginInvoke), "Test ToolTip") );
            }
            if( propDesc.DisplayName.Equals( "VerticalMargin" ) )
            {
                Image img = DeserializeFromBase64Text(imageBlob1);
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                itemList.Add( new PropertyValueUIItem( img, new PropertyValueUIItemInvokeHandler(this.marginInvoke), "Test ToolTip") );
            }
        }
//</Snippet2>

        // Invoke handler associated with the PropertyValueUIItem objects 
        // provided by the marginPropertyValueUIHandler.
        private void marginInvoke(System.ComponentModel.ITypeDescriptorContext context, System.ComponentModel.PropertyDescriptor propDesc, PropertyValueUIItem item)
        {
            MessageBox.Show("Test invoke message box");
        }

        // Component.Site override to add the marginPropertyValueUIHandler
        // when the component is sited, and to remove it when the site is 
        // set to null.
        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {                
                if( value != null )
                {
                    base.Site = value;
                    IPropertyValueUIService uiService = (IPropertyValueUIService)this.GetService(typeof(IPropertyValueUIService));
                    if( uiService != null )                    
                        uiService.AddPropertyValueUIHandler( new PropertyValueUIHandler(this.marginPropertyValueUIHandler) );                                        
                }
                else
                {
                    IPropertyValueUIService uiService = (IPropertyValueUIService)this.GetService(typeof(IPropertyValueUIService));
                    if( uiService != null )                    
                        uiService.RemovePropertyValueUIHandler( new PropertyValueUIHandler(this.marginPropertyValueUIHandler) );                                        
                    base.Site = value;
                }
            }
        }

        // This method can be used to retrieve an Image from a block 
        // of Base64-encoded text.
        private Image DeserializeFromBase64Text(string text)
        {
            Image img = null;
            byte[] memBytes = Convert.FromBase64String(text);
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(memBytes);
            img = (Image)formatter.Deserialize(stream);
            stream.Close();
            return img;
        }
    }
}
//</Snippet1>