    '////////////////////////////////////////////////////////////
    '
    ' The strongly typed CycleCollection class is a collection
    ' that contains Cycle class instances, which implement the
    ' IStateManager interface.
    '
    '////////////////////////////////////////////////////////////
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
                   Public NotInheritable Class CycleCollection
        Inherits StateManagedCollection

        Private Shared _typesOfCycles() As Type = _
            {GetType(Bicycle), GetType(Tricycle)}

        Protected Overrides Function CreateKnownType(ByVal index As Integer) As Object
            Select Case index
                Case 0
                    Return New Bicycle()
                Case 1
                    Return New Tricycle()
                Case Else
                    Throw New ArgumentOutOfRangeException("Unknown Type")
            End Select

        End Function


        Protected Overrides Function GetKnownTypes() As Type()
            Return _typesOfCycles

        End Function


        Protected Overrides Sub SetDirtyObject(ByVal o As Object)
            CType(o, Cycle).SetDirty()

        End Sub
    End Class