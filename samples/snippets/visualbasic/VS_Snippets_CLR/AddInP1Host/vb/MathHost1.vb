'<Snippet1>
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.AddIn.Hosting
Imports Calc1HVA.CalcHVAs

Namespace MathHost

    Module MathHost1

        Sub Main()
            ' Assume that the current directory is the application folder, 
            ' and that it contains the pipeline folder structure.
            Dim addInRoot As String = Environment.CurrentDirectory & "\Pipeline"

            ' Update the cache files of the pipeline segments and add-ins.
            Dim warnings() As String = AddInStore.Update(addInRoot)
            For Each warning As String In warnings
                Console.WriteLine(warning)
            Next

            ' Search for add-ins of type ICalculator (the host view of the add-in).
            Dim tokens As System.Collections.ObjectModel.Collection(Of AddInToken) = _
                AddInStore.FindAddIns(GetType(ICalculator), addinRoot)

            ' Ask the user which add-in they would like to use.
            Dim calcToken As AddInToken = ChooseCalculator(tokens)

            ' Activate the selected AddInToken in a new application domain 
            ' with the Internet trust level.
            Dim calc As ICalculator = _
                calcToken.Activate(Of ICalculator)(AddInSecurityLevel.Internet)

            ' Run the add-in.
            RunCalculator(calc)
        End Sub

        Private Function ChooseCalculator(ByVal tokens As Collection(Of AddInToken)) _
                As AddInToken

            If (tokens.Count = 0) Then
                Console.WriteLine("No calculators are available")
                Return Nothing
            End If

            Console.WriteLine("Available Calculators: ")
            ' Show the token properties for each token in the AddInToken collection
            ' (tokens), preceded by the add-in number in [] brackets.
            Dim tokNumber As Integer = 1
            For Each tok As AddInToken In tokens
                Console.WriteLine(vbTab & "[{0}]: {1} - {2}" & _
                        vbLf & vbTab & "{3}" & _
                        vbLf & vbTab & "{4}" & _
                        vbLf & vbTab & "{5} - {6}", _
                        tokNumber.ToString, tok.Name, _
                        tok.AddInFullName, tok.AssemblyName, _
                        tok.Description, tok.Version, tok.Publisher)
                tokNumber = tokNumber + 1
            Next
            Console.WriteLine("Which calculator do you want to use?")
            Dim line As String = Console.ReadLine
            Dim selection As Integer
            If Int32.TryParse(line, selection) Then
                If (selection <= tokens.Count) Then
                    Return tokens((selection - 1))
                End If
            End If
            Console.WriteLine("Invalid selection: {0}. Please choose again.", line)
            Return ChooseCalculator(tokens)
        End Function

        Private Sub RunCalculator(ByVal calc As ICalculator)
            If IsNothing(calc) Then
                'No calculators were found, read a line and exit.
                Console.ReadLine()
            End If
            Console.WriteLine("Available operations: +, -, *, /")
            Console.WriteLine("Request a calculation , such as: 2 + 2")
            Console.WriteLine("Type 'exit' to exit")
            Dim line As String = Console.ReadLine

            While Not line.Equals("exit")
                ' The Parser class parses the user's input.
                Try
                    Dim c As Parser = New Parser(line)
                    Select Case (c.action)
                        Case "+"
                            Console.WriteLine(calc.Add(c.a, c.b))
                        Case "-"
                            Console.WriteLine(calc.Subtract(c.a, c.b))
                        Case "*"
                            Console.WriteLine(calc.Multiply(c.a, c.b))
                        Case "/"
                            Console.WriteLine(calc.Divide(c.a, c.b))
                        Case Else
                            Console.WriteLine("{0} is an invalid command. Valid commands are +,-,*,/", c.action)
                    End Select
                Catch Ex As System.Exception
                    Console.WriteLine("Invalid command: {0}. Commands must be formated: [number] [operation] [number]", line)
                End Try
                line = Console.ReadLine

            End While
        End Sub
    End Module

    Class Parser

        Public partA As Double
        Public partB As Double
        Public action As String

        Friend Sub New(ByVal line As String)
            MyBase.New()
            Dim parts() As String = line.Split(" ")
            partA = Double.Parse(parts(0))
            action = parts(1)
            partB = Double.Parse(parts(2))
        End Sub

        Public ReadOnly Property A() As Double
            Get
                Return partA
            End Get
        End Property

        Public ReadOnly Property B() As Double
            Get
                Return partB
            End Get
        End Property

        Public ReadOnly Property CalcAction() As String
            Get
                Return Action
            End Get
        End Property
    End Class

End Namespace
' </Snippet1>

