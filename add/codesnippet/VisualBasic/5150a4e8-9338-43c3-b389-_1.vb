      Dim myPostOperation As New Operation()
      myPostOperation.Name = myOperationBinding.Name
      Console.WriteLine("'Operation' instance uses 'OperationBinding': " + _
                                 myPostOperation.IsBoundBy(myOperationBinding).ToString())