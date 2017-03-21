      Operation myPostOperation = new Operation();
      myPostOperation.Name = myOperationBinding.Name;
      Console.WriteLine("'Operation' instance uses 'OperationBinding': " 
         +myPostOperation.IsBoundBy(myOperationBinding));