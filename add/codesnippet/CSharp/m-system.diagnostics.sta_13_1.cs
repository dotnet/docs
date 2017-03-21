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