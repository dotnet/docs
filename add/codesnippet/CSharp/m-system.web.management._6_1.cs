        public override void  Flush()
        {
            customInfo.AppendLine("Perform custom flush");
            StoreToFile(customInfo, logFilePath, FileMode.Append);
        }