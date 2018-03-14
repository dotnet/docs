Option Explicit On
Option Strict On

'<snippetCustomIUpdatable>
Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Data.Services
Imports System.Linq

Namespace CustomDataServiceClient
    Partial Public Class OrderItemData
        Implements IUpdatable
        ' Creates an object in the container.
        Function CreateResource(ByVal containerName As String, _
        ByVal fullTypeName As String) As Object Implements IUpdatable.CreateResource

            Dim t As Type = Type.GetType(fullTypeName, True)
            Dim resource As Object = Activator.CreateInstance(t)
            Return resource
        End Function
        ' Gets the object referenced by the resource.
        Function GetResource(ByVal query As IQueryable, ByVal fullTypeName As String) As Object _
        Implements IUpdatable.GetResource
            Dim resource As Object = query.Cast(Of Object)().SingleOrDefault()

            ' fullTypeName can be null for deletes
            If fullTypeName IsNot Nothing AndAlso resource.GetType().FullName <> fullTypeName Then
                Throw New ApplicationException("Unexpected type for this resource.")
            End If
            Return resource
        End Function
        ' Resets the value of the object to its default value.
        Function ResetResource(ByVal resource As Object) As Object _
        Implements IUpdatable.ResetResource
            ' Nothing to do for this in-memory provider.
            Return resource
        End Function
        ' Sets the value of the given property on the object.
        Sub SetValue(ByVal targetResource As Object, ByVal propertyName As String, _
                     ByVal propertyValue As Object) Implements IUpdatable.SetValue
            ' Use reflection to set the property on the object.
            Dim t As Type = targetResource.GetType()
            Dim p As PropertyInfo = t.GetProperty(propertyName)
            p.SetValue(targetResource, propertyValue, Nothing)
        End Sub
        ' Gets the value of a property on an object.
        Function GetValue(ByVal targetResource As Object, ByVal propertyName As String) As Object _
        Implements IUpdatable.GetValue
            ' Use reflection to get the property to set.
            Dim t As Type = targetResource.GetType()
            Dim p As PropertyInfo = t.GetProperty(propertyName)
            Return p.GetValue(targetResource, Nothing)
        End Function
        ' Sets the related object for a reference.
        Sub SetReference(ByVal targetResource As Object, ByVal propertyName As String, ByVal _
                         propertyValue As Object) Implements IUpdatable.SetReference
            CType(Me, IUpdatable).SetValue(targetResource, propertyName, propertyValue)
        End Sub
        ' Adds the object to the related objects collection.
        Sub AddReferenceToCollection(ByVal targetResource As Object, ByVal propertyName As String, _
                                     ByVal resourceToBeAdded As Object) _
                                     Implements IUpdatable.AddReferenceToCollection
            Dim pi As PropertyInfo = targetResource.GetType().GetProperty(propertyName)
            If pi Is Nothing Then
                Throw New Exception("Can't find property")
            End If
            Dim collection As IList = CType(pi.GetValue(targetResource, Nothing), IList)
            collection.Add(resourceToBeAdded)
        End Sub
        ' Removes the object from the related objects collection.
        Sub RemoveReferenceFromCollection(ByVal targetResource As Object, ByVal propertyName As String, _
                               ByVal resourceToBeRemoved As Object) _
                               Implements IUpdatable.RemoveReferenceFromCollection
            Dim pi As PropertyInfo = targetResource.GetType().GetProperty(propertyName)
            If pi Is Nothing Then
                Throw New Exception("Can't find property")
            End If
            Dim collection As IList = CType(pi.GetValue(targetResource, Nothing), IList)
            collection.Remove(resourceToBeRemoved)
        End Sub
        ' Deletes the resource.
        Sub DeleteResource(ByVal targetResource As Object) _
        Implements IUpdatable.DeleteResource
            ' Nothing to do for this provider.
        End Sub
        ' Saves all the pending changes.
        Sub SaveChanges() Implements IUpdatable.SaveChanges
            '' Nothing to do for this in-memory provider (uncomment to raise an exception).
            ' throw new NotSupportedException(
            '    "The save changes functionality is not supported by this in-memory provider");
        End Sub
        ' Returns the actual instance of the resource represented 
        ' by the resource object.
        Function ResolveResource(ByVal resource As Object) As Object _
        Implements IUpdatable.ResolveResource
            Return resource
        End Function
' Reverts all the pending changes.
        Sub ClearChanges() Implements IUpdatable.ClearChanges
            '' Nothing to do for this in-memory provider (uncomment to raise an exception).
            'throw new NotSupportedException(
            '    "The clear changes functionality is not supported by this in-memory provider");
        End Sub
    End Class
End Namespace 
'</snippetCustomIUpdatable>