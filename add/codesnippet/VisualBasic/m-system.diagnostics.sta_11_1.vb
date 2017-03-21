               ' Display the stack frame properties.
               Dim sf As StackFrame = st.GetFrame(i)
               Console.WriteLine(" File: {0}", sf.GetFileName())
               Console.WriteLine(" Line Number: {0}", _
                  sf.GetFileLineNumber())
               ' The column number defaults to zero when not initialized.
               Console.WriteLine(" Column Number: {0}", _
                  sf.GetFileColumnNumber())
               If sf.GetILOffset <> StackFrame.OFFSET_UNKNOWN
                  Console.WriteLine(" Intermediate Language Offset: {0}", _
                      sf.GetILOffset())
               End If
               If sf.GetNativeOffset <> StackFrame.OFFSET_UNKNOWN
                 Console.WriteLine(" Native Offset: {0}", _
                     sf.GetNativeOffset())
               End If