Option Explicit On
Option Strict On

Class Class29f9361e8c624d2ea4f044b2dc43b9aa
' 29f9361e-8c62-4d2e-a4f0-44b2dc43b9aa
' My.Computer.Network.IsAvailable Property

Public Sub Method1()
' <snippet1>
If My.Computer.Network.IsAvailable = True Then
    MsgBox("Computer is connected.")
Else  
    MsgBox("Computer is not connected.")
End If
' </snippet1>
End Sub

End Class

Class Class5505ea3e3dbd460b9f8f62c84c0a4de6
' 5505ea3e-3dbd-460b-9f8f-62c84c0a4de6
' My.Computer.Network.UploadFile Method

Public Sub Method2()
' <snippet2>
My.Computer.Network.UploadFile ( "C:\My Documents\Order.txt", 
"http://www.cohowinery.com/upload.aspx")
' </snippet2>
End Sub

Public Sub Method3()
' <snippet3>
My.Computer.Network.UploadFile ("C:\My Documents\Order.txt", 
"http://www.cohowinery.com/upload.aspx","","",True,500)
' </snippet3>
End Sub

End Class

Class Class5f1eff72388244a48234ac21daac464c
' 5f1eff72-3882-44a4-8234-ac21daac464c
' My.Computer.Network.Ping Method

Public Sub Method4()
' <snippet4>
If My.Computer.Network.Ping("198.01.01.01") Then
   MsgBox("Server pinged successfully.")
Else
   MsgBox("Ping request timed out.")
End If
' </snippet4>
End Sub

Public Sub Method5()
' <snippet5>
If My.Computer.Network.Ping("www.cohowinery.com",1000) Then
   MsgBox("Server pinged successfully.")
Else
   MsgBox("Ping request timed out.")
End If
' </snippet5>
End Sub

End Class

Class Class94ddbadeaff142f8a6c888b78c28c0db
' 94ddbade-aff1-42f8-a6c8-88b78c28c0db
' My.Computer.Network Object

Public Sub Method6()
' <snippet6>
My.Computer.Network.UploadFile ( 
"C:\My Documents\Order.txt", 
"http://www.cohowinery.com/uploads.aspx")
' </snippet6>
End Sub

End Class

Class Classaeb7ed8f1ac94242ae579f35914eb329
' aeb7ed8f-1ac9-4242-ae57-9f35914eb329
' My.Computer.Network.DownloadFile Method

Public Sub Method7()
' <snippet7>
My.Computer.Network.DownloadFile(
  "http://www.cohowinery.com/downloads/WineList.txt", 
  "C:\Documents and Settings\All Users\Documents\WineList.txt")
' </snippet7>
End Sub

Public Sub Method8()
' <snippet8>
My.Computer.Network.DownloadFile(
  "http://www.cohowinery.com/downloads/", 
  "C:\Documents and Settings\All Users\Documents\WineList.txt", 
  "", "", False, 500, True)
' </snippet8>
End Sub

End Class


