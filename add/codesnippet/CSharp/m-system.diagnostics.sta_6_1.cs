               // Display the stack frame properties.
               StackFrame sf = st.GetFrame(i);
               Console.WriteLine(" File: {0}", sf.GetFileName());
               Console.WriteLine(" Line Number: {0}", 
                  sf.GetFileLineNumber());
               // Note that the column number defaults to zero
               // when not initialized.
               Console.WriteLine(" Column Number: {0}", 
                  sf.GetFileColumnNumber());
               if (sf.GetILOffset() != StackFrame.OFFSET_UNKNOWN)
               {
                  Console.WriteLine(" Intermediate Language Offset: {0}", 
                     sf.GetILOffset());
               }
               if (sf.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN)
               {
                  Console.WriteLine(" Native Offset: {0}", 
                     sf.GetNativeOffset());
               }