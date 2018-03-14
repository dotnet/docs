 '
'  This program demonstrates 'Item(string)' and 'Count' properties of 'CookieCollection' class.
'
'  This program uses an internal site called "CookiesServer.aspx". The program creates a 'HttpWebRequest'
'  object with the 'URL' taken from command line argument. When no cookies are initially sent to
'  the server, it responds with a specific page querying the client for information. The client queries
'  this information from the user and sends it to the server in the second request. This information is  
'  used by the server to not only structure the page sent subsequently but also construct some cookies to be
'  set by the client, for future requests. The response and the cookies that are sent from the server are 
'  displayed to the console.
'
'  Note: This program requires the "CookiesServer.aspx" server to be running before the execution of this 
'        program.Please refer the "ReadmeCookiesServer.txt" file for setting up the server.
'

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic


Public Class CookieCollection_Item_1
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    
    Overloads Public Shared Sub Main(args() As [String])
        Try
            If args.Length < 2 Then
                printUsage()
                Return
            End If
            GetPage(New Uri(args(1)))
        Catch e As UriFormatException
            Console.WriteLine(("UriFormatException raised." + ControlChars.Cr + "Error : " + e.Message))
        Catch e As Exception
            Console.WriteLine(("Exception raised." + ControlChars.Cr + "Error : " + e.Message))
        End Try
    End Sub 'Main
    
    
    Public Shared Sub GetPage(requestUri As Uri)
        Try
            Dim output(120) As Byte
            Dim myStream As Stream
            Dim asciiEncoding as New ASCIIEncoding()
            
            'Create the request.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            
            'Get the response without any cookies sent to the server.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
            Dim usrName As [String]
            Dim dateBirth As [String]
            Dim placeBirth As [String]
            
            'Get the information from the user as requested by the server and send it over to the server.
            myHttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            myHttpWebRequest.Method = "POST"
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            Console.WriteLine(ControlChars.Cr + "Enter the values to be sent to the server :" + ControlChars.Cr)
            Console.Write("UserName : ")
            usrName = Console.ReadLine()
            Console.Write(ControlChars.Cr + "DateOfBirth [dd/mm/yyyy]: ")
            dateBirth = Console.ReadLine()
            Dim regex As New Regex("/")
            Dim convertDate As [String] = regex.Replace(dateBirth, "%2F")
            Console.Write(ControlChars.Cr + "PlaceOfBirth : ")
            placeBirth = Console.ReadLine()
            Console.WriteLine("")
            output = asciiEncoding.GetBytes(("UserName" + ChrW(61) + usrName + "&DateOfBirth" + ChrW(61) + convertDate + "&PlaceOfBirth" + ChrW(61) + placeBirth + "&__EVENTTARGET" + ChrW(61) + "PlaceOfBirth&__EVENTARGUMENT" + ChrW(61)))
            myHttpWebRequest.ContentLength = output.Length
            myStream = myHttpWebRequest.GetRequestStream()
            myStream.Write(output, 0, output.Length)
            myStream.Close()
            myHttpWebResponse.Close()
            'Get the response.
            myHttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
            'Output the response to the console.
            myStream = myHttpWebResponse.GetResponseStream()
            
            Console.WriteLine("Displaying the contents of the page of '{0}' site:", requestUri.ToString())
            Console.WriteLine("")
            
            Dim bytesRead As Integer = 0
            While(bytesRead <= myStream.Read(output, 0, output.Length)) <> 0 'ToDo: Unsupported feature: assignment within expression. "=" changed to "<="
                Console.Write(asciiEncoding.GetString(output, 0, bytesRead))
            End While
            Console.WriteLine("")
            
            Console.WriteLine(ControlChars.Cr + "Displaying the cookies in the response : ")
            Console.WriteLine("")
            DisplayCookies(myHttpWebResponse.Cookies)
            myHttpWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(("WebException raised." + ControlChars.Cr + "Error : " + e.Message))
        Catch e As Exception
            Console.WriteLine(("Exception raised." + ControlChars.Cr + "Error : " + e.Message))
        End Try
    End Sub 'GetPage
    
    
    Public Shared Sub DisplayCookies(cookies As CookieCollection)
' <Snippet1>
' <Snippet2>
        ' Get the cookies in the 'CookieCollection' object using the 'Item' property.


        Try
            If cookies.Count = 0 Then
                Console.WriteLine("No cookies to display")
                Return
            End If
            Console.WriteLine("{0}", cookies("UserName").ToString())
            Console.WriteLine("{0}", cookies("DateOfBirth").ToString())
            Console.WriteLine("{0}", cookies("PlaceOfBirth").ToString())
            Console.WriteLine("")
        Catch e As Exception
            Console.WriteLine(("Exception raised." + ControlChars.Cr + "Error : " + e.Message))
        End Try
' </Snippet2>
' </Snippet1>
    End Sub 'DisplayCookies
     
'The Snippet for 'Count' property of 'CookieCollection' class ends.
'The Snippet for 'Item(string)' property of 'CookieCollection' class ends.

    Public Shared Sub printUsage()
        Console.WriteLine("Usage : ")
        Console.WriteLine("CookieCollection_Item_1 " + ChrW(60) + "urlname" + ChrW(62))
        Console.WriteLine(ChrW(60) + "urlname" + ChrW(62) + " is the name of the CookiesServer.aspx site installed locally")
        Console.WriteLine(ControlChars.Cr + "Example : CookieCollection_Item_1 http://www.MyServer.com/CookiesServer.aspx")
    End Sub 'printUsage
End Class 'CookieCollection_Item_1 