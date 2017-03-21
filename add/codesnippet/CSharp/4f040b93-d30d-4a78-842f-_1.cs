         try 
         {
            ClassLevel5 nestedClass = new ClassLevel5();
            nestedClass.Level5Method();
         }
         catch (Exception e) 
         {
            Console.WriteLine(" Level4Method exception handler");

            // Build a stack trace from a dummy stack frame.
            // Explicitly specify the source file name, line number
            // and column number.
            StackTrace st = new StackTrace(new StackFrame("source.cs", 79, 24));
            Console.WriteLine(" Stack trace with dummy stack frame: {0}", 
                           st.ToString());

            // Access the StackFrames explicitly to display the file
            // name, line number and column number properties.
            // StackTrace.ToString only includes the method name. 
            for(int i =0; i< st.FrameCount; i++ )
            {
               StackFrame sf = st.GetFrame(i);
               Console.WriteLine(" File: {0}", sf.GetFileName());
               Console.WriteLine(" Line Number: {0}", 
                  sf.GetFileLineNumber());
               Console.WriteLine(" Column Number: {0}", 
                  sf.GetFileColumnNumber());
            }
            Console.WriteLine();
            Console.WriteLine("   ... throwing exception to next level ...");
            Console.WriteLine("-------------------------------------------------\n");
            throw e;
         }