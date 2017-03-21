        // Obtains the current process information.
        public string GetProcessInfo()
        {
            StringBuilder tempPi = new StringBuilder();
            WebProcessInformation pi = ProcessInformation;
            tempPi.Append(
                pi.ProcessName + Environment.NewLine);
            tempPi.Append(
                pi.ProcessID.ToString() + Environment.NewLine);
            tempPi.Append(
                pi.AccountName + Environment.NewLine);
            return tempPi.ToString();
        }