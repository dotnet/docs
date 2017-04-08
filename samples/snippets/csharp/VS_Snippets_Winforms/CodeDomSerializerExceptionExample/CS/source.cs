using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;

namespace CodeDomSerializerExceptionExample
{
    class CodeDomSerializerExceptionExample
    {
        [STAThread]
        static void Main(string[] args)
        {
            //<Snippet1>
            throw new CodeDomSerializerException("This exception was raised as an example.", new CodeLinePragma("Example.txt", 20));            
            //</Snippet1>
        }
    }
}
