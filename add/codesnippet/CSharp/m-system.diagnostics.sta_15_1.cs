      public void Level3Method()
      {
         try 
         {
            ClassLevel4 nestedClass = new ClassLevel4();
            nestedClass.Level4Method();
         }
         catch (Exception e) 
         {
            Console.WriteLine(" Level3Method exception handler");

            // Build a stack trace from a dummy stack frame.
            // Explicitly specify the source file name and 
            // line number.
            StackTrace st = new StackTrace(new StackFrame("source.cs", 60));
            Console.WriteLine(" Stack trace with dummy stack frame: {0}", 
                        st.ToString());
            for(int i =0; i< st.FrameCount; i++ )
            {
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
            }
            Console.WriteLine();
            Console.WriteLine("   ... throwing exception to next level ...");
            Console.WriteLine("-------------------------------------------------\n");
            throw e;
         }
      }