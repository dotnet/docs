        My.Computer.FileSystem.DeleteFile(
          "C:\test.txt",
          FileIO.UIOption.AllDialogs,
          FileIO.RecycleOption.SendToRecycleBin,
          FileIO.UICancelOption.ThrowException)