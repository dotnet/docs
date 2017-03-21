        My.Computer.FileSystem.DeleteDirectory(
          "C:\OldDirectory",
          FileIO.UIOption.AllDialogs,
          FileIO.RecycleOption.DeletePermanently,
          FileIO.UICancelOption.ThrowException)