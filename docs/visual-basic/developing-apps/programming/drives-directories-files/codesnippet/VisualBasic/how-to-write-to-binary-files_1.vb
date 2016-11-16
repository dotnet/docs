        Dim CustomerData As Byte() = (From c In customerQuery).ToArray()

        My.Computer.FileSystem.WriteAllBytes(
          "C:\MyDocuments\CustomerData", CustomerData, True)