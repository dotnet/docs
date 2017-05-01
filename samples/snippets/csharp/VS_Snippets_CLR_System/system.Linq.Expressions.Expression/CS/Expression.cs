using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSnippets
{
    static class Examples
    {
        static void Main(string[] args)
        {
            //NewArrayInit();
            //NewArrayBounds();
            //ArrayIndex();
            //ElementInit();
            //Field();
            //Invoke();
            //ListInit();
            //MakeBinary();
            //MemberInit();
            //New();
            TypeAs();
            //TypeIs();
        }

        static void NewArrayInit()
        {
            // <Snippet1>
            List<System.Linq.Expressions.Expression> trees =
                new List<System.Linq.Expressions.Expression>()
                    { System.Linq.Expressions.Expression.Constant("oak"),
                      System.Linq.Expressions.Expression.Constant("fir"),
                      System.Linq.Expressions.Expression.Constant("spruce"),
                      System.Linq.Expressions.Expression.Constant("alder") };

            // Create an expression tree that represents creating and  
            // initializing a one-dimensional array of type string.
            System.Linq.Expressions.NewArrayExpression newArrayExpression =
                System.Linq.Expressions.Expression.NewArrayInit(typeof(string), trees);

            // Output the string representation of the Expression.
            Console.WriteLine(newArrayExpression.ToString());

            // This code produces the following output:
            //
            // new [] {"oak", "fir", "spruce", "alder"}
            // </Snippet1>
        }

        static void NewArrayBounds()
        {
            // <Snippet2>
            // Create an expression tree that represents creating a 
            // two-dimensional array of type string with bounds [3,2].
            System.Linq.Expressions.NewArrayExpression newArrayExpression =
                System.Linq.Expressions.Expression.NewArrayBounds(
                        typeof(string),
                        System.Linq.Expressions.Expression.Constant(3),
                        System.Linq.Expressions.Expression.Constant(2));

            // Output the string representation of the Expression.
            Console.WriteLine(newArrayExpression.ToString());

            // This code produces the following output:
            //
            // new System.String[,](3, 2)
            // </Snippet2>
        }

        static void ArrayIndex()
        {
            // <Snippet3>
            string[,] gradeArray =
                { {"chemistry", "history", "mathematics"}, {"78", "61", "82"} };

            System.Linq.Expressions.Expression arrayExpression =
                System.Linq.Expressions.Expression.Constant(gradeArray);

            // Create a MethodCallExpression that represents indexing
            // into the two-dimensional array 'gradeArray' at (0, 2).
            // Executing the expression would return "mathematics".
            System.Linq.Expressions.MethodCallExpression methodCallExpression =
                System.Linq.Expressions.Expression.ArrayIndex(
                    arrayExpression,
                    System.Linq.Expressions.Expression.Constant(0),
                    System.Linq.Expressions.Expression.Constant(2));

            Console.WriteLine(methodCallExpression.ToString());

            // This code produces the following output:
            //
            // value(System.String[,]).Get(0, 2)
            // </Snippet3>
        }

        static void ElementInit()
        {
            // <Snippet4>
            string tree = "maple";

            System.Reflection.MethodInfo addMethod = typeof(Dictionary<int, string>).GetMethod("Add");

            // Create an ElementInit that represents calling
            // Dictionary<int, string>.Add(tree.Length, tree).
            System.Linq.Expressions.ElementInit elementInit =
                System.Linq.Expressions.Expression.ElementInit(
                    addMethod,
                    System.Linq.Expressions.Expression.Constant(tree.Length),
                    System.Linq.Expressions.Expression.Constant(tree));

            Console.WriteLine(elementInit.ToString());

            // This code produces the following output:
            //
            // Void Add(Int32, System.String)(5,"maple")
            // </Snippet4>
        }

        static void Field()
        {
            FieldExample.CreateFieldExpression();
        }

        static void Invoke()
        {
            // <Snippet6>
            System.Linq.Expressions.Expression<Func<int, int, bool>> largeSumTest =
                (num1, num2) => (num1 + num2) > 1000;

            // Create an InvocationExpression that represents applying
            // the arguments '539' and '281' to the lambda expression 'largeSumTest'.
            System.Linq.Expressions.InvocationExpression invocationExpression =
                System.Linq.Expressions.Expression.Invoke(
                    largeSumTest,
                    System.Linq.Expressions.Expression.Constant(539),
                    System.Linq.Expressions.Expression.Constant(281));

            Console.WriteLine(invocationExpression.ToString());

            // This code produces the following output:
            //
            // Invoke((num1, num2) => ((num1 + num2) > 1000),539,281)
            // </Snippet6>
        }

        static void ListInit()
        {
            // <Snippet7>
            string tree1 = "maple";
            string tree2 = "oak";

            System.Reflection.MethodInfo addMethod = typeof(Dictionary<int, string>).GetMethod("Add");

            // Create two ElementInit objects that represent the
            // two key-value pairs to add to the Dictionary.
            System.Linq.Expressions.ElementInit elementInit1 =
                System.Linq.Expressions.Expression.ElementInit(
                    addMethod,
                    System.Linq.Expressions.Expression.Constant(tree1.Length),
                    System.Linq.Expressions.Expression.Constant(tree1));
            System.Linq.Expressions.ElementInit elementInit2 =
                System.Linq.Expressions.Expression.ElementInit(
                    addMethod,
                    System.Linq.Expressions.Expression.Constant(tree2.Length),
                    System.Linq.Expressions.Expression.Constant(tree2));

            // Create a NewExpression that represents constructing
            // a new instance of Dictionary<int, string>.
            System.Linq.Expressions.NewExpression newDictionaryExpression =
                System.Linq.Expressions.Expression.New(typeof(Dictionary<int, string>));

            // Create a ListInitExpression that represents initializing
            // a new Dictionary<> instance with two key-value pairs.
            System.Linq.Expressions.ListInitExpression listInitExpression =
                System.Linq.Expressions.Expression.ListInit(
                    newDictionaryExpression,
                    elementInit1,
                    elementInit2);

            Console.WriteLine(listInitExpression.ToString());

            // This code produces the following output:
            //
            // new Dictionary`2() {Void Add(Int32, System.String)(5,"maple"),
            // Void Add(Int32, System.String)(3,"oak")}
            // </Snippet7>
        }

        static void MakeBinary()
        {
            // <Snippet8>
            // Create a BinaryExpression that represents subtracting 14 from 53.
            System.Linq.Expressions.BinaryExpression binaryExpression =
                System.Linq.Expressions.Expression.MakeBinary(
                    System.Linq.Expressions.ExpressionType.Subtract,
                    System.Linq.Expressions.Expression.Constant(53),
                    System.Linq.Expressions.Expression.Constant(14));

            Console.WriteLine(binaryExpression.ToString());

            // This code produces the following output:
            //
            // (53 - 14)
            // </Snippet8>
        }

        static void MemberInit()
        {
            MemberInitExample.CreateMemberInitExpression();
        }

        static void New()
        {
            // <Snippet10>
            // Create a NewExpression that represents constructing
            // a new instance of Dictionary<int, string>.
            System.Linq.Expressions.NewExpression newDictionaryExpression =
                System.Linq.Expressions.Expression.New(typeof(Dictionary<int, string>));

            Console.WriteLine(newDictionaryExpression.ToString());

            // This code produces the following output:
            //
            // new Dictionary`2()
            // </Snippet10>
        }

        static void TypeAs()
        {
            // <Snippet11>
            // Create a UnaryExpression that represents a
            // conversion of an int to an int?.
            System.Linq.Expressions.UnaryExpression typeAsExpression =
                System.Linq.Expressions.Expression.TypeAs(
                    System.Linq.Expressions.Expression.Constant(34, typeof(int)),
                    typeof(int?));

            Console.WriteLine(typeAsExpression.ToString());

            // This code produces the following output:
            //
            // (34 As Nullable`1)
            // </Snippet11>
        }

        static void TypeIs()
        {
            // <Snippet12>
            // Create a TypeBinaryExpression that represents a
            // type test of the string "spruce" against the 'int' type.
            System.Linq.Expressions.TypeBinaryExpression typeBinaryExpression =
                System.Linq.Expressions.Expression.TypeIs(
                    System.Linq.Expressions.Expression.Constant("spruce"),
                    typeof(int));

            Console.WriteLine(typeBinaryExpression.ToString());

            // This code produces the following output:
            //
            // ("spruce" Is Int32)
            // </Snippet12>
        }
    }

    class FieldExample
    {
        // <Snippet5>
        class Animal
        {
            public string species;
        }

        public static void CreateFieldExpression()
        {
            Animal horse = new Animal();

            // Create a MemberExpression that represents getting
            // the value of the 'species' field of class 'Animal'.
            System.Linq.Expressions.MemberExpression memberExpression =
                System.Linq.Expressions.Expression.Field(
                    System.Linq.Expressions.Expression.Constant(horse),
                    "species");

            Console.WriteLine(memberExpression.ToString());

            // This code produces the following output:
            //
            // value(CodeSnippets.FieldExample+Animal).species
        }
        // </Snippet5>
    }

    class MemberInitExample
    {
        // <Snippet9>
        class Animal
        {
            public string Species {get; set;}
            public int Age {get; set;}
        }

        public static void CreateMemberInitExpression()
        {
            System.Linq.Expressions.NewExpression newAnimal =
                System.Linq.Expressions.Expression.New(typeof(Animal));

            System.Reflection.MemberInfo speciesMember =
                typeof(Animal).GetMember("Species")[0];
            System.Reflection.MemberInfo ageMember =
                typeof(Animal).GetMember("Age")[0];

            // Create a MemberBinding object for each member
            // that you want to initialize.
            System.Linq.Expressions.MemberBinding speciesMemberBinding =
                System.Linq.Expressions.Expression.Bind(
                    speciesMember,
                    System.Linq.Expressions.Expression.Constant("horse"));
            System.Linq.Expressions.MemberBinding ageMemberBinding =
                System.Linq.Expressions.Expression.Bind(
                    ageMember,
                    System.Linq.Expressions.Expression.Constant(12));

            // Create a MemberInitExpression that represents initializing
            // two members of the 'Animal' class.
            System.Linq.Expressions.MemberInitExpression memberInitExpression =
                System.Linq.Expressions.Expression.MemberInit(
                    newAnimal,
                    speciesMemberBinding,
                    ageMemberBinding);

            Console.WriteLine(memberInitExpression.ToString());

            // This code produces the following output:
            //
            // new Animal() {Species = "horse", Age = 12}
        }
        // </Snippet9>
    }
}
