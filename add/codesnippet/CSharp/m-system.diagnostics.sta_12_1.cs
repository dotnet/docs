                StackFrame fr = new StackFrame(1,true);
                StackTrace st = new StackTrace(fr);
                EventLog.WriteEntry(fr.GetMethod().Name,
                                    st.ToString(),
                                    EventLogEntryType.Warning);