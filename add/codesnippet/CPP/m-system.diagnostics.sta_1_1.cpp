            StackFrame^ fr = gcnew StackFrame( 1,true );
            StackTrace^ st = gcnew StackTrace( fr );
            EventLog::WriteEntry( fr->GetMethod()->Name, st->ToString(), EventLogEntryType::Warning );