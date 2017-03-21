      public void Level5Method()
      {
         try 
         {
            ClassLevel6 nestedClass = new ClassLevel6();
            nestedClass.Level6Method();
         }
         catch (Exception e) 
         {
            Console.WriteLine(" Level5Method exception handler");

            StackTrace st = new StackTrace();
            
            // Display the most recent function call.
            StackFrame sf = st.GetFrame(0);
            Console.WriteLine();
            Console.WriteLine("  Exception in method: ");
            Console.WriteLine("      {0}", sf.GetMethod());

            if (st.FrameCount >1)
            {
               // Display the highest-level function call 
               // in the trace.
               sf = st.GetFrame(st.FrameCount-1);
               Console.WriteLine("  Original function call at top of call stack):");
               Console.WriteLine("      {0}", sf.GetMethod());
            }

            Console.WriteLine();
            Console.WriteLine("   ... throwing exception to next level ...");
            Console.WriteLine("-------------------------------------------------\n");
            throw e;
         }        
      }