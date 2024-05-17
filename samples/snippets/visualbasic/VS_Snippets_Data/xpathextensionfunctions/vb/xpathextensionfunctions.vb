'<snippet1>
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.IO

Module Program

    Sub Main()

        Dim KeyChar As Char = " "

        While (True)
            Console.WriteLine()
            Console.Write("Enter key character to count in names: ")
            KeyChar = Console.ReadKey().KeyChar()
            If KeyChar = "q" Then Return

            Try
                ' Load source XML into an XPathDocument object instance.
                Dim XmlDoc As New XPathDocument("Tasks.xml")
                ' Create an XPathNavigator from the XPathDocument.
                Dim Navigator As XPathNavigator = XmlDoc.CreateNavigator()

                ' Create argument list and add the parameters.
                Dim VarList As New XsltArgumentList()
                VarList.AddParam("charToCount", "", KeyChar)

                ' Create an instance of custom XsltContext object.
                ' Pass in the XsltArgumentList object in which
                ' the user-defined variable will be defined.
                Dim Context As New CustomContext(New NameTable(), VarList)

                ' Add a namespace definition for the namespace prefix that qualifies
                ' the user-defined function name in the query expression.
                Context.AddNamespace("Extensions", "http://xpathExtensions")

                ' Create the XPath expression using extension function select nodes
                ' that contain 3 occurrences of the character entered by user.
                Dim XPath As XPathExpression = _
                   XPathExpression.Compile("/Tasks/Name[Extensions:CountChar(., $charToCount) = 2]")

                XPath.SetContext(Context)
                Dim Iterator As XPathNodeIterator = Navigator.Select(XPath)

                Console.WriteLine(vbCrLf)
                If Iterator.Count = 0 Then
                    Console.WriteLine("No results contain 2 instances of {0}.", _
                        KeyChar.ToString())
                Else
                    Console.WriteLine("Results that contain 2 instances of {0}: ", _
                        KeyChar.ToString())
                    ' Iterate over the selected nodes and output
                    ' the results filtered by extension function.
                    While Iterator.MoveNext()
                        Console.WriteLine(Iterator.Current.Value)
                    End While
                end if
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End While

    End Sub

End Module

'</snippet1>

'<snippet2>
Class CustomContext
    Inherits XsltContext

    Private Const ExtensionsNamespaceUri As String = "http://xpathExtensions"

    ' XsltArgumentList to store names and values of user-defined variables.
    Private m_ArgList As XsltArgumentList

    Public Sub New()

    End Sub

    Public Sub New(ByVal NT As NameTable, ByVal Args As XsltArgumentList)
        MyBase.New(NT)
        m_ArgList = Args
    End Sub

    ' Empty implementation, returns 0.
    Public Overrides Function CompareDocument(ByVal BaseUri As String, ByVal NextBaseUri As String) As Integer
        Return 0
    End Function

    ' Empty implementation, returns false.
    Public Overrides Function PreserveWhitespace(ByVal Node As XPathNavigator) As Boolean
        Return False
    End Function

    Public Overrides Function ResolveFunction(ByVal Prefix As String, ByVal Name As String, ByVal ArgTypes() As XPathResultType) As IXsltContextFunction

        If LookupNamespace(Prefix) = ExtensionsNamespaceUri Then
            Select Case Name
                Case "CountChar"
                    Return New XPathExtensionFunctions(2, 2, _
                                    XPathResultType.Number, ArgTypes, "CountChar")

                Case "FindTaskBy" ' Implemented but not called.
                    Return New XPathExtensionFunctions(2, 2, _
                                    XPathResultType.String, ArgTypes, "FindTaskBy")

                Case "Right"  ' Implemented but not called.
                    Return New XPathExtensionFunctions(2, 2, _
                                    XPathResultType.String, ArgTypes, "Right")

                Case "Left"   ' Implemented but not called.
                    Return New XPathExtensionFunctions(2, 2, _
                                    XPathResultType.String, ArgTypes, "Left")

                Case Else

            End Select
        End If
        ' Return Nothing if none of the functions match name.
        Return Nothing

    End Function

    ' Function to resolve references to user-defined XPath
    ' extension variables in XPath query.
    Public Overrides Function ResolveVariable(ByVal Prefix As String, ByVal Name As String) As IXsltContextVariable
        If LookupNamespace(Prefix) = ExtensionsNamespaceUri OrElse Len(Prefix) > 0 Then
            Throw New XPathException(String.Format("Variable '{0}:{1}' is not defined.", Prefix, Name))
        End If

        Select Case Name
            Case "charToCount", "left", "right", "text"
                ' Create an instance of an XPathExtensionVariable
                ' (custom IXsltContextVariable implementation) object
                ' by supplying the name of the user-defined variable to resolve.
                Return New XPathExtensionVariable(Prefix, Name)

                ' The Evaluate method of the returned object will be used at run time
                ' to resolve the user-defined variable that is referenced in the XPath
                ' query expression.
            Case Else

        End Select
        ' Return Nothing if none of the variables match name.
        Return Nothing

    End Function

    Public Overrides ReadOnly Property Whitespace() As Boolean
        Get
            Return True
        End Get
    End Property

    ' The XsltArgumentList property is accessed by the Evaluate method of the
    ' XPathExtensionVariable object that the ResolveVariable method returns.
    ' It is used to resolve references to user-defined variables in XPath query
    ' expressions.
    Public ReadOnly Property ArgList() As XsltArgumentList
        Get
            Return m_ArgList
        End Get
    End Property
End Class

'</snippet2>
'<snippet3>
' The interface that resolves and executes a specified user-defined function.
Public Class XPathExtensionFunctions
    Implements IXsltContextFunction

    ' The data types of the arguments passed to XPath extension function.
    Private m_ArgTypes() As XPathResultType
    ' The minimum number of arguments that can be passed to function.
    Private m_MinArgs As Integer
    ' The maximum number of arguments that can be passed to function.
    Private m_MaxArgs As Integer
    ' The data type returned by extension function.
    Private m_ReturnType As XPathResultType
    ' The name of the extension function.
    Private m_FunctionName As String

    ' Constructor used in the ResolveFunction method of the custom XsltContext
    ' class to return an instance of IXsltContextFunction at run time.
    Public Sub New(ByVal MinArgs As Integer, ByVal MaxArgs As Integer, ByVal ReturnType As XPathResultType, ByVal ArgTypes() As XPathResultType, ByVal FunctionName As String)
        m_MinArgs = MinArgs
        m_MaxArgs = MaxArgs
        m_ReturnType = ReturnType
        m_ArgTypes = ArgTypes
        m_FunctionName = FunctionName
    End Sub

    ' Readonly property methods to access private fields.
    Public ReadOnly Property ArgTypes() As XPathResultType() Implements IXsltContextFunction.ArgTypes
        Get
            Return m_ArgTypes
        End Get
    End Property

    Public ReadOnly Property MaxArgs() As Integer Implements IXsltContextFunction.Maxargs
        Get
            Return m_MaxArgs
        End Get
    End Property

    Public ReadOnly Property MinArgs() As Integer Implements IXsltContextFunction.Minargs
        Get
            Return m_MinArgs
        End Get
    End Property

    Public ReadOnly Property ReturnType() As XPathResultType Implements IXsltContextFunction.ReturnType
        Get
            Return m_ReturnType
        End Get
    End Property

    ' Function to execute a specified user-defined XPath
    ' extension function at run time.
    Public Function Invoke(ByVal Context As XsltContext, ByVal Args() As Object, ByVal DocContext As XPathNavigator) As Object Implements IXsltContextFunction.Invoke

        Select Case m_FunctionName
            Case "CountChar"
                Return CountChar(DirectCast(Args(0), XPathNodeIterator), CChar(Args(1)))
            Case "FindTaskBy"
                Return FindTaskBy(DirectCast(Args(0), XPathNodeIterator), CStr(Args(1).ToString()))
            Case "Left"
                Return Left(CStr(Args(0)), CInt(Args(1)))
            Case "Right"
                Return Right(CStr(Args(0)), CInt(Args(1)))
            Case Else

        End Select
        ' Return Nothing for unknown function name.
        Return Nothing

    End Function

    ' XPath extension functions.
    Private Function CountChar(ByVal Node As XPathNodeIterator, ByVal CharToCount As Char) As Integer

        Dim CharCount As Integer = 0

        For CharIndex As Integer = 0 To Node.Current.Value.Length - 1
            If Node.Current.Value(CharIndex) = CharToCount Then
                CharCount += 1
            End If
        Next

        Return CharCount

    End Function

    ' This overload will not force the user
    ' to cast to string in the xpath expression
    Private Function FindTaskBy(ByVal Node As XPathNodeIterator, ByVal Text As String) As String

        If (Node.Current.Value.Contains(Text)) Then
            Return Node.Current.Value
        Else
            Return ""
        End If

    End Function

End Class

'</snippet3>
'<snippet4>
' The interface used to resolve references to user-defined variables
' in XPath query expressions at run time. An instance of this class
' is returned by the overridden ResolveVariable function of the
' custom XsltContext class.
Public Class XPathExtensionVariable
    Implements IXsltContextVariable

    ' Namespace of user-defined variable.
    Private m_Prefix As String
    ' The name of the user-defined variable.
    Private m_VarName As String

    ' Constructor used in the overridden ResolveVariable function of custom XsltContext.
    Public Sub New(ByVal Prefix As String, ByVal VarName As String)
        m_Prefix = Prefix
        m_VarName = VarName
    End Sub

    ' Function to return the value of the specified user-defined variable.
    ' The GetParam method of the XsltArgumentList property of the active
    ' XsltContext object returns value assigned to the specified variable.
    Public Function Evaluate(ByVal Context As XsltContext) As Object Implements IXsltContextVariable.Evaluate
        Dim vars As XsltArgumentList = DirectCast(Context, CustomContext).ArgList
        Return vars.GetParam(m_VarName, m_Prefix)
    End Function

    ' Determines whether this variable is a local XSLT variable.
    ' Needed only when using a style sheet.
    Public ReadOnly Property IsLocal() As Boolean Implements IXsltContextVariable.IsLocal
        Get
            Return False
        End Get
    End Property

    ' Determines whether this parameter is an XSLT parameter.
    ' Needed only when using a style sheet.
    Public ReadOnly Property IsParam() As Boolean Implements IXsltContextVariable.IsParam
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property VariableType() As XPathResultType Implements IXsltContextVariable.VariableType
        Get
            Return XPathResultType.Any
        End Get
    End Property
End Class
'</snippet4>
