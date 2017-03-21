
            // Get the history size.
            int historySize =
                sessionPageState.HistorySize;

            string msg = String.Format(
            "Current history size: {0}\n",
            historySize.ToString());

            Console.Write(msg);


            if (!sessionPageState.IsReadOnly())
            {
                // Double current history size.
                sessionPageState.HistorySize =
                    2 * sessionPageState.HistorySize;

                configuration.Save();

                historySize =
                    sessionPageState.HistorySize;

                msg = String.Format(
                "New history size: {0}\n",
                historySize.ToString());

                Console.Write(msg);
            }
