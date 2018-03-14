
//<snippet1>
using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;
 
namespace CodeDomSerializerSample
{
    internal class MyCodeDomSerializer : CodeDomSerializer {
        public override object Deserialize(IDesignerSerializationManager manager, object codeObject) {
            // This is how we associate the component with the serializer.
                CodeDomSerializer baseClassSerializer = (CodeDomSerializer)manager.
                GetSerializer(typeof(MyComponent).BaseType, typeof(CodeDomSerializer));

            /* This is the simplest case, in which the class just calls the base class
                to do the work. */
            return baseClassSerializer.Deserialize(manager, codeObject);
        }
 
        public override object Serialize(IDesignerSerializationManager manager, object value) {
            /* Associate the component with the serializer in the same manner as with
                Deserialize */
            CodeDomSerializer baseClassSerializer = (CodeDomSerializer)manager.
                GetSerializer(typeof(MyComponent).BaseType, typeof(CodeDomSerializer));
 
            object codeObject = baseClassSerializer.Serialize(manager, value);
 
            /* Anything could be in the codeObject.  This sample operates on a
                CodeStatementCollection. */
            if (codeObject is CodeStatementCollection) {
                CodeStatementCollection statements = (CodeStatementCollection)codeObject;
 
                // The code statement collection is valid, so add a comment.
                string commentText = "This comment was added to this object by a custom serializer.";
                CodeCommentStatement comment = new CodeCommentStatement(commentText);
                statements.Insert(0, comment);
            }
            return codeObject;
        }
    }
 
//<Snippet2>
    [DesignerSerializer(typeof(MyCodeDomSerializer), typeof(CodeDomSerializer))]
    public class MyComponent : Component {
        private string localProperty = "Component Property Value";
        public string LocalProperty {
            get {
                return localProperty;
            }
            set {
                localProperty = value;
            }
        }
    }
//</Snippet2>

}
//</snippet1>

namespace CodeDomSerializerSample
{
    class CodeDomSerializerStart {
        [STAThread]
        static void Main() {

        }
    }
}
