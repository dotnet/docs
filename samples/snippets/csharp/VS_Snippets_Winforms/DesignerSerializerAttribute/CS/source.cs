using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ExampleControl
{
    //<Snippet1>
    [DesignerSerializerAttribute(typeof(ExampleSerializer), typeof(CodeDomSerializer))]
	public class ExampleControl : System.Windows.Forms.UserControl
	{
		public ExampleControl()
		{

		}
	}
    //</Snippet1>

    public class ExampleSerializer : System.ComponentModel.Design.Serialization.CodeDomSerializer
    {
        public ExampleSerializer()
        {
        }

        public override object Deserialize(System.ComponentModel.Design.Serialization.IDesignerSerializationManager manager, object codeObject)
        {
            return null;
        }

        public override object Serialize(System.ComponentModel.Design.Serialization.IDesignerSerializationManager manager, object value)
        {
            return null;
        }
    }

}