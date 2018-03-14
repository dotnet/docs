// <Snippet1>
using System;
using System.CodeDom;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Compilation;
using System.Web.UI.Design;

// Apply ExpressionEditorAttributes to allow the 
// expression to appear in the designer.
[ExpressionPrefix("MyCustomExpression")]
[ExpressionEditor("MyCustomExpressionEditor")]
public class MyExpressionBuilder : ExpressionBuilder
{
    // Create a method that will return the result 
    // set for the expression argument.
    public static object GetEvalData(string expression, Type target, string entry)
    {
        return expression;
    }

    // <Snippet3>
    public override object EvaluateExpression(object target, BoundPropertyEntry entry, 
	object parsedData, ExpressionBuilderContext context)
    {
        return GetEvalData(entry.Expression, target.GetType(), entry.Name);
    }
    // </Snippet3>

    // <Snippet4>
    public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, 
	object parsedData, ExpressionBuilderContext context)
    {
        Type type1 = entry.DeclaringType;
        PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(type1)[entry.PropertyInfo.Name];
        CodeExpression[] expressionArray1 = new CodeExpression[3];
        expressionArray1[0] = new CodePrimitiveExpression(entry.Expression.Trim());
        expressionArray1[1] = new CodeTypeOfExpression(type1);
        expressionArray1[2] = new CodePrimitiveExpression(entry.Name);
        return new CodeCastExpression(descriptor1.PropertyType, new CodeMethodInvokeExpression(new 
	   CodeTypeReferenceExpression(base.GetType()), "GetEvalData", expressionArray1));
    }
    // </Snippet4>

    // <Snippet2> 
    public override bool SupportsEvaluate
    {
        get { return true; }
    }
    // </Snippet2> 
}
// </Snippet1> 


/*
------  ADDITIONAL CODE SAMPLES -------------
*/

// web.config
/*
<!-- <Snippet5> -->
<configuration>
    <system.web>
       <compilation>
          <expressionBuilders>
              <add expressionPrefix="MyCustomExpression" type="MyCustomExpressionBuilder"/>
          </expressionBuilders>
       </compilation>
    </system.web>
</configuration>
<!-- </Snippet5> -->
*/

// ASPX page
/*
<!-- <Snippet6> -->
<asp:Label ID="Label1" runat="server" Text="<%$ MyCustomExpression:Hello, world! %>" />
<!-- </Snippet6> -->
*/