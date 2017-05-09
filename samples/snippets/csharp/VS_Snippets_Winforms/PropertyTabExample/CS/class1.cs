//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TypeCategoryTabExample
{	
    // This component adds a TypeCategoryTab to the property browser 
    // that is available for any components in the current design mode document.
    [PropertyTabAttribute(typeof(TypeCategoryTab), PropertyTabScope.Document)]
    public class TypeCategoryTabComponent : System.ComponentModel.Component
    {           
        public TypeCategoryTabComponent()
        {
        }
    }

    // A TypeCategoryTab property tab lists properties by the 
    // category of the type of each property.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class TypeCategoryTab : PropertyTab
    {
        [BrowsableAttribute(true)]
        // This string contains a Base-64 encoded and serialized example property tab image.
        private string img = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9gAAAAJCTfYAAAAAAAAANgAAACgAAAAIAAAACAAAAAEAGAAAAAAAAAAAAMQOAADEDgAAAAAAAAAAAAD///////////////////////////////////9ZgABZgADzPz/zPz/zPz9AgP//////////gAD/gAD/AAD/AAD/AACKyub///////+AAACAAAAAAP8AAP8AAP9AgP////////9ZgABZgABz13hz13hz13hAgP//////////gAD/gACA/wCA/wCA/wAA//////////+AAACAAAAAAP8AAP8AAP9AgP////////////////////////////////////8L";

        public TypeCategoryTab()
        {            
        }

        //<Snippet2>
        // Returns the properties of the specified component extended with 
        // a CategoryAttribute reflecting the name of the type of the property.
        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(object component, System.Attribute[] attributes)
        {
            PropertyDescriptorCollection props;
            if( attributes == null )
                props = TypeDescriptor.GetProperties(component);    
            else
                props = TypeDescriptor.GetProperties(component, attributes);    
            
            PropertyDescriptor[] propArray = new PropertyDescriptor[props.Count];            
            for(int i=0; i<props.Count; i++)           
            {                
                // Create a new PropertyDescriptor from the old one, with 
                // a CategoryAttribute matching the name of the type.
                propArray[i] = TypeDescriptor.CreateProperty(props[i].ComponentType, props[i], new CategoryAttribute(props[i].PropertyType.Name));
            }
            return new PropertyDescriptorCollection( propArray );
        }

        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(object component)
        {                     
            return this.GetProperties(component, null);
        }
        //</Snippet2>

        // Provides the name for the property tab.
        public override string TabName
        {
            get
            {
                return "Properties by Type";
            }
        }

        // Provides an image for the property tab.
        public override System.Drawing.Bitmap Bitmap
        {
            get
            {
                Bitmap bmp = new Bitmap(DeserializeFromBase64Text(img));
                return bmp;
            }
        }

        // This method can be used to retrieve an Image from a block of Base64-encoded text.
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