using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace ContextStackExample
{
    class ContextStackExample
    {
        [STAThread]
        static void Main(string[] args)
        {            
            // Create a ContextStack.
            ContextStack stack = new ContextStack();
            
            // Push ten items on to the stack and output the value of each.
            for( int number = 0; number < 10; number ++ )
            {
                Console.WriteLine( "Value pushed to stack: "+number.ToString() );
                stack.Push( number );
            }

            // Pop each item off the stack.
            object item = null;
            while( (item = stack.Pop()) != null )
                Console.WriteLine( "Value popped from stack: "+item.ToString() );
        }
    }
}