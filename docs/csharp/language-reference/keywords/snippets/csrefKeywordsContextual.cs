using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace csrefKeywordsContextual
{
    class Test
    {
        class Student
        {
            public string LastName;
            public Student(string name)
            {
                LastName = name;
            }
        }

        class Category
        {
            public int ID;
            public string Name;

            public Category(int i, string n)
            {
                ID = i;
                Name = n;
            }
        }

        class Product
        {
            public string Name;
            public int ProdID;
            public int CategoryID;
            public Product(string n, int pid, int cid)
            {
                Name = n;
                ProdID = pid;
                CategoryID = cid;
            }
        }

        static string[] vegetables = { "carrot", "celery" };
        static void Main()
        {
            List<Student> students = new List<Student>();
            //<Snippet10>
            var query = from student in students
                        group student by student.LastName[0];
            //</Snippet10>

            //<Snippet11>
            IEnumerable<string> sortDescendingQuery =
                from vegetable in vegetables
                orderby vegetable descending
                select vegetable;
            //</Snippet11>

            //<Snippet14>
            IEnumerable<string> sortAscendingQuery =
                from vegetable in vegetables
                orderby vegetable ascending
                select vegetable;
            //</Snippet14>

            List<Category> categories = new List<Category>();
            List<Product> products = new List<Product>();

            //<Snippet12>
            var innerJoinQuery =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID
                select new { ProductName = prod.Name, Category = category.Name };
            //</Snippet12>
        }

    }
}
