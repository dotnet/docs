Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Configuration
Imports System.Collections.Specialized

Namespace Samples.AspNet.Config
  Class CommaDelimitedStrCollection
    Shared Sub Main(ByVal args() As String)
      ' Display title and info.
      Console.WriteLine("ASP.NET Configuration Info")
      Console.WriteLine("Type: CommaDelimitedStringCollection")
      Console.WriteLine()

      ' Set the path of the config file.
      Dim configPath As String = "/aspnet"

      ' Get the Web application configuration object.
      Dim config As Configuration = _
      WebConfigurationManager.OpenWebConfiguration(configPath)

      ' Get the section related object.
      Dim configSection As AuthorizationSection = _
      CType(config.GetSection("system.web/authorization"), AuthorizationSection)

      ' Get the authorization rule collection.
      Dim authorizationRuleCollection As AuthorizationRuleCollection = _
      configSection.Rules()

      ' Create a CommaDelimitedStringCollection object.
      Dim myStrCollection As CommaDelimitedStringCollection = _
        New CommaDelimitedStringCollection()

      Dim i As Integer
      For i = 0 To authorizationRuleCollection.Count - 1 Step i + 1
        If authorizationRuleCollection.Get(i).Action.ToString().ToLower() _
          = "allow" Then
          ' Add values to the CommaDelimitedStringCollection object.
          myStrCollection.AddRange( _
            authorizationRuleCollection.Get(i).Users.ToString().Split( _
            ",".ToCharArray()))
        End If
      Next

      Console.WriteLine("Allowed Users: {0}", _
        myStrCollection.ToString())

      ' Count the elements in the collection.
      Console.WriteLine("Allowed User Count: {0}", _
        myStrCollection.Count)

      ' Call the Contains method.
      Console.WriteLine("Contains 'userName1': {0}", _
        myStrCollection.Contains("userName1"))

      ' Determine the index of an element
      ' in the collection.
      Console.WriteLine("IndexOf 'userName0': {0}", _
        myStrCollection.IndexOf("userName0"))

      ' Call IsModified.
      Console.WriteLine("IsModified: {0}", _
        myStrCollection.IsModified)

      ' Call IsReadyOnly.
      Console.WriteLine("IsReadOnly: {0}", _
        myStrCollection.IsReadOnly)

      Console.WriteLine()
      Console.WriteLine("Add a user name to the collection.")
      ' Insert a new element in the collection.
      myStrCollection.Insert(myStrCollection.Count, "userNameX")

      Console.WriteLine("Collection Value: {0}", _
        myStrCollection.ToString())

      Console.WriteLine()
      Console.WriteLine("Remove a user name from the collection.")
      ' Remove an element of the collection.
      myStrCollection.Remove("userNameX")

      Console.WriteLine("Collection Value: {0}", _
        myStrCollection.ToString())

      ' Display and wait
      Console.ReadLine()
    End Sub
  End Class
End Namespace