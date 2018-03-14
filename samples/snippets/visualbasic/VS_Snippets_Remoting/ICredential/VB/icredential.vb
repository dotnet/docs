 '
'   This program demonstrates 'GetCredential' method of 'ICredentials' interface.
'   The 'CredentialList' class implements 'ICredentials' interface which stores credentials for multiple 
'   internet resources.The Program takes URL, Username, Password and Domain name from commandline and adds 
'   it to an instance of 'CredentialList' class.An instance of 'WebRequest' class is obtained and 'Credentials'
'   property of 'WebRequest' class is set to an instance of 'NetworkCredential' class obtained by calling 
'   'GetCredential' method of 'CredentialList' class. Then it sends the request and obtains a response.
'


Imports System
Imports System.Net
Imports System.Collections
Imports Microsoft.VisualBasic

Namespace CrendentialSample
    
    

    Class CredentialList
        Implements ICredentials

' <Snippet1>	
       
        Class CredentialInfo
            Public uriObj As Uri
            Public authenticationType As [String]
            Public networkCredentialObj As NetworkCredential
            
            
            Public Sub New(uriObj As Uri, authenticationType As [String], networkCredentialObj As NetworkCredential)
                Me.uriObj = uriObj
                Me.authenticationType = authenticationType
                Me.networkCredentialObj = networkCredentialObj
            End Sub 'New
        End Class 'CredentialInfo
        
        Private arrayListObj As ArrayList
        
        
        Public Sub New()
            arrayListObj = New ArrayList()
        End Sub 'New
        
        
        Public Sub Add(uriObj As Uri, authenticationType As [String], credential As NetworkCredential)
            ' adds a 'CredentialInfo' object into a list
            arrayListObj.Add(New CredentialInfo(uriObj, authenticationType, credential))
        End Sub 'Add
        
        ' Remove the 'CredentialInfo' object from the list which matches to the given 'Uri' and 'AuthenticationType'
        Public Sub Remove(uriObj As Uri, authenticationType As [String])
            Dim index As Integer
            For index = 0 To arrayListObj.Count - 1
                Dim credentialInfo As CredentialInfo = CType(arrayListObj(index), CredentialInfo)
                If uriObj.Equals(credentialInfo.uriObj) And authenticationType.Equals(credentialInfo.authenticationType) Then
                    arrayListObj.RemoveAt(index)
                End If
            Next index
        End Sub 'Remove
        
        Public Function GetCredential(uriObj As Uri, authenticationType As [String]) As NetworkCredential  Implements ICredentials.GetCredential
            Dim index As Integer
            For index = 0 To arrayListObj.Count - 1
                Dim credentialInfoObj As CredentialInfo = CType(arrayListObj(index), CredentialInfo)
                If uriObj.Equals(credentialInfoObj.uriObj) And authenticationType.Equals(credentialInfoObj.authenticationType) Then
                    Return credentialInfoObj.networkCredentialObj
                End If
            Next index
            Return Nothing
        End Function 'GetCredential
' </Snippet1>	

    End Class 'CredentialList
    
    
    'The 'CredentialTest' is defined to test the 'CredentialList' class.
    Class CredentialTest
        
        Public Shared Sub Main()
            Dim urlString, username, password, domainname As String
            Console.Write("Enter a URL(for e.g. http://www.microsoft.com : ")
            urlString = Console.ReadLine()
            Console.Write("Enter User name : ")
            username = Console.ReadLine()
            Console.Write("Enter Password :")
            password = Console.ReadLine()
            Console.Write("Enter Domain name : ")
            domainname = Console.ReadLine()
            GetPage(urlString, username, password, domainname)
        End Sub 'Main
        
        
        Public Shared Sub GetPage(urlString As String, UserName As String, password As String, DomainName As String)
            Try
                Dim credentialListObj As New CredentialList()
                'Dummy names used as credentials
                credentialListObj.Add(New Uri(urlString), "Basic", New NetworkCredential(UserName, password, DomainName))
                credentialListObj.Add(New Uri("http://www.msdn.microsoft.com"), "Basic", New NetworkCredential("User1", "Passwd1", "Domain1"))
                'Create a 'WebRequest' for the specified url 
                Dim myWebRequest As WebRequest = WebRequest.Create(urlString)
                'Call 'GetCredential' to obtain the credentials specific to a Uri
                myWebRequest.Credentials = credentialListObj.GetCredential(New Uri(urlString), "Basic")
                
                'Send the request and get the  response.
                Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
                ' ....Process the response here
                Console.WriteLine(ControlChars.Cr + " Response Received.")
                myWebResponse.Close()
            Catch e As WebException
                Console.WriteLine("WebException caught !!!")
                Console.WriteLine(("Message : " + e.Message))
            Catch e As Exception
                Console.WriteLine("Exception caught !!!")
                Console.WriteLine(("Message : " + e.Message))
            End Try
        End Sub 'GetPage
    End Class 'CredentialTest
End Namespace 'CrendentialSample