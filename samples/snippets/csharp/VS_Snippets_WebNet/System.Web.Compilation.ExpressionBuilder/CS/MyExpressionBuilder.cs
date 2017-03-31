//<!--<snippet1>-->
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

    //<!--<snippet3>-->
    public override object EvaluateExpression(object target, BoundPropertyEntry entry, 
	object parsedData, ExpressionBuilderContext context)
    {
        return GetEvalData(entry.Expression, target.GetType(), entry.Name);
    }
    //<!--</snippet3>-->

    //<!--<snippet4>-->
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
    //<!--</snippet4>-->

    //<!--<snippet2>-->
    public override bool SupportsEvaluate
    {
        get { return true; }
    }
    //<!--</snippet2>-->
}
//<!--</snippet1>-->


/*
------  ADDITIONAL CODE SAMPLES -------------
*/

// web.config
/*
<!--<snippet5>-->
<configuration>
    <system.web>
       <compilation>
          <expressionBuilders>
              <add expressionPrefix="MyCustomExpression" type="MyCustomExpressionBuilder"/>
          </expressionBuilders>
       </compilation>
    </system.web>
</configuration>
<!--</snippet5>-->
*/

// ASPX page
/*
<!--<snippet6>-->
<asp:Label ID="Label1" runat="server" Text="<%$ MyCustomExpression:Hello, world! %>" />
<!--</snippet6>-->
*/