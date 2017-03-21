If My.Computer.Clipboard.ContainsFileDropList Then
   Dim filelist = My.Computer.Clipboard.GetFileDropList()
   For Each filePath In filelist
       lstFiles.Items.Add(filePath)
   Next
End If