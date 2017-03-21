                StackTrace st = new StackTrace(1, true);
                StackFrame [] stFrames = st.GetFrames();

                foreach(StackFrame sf in stFrames )
                {
                   Console.WriteLine("Method: {0}", sf.GetMethod() );
                }