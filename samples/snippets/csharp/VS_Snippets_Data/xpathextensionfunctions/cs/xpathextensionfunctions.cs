//<snippet1>
using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;

namespace XPathExtensionFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            char keychar = ' ';

            while (true)
            {
                Console.Write("\r\nEnter key character to count in names: ");
                keychar = Console.ReadKey().KeyChar;
                if (keychar.Equals('q')) return;

                try
                {
                    // Load source XML into an XPathDocument object instance.
                    XPathDocument xmldoc = new XPathDocument("Tasks.xml");

                    // Create an XPathNavigator from the XPathDocument.
                    XPathNavigator nav = xmldoc.CreateNavigator();

                    //Create argument list and add the parameters.
                    XsltArgumentList varList = new XsltArgumentList();

                    varList.AddParam("charToCount", string.Empty, keychar);

                    // Create an instance of custom XsltContext object.
                    // Pass in the XsltArgumentList object
                    // in which the user-defined variable will be defined.
                    CustomContext context = new CustomContext(new NameTable(), varList);

                    // Add a namespace definition for the namespace prefix that qualifies the
                    // user-defined function name in the query expression.
                    context.AddNamespace("Extensions", "http://xpathExtensions");

                    // Create the XPath expression using extension function to select nodes
                    // that contain 2 occurrences of the character entered by user.
                    XPathExpression xpath = XPathExpression.Compile(
                        "/Tasks/Name[Extensions:CountChar(., $charToCount) = 2]");

                    xpath.SetContext(context);
                    XPathNodeIterator iter = nav.Select(xpath);

                    if (iter.Count.Equals(0))
                        Console.WriteLine("\n\n\rNo results contain 2 instances of "
                                                                 + keychar.ToString());
                    else
                    {
                        Console.WriteLine("\n\n\rResults that contain 2 instances of : "
                                                                 + keychar.ToString());
                        // Iterate over the selected nodes and output the
                        // results filtered by extension function.
                        while (iter.MoveNext())
                        {
                            Console.WriteLine(iter.Current.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //</snippet1>

        //<snippet2>
        class CustomContext : System.Xml.Xsl.XsltContext
        {
            private const string ExtensionsNamespaceUri = "http://xpathExtensions";
            // XsltArgumentList to store names and values of user-defined variables.
            private XsltArgumentList argList;

            public CustomContext()
            {
            }

            public CustomContext(NameTable nt, XsltArgumentList args)
                : base(nt)
            {
                argList = args;
            }

            // Function to resolve references to user-defined XPath extension
            // functions in XPath query expressions evaluated by using an
            // instance of this class as the XsltContext.
            public override System.Xml.Xsl.IXsltContextFunction ResolveFunction(
                                        string prefix, string name,
                                        System.Xml.XPath.XPathResultType[] argTypes)
            {
                // Verify namespace of function.
                if (this.LookupNamespace(prefix) == ExtensionsNamespaceUri)
                {
                    string strCase = name;

                    switch (strCase)
                    {
                        case "CountChar":
                            return new XPathExtensionFunctions(2, 2, XPathResultType.Number,
                                                                        argTypes, "CountChar");

                        case "FindTaskBy": // This function is implemented but not called.
                            return new XPathExtensionFunctions(2, 2, XPathResultType.String,
                                                                        argTypes, "FindTaskBy");

                        case "Right": // This function is implemented but not called.
                            return new XPathExtensionFunctions(2, 2, XPathResultType.String,
                                                                            argTypes, "Right");

                        case "Left": // This function is implemented but not called.
                            return new XPathExtensionFunctions(2, 2, XPathResultType.String,
                                                                             argTypes, "Left");
                    }
                }
                // Return null if none of the functions match name.
                return null;
            }

            // Function to resolve references to user-defined XPath
            // extension variables in XPath query.
            public override System.Xml.Xsl.IXsltContextVariable ResolveVariable(
                                                             string prefix, string name)
            {
                if (this.LookupNamespace(prefix) == ExtensionsNamespaceUri || !prefix.Equals(string.Empty))
                {
                    throw new XPathException(string.Format("Variable '{0}:{1}' is not defined.", prefix, name));
                }

                // Verify name of function is defined.
                if (name.Equals("text") || name.Equals("charToCount") ||
                    name.Equals("right") || name.Equals("left"))
                {
                    // Create an instance of an XPathExtensionVariable
                    // (custom IXsltContextVariable implementation) object
                    //  by supplying the name of the user-defined variable to resolve.
                    XPathExtensionVariable var;
                    var = new XPathExtensionVariable(prefix, name);

                    // The Evaluate method of the returned object will be used at run time
                    // to resolve the user-defined variable that is referenced in the XPath
                    // query expression.
                    return var;
                }
                return null;
            }

            // Empty implementation, returns false.
            public override bool PreserveWhitespace(System.Xml.XPath.XPathNavigator node)
            {
                return false;
            }

            // empty implementation, returns 0.
            public override int CompareDocument(string baseUri, string nextbaseUri)
            {
                return 0;
            }

            public override bool Whitespace
            {
                get
                {
                    return true;
                }
            }

            // The XsltArgumentList property is accessed by the Evaluate method of the
            // XPathExtensionVariable object that the ResolveVariable method returns. It is used
            // to resolve references to user-defined variables in XPath query expressions.
            public XsltArgumentList ArgList
            {
                get
                {
                    return argList;
                }
            }
        }

        //</snippet2>

        //<snippet3>
        // The interface that resolves and executes a specified user-defined function.
        public class XPathExtensionFunctions : System.Xml.Xsl.IXsltContextFunction
        {
            // The data types of the arguments passed to XPath extension function.
            private System.Xml.XPath.XPathResultType[] argTypes;
            // The minimum number of arguments that can be passed to function.
            private int minArgs;
            // The maximum number of arguments that can be passed to function.
            private int maxArgs;
            // The data type returned by extension function.
            private System.Xml.XPath.XPathResultType returnType;
            // The name of the extension function.
            private string FunctionName;

            // Constructor used in the ResolveFunction method of the custom XsltContext
            // class to return an instance of IXsltContextFunction at run time.
            public XPathExtensionFunctions(int minArgs, int maxArgs,
                XPathResultType returnType, XPathResultType[] argTypes, string functionName)
            {
                this.minArgs = minArgs;
                this.maxArgs = maxArgs;
                this.returnType = returnType;
                this.argTypes = argTypes;
                this.FunctionName = functionName;
            }

            // Readonly property methods to access private fields.
            public System.Xml.XPath.XPathResultType[] ArgTypes
            {
                get
                {
                    return argTypes;
                }
            }
            public int Maxargs
            {
                get
                {
                    return maxArgs;
                }
            }

            public int Minargs
            {
                get
                {
                    return maxArgs;
                }
            }

            public System.Xml.XPath.XPathResultType ReturnType
            {
                get
                {
                    return returnType;
                }
            }

            // XPath extension functions.

            private int CountChar(XPathNodeIterator node, char charToCount)
            {
                int charCount = 0;
                for (int charIdx = 0; charIdx < node.Current.Value.Length; charIdx++)
                {
                    if (node.Current.Value[charIdx] ==  charToCount)
                    {
                        charCount++;
                    }
                }
                return charCount;
            }

            // This overload will not force the user
            // to cast to string in the xpath expression
            private string FindTaskBy(XPathNodeIterator node, string text)
            {
                if (node.Current.Value.Contains(text))
                    return node.Current.Value;
                else
                    return "";
            }

            private string Left(string str, int length)
            {
                return str.Substring(0, length);
            }

            private string Right(string str, int length)
            {
                return str.Substring((str.Length - length), length);
            }

            // Function to execute a specified user-defined XPath extension
            // function at run time.
            public object Invoke(System.Xml.Xsl.XsltContext xsltContext,
                           object[] args, System.Xml.XPath.XPathNavigator docContext)
            {
                if (FunctionName == "CountChar")
                    return (Object)CountChar((XPathNodeIterator)args[0],
                                                     Convert.ToChar(args[1]));
                if (FunctionName == "FindTaskBy")
                    return FindTaskBy((XPathNodeIterator)args[0],
                                                  Convert.ToString(args[1]));

                if (FunctionName == "Left")
                    return (Object)Left(Convert.ToString(args[0]),
                                                     Convert.ToInt16(args[1]));

                if (FunctionName == "Right")
                    return (Object)Right(Convert.ToString(args[0]),
                                                     Convert.ToInt16(args[1]));

                return null;
            }
        }

        //</snippet3>

        //<snippet4>
        // The interface used to resolve references to user-defined variables
        // in XPath query expressions at run time. An instance of this class
        // is returned by the overridden ResolveVariable function of the
        // custom XsltContext class.
        public class XPathExtensionVariable : IXsltContextVariable
        {
            // Namespace of user-defined variable.
            private string prefix;
            // The name of the user-defined variable.
            private string varName;

            // Constructor used in the overridden ResolveVariable function of custom XsltContext.
            public XPathExtensionVariable(string prefix, string varName)
            {
                this.prefix = prefix;
                this.varName = varName;
            }

            // Function to return the value of the specified user-defined variable.
            // The GetParam method of the XsltArgumentList property of the active
            // XsltContext object returns value assigned to the specified variable.
            public object Evaluate(System.Xml.Xsl.XsltContext xsltContext)
            {
                XsltArgumentList vars = ((CustomContext)xsltContext).ArgList;
                return vars.GetParam(varName, prefix);
            }

            // Determines whether this variable is a local XSLT variable.
            // Needed only when using a style sheet.
            public bool IsLocal
            {
                get
                {
                    return false;
                }
            }

            // Determines whether this parameter is an XSLT parameter.
            // Needed only when using a style sheet.
            public bool IsParam
            {
                get
                {
                    return false;
                }
            }

            public System.Xml.XPath.XPathResultType VariableType
            {
                get
                {
                    return XPathResultType.Any;
                }
            }
        }

        //</snippet4>
    }
}
