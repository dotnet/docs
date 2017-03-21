    Public Class Customer
        Implements IEditableObject

        Structure CustomerData
            Friend id As String
            Friend firstName As String
            Friend lastName As String
        End Structure 

        Public parent As CustomersList
        Private custData As CustomerData
        Private backupData As CustomerData
        Private inTxn As Boolean = False


        ' Implements IEditableObject
        Sub BeginEdit() Implements IEditableObject.BeginEdit
            Console.WriteLine("Start BeginEdit")
            If Not inTxn Then
                Me.backupData = custData
                inTxn = True
                Console.WriteLine(("BeginEdit - " + Me.backupData.lastName))
            End If
            Console.WriteLine("End BeginEdit")
        End Sub 


        Sub CancelEdit() Implements IEditableObject.CancelEdit
            Console.WriteLine("Start CancelEdit")
            If inTxn Then
                Me.custData = backupData
                inTxn = False
                Console.WriteLine(("CancelEdit - " + Me.custData.lastName))
            End If
            Console.WriteLine("End CancelEdit")
        End Sub 


        Sub EndEdit() Implements IEditableObject.EndEdit
            Console.WriteLine(("Start EndEdit" + Me.custData.id + Me.custData.lastName))
            If inTxn Then
                backupData = New CustomerData()
                inTxn = False
                Console.WriteLine(("Done EndEdit - " + Me.custData.id + Me.custData.lastName))
            End If
            Console.WriteLine("End EndEdit")
        End Sub 


        Public Sub New(ByVal ID As String)
            Me.custData = New CustomerData()
            Me.custData.id = ID
            Me.custData.firstName = ""
            Me.custData.lastName = ""
        End Sub 


        Public ReadOnly Property ID() As String
            Get
                Return Me.custData.id
            End Get
        End Property


        Public Property FirstName() As String
            Get
                Return Me.custData.firstName
            End Get
            Set(ByVal Value As String)
                Me.custData.firstName = Value
                Me.OnCustomerChanged()
            End Set
        End Property


        Public Property LastName() As String
            Get
                Return Me.custData.lastName
            End Get
            Set(ByVal Value As String)
                Me.custData.lastName = Value
                Me.OnCustomerChanged()
            End Set
        End Property


        Friend Property Parents() As CustomersList
            Get
                Return Parent
            End Get
            Set(ByVal Value As CustomersList)
                parent = Value
            End Set
        End Property


        Private Sub OnCustomerChanged()
            If Not inTxn And (Parent IsNot Nothing) Then
                Parent.CustomerChanged(Me)
            End If
        End Sub 

        
        Public Overrides Function ToString() As String
            Dim sb As New StringWriter()
            sb.Write(Me.FirstName)
            sb.Write(" ")
            sb.Write(Me.LastName)
            Return sb.ToString()
        End Function 
    End Class
