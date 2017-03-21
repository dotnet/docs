      Public Overrides Function CreateObjRef(ServerType As Type) As ObjRef
         Console.WriteLine("CreateObjRef Method Called ...")
         Dim myObjRef As New CustomObjRef(myMarshalByRefObject, ServerType)
         myObjRef.URI = myUri
         Return myObjRef
      End Function 'CreateObjRef