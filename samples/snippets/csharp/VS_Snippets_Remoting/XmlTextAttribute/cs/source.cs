using System.Xml.Serialization;
using System.Security.Permissions;
[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]

//<snippet0>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class LinkList
{

    private int idField;
    private string nameField;
    private LinkList nextField;
    private string[] textField;

    public int id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    public LinkList next
    {
        get
        {
            return this.nextField;
        }
        set
        {
            this.nextField = value;
        }
    }

    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }
}
//</snippet0>
