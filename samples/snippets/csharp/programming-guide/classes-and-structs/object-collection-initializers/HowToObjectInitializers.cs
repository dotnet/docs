﻿using System;
using System.Collections.Generic;
using System.Text;

namespace object_collection_initializers
{
    // <SnippetHowToObjectInitializers>
    public class HowToObjectInitializers
    {
        public static void Main()
        {
            // Declare a StudentName by using the constructor that has two parameters.
            StudentName student1 = new StudentName("Craig", "Playstead");

            // Make the same declaration by using an object initializer and sending
            // arguments for the first and last names. The parameterless constructor is
            // invoked in processing this declaration, not the constructor that has
            // two parameters.
            StudentName student2 = new StudentName
            {
                FirstName = "Craig",
                LastName = "Playstead"
            };

            // Declare a StudentName by using an object initializer and sending
            // an argument for only the ID property. No corresponding constructor is
            // necessary. Only the parameterless constructor is used to process object
            // initializers.
            StudentName student3 = new StudentName
            {
                ID = 183
            };

            // Declare a StudentName by using an object initializer and sending
            // arguments for all three properties. No corresponding constructor is
            // defined in the class.
            StudentName student4 = new StudentName
            {
                FirstName = "Craig",
                LastName = "Playstead",
                ID = 116
            };

            Console.WriteLine(student1.ToString());
            Console.WriteLine(student2.ToString());
            Console.WriteLine(student3.ToString());
            Console.WriteLine(student4.ToString());
        }
        // Output:
        // Craig  0
        // Craig  0
        //   183
        // Craig  116

        public class StudentName
        {
            // This constructor has no parameters. The parameterless constructor
            // is invoked in the processing of object initializers.
            // You can test this by changing the access modifier from public to
            // private. The declarations in Main that use object initializers will
            // fail.
            public StudentName() { }

            // The following constructor has parameters for two of the three
            // properties.
            public StudentName(string first, string last)
            {
                FirstName = first;
                LastName = last;
            }

            // Properties.
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }

            public override string ToString() => FirstName + "  " + ID;
        }
    }
    // </SnippetHowToObjectInitializers>
}
