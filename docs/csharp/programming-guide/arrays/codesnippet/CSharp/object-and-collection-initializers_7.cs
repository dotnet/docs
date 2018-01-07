using System;
using System.Collections;
using System.Collections.Generic;

namespace ExampleProject
{
    class FormattedAddresses : IEnumerable<string>
    {
        private List<string> internalList;
        public IEnumerator<string> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        public FormattedAddresses()
        {
            internalList = new List<string>();
        }

        public void Add(string firstname, string lastname, string street, string city, string state, string zipcode)
        {
            internalList.Add(
                $@"{firstname} {lastname}
{street}
{city}, {state} {zipcode}"
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FormattedAddresses addresses = new FormattedAddresses()
            {
                {"John", "Doe", "123 Street", "Topeka", "KS", "00000" },
                {"Jane", "Smith", "456 Street", "Topeka", "KS", "00000" }
            };

            Console.WriteLine("Address Entries:");

            foreach(string addressEntry in addresses)
            {
                Console.WriteLine("\r\n" + addressEntry);
            }
        }

        /*
         * Prints:
         
            Address Entries:

            John Doe
            123 Street
            Topeka, KS 00000

            Jane Smith
            456 Street
            Topeka, KS 00000
         */
    }
}
