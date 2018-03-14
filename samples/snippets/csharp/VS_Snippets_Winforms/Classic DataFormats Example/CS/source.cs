// <Snippet1>
using System;
using System.Windows.Forms;

public class MyClass : Form {
    protected TextBox textBox1;
    
    public void MyClipboardMethod() {
       // Creates a new data format.
       DataFormats.Format myFormat = DataFormats.GetFormat("myFormat");
       
       /* Creates a new object and stores it in a DataObject using myFormat 
        * as the type of format. */
       MyNewObject myObject = new MyNewObject();
       DataObject myDataObject = new DataObject(myFormat.Name, myObject);
 
       // Copies myObject into the clipboard.
       Clipboard.SetDataObject(myDataObject);
 
       // Performs some processing steps.
 
       // Retrieves the data from the clipboard.
       IDataObject myRetrievedObject = Clipboard.GetDataObject();
 
       // Converts the IDataObject type to MyNewObject type. 
       MyNewObject myDereferencedObject = (MyNewObject)myRetrievedObject.GetData(myFormat.Name);
 
       // Prints the value of the Object in a textBox.
       textBox1.Text = myDereferencedObject.MyObjectValue;
    }
 }
 
 // Creates a new type.
 [Serializable]
 public class MyNewObject : Object {
    private string myValue;
 
    // Creates a default constructor for the class.
    public MyNewObject() {
       myValue = "This is the value of the class";
    }
 
    // Creates a property to retrieve or set the value.
    public string MyObjectValue {
       get {
          return myValue;
       }
       set {
          myValue = value;
       }
    }
 }

 
// </Snippet1>
