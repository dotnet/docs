        My.Computer.FileSystem.DeleteFile(
          "C:\test.txt",
          FileIO.UIOption.OnlyErrorDialogs,
          FileIO.RecycleOption.SendToRecycleBin,
          FileIO.UICancelOption.ThrowException)