'<Snippet1>
Imports System

Namespace DesignLibrary

   Public Class ErrorProne
   
      Dim someUriValue As String 

      ' Violates rule UriPropertiesShouldNotBeStrings.
      Property SomeUri As String
         Get 
            Return someUriValue 
         End Get
         Set 
            someUriValue = Value 
         End Set
      End Property

      ' Violates rule UriParametersShouldNotBeStrings.
      Sub AddToHistory(uriString As String)
      End Sub

      ' Violates rule UriReturnValuesShouldNotBeStrings.
      Function GetRefererUri(httpHeader As String) As String
         Return "http://www.adventure-works.com"
      End Function

   End Class

   Public Class SaferWay
   
      Dim someUriValue As Uri 

      ' To retrieve a string, call SomeUri.ToString().
      ' To set using a string, call SomeUri = New Uri(string).
      Property SomeUri As Uri
         Get 
            Return someUriValue 
         End Get
         Set 
            someUriValue = Value 
         End Set
      End Property

      Sub AddToHistory(uriString As String)
         ' Check for UriFormatException.
         AddToHistory(New Uri(uriString))
      End Sub

      Sub AddToHistory(uriString As Uri)
      End Sub

      Function GetRefererUri(httpHeader As String) As Uri
         Return New Uri("http://www.adventure-works.com")
      End Function

   End Class

End Namespace
'</Snippet1>
