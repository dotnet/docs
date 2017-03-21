Module TestIEquatable
   Public Sub Main()
      ' Create a Person object for each job applicant.
      Dim applicant1 As New Person("Jones", "099-29-4999")
      Dim applicant2 As New Person("Jones", "199-29-3999")
      Dim applicant3 As New Person("Jones", "299-49-6999")

      ' Add applicants to a List object.
      Dim applicants As New List(Of Person)
      applicants.Add(applicant1)
      applicants.Add(applicant2)
      applicants.Add(applicant3)
      
      ' Create a Person object for the final candidate.
      Dim candidate As New Person("Jones", "199-29-3999")
      
      If applicants.Contains(candidate) Then
         Console.WriteLine("Found {0} (SSN {1}).", _
                            candidate.LastName, candidate.SSN)
      Else
         Console.WriteLine("Applicant {0} not found.", candidate.SSN)
      End If         

      ' Call the shared inherited Equals(Object, Object) method.
      ' It will in turn call the IEquatable(Of T).Equals implementation.
      Console.WriteLine("{0}({1}) already on file: {2}.", _ 
                        applicant2.LastName, _
                        applicant2.SSN, _
                        Person.Equals(applicant2, candidate)) 
   End Sub
End Module
' The example displays the following output:
'       Found Jones (SSN 199-29-3999).
'       Jones(199-29-3999) already on file: True.