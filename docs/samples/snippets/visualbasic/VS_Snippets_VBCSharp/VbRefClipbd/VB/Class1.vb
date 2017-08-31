Class Class16e44442bc65408fab450eb9c06c8625
' My.Computer.Clipboard.GetDataObjectMethod

Public Sub Method1()
' <snippet1>
Dim someData As Object
someData = My.Computer.Clipboard.GetDataObject()
My.Computer.FileSystem.WriteAllBytes("C:\mylogfile", someData, True)
' </snippet1>
End Sub

End Class

Class Class24e22a44e0f34872a9d31990b5c2f4ca
' My.Computer.Clipboard.SetAudioMethod

Public Sub Method2()
' <snippet2>
Dim musicReader = My.Computer.FileSystem.ReadAllBytes("cool.wav")
My.Computer.Clipboard.SetAudio(musicReader)
' </snippet2>
End Sub

End Class

Class Class2672d8ec65714620ad34d54e81883280
' My.Computer.Clipboard.SetFileDropListMethod

Public Sub Method3()
' <snippet3>
Dim list = My.Computer.FileSystem.GetFiles(
    My.Computer.FileSystem.SpecialDirectories.MyDocuments)
Dim listReader As New System.Collections.Specialized.StringCollection
For Each item As String In list
   listReader.Add(item)
Next
My.Computer.Clipboard.SetFileDropList(listReader)
' </snippet3>
End Sub

End Class

Class Class5474cce52356438cb0f23f3fcb1a2bba
' My.Computer.Clipboard.GetImageMethod

Public Sub Method4()
Dim PictureBox1 As New System.Windows.Forms.PictureBox
' <snippet4>
If My.Computer.Clipboard.ContainsImage() Then
   Dim grabpicture = My.Computer.Clipboard.GetImage()
   PictureBox1.Image = grabpicture
End If
' </snippet4>
End Sub

End Class

Class Class93cc3ba22d9b4c7883d3f9e70134dbb2
' My.Computer.Clipboard.ContainsTextMethod

Public Sub Method5()
' <snippet5>
If My.Computer.Clipboard.ContainsText(
   System.Windows.Forms.TextDataFormat.Html) Then

   Dim clipText = My.Computer.Clipboard.GetText()
End If
' </snippet5>
End Sub

End Class

Class Class9cdf1cb2d00345d187995dea9e8ef241
' My.Computer.Clipboard.ContainsDataMethod

Public Sub Method6()
' <snippet6>
If My.Computer.Clipboard.ContainsData("specialFormat") Then
   MsgBox("Data found.")
End If
' </snippet6>
End Sub

End Class

Class Classaccdb3c880744fc48fcd5c476a58bab6
' My.Computer.Clipboard.GetDataMethod

Public Sub Method7()
' <snippet7>
Dim someData As Object
someData = My.Computer.Clipboard.GetData("specialformat")
My.Computer.FileSystem.WriteAllBytes("C:\\mylogfile", someData, True)
' </snippet7>
End Sub

End Class

Class Classc7e2d10b213c4fbeb8d199dcca89dc35
' My.Computer.Clipboard.ContainsImageMethod

Public Sub Method8()
Dim PictureBox1 As New System.Windows.Forms.PictureBox
' <snippet8>
If My.Computer.Clipboard.ContainsImage() Then
   Dim grabpicture = My.Computer.Clipboard.GetImage()
   PictureBox1.Image = grabpicture
End If
' </snippet8>
End Sub

End Class

Class Classcbb94f038a12413dbfa69562e526c76b
' My.Computer.Clipboard.GetFileDropListMethod

Public Sub Method9()
Dim lstfiles As New System.Windows.Forms.ListBox
' <snippet9>
If My.Computer.Clipboard.ContainsFileDropList Then
   Dim filelist = My.Computer.Clipboard.GetFileDropList()
   For Each filePath In filelist
       lstFiles.Items.Add(filePath)
   Next
End If
' </snippet9>
End Sub

End Class

Class Classcc823fdab3c24b218036bd4d42174575
' My.Computer.Clipboard.ContainsAudioMethod

Public Sub Method10()
' <snippet10>
If My.Computer.Clipboard.ContainsAudio() Then
   MsgBox("The clipboard contains audio data.")
Else
   MsgBox("The clipboard does not contain audio data.")
End If
' </snippet10>
End Sub

End Class

Class Classdb8e79622ac241029f484eb7c26cce38
' My.Computer.Clipboard.GetAudioStreamMethod

Public Sub Method11()
' <snippet11>
If My.Computer.Clipboard.ContainsAudio Then
   Dim song = My.Computer.Clipboard.GetAudioStream
   My.Computer.Audio.Play(song, AudioPlayMode.WaitToComplete)
End If
' </snippet11>
End Sub

End Class

Class Classe3d36ba4a63a4272975ead012bf02ec6
' My.Computer.Clipboard.ContainsFileDropListMethod

Public Sub Method12()
Dim lstfiles As New System.Windows.Forms.ListBox
' <snippet12>
If My.Computer.Clipboard.ContainsFileDropList Then
   Dim filelist = My.Computer.Clipboard.GetFileDropList()
   For Each filePath In filelist
       lstFiles.Items.Add(filePath)
   Next
End If
' </snippet12>
End Sub

End Class


