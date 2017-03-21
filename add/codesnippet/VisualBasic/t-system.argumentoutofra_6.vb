      ' Get the index of the element whose value is "Z".
      Dim index As Integer = list.FindIndex(AddressOf (New StringSearcher("Z")).FindEquals)
      If index >= 0 Then
         Console.WriteLine("Index {0} contains '{1}'", index, list(index)) 
      End If