      Dim myImports(myServiceDescription.Imports.Count - 1) As Import
      ' Copy 'ImportCollection' to an array.
      myServiceDescription.Imports.CopyTo(myImports, 0)
      Console.WriteLine("Imports that are copied to Importarray ...")
      Dim j As Integer
      For j = 0 To myImports.Length - 1
         Console.WriteLine(ControlChars.Tab + _
                           "Import Namespace :{0} Import Location :{1} ", _
                           myImports(j).Namespace, myImports(j).Location)
      Next j