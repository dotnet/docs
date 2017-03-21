   ' This InsertNewEmployeeWrapper method is a wrapper method that enables
   ' the use of ObjectDataSource and InsertParameters, without
   ' substantially rewriting the true implementation for the NorthwindEmployee
   ' or the EmployeeLogic objects.
   '
   ' The parameters to the method must be named the same as the
   ' DataControlFields used by the GridView or DetailsView controls.
   Public Shared Sub InsertNewEmployeeWrapper(FirstName As String, LastName As String, Title As String, Courtesy As String, Supervisor As Integer)
      ' Build the NorthwindEmployee object and
      ' call the true  implementation.
      Dim tempEmployee As New NorthwindEmployee()

      tempEmployee.FirstName = FirstName
      tempEmployee.LastName = LastName
      tempEmployee.Title = Title
      tempEmployee.Courtesy = Courtesy
      tempEmployee.Supervisor = Supervisor

      ' Call the true implementation.
      InsertNewEmployee(tempEmployee)
   End Sub 'InsertNewEmployeeWrapper


   Public Shared Sub InsertNewEmployee(ne As NorthwindEmployee)
      Dim retval As Boolean = ne.Save()
      If Not retval Then
         Throw New NorthwindDataException("InsertNewEmployee failed.")
      End If
   End Sub 'InsertNewEmployee