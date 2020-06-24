Class Class548eebe186c44377b2f5447cb8be3d90
    ' 548eebe1-86c4-4377-b2f5-447cb8be3d90
    ' Using Constructors and Destructors

    ' <snippet42>
    Sub New(ByVal s As String)
        ' </snippet42>
    End Sub

    ' <snippet116>
    Sub New(ByVal s As String, i As Integer)
        ' </snippet116>
    End Sub

    ' <snippet43>
    ' Design pattern for a base class.
    Public Class Base
        Implements IDisposable

        ' Keep track of when the object is disposed.
        Protected disposed As Boolean = False

        ' This method disposes the base object's resources.
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposed Then
                If disposing Then
                    ' Insert code to free managed resources.
                End If
                ' Insert code to free unmanaged resources.
            End If
            Me.disposed = True
        End Sub

#Region " IDisposable Support "
        ' Do not change or add Overridable to these methods.
        ' Put cleanup code in Dispose(ByVal disposing As Boolean).
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
        Protected Overrides Sub Finalize()
            Dispose(False)
            MyBase.Finalize()
        End Sub
#End Region
    End Class
    ' </snippet43>

    ' <snippet44>
    ' Design pattern for a derived class.
    Public Class Derived
        Inherits Base

        ' This method disposes the derived object's resources.
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposed Then
                If disposing Then
                    ' Insert code to free managed resources.
                End If
                ' Insert code to free unmanaged resources.
            End If
            MyBase.Dispose(disposing)
        End Sub

        ' The derived class does not have a Finalize method
        ' or a Dispose method with parameters because it inherits
        ' them from the base class.
    End Class
    ' </snippet44>

    ' <snippet45>
    Sub DemonstrateUsing()
        Using d As New Derived
            ' Code to use the Derived object goes here.
        End Using
    End Sub

    Sub DemonstrateTry()
        Dim d As Derived = Nothing
        Try
            d = New Derived
            ' Code to use the Derived object goes here.
        Finally
            ' Call the Dispose method when done, even if there is an exception.
            If Not d Is Nothing Then
                d.Dispose()
            End If
        End Try
    End Sub
    ' </snippet45>

    ' <snippet46>
    Sub TestConstructorsAndDestructors()
        ' Demonstrate how the Using statement calls the Dispose method.
        Using AnObject As New ThisClass(6)
            ' Place statements here that use the object.
            MsgBox("The value of ThisProperty after being initialized " &
            " by the constructor is " & AnObject.ThisProperty & ".")
        End Using

        ' Demonstrate how the garbage collector calls the Finalize method.
        Dim AnObject2 As New ThisClass(6)
        AnObject2 = Nothing
        GC.Collect()
    End Sub

    Public Class BaseClass
        Sub New()
            MsgBox("BaseClass is initializing with Sub New.")
        End Sub

        Protected Overrides Sub Finalize()
            MsgBox("BaseClass is shutting down with Sub Finalize.")
            ' Place final cleanup tasks here.
            MyBase.Finalize()
        End Sub
    End Class

    Public Class ThisClass
        Inherits BaseClass
        Implements IDisposable

        Sub New(ByVal SomeValue As Integer)
            ' Call MyBase.New if this is a derived class.
            MyBase.New()
            MsgBox("ThisClass is initializing with Sub New.")
            ' Place initialization statements here. 
            ThisPropertyValue = SomeValue
        End Sub

        Private ThisPropertyValue As Integer
        Property ThisProperty() As Integer
            Get
                CheckIfDisposed()
                ThisProperty = ThisPropertyValue
            End Get
            Set(ByVal Value As Integer)
                CheckIfDisposed()
                ThisPropertyValue = Value
            End Set
        End Property

        Protected Overrides Sub Finalize()
            MsgBox("ThisClass is shutting down with Sub Finalize.")
            Dispose(False)
        End Sub

        ' Do not add Overridable to this method.
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            MsgBox("ThisClass is shutting down with Sub Dispose.")
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Private disposed As Boolean = False
        Public Sub CheckIfDisposed()
            If Me.disposed Then
                Throw New ObjectDisposedException(Me.GetType().ToString,
                "This object has been disposed.")
            End If
        End Sub

        Protected Overridable Overloads Sub Dispose(
            ByVal disposing As Boolean)

            MsgBox("ThisClass is shutting down with the Sub Dispose overload.")
            ' Place final cleanup tasks here.
            If Not Me.disposed Then
                If disposing Then
                    ' Dispose of any managed resources.
                End If
                ' Dispose of any unmanaged resource.

                ' Call MyBase.Finalize if this is a derived class, 
                ' and the base class does not implement Dispose.
                MyBase.Finalize()
            End If
            Me.disposed = True
        End Sub

    End Class
    ' </snippet46>

End Class

Class Class785b286bac904514a3e05a7009390d69
    ' 785b286b-ac90-4514-a3e0-5a7009390d69
    ' How to: Access a Form

    ' <snippet50>
    Public Sub ChangeForm1Colors()
        Form1.ForeColor = System.Drawing.Color.Coral
        Form1.BackColor = System.Drawing.Color.Cyan
        Form1.Show()
    End Sub
    ' </snippet50>

    ' <snippet51>
    Public Sub GetSecondInstance()
        Dim newForm1 As New Form1
        newForm1.BackColor = System.Drawing.Color.YellowGreen
        newForm1.Show()
    End Sub
    ' </snippet51>

End Class
