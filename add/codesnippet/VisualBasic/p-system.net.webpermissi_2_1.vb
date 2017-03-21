      ' Gets all URIs with Connect permission.
      Dim myEnum As IEnumerator = myWebPermission1.ConnectList
      Console.WriteLine(ControlChars.Cr + "The URIs with Connect permission are :" + ControlChars.Cr)
      While myEnum.MoveNext()
         Console.WriteLine((ControlChars.Tab + "The URI is : " + myEnum.Current))
      End While 