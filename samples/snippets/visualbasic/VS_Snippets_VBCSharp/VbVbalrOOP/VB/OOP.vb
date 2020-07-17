Option Explicit On
Option Strict On

Imports System.Drawing
Imports System.Windows.Forms

Class Class03c4556dfe0b45eb9e173de9a1424912
    ' 03c4556d-fe0b-45eb-9e17-3de9a1424912
    ' How to: Treat Forms as Objects

    Class Form1
        Inherits System.Windows.Forms.Form
        ' <snippet1>
        ' Create a custom method on a form.
        Public Sub PrintMyJob()
            ' Insert the code for your method here.
        End Sub
        ' </snippet1>

        ' <snippet2>
        Public IDNumber As Integer
        ' </snippet2>
    End Class

    Public Sub Method3()
        ' <snippet3>
        Dim newForm1 As New Form1
        newForm1.PrintMyJob()
        ' </snippet3>

        ' <snippet4>
        newForm1.Show()
        ' </snippet4>
    End Sub

End Class

Class Class070188282d494cf5a44b19fb15d9efea
    ' 07018828-2d49-4cf5-a44b-19fb15d9efea
    ' Walkthrough: Defining Classes

    Class Class5
        ' <snippet5>
        Public Class UserNameInfo
        End Class
        ' </snippet5>
    End Class

    Class Class7
        Public Class UserNameInfo
            ' <snippet7>
            Private userNameValue As String
            ' </snippet7>

            ' <snippet8>
            Public Property UserName() As String
                Get
                    ' Gets the property value.
                    Return userNameValue
                End Get
                Set(ByVal Value As String)
                    ' Sets the property value.
                    userNameValue = Value
                End Set
            End Property
            ' </snippet8>

            ' <snippet9>
            Public Sub Capitalize()
                ' Capitalize the value of the property.
                userNameValue = UCase(userNameValue)
            End Sub
            ' </snippet9>

            ' <snippet10>
            Public Sub New(ByVal UserName As String)
                ' Set the property value.
                Me.UserName = UserName
            End Sub
            ' </snippet10>
        End Class

        Public Sub Method12()
            ' <snippet12>
            ' Create an instance of the class.
            Dim user As New UserNameInfo("Moore, Bobby")
            ' Capitalize the value of the property.
            user.Capitalize()
            ' Display the value of the property.
            MsgBox("The original UserName is: " & user.UserName)
            ' Change the value of the property.
            user.UserName = "Worden, Joe"
            ' Redisplay the value of the property.
            MsgBox("The new UserName is: " & user.UserName)
            ' </snippet12>
        End Sub
    End Class

End Class

Class Class15785a8ea9884de2a88f54ee6c9480bc
    ' 15785a8e-a988-4de2-a88f-54ee6c9480bc
    ' How to: Pass Objects to Procedures
    Class Form1
        Inherits Form

        Dim WithEvents Button1 As New Button

        ' <snippet13>
        Private Sub Button1_Click(ByVal sender As Object,
            ByVal e As System.EventArgs) Handles Button1.Click
            Dim newForm As New Form1
            newForm.Show()
            CenterForm(newForm)
        End Sub

        Sub CenterForm(ByVal TheForm As Form)
            ' Centers the form on the screen when you click the button.
            Dim RecForm As Rectangle = Screen.GetBounds(TheForm)
            TheForm.Left = CInt((RecForm.Width - TheForm.Width) / 2)
            TheForm.Top = CInt((RecForm.Height - TheForm.Height) / 2)
        End Sub
        ' </snippet13>

        Dim PictureBox1 As New PictureBox
        ' <snippet15>
        Protected Sub Form1_Click(ByVal sender As System.Object,
              ByVal e As System.EventArgs) Handles MyBase.Click
            Dim pictureSource As New Form2
            pictureSource.GetPicture(PictureBox1)
        End Sub
        ' </snippet15>
    End Class

    Class Form2
        Inherits Form

        Dim PictureBox2 As New PictureBox
        ' <snippet14>
        Public Sub GetPicture(ByVal x As PictureBox)
            Dim objX As PictureBox
            ' Assign the passed-in picture box to an object variable.
            objX = x
            ' Assign the value of the Picture property to the Form1 picture box.
            objX.Image = PictureBox2.Image
        End Sub
        ' </snippet14>

    End Class
End Class

Class Class18326e85d3e14e7a9b026e863d78574f
    ' 18326e85-d3e1-4e7a-9b02-6e863d78574f
    ' How to: Create and Implement Interfaces

    Class Class16
        ' <snippet16>
        Interface IAsset
        End Interface
        ' </snippet16>

        ' <snippet18>
        Class Computer
            Implements IAsset
        End Class
        ' </snippet18>
    End Class

    Class Class17
        ' <snippet17>
        Interface IAsset
            Event ComittedChange(ByVal Success As Boolean)
            Property Division() As String
            Function GetID() As Integer
        End Interface
        ' </snippet17>

        ' <snippet19>
        Class Computer
            Implements IAsset

            Public Event ComittedChange(
               ByVal Success As Boolean) Implements IAsset.ComittedChange

            Private divisionValue As String

            Public Property Division() As String Implements IAsset.Division

                Get
                    Return divisionValue
                End Get
                Set(ByVal value As String)
                    divisionValue = value
                    RaiseEvent ComittedChange(True)
                End Set
            End Property

            Private IDValue As Integer

            Public Function GetID() As Integer Implements IAsset.GetID

                Return IDValue
            End Function

            Public Sub New(ByVal Division As String, ByVal ID As Integer)
                Me.divisionValue = Division
                Me.IDValue = ID
            End Sub
        End Class
        ' </snippet19>
    End Class
End Class

Class Class18e8ef02e79b470e837a46a8f4163d32
    ' 18e8ef02-e79b-470e-837a-46a8f4163d32
    ' Override Modifiers

    ' <snippet20>
    MustInherit Class BaseClass
        Public MustOverride Sub aProcedure()
    End Class

    Class DerivedClass
        Inherits BaseClass
        Public NotOverridable Overrides Sub aProcedure()
            ' Override a procedure inherited from the base class
            ' and mark it with the NotOverridable modifier so that 
            ' it cannot be overridden in classes derived from this class.
        End Sub
    End Class
    ' </snippet20>

End Class

Class Class19c0598e9c8e4f0382b772f1684e3d34
    ' 19c0598e-9c8e-4f03-82b7-72f1684e3d34
    ' When to Use Inheritance

    Class Class21
        ' <snippet21>
        Class CustomerInfo
            Protected PreviousCustomer As CustomerInfo
            Protected NextCustomer As CustomerInfo
            Public ID As Integer
            Public FullName As String

            Public Sub InsertCustomer(ByVal FullName As String)
                ' Insert code to add a CustomerInfo item to the list.
            End Sub

            Public Sub DeleteCustomer()
                ' Insert code to remove a CustomerInfo item from the list.
            End Sub

            Public Function GetNextCustomer() As CustomerInfo
                ' Insert code to get the next CustomerInfo item from the list.
                Return NextCustomer
            End Function

            Public Function GetPrevCustomer() As CustomerInfo
                'Insert code to get the previous CustomerInfo item from the list.
                Return PreviousCustomer
            End Function
        End Class
        ' </snippet21>

        ' <snippet22>
        Class ShoppingCartItem
            Protected PreviousItem As ShoppingCartItem
            Protected NextItem As ShoppingCartItem
            Public ProductCode As Integer
            Public Function GetNextItem() As ShoppingCartItem
                ' Insert code to get the next ShoppingCartItem from the list.
                Return NextItem
            End Function
        End Class
        ' </snippet22>
    End Class

    Class Class23
        ' <snippet23>
        Class ListItem
            Protected PreviousItem As ListItem
            Protected NextItem As ListItem
            Public Function GetNextItem() As ListItem
                ' Insert code to get the next item in the list.
                Return NextItem
            End Function
            Public Sub InsertNextItem()
                ' Insert code to add a item to the list.
            End Sub

            Public Sub DeleteNextItem()
                ' Insert code to remove a item from the list.
            End Sub

            Public Function GetPrevItem() As ListItem
                'Insert code to get the previous item from the list.
                Return PreviousItem
            End Function
        End Class
        ' </snippet23>

        ' <snippet24>
        Class CustomerInfo
            Inherits ListItem
            Public ID As Integer
            Public FullName As String
        End Class
        Class ShoppingCartItem
            Inherits ListItem
            Public ProductCode As Integer
        End Class
        ' </snippet24>
    End Class

    Class DrawingShape
        Private Const shpCircle As String = "circle"
        Private Const shpLine As String = "line"
        Dim type As String
        ' <snippet115>
        Sub Draw(ByVal Shape As DrawingShape, ByVal X As Integer,
            ByVal Y As Integer, ByVal Size As Integer)

            Select Case Shape.type
                Case shpCircle
                    ' Insert circle drawing code here.
                Case shpLine
                    ' Insert line drawing code here.
            End Select
        End Sub
        ' </snippet115>
    End Class

    ' <snippet25>
    MustInherit Class Shape
        Public X As Integer
        Public Y As Integer
        MustOverride Sub Draw()
    End Class
    ' </snippet25>

    ' <snippet26>
    Class Line
        Inherits Shape
        Public Length As Integer
        Overrides Sub Draw()
            ' Insert code here to implement Draw for this shape.
        End Sub
    End Class
    ' </snippet26>

    ' <snippet27>
    Class Rectangle
        Inherits Line
        Public Width As Integer
        Overrides Sub Draw()
            ' Insert code here to implement Draw for the Rectangle shape.
        End Sub
    End Class
    ' </snippet27>

End Class

Class Class2167e8f512254b139ebd02591ba90213
    ' 2167e8f5-1225-4b13-9ebd-02591ba90213
    ' Overriding Properties and Methods

    ' <snippet28>
    Const BonusRate As Decimal = 1.45D
    Const PayRate As Decimal = 14.75D

    Class Payroll
        Overridable Function PayEmployee(
            ByVal HoursWorked As Decimal,
            ByVal PayRate As Decimal) As Decimal

            PayEmployee = HoursWorked * PayRate
        End Function
    End Class

    Class BonusPayroll
        Inherits Payroll
        Overrides Function PayEmployee(
            ByVal HoursWorked As Decimal,
            ByVal PayRate As Decimal) As Decimal

            ' The following code calls the original method in the base 
            ' class, and then modifies the returned value.
            PayEmployee = MyBase.PayEmployee(HoursWorked, PayRate) * BonusRate
        End Function
    End Class

    Sub RunPayroll()
        Dim PayrollItem As Payroll = New Payroll
        Dim BonusPayrollItem As New BonusPayroll
        Dim HoursWorked As Decimal = 40

        MsgBox("Normal pay is: " &
            PayrollItem.PayEmployee(HoursWorked, PayRate))
        MsgBox("Pay with bonus is: " &
            BonusPayrollItem.PayEmployee(HoursWorked, PayRate))
    End Sub
    ' </snippet28>

End Class

Class Class23e2a1ec7e9d41098940c703d981077b
    ' 23e2a1ec-7e9d-4109-8940-c703d981077b
    ' Properties and Property Procedures

    ' <snippet29>
    Protected Sub TestFieldsAndProperties()
        ' Assume, for this example, that the only valid values for
        ' the field and property are numbers less than 10.
        Dim NewClass As New ThisClass

        ' Test data validation. 

        ' Works because there is no data validation.
        NewClass.ThisField = 36
        ' Will print 36.
        MsgBox("ThisField = " & NewClass.ThisField)

        ' The attempt to set the field to a value greater than 10 will silently fail.
        NewClass.ThisProperty = 36
        ' The next statement will print the old value of 0 instead.
        MsgBox("ThisProperty = " & NewClass.ThisProperty)
    End Sub

    Public Class ThisClass
        ' Declare a field.
        Public ThisField As Integer
        ' Field used for Property Set operations.
        Private thisPropertyValue As Integer = 0
        ' Declare a property.
        Public Property ThisProperty() As Integer
            Get
                Return thisPropertyValue
            End Get
            Set(ByVal Value As Integer)
                ' Only allow Set operation for values less than 10.
                If Value < 10 Then thisPropertyValue = Value
            End Set
        End Property
    End Class
    ' </snippet29>

End Class

Class Class279c232acee54e3c97103696875c8ee4
    ' 279c232a-cee5-4e3c-9710-3696875c8ee4
    ' How to: Write Class Data to an XML File (Visual Basic)

    ' <snippet30>
    Public Class Book
        Public Title As String
        Public Sub New()
        End Sub
    End Class

    Public Sub WriteXML()
        Dim introToVB As New Book
        introToVB.Title = "Intro to Visual Basic"
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(Book))
        Dim file As New System.IO.StreamWriter("c:\IntroToVB.xml")
        writer.Serialize(file, introToVB)
        file.Close()
    End Sub
    ' </snippet30>

End Class

Class Class2c86373d03334616a7d84790c4e89f7b
    ' 2c86373d-0333-4616-a7d8-4790c4e89f7b
    ' Classes: Blueprints for Objects

    ' <snippet31>
    Class BankAccount
        Private AccountNumber As String
        Private AccountBalance As Decimal
        Private HoldOnAccount As Boolean = False
        Public Sub PostInterest()
            ' Add code to calculate the interest for this account.
        End Sub
        ReadOnly Property Balance() As Decimal
            Get
                ' Return the available balance.
                Return AccountBalance
            End Get
        End Property
    End Class

    Class CheckingAccount
        Inherits BankAccount
        Sub ProcessCheck()
            ' Add code to process a check drawn on this account.
        End Sub
    End Class
    ' </snippet31>

End Class

Class Class326214bb636748e7bb24714844791400
    ' 326214bb-6367-48e7-bb24-714844791400
    ' Class Methods

    ' <snippet32>
    Public Function WithDrawal(ByVal Amount As Decimal,
          ByVal TransactionCode As Byte) As Double
        ' Add code here to perform the withdrawal,
        ' return a transaction code, 
        ' or to raise an overdraft error.
    End Function
    ' </snippet32>

    ' <snippet33>
    Class ShareClass
        Shared Sub SharedSub()
            MsgBox("Shared method.")
        End Sub
    End Class

    Sub Test()
        ' Call the method.
        ShareClass.SharedSub()
    End Sub
    ' </snippet33>

End Class

Class Class44a46dd6c3ab4713ab8cdd677a2db107
    ' 44a46dd6-c3ab-4713-ab8c-dd677a2db107
    ' How to: Set and Retrieve Properties

    Public Sub Method35()
        Dim TextBox1 As New TextBox
        ' <snippet35>
        ' Set the Top property to 200 twips.
        TextBox1.Top = 200
        ' Display the text box.
        TextBox1.Visible = True
        ' Display 'hello' in the text box.
        TextBox1.Text = "hello"
        ' </snippet35>
    End Sub

    Dim WithEvents RadioButton1 As New RadioButton
    Protected Sub Method37()
        ' <snippet37>
        RadioButton1.Top += 20
        ' </snippet37>
    End Sub

End Class

Class Class4bb723b39190442a970fded6678f8604
    ' 4bb723b3-9190-442a-970f-ded6678f8604
    ' How to: Inherit from a Class (Visual Basic)

    ' <snippet38>
    Public Class Shape
        ' Definitions of properties, methods, fields, and events.
    End Class
    Public Class Circle : Inherits Shape
        ' Specialized properties, methods, fields, events for Circle.
    End Class
    Public Class Rectangle : Inherits Shape
        ' Specialized properties, methods, fields, events for Rectangle.
    End Class
    Public Class Square : Inherits Rectangle
        ' Specialized properties, methods, fields, events for Square.
    End Class
    ' </snippet38>

End Class

Class Class50bf2a3073b64126a921075fd6eec278
    ' 50bf2a30-73b6-4126-a921-075fd6eec278
    ' Interface Implementation Examples in Visual Basic

    ' <snippet39>
    Interface Interface1
        Sub sub1(ByVal i As Integer)
    End Interface

    ' Demonstrates interface inheritance.
    Interface Interface2
        Inherits Interface1
        Sub M1(ByVal y As Integer)
        ReadOnly Property Num() As Integer
    End Interface
    ' </snippet39>

    ' <snippet40>
    Public Class ImplementationClass1
        Implements Interface1
        Sub Sub1(ByVal i As Integer) Implements Interface1.sub1
            ' Insert code here to implement this method.
        End Sub
    End Class
    ' </snippet40>

    ' <snippet41>
    Public Class ImplementationClass2
        Implements Interface2
        Dim INum As Integer = 0
        Sub sub1(ByVal i As Integer) Implements Interface2.sub1
            ' Insert code here that implements this method.
        End Sub
        Sub M1(ByVal x As Integer) Implements Interface2.M1
            ' Insert code here to implement this method.
        End Sub

        ReadOnly Property Num() As Integer Implements Interface2.Num
            Get
                Num = INum
            End Get
        End Property
    End Class
    ' </snippet41>

End Class

Class Class57be4229e5254926a8a000616896116f
    ' 57be4229-e525-4926-a8a0-00616896116f
    ' How to: Use the New Keyword

    Class Form1 : Inherits Form
    End Class

    Public Sub Method47()
        ' <snippet117>
        Dim Button1 As System.Windows.Forms.Button
        Dim Button2 As New System.Windows.Forms.Button()
        ' </snippet117>
        Button1 = New System.Windows.Forms.Button()

        ' <snippet47>
        Dim f As New Form1
        f.Show()
        ' </snippet47>
    End Sub

    ' <snippet48>
    Public Class ShowMe
        Sub ShowFrm()
            Dim frmNew As Form1
            frmNew = New Form1
            frmNew.Show()
            frmNew.WindowState = FormWindowState.Minimized
        End Sub
    End Class
    ' </snippet48>

    Dim WithEvents Button1 As New Button
    ' <snippet49>
    Protected Sub Button1_Click(ByVal sender As System.Object,
          ByVal e As System.EventArgs) Handles Button1.Click
        Dim clsNew As New ShowMe
        clsNew.ShowFrm()
    End Sub
    ' </snippet49>

End Class

Class Class79a7b8b4b8c74ad8aca812a9a2b32f03
    ' 79a7b8b4-b8c7-4ad8-aca8-12a9a2b32f03
    ' Calling a Property or Method Using a String Name

    ' <snippet53>
    Class MathClass
        Function SquareRoot(ByVal X As Double) As Double
            Return Math.Sqrt(X)
        End Function
        Function InverseSine(ByVal X As Double) As Double
            Return Math.Atan(X / Math.Sqrt(-X * X + 1))
        End Function
        Function Acos(ByVal X As Double) As Double
            Return Math.Atan(-X / Math.Sqrt(-X * X + 1)) + 2 * Math.Atan(1)
        End Function
    End Class
    ' </snippet53>

    Dim TextBox1 As New TextBox
    Dim TextBox2 As New TextBox
    ' <snippet54>
    Private Sub CallMath()
        Dim Math As New MathClass
        Me.TextBox1.Text = CStr(CallByName(Math, Me.TextBox2.Text,
           Microsoft.VisualBasic.CallType.Method, TextBox1.Text))
    End Sub
    ' </snippet54>

End Class

Class Class7e677b9375264f229de79dffa4c62ef3
    ' 7e677b93-7526-4f22-9de7-9dffa4c62ef3
    ' How to: Read Class Data from an XML File (Visual Basic)

    ' <snippet55>
    Public Class Book
        Public Title As String
        Public Sub New()
        End Sub
    End Class

    Public Sub ReadXML()
        Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(Book))
        Dim file As New System.IO.StreamReader("c:\IntroToVB.xml")
        Dim introToVB As Book
        introToVB = CType(reader.Deserialize(file), Book)
    End Sub
    ' </snippet55>

End Class

Class Classa70f2a2781764858935ef25afdd43ab5
    ' a70f2a27-8176-4858-935e-f25afdd43ab5
    ' Default Properties

    ' <snippet58>
    Class Class2
        ' Define a local variable to store the property value.
        Private PropertyValues As String()
        ' Define the default property.
        Default Public Property Prop1(ByVal Index As Integer) As String
            Get
                Return PropertyValues(Index)
            End Get
            Set(ByVal Value As String)
                If PropertyValues Is Nothing Then
                    ' The array contains Nothing when first accessed.
                    ReDim PropertyValues(0)
                Else
                    ' Re-dimension the array to hold the new element.
                    ReDim Preserve PropertyValues(UBound(PropertyValues) + 1)
                End If
                PropertyValues(Index) = Value
            End Set
        End Property
    End Class
    ' </snippet58>

    Public Sub Method59()
        ' <snippet59>
        Dim C As New Class2
        ' The first two lines of code access a property the standard way.

        ' Property assignment.
        C.Prop1(0) = "Value One"
        ' Property retrieval.
        MsgBox(C.Prop1(0))

        ' The following two lines of code use default property syntax.

        ' Property assignment.
        C(1) = "Value Two"
        ' Property retrieval.
        MsgBox(C(1))
        ' </snippet59>
    End Sub

End Class

Class Classadf7a2324ebb485d86268d64421eb0c4
    ' adf7a232-4ebb-485d-8626-8d64421eb0c4
    ' How to: Implement the Dispose Finalize Pattern (Visual Basic)

    ' <snippet60>
    Public Class ResourceClass
        Implements IDisposable

        Private managedResource As System.ComponentModel.Component
        Private unmanagedResource As IntPtr
        Protected disposed As Boolean = False

        Public Sub New()
            ' Insert appropriate constructor code here.
        End Sub

        Protected Overridable Overloads Sub Dispose(
            ByVal disposing As Boolean)
            If Not Me.disposed Then
                If disposing Then
                    managedResource.Dispose()
                End If
                ' Add code here to release the unmanaged resource.
                unmanagedResource = IntPtr.Zero
                ' Note that this is not thread safe.
            End If
            Me.disposed = True
        End Sub

        Public Sub AnyOtherMethods()
            If Me.disposed Then
                Throw New ObjectDisposedException(Me.GetType().ToString,
                    "This object has been disposed.")
            End If
        End Sub

#Region " IDisposable Support "
        ' Do not change or add Overridable to these methods.
        ' Put cleanup code in Dispose(ByVal disposing As Boolean).
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
        Protected Overrides Sub Finalize()
            Dispose(False)
            MyBase.Finalize()
        End Sub
#End Region
    End Class
    ' </snippet60>

End Class

Class Classae53f61b3abc413e8931703c5f5e8fc2
    ' ae53f61b-3abc-413e-8931-703c5f5e8fc2
    ' How to: Add Fields and Properties to a Class

    Class Class61
        ' <snippet61>
        Class ThisClass
            Private m_PropVal As String
            Public Property One() As String
                Get
                    ' Return the value stored in the local variable.
                    Return m_PropVal
                End Get
                Set(ByVal Value As String)
                    ' Store the value in a local variable.
                    m_PropVal = Value
                End Set
            End Property
        End Class
        ' </snippet61>
    End Class

    Class Class62
        ' <snippet62>
        Class ThisClass
            Public ThisField As String
        End Class
        ' </snippet62>
    End Class

End Class

Class Classb12da757102c428ba8ddd3c1bce14c6b
    ' b12da757-102c-428b-a8dd-d3c1bce14c6b
    ' Inheritance-Based Polymorphism

    ' <snippet63>
    ' %5.3 State tax
    Const StateRate As Double = 0.053
    ' %2.8 City tax
    Const CityRate As Double = 0.028
    Public Class BaseTax
        Overridable Function CalculateTax(ByVal Amount As Double) As Double
            ' Calculate state tax.
            Return Amount * StateRate
        End Function
    End Class

    Public Class CityTax
        ' This method calls a method in the base class 
        ' and modifies the returned value.
        Inherits BaseTax
        Private BaseAmount As Double
        Overrides Function CalculateTax(ByVal Amount As Double) As Double
            ' Some cities apply a tax to the total cost of purchases,
            ' including other taxes. 
            BaseAmount = MyBase.CalculateTax(Amount)
            Return CityRate * (BaseAmount + Amount) + BaseAmount
        End Function
    End Class

    Sub TestPoly()
        Dim Item1 As New BaseTax
        Dim Item2 As New CityTax
        ' $22.74 normal purchase.
        ShowTax(Item1, 22.74)
        ' $22.74 city purchase.
        ShowTax(Item2, 22.74)
    End Sub

    Sub ShowTax(ByVal Item As BaseTax, ByVal SaleAmount As Double)
        ' Item is declared as BaseTax, but you can 
        ' pass an item of type CityTax instead.
        Dim TaxAmount As Double
        TaxAmount = Item.CalculateTax(SaleAmount)
        MsgBox("The tax is: " & Format(TaxAmount, "C"))
    End Sub
    ' </snippet63>

End Class

Class Classb686fb97e7d74001afaa6650cba08f0d
    ' b686fb97-e7d7-4001-afaa-6650cba08f0d
    ' Overloaded Properties and Methods

    ' <snippet64>
    Overloads Sub Display(ByVal theChar As Char)
        ' Add code that displays Char data.
    End Sub
    Overloads Sub Display(ByVal theInteger As Integer)
        ' Add code that displays Integer data.
    End Sub
    Overloads Sub Display(ByVal theDouble As Double)
        ' Add code that displays Double data.
    End Sub
    ' </snippet64>

    ' <snippet65>
    Sub DisplayChar(ByVal theChar As Char)
        ' Add code that displays Char data.
    End Sub
    Sub DisplayInt(ByVal theInteger As Integer)
        ' Add code that displays Integer data.
    End Sub
    Sub DisplayDouble(ByVal theDouble As Double)
        ' Add code that displays Double data.
    End Sub
    ' </snippet65>

    Public Sub Method66()
        ' <snippet66>
        ' Call Display with a literal of type Char.
        Display("9"c)
        ' Call Display with a literal of type Integer.
        Display(9)
        ' Call Display with a literal of type Double.
        Display(9.9R)
        ' </snippet66>
    End Sub

    ' <snippet67>
    Public Class TaxClass
        Overloads Function TaxAmount(ByVal decPrice As Decimal,
             ByVal TaxRate As Single) As String
            TaxAmount = "Price is a Decimal. Tax is $" &
               (CStr(decPrice * TaxRate))
        End Function

        Overloads Function TaxAmount(ByVal strPrice As String,
              ByVal TaxRate As Single) As String
            TaxAmount = "Price is a String. Tax is $" &
               CStr((CDec(strPrice) * TaxRate))
        End Function
    End Class
    ' </snippet67>

    ' <snippet68>
    Sub ShowTax()
        ' 8% tax rate.
        Const TaxRate As Single = 0.08
        ' $64.00 Purchase as a String.
        Dim strPrice As String = "64.00"
        ' $64.00 Purchase as a Decimal.
        Dim decPrice As Decimal = 64
        Dim aclass As New TaxClass
        'Call the same method with two different kinds of data.
        MsgBox(aclass.TaxAmount(strPrice, TaxRate))
        MsgBox(aclass.TaxAmount(decPrice, TaxRate))
    End Sub
    ' </snippet68>

End Class

Class Classb96560f76413480fa1e2f80253bab5be
    ' b96560f7-6413-480f-a1e2-f80253bab5be
    ' Implements Keyword and Implements Statement

    Class interfaceclass
        Interface interface2
            Sub Sub1(ByVal i As Integer)
        End Interface
    End Class
    ' <snippet69>
    Class Class1
        Implements interfaceclass.interface2

        Sub Sub1(ByVal i As Integer) Implements interfaceclass.interface2.Sub1
        End Sub
    End Class
    ' </snippet69>

    Interface I1
        Sub M1()
        Sub M2()
    End Interface
    Interface I2
        Sub M3()
        Sub M4()
    End Interface
    ' <snippet70>
    Class Class2
        Implements I1, I2

        Protected Sub M1() Implements I1.M1, I1.M2, I2.M3, I2.M4
        End Sub
    End Class
    ' </snippet70>

End Class

Class Classc5729e29104244e8904d7b24e0d50b01
    ' c5729e29-1042-44e8-904d-7b24e0d50b01
    ' How to: Perform Actions with Methods

    Dim PictureBox1 As New PictureBox
    Public Sub Method72()
        ' <snippet72>
        ' Force the control to repaint.
        PictureBox1.Refresh()
        ' </snippet72>
    End Sub

    Public Sub Method73()
        ' <snippet73>
        MsgBox("Database update complete",
               MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation,
               "My Application")
        ' </snippet73>
    End Sub

    Public Sub Method74()
        ' <snippet74>
        Dim Response As MsgBoxResult
        Response = MsgBox("Do you want to exit?",
                           MsgBoxStyle.YesNo Or MsgBoxStyle.Question,
                           "My Application")
        ' </snippet74>
    End Sub

    Public Sub Method75()
        ' <snippet75>
        Dim TestStr As String = "Some String"
        ' Display the string "String length is : 11".
        MsgBox("String length is : " & Len(TestStr))
        ' </snippet75>
    End Sub

End Class

Class Classcf067cdabdc74c55b695238095d4005a
    ' cf067cda-bdc7-4c55-b695-238095d4005a
    ' How to: Create Derived Classes

    ' <snippet87>
    Class Class1
        Sub Method1()
            MsgBox("This is a method in the base class.")
        End Sub
        Overridable Sub Method2()
            MsgBox("This is another method in the base class.")
        End Sub
    End Class

    Class Class2
        Inherits Class1
        Public Field2 As Integer
        Overrides Sub Method2()
            MsgBox("This is a method in a derived class.")
        End Sub
    End Class

    Protected Sub TestInheritance()
        Dim C1 As New Class1
        Dim C2 As New Class2
        C1.Method1() ' Calls a method in the base class.
        C1.Method2() ' Calls another method from the base class.
        C2.Method1() ' Calls an inherited method from the base class.
        C2.Method2() ' Calls a method from the derived class.
    End Sub
    ' </snippet87>

End Class

Class Classd2f774502bf24b1eb95fdbc7878f2777
    ' d2f77450-2bf2-4b1e-b95f-dbc7878f2777
    ' Operator '<operatorname>' is not defined for types '<typename1>' and '<typename2>'

    Public Sub Method89()
        Dim A As New Object
        Dim B As New Object
        ' <snippet89>
        If A IsNot B Then
            ' </snippet89>
        End If
    End Sub

End Class

Class Classd6ff7f1eb94f4205ab8d5cfa91758724
    ' d6ff7f1e-b94f-4205-ab8d-5cfa91758724
    ' Early and Late Binding

    Public Sub Method90()
        ' <snippet90>
        '  Create a variable to hold a new object.
        Dim FS As System.IO.FileStream
        ' Assign a new object to the variable.
        FS = New System.IO.FileStream("C:\tmp.txt",
            System.IO.FileMode.Open)
        ' </snippet90>
    End Sub

End Class

Class Classd95e7ad1cd6341d69a28d7a1380d49c1
    ' d95e7ad1-cd63-41d6-9a28-d7a1380d49c1
    ' Determining Object Type

    Public Sub Method92()
        ' <snippet92>
        Dim Ctrl As Control = New TextBox
        MsgBox(TypeName(Ctrl))
        ' </snippet92>

        ' <snippet93>
        If TypeOf Ctrl Is Button Then
            MsgBox("The control is a button.")
        End If
        ' </snippet93>
    End Sub

    ' <snippet94>
    Sub CheckType(ByVal InParam As Object)
        ' Both If statements evaluate to True when an
        ' Integer is passed to this procedure.
        If TypeOf InParam Is Object Then
            MsgBox("InParam is an Object")
        End If
        If TypeOf InParam Is Integer Then
            MsgBox("InParam is an Integer")
        End If
    End Sub
    ' </snippet94>

    Dim Button1 As New Button
    Dim CheckBox1 As New CheckBox
    Dim RadioButton1 As New RadioButton
    ' <snippet95>
    Sub ShowType(ByVal Ctrl As Object)
        'Use the TypeName function to display the class name as text.
        MsgBox(TypeName(Ctrl))
        'Use the TypeOf function to determine the object's type.
        If TypeOf Ctrl Is Button Then
            MsgBox("The control is a button.")
        ElseIf TypeOf Ctrl Is CheckBox Then
            MsgBox("The control is a check box.")
        Else
            MsgBox("The object is some other type of control.")
        End If
    End Sub

    Protected Sub TestObject()
        'Test the ShowType procedure with three kinds of objects.
        ShowType(Me.Button1)
        ShowType(Me.CheckBox1)
        ShowType(Me.RadioButton1)
    End Sub
    ' </snippet95>

End Class

Class Classdbc3783f83a24225995dc2d6d025663d
    ' dbc3783f-83a2-4225-995d-c2d6d025663d
    ' Shared Members in Visual Basic

    ' <snippet96>
    Public Class Item
        Public Shared Count As Integer = 1
        Public Shared Sub ShareMethod()
            MsgBox("Current value of Count: " & Count)
        End Sub

        Public Sub New(ByVal Name As String)
            ' Use Count to initialize SerialNumber.
            Me.SerialNumber = Count
            Me.Name = Name
            ' Increment the shared variable
            Count += 1
        End Sub
        Public SerialNumber As Integer
        Public Name As String
        Public Sub InstanceMethod()
            MsgBox("Information in the first object: " &
                Me.SerialNumber & vbTab & Me.Name)
        End Sub
    End Class

    Sub TestShared()
        ' Create two instances of the class.
        Dim part1 As New Item("keyboard")
        Dim part2 As New Item("monitor")

        part1.InstanceMethod()
        part2.InstanceMethod()
        Item.ShareMethod()
    End Sub
    ' </snippet96>

End Class

Class Classded82af29f52423298effe458180f112
    Class Form1
        Inherits Form
        ' ded82af2-9f52-4232-98ef-fe458180f112
        ' Walkthrough: Creating and Implementing Interfaces

        Interface TestInterface
            ' <snippet98>
            Property Prop1() As Integer
            Sub Method1(ByVal X As Integer)
            Event Event1()
            ' </snippet98>
        End Interface

        Class Class99
            ' <snippet99>
            Class ImplementationClass
                ' </snippet99>
                ' <snippet100>
                Implements TestInterface
                ' </snippet100>

                ' <snippet101>
                Event Event1() Implements TestInterface.Event1

                Public Sub Method1(ByVal X As Integer) Implements TestInterface.Method1
                End Sub

                Public Property Prop1() As Integer Implements TestInterface.Prop1
                    Get
                    End Get
                    Set(ByVal value As Integer)
                    End Set
                End Property
                ' </snippet101>
            End Class
        End Class

        Class ImplementationClass
            Implements TestInterface

            Event Event1() Implements TestInterface.Event1

            Public Sub Method1(ByVal X As Integer) Implements TestInterface.Method1
                ' <snippet105>
                MsgBox("The X parameter for Method1 is " & X)
                RaiseEvent Event1()
                ' </snippet105>
            End Sub

            ' <snippet102>
            ' Holds the value of the property.
            Private pval As Integer
            ' </snippet102>

            Public Property Prop1() As Integer Implements TestInterface.Prop1
                Get
                    ' <snippet103>
                    Return pval
                    ' </snippet103>
                End Get
                Set(ByVal value As Integer)
                    ' <snippet104>
                    pval = value
                    ' </snippet104>
                End Set
            End Property
        End Class

        ' <snippet120>
        Dim WithEvents testInstance As TestInterface
        ' </snippet120>

        ' <snippet106>
        Sub EventHandler() Handles testInstance.Event1
            MsgBox("The event handler caught the event.")
        End Sub
        ' </snippet106>

        ' <snippet107>
        Sub Test()
            '  Create an instance of the class.
            Dim T As New ImplementationClass
            ' Assign the class instance to the interface.
            ' Calls to the interface members are 
            ' executed through the class instance.
            testInstance = T
            ' Set a property.
            testInstance.Prop1 = 9
            ' Read the property.
            MsgBox("Prop1 was set to " & testInstance.Prop1)
            '  Test the method and raise an event.
            testInstance.Method1(5)
        End Sub
        ' </snippet107>

        ' <snippet108>
        Private Sub Form1_Load(ByVal sender As System.Object,
                               ByVal e As System.EventArgs) Handles MyBase.Load
            Test() ' Test the class.
        End Sub
        ' </snippet108>
    End Class
End Class

Class Classdfc8debaf5b34d1da9377cb826446fc5
    ' dfc8deba-f5b3-4d1d-a937-7cb826446fc5
    ' Inheritance Basics

    Class BaseClass
        Public Overridable Function CalculateShipping(
            ByVal Dist As Double,
            ByVal Rate As Double) As Double

            Return Dist * Rate
        End Function
    End Class

    ' <snippet109>
    Class DerivedClass
        Inherits BaseClass
        Public Overrides Function CalculateShipping(
            ByVal Dist As Double,
            ByVal Rate As Double) As Double

            ' Call the method in the base class and modify the return value.
            Return MyBase.CalculateShipping(Dist, Rate) * 2
        End Function
    End Class
    ' </snippet109>

End Class

Class Classe9039225e8004f27b1eb9d448ebbfbe1
    ' e9039225-e800-4f27-b1eb-9d448ebbfbe1
    ' Interface-Based Polymorphism

    ' <snippet111>
    Sub TestInterface()
        Dim RectangleObject2 As New RectangleClass2
        Dim RightTriangleObject2 As New RightTriangleClass2
        ProcessShape2(RightTriangleObject2, 3, 14)
        ProcessShape2(RectangleObject2, 3, 5)
    End Sub

    Sub ProcessShape2(ByVal Shape2 As Shape2, ByVal X As Double,
          ByVal Y As Double)
        MsgBox("The area of the object is " &
            Shape2.CalculateArea(X, Y))
    End Sub

    Public Interface Shape2
        Function CalculateArea(ByVal X As Double, ByVal Y As Double) As Double
    End Interface

    Public Class RightTriangleClass2
        Implements Shape2
        Function CalculateArea(ByVal X As Double,
              ByVal Y As Double) As Double Implements Shape2.CalculateArea
            ' Calculate the area of a right triangle. 
            Return 0.5 * (X * Y)
        End Function
    End Class

    Public Class RectangleClass2
        Implements Shape2
        Function CalculateArea(ByVal X As Double,
              ByVal Y As Double) As Double Implements Shape2.CalculateArea
            ' Calculate the area of a rectangle. 
            Return X * Y
        End Function
    End Class
    ' </snippet111>

End Class

Class Classf5e23d63dd7948508e10d4e37d06efdb
    ' f5e23d63-dd79-4850-8e10-d4e37d06efdb
    ' How to: Perform Multiple Actions on an Object

    Class Form1
        Inherits Form

        Dim Button1 As New Button
        ' <snippet112>
        Private Sub UpdateForm()
            Button1.Text = "OK"
            Button1.Visible = True
            Button1.Top = 24
            Button1.Left = 100
            Button1.Enabled = True
            Button1.Refresh()
        End Sub
        ' </snippet112>

        ' <snippet113>
        Private Sub UpdateForm2()
            With Button1
                .Text = "OK"
                .Visible = True
                .Top = 24
                .Left = 100
                .Enabled = True
                .Refresh()
            End With
        End Sub
        ' </snippet113>

        ' <snippet114>
        Sub setupForm()
            Dim anotherForm As New System.Windows.Forms.Form
            Dim button1 As New System.Windows.Forms.Button
            With anotherForm
                .Show()
                .Top = 250
                .Left = 250
                .ForeColor = System.Drawing.Color.LightBlue
                .BackColor = System.Drawing.Color.DarkBlue
                .Controls.Add(button1)
                With .Controls.Item(1)
                    .BackColor = System.Drawing.Color.Thistle
                    .Text = "Text on button1"
                End With
            End With
        End Sub
        ' </snippet114>
    End Class

End Class
