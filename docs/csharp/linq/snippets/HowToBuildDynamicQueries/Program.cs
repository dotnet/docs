using LinqKit;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;
using System.Reflection;
using System.Linq.Dynamic.Core;

// <Initialize>
string[] companyNames = [
    "Consolidated Messenger", "Alpine Ski House", "Southridge Video",
    "City Power & Light", "Coho Winery", "Wide World Importers",
    "Graphic Design Institute", "Adventure Works", "Humongous Insurance",
    "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
    "Blue Yonder Airlines", "Trey Research", "The Phone Company",
    "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
];

// Use an in-memory array as the data source, but the IQueryable could have come
// from anywhere -- an ORM backed by a database, a web request, or any other LINQ provider.
IQueryable<string> companyNamesSource = companyNames.AsQueryable();
var fixedQry = companyNames.OrderBy(x => x);
// </Initialize>

Console.WriteLine("Runtime state from expression tree:");
RuntimeStateFromWithinExpressionTree();
AddMethodCalls();
VaryExpressions();
ComposeExpressions();
FactoryMethodModifyExpressionTree();
FactoryMethodExpressionOfDelegate();
BuildMoreExpressions();
DynamicLinq();

// <Compiler_generated_expression_tree>
Expression<Func<string, bool>> expr = x => x.StartsWith("a");
// </Compiler_generated_expression_tree>


void RuntimeStateFromWithinExpressionTree()
{
    // <Runtime_state_from_within_expression_tree>
    var length = 1;
    var qry = companyNamesSource
        .Select(x => x.Substring(0, length))
        .Distinct();

    Console.WriteLine(string.Join(",", qry));
    // prints: C, A, S, W, G, H, M, N, B, T, L, F

    length = 2;
    Console.WriteLine(string.Join(",", qry));
    // prints: Co, Al, So, Ci, Wi, Gr, Ad, Hu, Wo, Ma, No, Bl, Tr, Th, Lu, Fo 
    // </Runtime_state_from_within_expression_tree>
}

void AddMethodCalls()
{
    bool sortByLength = true;

    // <Added_method_calls>
    // bool sortByLength = /* ... */;

    var qry = companyNamesSource;
    if (sortByLength)
    {
        qry = qry.OrderBy(x => x.Length);
    }
    // </Added_method_calls>
}

void VaryExpressions()
{
    string? startsWith = "";
    string? endsWith = "";

    // <Varying_expressions>
    // string? startsWith = /* ... */;
    // string? endsWith = /* ... */;

    Expression<Func<string, bool>> expr = (startsWith, endsWith) switch
    {
        ("" or null, "" or null) => x => true,
        (_, "" or null) => x => x.StartsWith(startsWith),
        ("" or null, _) => x => x.EndsWith(endsWith),
        (_, _) => x => x.StartsWith(startsWith) || x.EndsWith(endsWith)
    };

    var qry = companyNamesSource.Where(expr);
    // </Varying_expressions>
}

void ComposeExpressions()
{
    string? startsWith = "";
    string? endsWith = "";

    // <Compose_expressions>
    // This is functionally equivalent to the previous example.

    // using LinqKit;
    // string? startsWith = /* ... */;
    // string? endsWith = /* ... */;

    Expression<Func<string, bool>>? expr = PredicateBuilder.New<string>(false);
    var original = expr;
    if (!string.IsNullOrEmpty(startsWith))
    {
        expr = expr.Or(x => x.StartsWith(startsWith));
    }
    if (!string.IsNullOrEmpty(endsWith))
    {
        expr = expr.Or(x => x.EndsWith(endsWith));
    }
    if (expr == original)
    {
        expr = x => true;
    }

    var qry = companyNamesSource.Where(expr);
    // </Compose_expressions>
}

void FactoryMethodModifyExpressionTree()
{
    // <Factory_method_expression_tree_parameter>
    ParameterExpression x = Parameter(typeof(string), "x");
    // </Factory_method_expression_tree_parameter>

    // <Factory_method_expression_tree_body>
    Expression body = Call(
        x,
        typeof(string).GetMethod("StartsWith", [typeof(string)])!,
        Constant("a")
    );
    // </Factory_method_expression_tree_body>

    // <Factory_method_expression_tree_lambda>
    Expression<Func<string, bool>> expr = Lambda<Func<string, bool>>(body, x);
    // </Factory_method_expression_tree_lambda>
}

void FactoryMethodExpressionOfDelegate()
{
    // <Factory_methods_expression_of_tdelegate>
    // using static System.Linq.Expressions.Expression;

    IQueryable<T> TextFilter<T>(IQueryable<T> source, string term)
    {
        if (string.IsNullOrEmpty(term)) { return source; }

        // T is a compile-time placeholder for the element type of the query.
        Type elementType = typeof(T);

        // Get all the string properties on this specific type.
        PropertyInfo[] stringProperties = elementType
            .GetProperties()
            .Where(x => x.PropertyType == typeof(string))
            .ToArray();
        if (!stringProperties.Any()) { return source; }

        // Get the right overload of String.Contains
        MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)])!;

        // Create a parameter for the expression tree:
        // the 'x' in 'x => x.PropertyName.Contains("term")'
        // The type of this parameter is the query's element type
        ParameterExpression prm = Parameter(elementType);

        // Map each property to an expression tree node
        IEnumerable<Expression> expressions = stringProperties
            .Select(prp =>
                // For each property, we have to construct an expression tree node like x.PropertyName.Contains("term")
                Call(                  // .Contains(...) 
                    Property(          // .PropertyName
                        prm,           // x 
                        prp
                    ),
                    containsMethod,
                    Constant(term)     // "term" 
                )
            );

        // Combine all the resultant expression nodes using ||
        Expression body = expressions
            .Aggregate((prev, current) => Or(prev, current));

        // Wrap the expression body in a compile-time-typed lambda expression
        Expression<Func<T, bool>> lambda = Lambda<Func<T, bool>>(body, prm);

        // Because the lambda is compile-time-typed (albeit with a generic parameter), we can use it with the Where method
        return source.Where(lambda);
    }
    // </Factory_methods_expression_of_tdelegate>

    // <Factory_methods_expression_of_tdelegate_usage>
    var qry = TextFilter(
            new List<Person>().AsQueryable(),
            "abcd"
        )
        .Where(x => x.DateOfBirth < new DateTime(2001, 1, 1));

    var qry1 = TextFilter(
            new List<Car>().AsQueryable(),
            "abcd"
        )
        .Where(x => x.Year == 2010);
    // </Factory_methods_expression_of_tdelegate_usage>
}

void BuildMoreExpressions()
{
    // This function has the logic for constructing the body of the TextFilter expression.
    (Expression? body, ParameterExpression? prm) constructBody(Type elementType, string term)
    {
        if (string.IsNullOrEmpty(term)) { return (null, null); }

        PropertyInfo[] stringProperties =
            elementType.GetProperties()
                .Where(x => x.PropertyType == typeof(string))
                .ToArray();
        if (!stringProperties.Any()) { return (null, null); }

        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;

        var prm = Parameter(elementType);
        var body = stringProperties
            .Select(prp =>
                Call(
                    Property(prm, prp),
                    containsMethod,
                    Constant(term)
                )
            )
            .Aggregate<Expression>((prev, current) => Or(prev, current)
            );

        return (body, prm);
    }

    // <Factory_methods_lambdaexpression>
    IQueryable TextFilter_Untyped(IQueryable source, string term)
    {
        if (string.IsNullOrEmpty(term)) { return source; }
        Type elementType = source.ElementType;

        // The logic for building the ParameterExpression and the LambdaExpression's body is the same as in the previous example,
        // but has been refactored into the constructBody function.
        (Expression? body, ParameterExpression? prm) = constructBody(elementType, term);
        if (body is null) { return source; }

        Expression filteredTree = Call(
            typeof(Queryable),
            "Where",
            [elementType],
            source.Expression,
            Lambda(body, prm!)
        );

        return source.Provider.CreateQuery(filteredTree);
    }
    // </Factory_methods_lambdaexpression>

    IQueryable qry = TextFilter_Untyped(
        new List<Person>().AsQueryable(),
        "abcd"
    );
}

void DynamicLinq()
{
    // <Dynamic_linq>
    // using System.Linq.Dynamic.Core

    IQueryable TextFilter_Strings(IQueryable source, string term)
    {
        if (string.IsNullOrEmpty(term)) { return source; }

        var elementType = source.ElementType;

        // Get all the string property names on this specific type.
        var stringProperties =
            elementType.GetProperties()
                .Where(x => x.PropertyType == typeof(string))
                .ToArray();
        if (!stringProperties.Any()) { return source; }

        // Build the string expression
        string filterExpr = string.Join(
            " || ",
            stringProperties.Select(prp => $"{prp.Name}.Contains(@0)")
        );

        return source.Where(filterExpr, term);
    }
    // </Dynamic_linq>

    IQueryable qry = new List<Person>().AsQueryable();
    qry = TextFilter_Strings(qry, "abcd");
}

// <Entities>
record Person(string LastName, string FirstName, DateTime DateOfBirth);
record Car(string Model, int Year);
// </Entities>
