Option Explicit On
Option Strict On

'<snippetLinq2SqlProvider>
Imports System.ComponentModel
Imports System.Collections
Imports System.Linq
Imports System.Reflection
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Data.Services
Imports System.Data.Services.Common

'<snippetIQueryableRequirements>
' Define the key properties for the LINQ to SQL data classes.
<DataServiceKeyAttribute("CustomerID")> _
Partial Public Class Customer
End Class
<DataServiceKeyAttribute("ProductID")> _
Partial Public Class Product
End Class
<DataServiceKeyAttribute("OrderID")> _
Partial Public Class Order
End Class
<DataServiceKeyAttribute("OrderID", "ProductID")> _
Partial Public Class Order_Detail
End Class
'</snippetIQueryableRequirements>
'<snippetIUdatableImplementation>
#Region "IUpdatable implementation"
' Define the IUpdatable implementation for LINQ to SQL.
Partial Public Class NorthwindDataContext
    Implements IUpdatable
    ' Creates an object in the container.
    Function CreateResource(ByVal containerName As String, ByVal fullTypeName As String) _
        As Object Implements IUpdatable.CreateResource

        Dim t = Type.GetType(fullTypeName, True)
        Dim table = GetTable(t)
        Dim resource = Activator.CreateInstance(t)
        table.InsertOnSubmit(resource)
        Return resource
    End Function
    ' Gets the object referenced by the resource.
    Function GetResource(ByVal query As IQueryable, ByVal fullTypeName As String) As Object _
     Implements IUpdatable.GetResource
        Dim resource = query.Cast(Of Object)().SingleOrDefault()

        ' fullTypeName can be null for deletes
        If fullTypeName IsNot Nothing AndAlso resource.GetType().FullName <> fullTypeName Then
            Throw New ApplicationException("Unexpected type for this resource.")
        End If
        Return resource
    End Function
    ' Resets the value of the object to its default value.
    Function ResetResource(ByVal resource As Object) As Object _
        Implements IUpdatable.ResetResource
        Dim t = resource.GetType()
        Dim table = Mapping.GetTable(t)
        Dim dummyResource = Activator.CreateInstance(t)
        For Each member In table.RowType.DataMembers

            If Not member.IsPrimaryKey AndAlso Not member.IsDeferred AndAlso _
                Not member.IsAssociation AndAlso Not member.IsDbGenerated Then
                Dim defaultValue = member.MemberAccessor.GetBoxedValue(dummyResource)
                member.MemberAccessor.SetBoxedValue(resource, defaultValue)
            End If
            Next
        Return resource
    End Function
    ' Sets the value of the given property on the object.
    Sub SetValue(ByVal targetResource As Object, ByVal propertyName As String, _
                 ByVal propertyValue As Object) Implements IUpdatable.SetValue
        Dim table = Mapping.GetTable(targetResource.GetType())
        Dim member = table.RowType.DataMembers.Single(Function(x) x.Name = propertyName)
        member.MemberAccessor.SetBoxedValue(targetResource, propertyValue)
    End Sub
    ' Gets the value of a property on an object.
    Function GetValue(ByVal targetResource As Object, ByVal propertyName As String) _
    As Object Implements IUpdatable.GetValue
        Dim table = Mapping.GetTable(targetResource.GetType())
        Dim member = _
        table.RowType.DataMembers.Single(Function(x) x.Name = propertyName)
        Return member.MemberAccessor.GetBoxedValue(targetResource)
    End Function
    ' Sets the related object for a reference.
    Sub SetReference(ByVal targetResource As Object, ByVal propertyName As String, _
                     ByVal propertyValue As Object) Implements IUpdatable.SetReference
        CType(Me, IUpdatable).SetValue(targetResource, propertyName, propertyValue)
    End Sub
' Adds the object to the related objects collection.
    Sub AddReferenceToCollection(ByVal targetResource As Object, ByVal propertyName As String, _
                                 ByVal resourceToBeAdded As Object) _
                                 Implements IUpdatable.AddReferenceToCollection
        Dim pi = targetResource.GetType().GetProperty(propertyName)
        If pi Is Nothing Then
            Throw New Exception("Can't find property")
        End If
        Dim collection = CType(pi.GetValue(targetResource, Nothing), IList)
        collection.Add(resourceToBeAdded)
    End Sub
    ' Removes the object from the related objects collection.
    Sub RemoveReferenceFromCollection(ByVal targetResource As Object, ByVal propertyName As String, _
                                      ByVal resourceToBeRemoved As Object) _
                                      Implements IUpdatable.RemoveReferenceFromCollection
        Dim pi = targetResource.GetType().GetProperty(propertyName)
        If pi Is Nothing Then
            Throw New Exception("Can't find property")
        End If
        Dim collection = CType(pi.GetValue(targetResource, Nothing), IList)
        collection.Remove(resourceToBeRemoved)
    End Sub
        ' Deletes the resource.
    Sub DeleteResource(ByVal targetResource As Object) _
    Implements IUpdatable.DeleteResource
        Dim table = GetTable(targetResource.GetType())
        table.DeleteOnSubmit(targetResource)
    End Sub
    ' Saves all the pending changes.
    Sub SaveChanges() Implements IUpdatable.SaveChanges
        SubmitChanges()
    End Sub
    ' Returns the actual instance of the resource represented 
    ' by the resource object.
    Function ResolveResource(ByVal resource As Object) As Object Implements IUpdatable.ResolveResource
        Return resource
    End Function
        ' Reverts all the pending changes.
    Sub ClearChanges() Implements IUpdatable.ClearChanges
        ' Raise an exception as there is no real way to do this with LINQ to SQL.
        ' Comment out the following line if you'd prefer a silent failure
        Throw New NotSupportedException()
    End Sub
End Class
#End Region
'</snippetIUdatableImplementation>
'</snippetLinq2SqlProvider>