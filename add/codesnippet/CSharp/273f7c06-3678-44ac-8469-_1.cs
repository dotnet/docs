        //Enumerating the contacts and letting the user choose which one to delete.
        public static void DeleteContact() 
        {
            PeerContactCollection pcc = null;
            string contactToDelete = "";

            try
            {
                pcc = EnumContacts();
                if (pcc == null ||
                    pcc.Count == 0)
                {
                    Console.WriteLine("Contact list is empty -- no such contact exists.");
                    return;
                }
                Console.Write("Please enter the nickname of the contact you wish to delete: ");
                contactToDelete = Console.ReadLine();

                foreach (PeerContact pc in pcc)
                {
                    if (pc.Nickname.Equals(contactToDelete))
                    {
                        PeerCollaboration.ContactManager.DeleteContact(pc);
                        Console.WriteLine("Contact {0} successfully deleted!", contactToDelete);
                        return;
                    }
                }
                Console.WriteLine("Contact {0} could not be found in the contact collection.", contactToDelete);
            }
            catch (ArgumentNullException argNullEx)
            {
                Console.WriteLine("The supplied contact is null: {0}", argNullEx.Message);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("The supplied contact \"{0}\" could not be found in the Contact Manager: {1}", 
                    contactToDelete, argEx.Message);
            }
            catch (PeerToPeerException p2pEx)
            {
                Console.WriteLine("The Peer Collaboration Infrastructure could not delete \"{0}\": {1}",
                    contactToDelete, p2pEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception when trying to delete a contact : {0}", ex);
            }
            return;
        }