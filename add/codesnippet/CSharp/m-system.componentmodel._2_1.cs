            // Pop each item off the stack.
            object item = null;
            while( (item = stack.Pop()) != null )
                Console.WriteLine( "Value popped from stack: "+item.ToString() );