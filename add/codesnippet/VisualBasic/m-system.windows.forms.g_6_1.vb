   private Sub TestContains()
      Dim isContained As Boolean
      isContained = myDataGrid.TableStyles.Contains("Customers")
      Console.WriteLine(isContained)
   End Sub