        // Create a record of previous account status, and deliver it to the clerk.
        int balance = AccountManager.ReadAccountBalance(filename);

	Object[] record = new Object[2];
	record[0] = filename;
        record[1] = balance;

        clerk.WriteLogRecord(record);
        clerk.ForceLog();