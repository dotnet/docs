//<snippetLinq2SqlProvider>
using System;
using System.ComponentModel;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Services;
using System.Data.Services.Common;

namespace NorthwindService
{
    //<snippetIQueryableRequirements>
    // Define the key properties for the LINQ to SQL data classes.
    [DataServiceKeyAttribute("CustomerID")]
    public partial class Customer { }

    [DataServiceKeyAttribute("ProductID")]
    public partial class Product { }

    [DataServiceKeyAttribute("OrderID")]
    public partial class Order { }

    [DataServiceKeyAttribute("OrderID", "ProductID")]
    public partial class Order_Detail { }
    //</snippetIQueryableRequirements>

    //<snippetIUdatableImplementation>
    #region IUpdatable implementation
    // Define the IUpdatable implementation for LINQ to SQL.
    public partial class NorthwindDataContext : IUpdatable
    {
        // Creates an object in the container.
        object IUpdatable.CreateResource(string containerName, string fullTypeName)
        {
            Type t = Type.GetType(fullTypeName, true);
            ITable table = GetTable(t);
            object resource = Activator.CreateInstance(t);
            table.InsertOnSubmit(resource);
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
            Type t = resource.GetType();
            MetaTable table = Mapping.GetTable(t);
            object dummyResource = Activator.CreateInstance(t);
            foreach (var member in table.RowType.DataMembers)
            {
                if (!member.IsPrimaryKey && !member.IsDeferred &&
                    !member.IsAssociation && !member.IsDbGenerated)
                {
                    object defaultValue = member.MemberAccessor.GetBoxedValue(dummyResource);
                    member.MemberAccessor.SetBoxedValue(ref resource, defaultValue);
                }
            }
            return resource;
        }

        // Sets the value of the given property on the object.
        void IUpdatable.SetValue(object targetResource, string propertyName, object propertyValue)
        {
            MetaTable table = Mapping.GetTable(targetResource.GetType());
            MetaDataMember member = table.RowType.DataMembers.Single(x => x.Name == propertyName);
            member.MemberAccessor.SetBoxedValue(ref targetResource, propertyValue);
        }

        // Gets the value of a property on an object.
        object IUpdatable.GetValue(object targetResource, string propertyName)
        {
            MetaTable table = Mapping.GetTable(targetResource.GetType());
            MetaDataMember member =
                table.RowType.DataMembers.Single(x => x.Name == propertyName);
            return member.MemberAccessor.GetBoxedValue(targetResource);
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
            ITable table = GetTable(targetResource.GetType());
            table.DeleteOnSubmit(targetResource);
        }

        // Saves all the pending changes.
        void IUpdatable.SaveChanges()
        {
            SubmitChanges();
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
            // Raise an exception as there is no real way to do this with LINQ to SQL.
            // Comment out the following line if you'd prefer a silent failure
            throw new NotSupportedException();
        }
    #endregion
        //</snippetIUdatableImplementation>
    }
}
//</snippetLinq2SqlProvider>