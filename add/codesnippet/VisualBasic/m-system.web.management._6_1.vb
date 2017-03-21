   Public Overrides Sub Flush()
      customInfo.AppendLine("Perform custom flush")
        StoreToFile(customInfo, _
        logFilePath, FileMode.Append)
   End Sub 'Flush