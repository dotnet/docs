      ' Create another WebPermission that is the Union of previous two WebPermission 
      ' instances.
      Dim myWebPermission3 As WebPermission = CType(myWebPermission1.Union(myWebPermission2), WebPermission)
      Console.WriteLine(ControlChars.Cr + "Attributes and values of the WebPermission after the Union are : ")
      ' Display the attributes,values and children.
      Console.WriteLine(myWebPermission3.ToXml().ToString())
   End Sub 'CreateUnion
    