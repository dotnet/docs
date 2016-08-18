namespace ClassesAndObjects
{
    using System;
    using System.Collections.Generic;
    public abstract class Expression
    {
        public abstract double Evaluate(Dictionary<string,object> vars);
    }
    public class Constant: Expression
    {
        double value;
        public Constant(double value) 
        {
            this.value = value;
        }
        public override double Evaluate(Dictionary<string,object> vars) 
        {
            return value;
        }
    }
    public class VariableReference: Expression
    {
        string name;
        public VariableReference(string name) 
        {
            this.name = name;
        }
        public override double Evaluate(Dictionary<string,object> vars) 
        {
            object value = vars[name];
            if (value == null) 
            {
                throw new Exception("Unknown variable: " + name);
            }
            return Convert.ToDouble(value);
        }
    }
    public class Operation: Expression
    {
        Expression left;
        char op;
        Expression right;
        public Operation(Expression left, char op, Expression right) 
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }
        public override double Evaluate(Dictionary<string,object> vars) 
        {
            double x = left.Evaluate(vars);
            double y = right.Evaluate(vars);
            switch (op) {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
            }
            throw new Exception("Unknown operator");
        }
    }
}

namespace ClassesAndObjects
{
    using System;
    using System.Collections.Generic;
    class InheritanceExample
    {
        public static void ExampleUsage() 
        {
            Expression e = new Operation(
                new VariableReference("x"),
                '*',
                new Operation(
                    new VariableReference("y"),
                    '+',
                    new Constant(2)
                )
            );
            Dictionary<string,object> vars = new Dictionary<string, object>();
            vars["x"] = 3;
            vars["y"] = 5;
            Console.WriteLine(e.Evaluate(vars));		// Outputs "21"
            vars["x"] = 1.5;
            vars["y"] = 9;
            Console.WriteLine(e.Evaluate(vars));		// Outputs "16.5"
        }
    }   
}