      ' Create a third WebPermission instance via the logical intersection of the previous
      ' two WebPermission instances.
      Dim myWebPermission3 As WebPermission = CType(myWebPermission1.Intersect(myWebPermission2), WebPermission)
      
      Console.WriteLine(ControlChars.Cr + "Attributes and Values of  the WebPermission instance after the Intersect are:" + ControlChars.Cr)
      Console.WriteLine(myWebPermission3.ToXml().ToString())
   End Sub 'CreateIntersect
    