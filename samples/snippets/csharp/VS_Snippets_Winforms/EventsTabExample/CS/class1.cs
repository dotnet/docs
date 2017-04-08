//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EventsTabExample
{    
    // This component adds a TypeEventsTab to the Properties Window.
    [PropertyTabAttribute(typeof(TypeEventsTab), PropertyTabScope.Document)]
    public class TypeEventsTabComponent : Component
    {
        public TypeEventsTabComponent()
        {
        }
    }

    // This example events tab lists events by their delegate type.
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name="FullTrust")]
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
    public class TypeEventsTab : System.Windows.Forms.Design.EventsTab
    {
        [BrowsableAttribute(true)]
        // This string contains a Base-64 encoded and serialized example 
        // property tab image.
        private string img = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtgIAAAJCTbYCAAAAAAAANgAAACgAAAANAAAAEAAAAAEAGAAAAAAAAAAAAMQOAADEDgAAAAAAAAAAAADO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tn/ztbZztbZHh4eHh4eztbZztbZztbZztbZztbZztbZztbZztbZztbZ/87W2c7W2QDBAB4eHh4eHs7W2c7W2c7W2c7W2c7W2c7W2c7W2c7W2f/O1tnO1tnO1tkAwQAeHh4eHh7O1tnO1tnO1tnO1tnO1tnO1tnO1tn/ztbZztbZlJSU////AMEAHh4eHh4eztbZztbZztbZztbZztbZztbZ/87W2c7W2c7W2ZSUlP///wDBAB4eHh4eHs7W2c7W2c7W2c7W2c7W2f/O1tnO1tnO1tnO1tmUlJT///8AwQAeHh4eHh7O1tnO1tnO1tnO1tn/ztbZHh4eHh4eHh4eHh4eHh4e////AIAAHh4eHh4eztbZztbZztbZ/87W2ZSUlP///wDBAADBAADBAADBAADBAACAAB4eHh4eHs7W2c7W2f/O1tnO1tmUlJT///8AwQAAgAAeHh4eHh7O1tnO1tnO1tnO1tnO1tn/ztbZztbZztbZlJSU////AMEAAIAAHh4eHh4eztbZztbZztbZztbZ/87W2c7W2c7W2c7W2ZSUlP///wDBAACAAB4eHh4eHs7W2c7W2c7W2f/O1tnO1tnO1tnO1tnO1tmUlJT///8AwQAAgAAeHh4eHh7O1tnO1tn/ztbZztbZztbZztbZztbZztbZlJSU////AMEAAIAAHh4eHh4eztbZ/87W2c7W2c7W2c7W2c7W2c7W2c7W2ZSUlP///wDBAACAAB4eHs7W2f/O1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tn/Cw==";
        private IServiceProvider sp;

        public TypeEventsTab(IServiceProvider sp) : base(sp)
        {
            this.sp = sp;           
        }
                  
        // Returns the properties of the specified component extended with a 
        // CategoryAttribute reflecting the name of the type of the property.
        public override System.ComponentModel.PropertyDescriptorCollection 
            GetProperties(ITypeDescriptorContext context, object component, 
            System.Attribute[] attributes)
        {            
            // Obtain an instance of the IEventBindingService.
            IEventBindingService eventPropertySvc = (IEventBindingService)
                sp.GetService(typeof(IEventBindingService));

            // Return if an IEventBindingService could not be obtained.
            if (eventPropertySvc == null)             
                return new PropertyDescriptorCollection(null);
            
            // Obtain the events on the component.
            EventDescriptorCollection events = 
                TypeDescriptor.GetEvents(component, attributes);       
     
            // Create an array of the events, where each event is assigned 
            // a category matching its type.
            EventDescriptor[] newEvents = new EventDescriptor[events.Count];
            for(int i=0;i < events.Count;i++)             
                newEvents[i] = TypeDescriptor.CreateEvent(events[i].ComponentType, events[i], 
                    new CategoryAttribute(events[i].EventType.FullName));            
            events = new EventDescriptorCollection(newEvents);

            // Return event properties for the event descriptors.
            return eventPropertySvc.GetEventProperties(events);
        }        

        // Provides the name for the event property tab.
        public override string TabName
        {
            get
            {
                return "Events by Type";
            }
        }

        // Provides an image for the event property tab.
        public override System.Drawing.Bitmap Bitmap
        {
            get
            {
                Bitmap bmp = new Bitmap(DeserializeFromBase64Text(img));
                return bmp;
            }
        }

        // This method can be used to retrieve an Image from a block of 
        // Base64-encoded text.
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