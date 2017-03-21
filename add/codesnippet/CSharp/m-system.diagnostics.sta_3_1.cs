      public void Level2Method()
      {
         try 
         {
            ClassLevel3 nestedClass = new ClassLevel3();
            nestedClass.Level3Method();

         }
         catch (Exception e) 
         {
            Console.WriteLine(" Level2Method exception handler");

            // Display the full call stack at this level.
            StackTrace st1 = new StackTrace(true);
            Console.WriteLine(" Stack trace for this level: {0}",
               st1.ToString());

            // Build a stack trace from one frame, skipping the current
            // frame and using the next frame.
            StackTrace st2 = new StackTrace(new StackFrame(1, true));
            Console.WriteLine(" Stack trace built with next level frame: {0}",
               st2.ToString());

            // Build a stack trace skipping the current frame, and
            // including all the other frames.
            StackTrace st3 = new StackTrace(1, true);
            Console.WriteLine(" Stack trace built from the next level up: {0}",
               st3.ToString());

            Console.WriteLine();
            Console.WriteLine("   ... throwing exception to next level ...");
            Console.WriteLine("-------------------------------------------------\n");
            throw e;
         }
      }