' <Snippet1>
Class MainClass
    Public Shared Sub Main()
        Dim MyData As New MailToData()

        Console.Write("Enter Your Name: ")
        MyData.Name = Console.ReadLine()
        Console.Write("Enter Your Address: ")
        MyData.Address = Console.ReadLine()
        Console.Write("Enter Your City, State, and ZIP Code separated by spaces: ")
        MyData.CityStateZip = Console.ReadLine()
        Console.WriteLine()

        If MyData.Validated Then
            Console.WriteLine("Name: {0}", MyData.Name)
            Console.WriteLine("Address: {0}", MyData.Address)
            Console.WriteLine("City: {0}", MyData.City)
            Console.WriteLine("State: {0}", MyData.State)
            Console.WriteLine("ZIP Code: {0}", MyData.Zip)

            Console.WriteLine("The following address will be used:")
            Console.WriteLine(MyData.Address)
            Console.WriteLine(MyData.CityStateZip)
        End If
    End Sub
End Class

Public Class MailToData
    Private strName As String = ""
    Private strAddress As String = ""
    Private strCityStateZip As String = ""
    Private strCity As String = ""
    Private strState As String = ""
    Private strZip As String = ""
    Private parseSucceeded As Boolean = False

    Public Property Name() As String
        Get
            Return strName
        End Get
        Set
            strName = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return strAddress
        End Get
        Set
            strAddress = value
        End Set
    End Property

    Public Property CityStateZip() As String
        Get
            Return String.Format("{0}, {1} {2}", strCity, strState, strZip)
        End Get
        Set
            strCityStateZip = value.Trim()
            ParseCityStateZip()
        End Set
    End Property

    Public Property City() As String
        Get
            Return strCity
        End Get
        Set
            strCity = value
        End Set
    End Property

    Public Property State() As String
        Get
            Return strState
        End Get
        Set
            strState = value
        End Set
    End Property

    Public Property Zip() As String
        Get
            Return strZip
        End Get
        Set
            strZip = value
        End Set
    End Property

    Public ReadOnly Property Validated As Boolean
        Get
            Return parseSucceeded
        End Get
    End Property

    Private Sub ParseCityStateZip()
        Dim msg As String = Nothing
        Const msgEnd As String = vbCrLf +
                                 "You must enter spaces between city, state, and zip code." +
                                 vbCrLf

        ' Throw a FormatException if the user did not enter the necessary spaces
        ' between elements. 
        Try
            ' City may consist of multiple words, so we'll have to parse the 
            ' string from right to left starting with the zip code.
            Dim zipIndex As Integer = strCityStateZip.LastIndexOf(" ")
            If zipIndex = -1 Then
                msg = vbCrLf + "Cannot identify a zip code." + msgEnd
                Throw New FormatException(msg)
            End If
            strZip = strCityStateZip.Substring(zipIndex + 1)

            Dim stateIndex As Integer = strCityStateZip.LastIndexOf(" ", zipIndex - 1)
            If stateIndex = -1 Then
                msg = vbCrLf + "Cannot identify a state." + msgEnd
                Throw New FormatException(msg)
            End If
            strState = strCityStateZip.Substring(stateIndex + 1, zipIndex - stateIndex - 1)
            strState = strState.ToUpper()

            strCity = strCityStateZip.Substring(0, stateIndex)
            If strCity.Length = 0 Then
                msg = vbCrLf + "Cannot identify a city." + msgEnd
                Throw New FormatException(msg)
            End If
            parseSucceeded = True
        Catch ex As FormatException
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class
' </Snippet1>
