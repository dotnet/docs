	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		// This method will run on a thread other than the UI thread.
		// Be sure not to manipulate any Windows Forms controls created
		// on the UI thread from this method.
		backgroundWorker.ReportProgress(0, "Working...");
		Decimal lastlast = 0;
		Decimal last = 1;
		Decimal current;
		if (requestedCount >= 1)
		{ AppendNumber(0); }
		if (requestedCount >= 2)
		{ AppendNumber(1); }
		for (int i = 2; i < requestedCount; ++i)
		{
			// Calculate the number.
			checked { current = lastlast + last; }
			// Introduce some delay to simulate a more complicated calculation.
			System.Threading.Thread.Sleep(100);
			AppendNumber(current);
			backgroundWorker.ReportProgress((100 * i) / requestedCount, "Working...");
			// Get ready for the next iteration.
			lastlast = last;
			last = current;
		}


		backgroundWorker.ReportProgress(100, "Complete!");
	}