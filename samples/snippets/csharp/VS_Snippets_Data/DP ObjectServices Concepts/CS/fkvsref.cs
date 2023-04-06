using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace ObjectServicesConceptsCS
{
    class FKvsRef
    {
        public void Create_new_Product_in_existing_Contact_by_value()
        {
            using (var context = new AdventureWorksEntities())
            {
                SalesOrderHeader order = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now,
                    ContactID = 13
                };
                context.SalesOrderHeaders.AddObject(order);
                context.SaveChanges();
            }
        }

        public void Create_new_Product_in_existing_Contact_by_reference()
        {
            using (var context = new AdventureWorksEntities())
            {
                SalesOrderHeader order = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now,
                    Contact = context.Contacts.Single(c => c.ContactID == 13)
                };
                context.SaveChanges();
            }
        }

        public void Create_new_Product_in_existing_Contact_relate_by_addition_to_collection()
        {
            using (var context = new AdventureWorksEntities())
            {
                SalesOrderHeader order = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now,
                };
                context.Contacts.Single(c => c.ContactID == 13).SalesOrderHeaders.Add(order);
                context.SaveChanges();
            }
        }

        public void Remove_a_product_from_ContactSalesOrderHeaders_by_setting_fk_value()
        {
            using (var context = new AdventureWorksEntities())
            {
                Contact contact = context.Contacts.Single(c => c.ContactID == 13);
                SalesOrderHeader order = contact.SalesOrderHeaders.First();
                order.SalesOrderID = 2;
                context.SaveChanges();
            }
        }

        public void Create_new_Product_and_new_Contact_relate_by_reference()
        {
            using (var context = new AdventureWorksEntities())
            {
                SalesOrderHeader order = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now,
                    Contact = new Contact { ContactID = 2, FirstName = "Alex" }
                };
                context.SalesOrderHeaders.AddObject(order);
                context.SaveChanges();
            }
        }

        public void Create_new_Product_and_new_Contact_relate_by_value()
        {
            using (var context = new AdventureWorksEntities())
            {
                Contact c = new Contact
                {
                    ContactID = 2,
                    FirstName = "Alex"
                };
                SalesOrderHeader order = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now,
                    ContactID = 2
                };
                context.SalesOrderHeaders.AddObject(order);
                // Not that the only difference from the customers perspective is
                // that the BOTH entities need to be added, this seems acceptable
                context.Contacts.AddObject(c);
                context.SaveChanges();
            }
        }

        public void Create_new_Product_and_new_Contact_with_pk_identity_and_relate_by_reference()
        {
            using (var context = new AdventureWorksEntities())
            {
                //c.ID is store generated
                Contact c = new Contact
                {
                    FirstName = "Alex"
                };
                SalesOrderHeader order = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now,
                    Contact = c
                };
                // Fix up needs to happen for the FK
                context.SalesOrderHeaders.AddObject(order);
                context.SaveChanges();
            }
        }

        public void Create_new_Product_and_new_Contact_with_pk_identity_and_relate_by_value()
        {
            using (var context = new AdventureWorksEntities())
            {
                //c.ID is store generated
                Contact c = new Contact
                {
                    ContactID = 0,
                    FirstName = "Alex"
                };
                SalesOrderHeader order = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now,
                    ContactID = 0
                };
                // The fixup occurs
                context.SalesOrderHeaders.AddObject(order);
                context.Contacts.AddObject(c);

                // Must not fail because of a dependency issue...
                // i.e. Update must re-order so that the Contact is created before the SalesOrderHeader
                context.SaveChanges();
            }
        }

        public void Create_new_Product_and_new_Contacts_with_pk_identity_and_relate_by_value()
        {
            using (var context = new AdventureWorksEntities())
            {
                //c.ID is store generated
                Contact c1 = new Contact
                {
                    FirstName = "Alex"
                };
                Contact c2 = new Contact
                {
                    FirstName = "Bob"
                };
                SalesOrderHeader order = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now
                };
                context.SalesOrderHeaders.AddObject(order);
                context.Contacts.AddObject(c1);
                context.Contacts.AddObject(c2);
                // Throw on SaveChanges() FK points to more than one Entity by temp key
                context.SaveChanges();
            }
        }

        public void Create_new_SalesOrderHeaders_and_new_Contacts_with_pk_identity_and_relate_by_fake_values()
        {
            using (var context = new AdventureWorksEntities())
            {
                //c.ID is store generated
                Contact c1 = new Contact
                {
                    ContactID = -1,
                    FirstName = "Alex"
                };
                Contact c2 = new Contact
                {
                    ContactID = -2,
                    FirstName = "Alex"
                };
                SalesOrderHeader o1 = new SalesOrderHeader
                {
                    SalesOrderID = 1,
                    ModifiedDate = DateTime.Now,
                    ContactID = -1
                };
                SalesOrderHeader o2 = new SalesOrderHeader
                {
                    SalesOrderID = 2,
                    ModifiedDate = DateTime.Now,
                    ContactID = -2
                };
                context.SalesOrderHeaders.AddObject(o1);
                context.SalesOrderHeaders.AddObject(o2);
                context.Contacts.AddObject(c1);
                context.Contacts.AddObject(c2);

                // Should work
                // Update will ensure that it handles:
                //  c1 will be saved before p1
                //  c2 will be saved before p2
                context.SaveChanges();
            }
        }

        public void Create_new_Product_Reference_Takes_Precedence()
        {
            using (var context = new AdventureWorksEntities())
            {
                Contact c = new Contact { ContactID = 1, FirstName = "Alex" };
                SalesOrderHeader order = new SalesOrderHeader();
                order.SalesOrderID = 2;
                order.ModifiedDate = DateTime.Now;
                order.ContactID = 3;
                // ADVICE: this will set ContactID to 1
                order.Contact = c;

                //Assuming we don't fail, the reference just takes precedence.
                context.SalesOrderHeaders.AddObject(order);
                context.SaveChanges();
            }
        }

        public void Create_new_Product_by_reference_then_by_value()
        {
            using (var context = new AdventureWorksEntities())
            {
                Contact c = new Contact { ContactID = 1, FirstName = "Alex" };
                SalesOrderHeader order = new SalesOrderHeader();
                order.SalesOrderID = 2;
                order.ModifiedDate = DateTime.Now;
                // ADVICE: this will set ContactID to 1
                order.Contact = c;
                // ADVICE: Reference is nulled out
                order.ContactID = 3;

                //This will NOT add c... because it is not in the graph
                context.SalesOrderHeaders.AddObject(order);
                context.SaveChanges();
            }
        }

        public void Update_existing_Product_with_new_Contact_with_pk_identity_by_reference()
        {
            using (var context = new AdventureWorksEntities())
            {
                SalesOrderHeader order = context.SalesOrderHeaders.Single(o => o.ModifiedDate == DateTime.Now && o.Contact.FirstName == "Alex");
                Contact c = new Contact { FirstName = "Bob" };
                // Works for two reason
                // ADVICE: set FK to c.ID
                // RULE: Reference to a NEW entity will win.
                order.Contact = c;
                context.SaveChanges();
            }
        }

        public void Update_existing_Product_with_new_Contact_with_pk_identity_by_value()
        {
            using (var context = new AdventureWorksEntities())
            {
                //Get the food category into the statemanager...
                //so the subsequent query will bring span in product.Contact? Is this the expected behavior?
                Contact contact = context.Contacts.Single(c => c.FirstName == "Alex");

                //Find an existing product that already has a category i.e. do fixup.
                SalesOrderHeader order = context.SalesOrderHeaders.Single(o => o.ModifiedDate == DateTime.Now && o.Contact.FirstName == "Alex");

                //RULE: we should have done fixup by now...
                //Debug.ReferenceEquals(order.Contact, food);

                Contact misc = new Contact { FirstName = "Bob" };
                order.ContactID = misc.ContactID;

                //NOTE: without this line Misc is not added, and we would be attempting to relate to something in
                // the database
                context.Contacts.AddObject(misc);
                context.SaveChanges();

                //Debug.Assert(misc.ID == product.ContactID);
                //Debug.ReferenceEquals(misc, product.Contact);
            }
        }

        public void Fixup_uses_current_values()
        {
            using (var context = new AdventureWorksEntities())
            {
                //Find an existing product that already has a category
                SalesOrderHeader order = context.SalesOrderHeaders.Single(o => o.ModifiedDate == DateTime.Now && o.Contact.FirstName == "Alex");

                //ADVICE: null out the reference
                order.ContactID = 2; // miscellaneous

                //NOTE: for POCO you would need to call DETECT changes before the QUERY to know that we need to fixup
                // to the new ID.
                Contact misc = context.Contacts.Single(c => c.FirstName == "Bob");
                //Debug.ReferenceEquals(misc, product.Contact);
            }
        }

        public void Fixup_does_not_take_precedence()
        {
            using (var context = new AdventureWorksEntities())
            {
                //Find an existing product that already has a category
                SalesOrderHeader order = context.SalesOrderHeaders.Single(o => o.ModifiedDate == DateTime.Now && o.Contact.FirstName == "Alex");

                Contact contact = context.Contacts.Single(c => c.FirstName == "Alex"); // Change made but fixup

                //Debug.ReferenceEquals(food, product.Contact);

                // ADVICE: should NULL out the category / or do some sort of query etc.
                // RULE: if this is EOCO we should notice that they made an EXPLICIT change
                // and that takes precedence over IMPLICIT fixup.
                order.ContactID = contact.ContactID + 1;
                context.SaveChanges();

                //Debug.Assert(product.Contact == null);
            }
        }

        public void POCO_fixup_based_on_known_current_values()
        {
            using (var context = new AdventureWorksEntities())
            {
                //Find an existing product that already has a category
                SalesOrderHeader order = context.SalesOrderHeaders.Single(o => o.ModifiedDate == DateTime.Now && o.Contact.FirstName == "Alex");

                //ADVICE: null out the reference
                order.ContactID = 2; // miscellaneous

                //NOTE: for POCO you would need to call DETECT changes before the QUERY to know that we need to fixup
                Contact misc = context.Contacts.Single(c => c.ContactID == 2);

                //What will have happen here?
                //Debug.ReferenceEquals(misc, product.Contact);
            }
        }

        public void ReAssigning_To_Same_Contact_by_value_no_effect_on_database()
        {
            using (var context = new AdventureWorksEntities())
            {
                var order = context.SalesOrderHeaders.Single(o => o.ModifiedDate == DateTime.Now);
                order.ContactID = order.ContactID;

                int updates = context.SaveChanges();
                //Nothing needs to be done.
                //Debug.Assert(updates == 0);
            }
        }

        public void ReAssigning_PK_value_with_same_value_has_no_effect_on_database()
        {
            using (var context = new AdventureWorksEntities())
            {
                var order = context.SalesOrderHeaders.Single(o => o.ModifiedDate == DateTime.Now);
                //No exception!
                order.SalesOrderID = order.SalesOrderID;

                //However the object state entry is marked dirty???
                ObjectStateEntry entry = context.ObjectStateManager.GetObjectStateEntry(order);
                //Debug.Assert(entry.State == EntityState.Modified);

                int updates = context.SaveChanges();

                //However we should recognize that nothing needs to be done to the database.
                //Debug.Assert(updates == 0);
            }
        }

        public void Initialize_data_and_fixup_using_AcceptChanges()
        {
            using (var ctx = new AdventureWorksEntities())
            {
                SalesOrderHeader order = new SalesOrderHeader { SalesOrderID = 1, ContactID = 2, ModifiedDate = DateTime.Now };
                Contact c = new Contact { ContactID = 2, FirstName = "Alex" };

                ctx.SalesOrderHeaders.AddObject(order);
                ctx.Contacts.AddObject(c);
                ctx.AcceptAllChanges();

//                Debug.ReferenceEquals(p.Contact, c);
            }
        }
    }
}



/*

// The following example creates a new order for existing Contact using the Foreign key property.
// Notice that you do not need to load a contact, just assign the Contact's ID to the foreign key property.
using (var context = new AdventureWorksEntities())
{
    SalesOrderHeader order = new SalesOrderHeader
    {
        SalesOrderID = 1,
        ModifiedDate = DateTime.Now,
        // Set the foreign key property to the ID of the principal
        // to create the association between the Category and SalesOrderHeader.
        ContactID = 13
    };
    context.SalesOrderHeaders.AddObject(order);
    context.SaveChanges();
}


// The following example creates a new order for existing Contact using the reference assignment.
// Notice that to set the reference, we need to load the contact.
// You do not need to call AddObject() because when you assign the reference
// to the navigation property the objects on both ends get synchronized in the state manager.
using (var context = new AdventureWorksEntities())
{
    SalesOrderHeader order = new SalesOrderHeader
    {
        SalesOrderID = 1,
        ModifiedDate = DateTime.Now,
        // Use Contact navigation property to create the association between Category and SalesOrderHeader.
        Contact = context.Contacts.Single(c => c.ContactID == 13)
    };
    context.SaveChanges();
}


*/
