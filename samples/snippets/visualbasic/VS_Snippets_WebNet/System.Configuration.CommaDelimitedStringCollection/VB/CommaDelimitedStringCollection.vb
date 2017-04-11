' <Snippet1>
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

      ' <Snippet2>
      ' Create a CommaDelimitedStringCollection object.
      Dim myStrCollection As CommaDelimitedStringCollection = _
        New CommaDelimitedStringCollection()
      ' </Snippet2>

      Dim i As Integer
      For i = 0 To authorizationRuleCollection.Count - 1 Step i + 1
        If authorizationRuleCollection.Get(i).Action.ToString().ToLower() _
          = "allow" Then
          ' <Snippet3>
          ' Add values to the CommaDelimitedStringCollection object.
          myStrCollection.AddRange( _
            authorizationRuleCollection.Get(i).Users.ToString().Split( _
            ",".ToCharArray()))
          ' </Snippet3>
        End If
      Next

      Console.WriteLine("Allowed Users: {0}", _
        myStrCollection.ToString())

      ' <Snippet4>
      ' Count the elements in the collection.
      Console.WriteLine("Allowed User Count: {0}", _
        myStrCollection.Count)
      ' </Snippet4>

      ' <Snippet5>
      ' Call the Contains method.
      Console.WriteLine("Contains 'userName1': {0}", _
        myStrCollection.Contains("userName1"))
      ' </Snippet5>

      ' <Snippet6>
      ' Determine the index of an element
      ' in the collection.
      Console.WriteLine("IndexOf 'userName0': {0}", _
        myStrCollection.IndexOf("userName0"))
      ' </Snippet6>

      ' <Snippet7>
      ' Call IsModified.
      Console.WriteLine("IsModified: {0}", _
        myStrCollection.IsModified)
      ' </Snippet7>

      ' <Snippet8>
      ' Call IsReadyOnly.
      Console.WriteLine("IsReadOnly: {0}", _
        myStrCollection.IsReadOnly)
      ' </Snippet8>

      Console.WriteLine()
      Console.WriteLine("Add a user name to the collection.")
      ' <Snippet9>
      ' Insert a new element in the collection.
      myStrCollection.Insert(myStrCollection.Count, "userNameX")
      ' </Snippet9>

      Console.WriteLine("Collection Value: {0}", _
        myStrCollection.ToString())

      Console.WriteLine()
      Console.WriteLine("Remove a user name from the collection.")
      ' <Snippet10>
      ' Remove an element of the collection.
      myStrCollection.Remove("userNameX")
      ' </Snippet10>

      Console.WriteLine("Collection Value: {0}", _
        myStrCollection.ToString())

      ' Display and wait
      Console.ReadLine()
    End Sub
  End Class
End Namespace
' </Snippet1>
