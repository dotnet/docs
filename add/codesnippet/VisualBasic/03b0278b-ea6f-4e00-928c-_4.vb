        My.Computer.FileSystem.DeleteDirectory(
         "C:\OldDirectory",
         FileIO.UIOption.AllDialogs,
         FileIO.RecycleOption.SendToRecycleBin,
         FileIO.UICancelOption.ThrowException)