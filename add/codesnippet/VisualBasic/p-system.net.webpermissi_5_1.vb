      ' Get all URI's with Accept permission.  
      Dim myEnum1 As IEnumerator = myWebPermission1.AcceptList
      Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "The URIs with Accept permission are :" + ControlChars.Cr)
      While myEnum1.MoveNext()
         Console.WriteLine((ControlChars.Tab + "The URI is : " + myEnum1.Current))
      End While 