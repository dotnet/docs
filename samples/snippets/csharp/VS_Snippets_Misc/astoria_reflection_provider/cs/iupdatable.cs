//<snippetCustomIUpdatable>
using System;
using System.Collections;
using System.Reflection;
using System.Data.Services;
using System.Linq;

namespace CustomDataServiceClient
{
    public partial class OrderItemData : IUpdatable
    {
        // Creates an object in the container.
        object IUpdatable.CreateResource(string containerName, string fullTypeName)
        {
            Type t = Type.GetType(fullTypeName, true);
            object resource = Activator.CreateInstance(t);
            return resource;
        }

        // Gets the object referenced by the resource.
        object IUpdatable.GetResource(IQueryable query, string fullTypeName)
        {
            object resource = query.Cast<object>().SingleOrDefault();

            // fullTypeName can be null for deletes
            if (fullTypeName != null && resource.GetType().FullName != fullTypeName)
                throw new ApplicationException("Unexpected type for this resource.");
            return resource;
        }

        // Resets the value of the object to its default value.
        object IUpdatable.ResetResource(object resource)
        {
            // Nothing to do for this in-memory provider.
            return resource;
        }

        // Sets the value of the given property on the object.
        void IUpdatable.SetValue(object targetResource, string propertyName, object propertyValue)
        {
            // Use reflection to set the property on the object.
            Type t = targetResource.GetType();
            PropertyInfo p = t.GetProperty(propertyName);
            p.SetValue(targetResource, propertyValue, null);
        }

        // Gets the value of a property on an object.
        object IUpdatable.GetValue(object targetResource, string propertyName)
        {
            // Use reflection to get the property to set.
            Type t = targetResource.GetType();
            PropertyInfo p = t.GetProperty(propertyName);
            return p.GetValue(targetResource, null);
        }

        // Sets the related object for a reference.
        void IUpdatable.SetReference(
            object targetResource, string propertyName, object propertyValue)
        {
            ((IUpdatable)this).SetValue(targetResource, propertyName, propertyValue);
        }

        // Adds the object to the related objects collection.
        void IUpdatable.AddReferenceToCollection(
            object targetResource, string propertyName, object resourceToBeAdded)
        {
            PropertyInfo pi = targetResource.GetType().GetProperty(propertyName);
            if (pi == null)
                throw new Exception("Can't find property");
            IList collection = (IList)pi.GetValue(targetResource, null);
            collection.Add(resourceToBeAdded);
        }

        // Removes the object from the related objects collection.
        void IUpdatable.RemoveReferenceFromCollection(
            object targetResource, string propertyName, object resourceToBeRemoved)
        {
            PropertyInfo pi = targetResource.GetType().GetProperty(propertyName);
            if (pi == null)
                throw new Exception("Can't find property");
            IList collection = (IList)pi.GetValue(targetResource, null);
            collection.Remove(resourceToBeRemoved);
        }

        // Deletes the resource.
        void IUpdatable.DeleteResource(object targetResource)
        {
            // Nothing to do for this provider.
        }

        // Saves all the pending changes.
        void IUpdatable.SaveChanges()
        {
            //// Nothing to do for this in-memory provider (uncomment to raise an exception).
            //throw new NotSupportedException(
            //    "The save changes functionality is not supported by this in-memory provider");
        }

        // Returns the actual instance of the resource represented 
        // by the resource object.
        object IUpdatable.ResolveResource(object resource)
        {
            return resource;
        }

        // Reverts all the pending changes.
        void IUpdatable.ClearChanges()
        {
            //// Nothing to do for this in-memory provider (uncomment to raise an exception).
            //throw new NotSupportedException(
            //    "The clear changes functionality is not supported by this in-memory provider");
        }
    }
}
//</snippetCustomIUpdatable>