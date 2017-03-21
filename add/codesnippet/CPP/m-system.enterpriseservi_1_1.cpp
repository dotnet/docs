        // Create a record of previous account status, and deliver it to the
        // clerk.
        int balance = ReadAccountBalance(Filename);

        array<Object^>^ record = gcnew array<Object^>(2);
        record[0] = Filename;
        record[1] = balance;

        clerk->WriteLogRecord(record);
        clerk->ForceLog();