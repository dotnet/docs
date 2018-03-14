//<snippet1>

using System;
using System.Diagnostics;

using SampleInternal;

namespace SamplePublic
{
    // This console application illustrates various uses
    // of the StackTrace and StackFrame classes.
    class ConsoleApp
    {
//<snippet2>
       [STAThread]
       static void Main()
        {
            ClassLevel1 mainClass = new ClassLevel1();

            try {
                mainClass.InternalMethod();
            }
            catch (Exception) {
               Console.WriteLine(" Main method exception handler");

               // Display file and line information, if available.
               StackTrace st = new StackTrace(new StackFrame(true));
               Console.WriteLine(" Stack trace for current level: {0}",
                   st.ToString());
               Console.WriteLine(" File: {0}", 
                  st.GetFrame(0).GetFileName());
               Console.WriteLine(" Line Number: {0}",
                   st.GetFrame(0).GetFileLineNumber().ToString());

               Console.WriteLine();
               Console.WriteLine("-------------------------------------------------\n");
            }
        }
       //</snippet2>
    }
}

namespace SampleInternal
{
   public class ClassLevel1
   {
//<snippet3>
      public void InternalMethod()
      {
         try
         {
            ClassLevel2 nestedClass = new ClassLevel2();
            nestedClass.Level2Method();
         }
         catch (Exception e)
         {
            Console.WriteLine(" InternalMethod exception handler");

            // Build a stack trace from one frame, skipping the
            // current frame and using the next frame.  By
            // default, file and line information are not displayed.
            StackTrace st = new StackTrace(new StackFrame(1));
            Console.WriteLine(" Stack trace for next level frame: {0}",
               st.ToString());
            Console.WriteLine(" Stack frame for next level: ");
            Console.WriteLine("   {0}", st.GetFrame(0).ToString());

            Console.WriteLine(" Line Number: {0}",
               st.GetFrame(0).GetFileLineNumber().ToString());

            Console.WriteLine();
            Console.WriteLine("   ... throwing exception to next level ...");
            Console.WriteLine("-------------------------------------------------\n");
            throw e;
         }
      }
      //</snippet3>
   }

   public class ClassLevel2
   {
//<snippet4>
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
      //</snippet4>
   }

   public class ClassLevel3
   {
//<snippet5>
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
//<snippet7>
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
//</snippet7>
            }
            Console.WriteLine();
            Console.WriteLine("   ... throwing exception to next level ...");
            Console.WriteLine("-------------------------------------------------\n");
            throw e;
         }
      }
      //</snippet5>
   }

   public class ClassLevel4
   {
      public void Level4Method()
      {
//<snippet6>
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
//</snippet6>
      }
   }

   public class ClassLevel5
   {
//<snippet8>
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
//</snippet8>

   }

   public class ClassLevel6
   {
      public void Level6Method()
      {
         throw new Exception("An error occurred in the lowest internal class method.");
      }

   }
}
//</snippet1>