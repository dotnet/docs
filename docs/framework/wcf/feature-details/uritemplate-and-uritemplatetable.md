---
title: "UriTemplate and UriTemplateTable"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5cbbe03f-4a9e-4d44-9e02-c5773239cf52
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# UriTemplate and UriTemplateTable
Web developers require the ability to describe the shape and layout of the URIs that their services respond to. [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] added two new classes to give developers control over their URIs. <xref:System.UriTemplate> and <xref:System.UriTemplateTable> form the basis of the URI-based dispatch engine in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. These classes can also be used on their own, allowing developers to take advantage of templates and the URI mapping mechanism without implementing a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
## Templates  
 A template is a way to describe a set of relative URIs. The set of URI templates in the following table shows how a system that retrieves various types of weather information might be defined.  
  
|Data|Template|  
|----------|--------------|  
|National Forecast|weather/national|  
|State Forecast|weather/{state}|  
|City Forecast|weather/{state}/{city}|  
|Activity Forecast|weather/{state}/{city}/{activity}|  
  
 This table describes a set of structurally similar URIs. Each entry is a URI template. The segments in curly braces describe variables. The segments not in curly braces describe literal strings. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] template classes allow a developer to take an incoming URI, for example, "/weather/wa/seattle/cycling", and match it to a template that describes it, "/weather/{state}/{city}/{activity}".  
  
## UriTemplate  
 <xref:System.UriTemplate> is a class that encapsulates a URI template. The constructor takes a string parameter that defines the template. This string contains the template in the format described in the next section. The <xref:System.UriTemplate> class provides methods that allow you match an incoming URI to a template, generate a URI from a template, retrieve a collection of variable names used in the template, determine whether two templates are equivalent, and return the template's string.  
  
 <xref:System.UriTemplate.Match%28System.Uri%2CSystem.Uri%29> takes a base address and a candidate URI and attempts to match the URI to the template. If the match is successful, a <xref:System.UriTemplateMatch> instance is returned. The <xref:System.UriTemplateMatch> object contains a base URI, the candidate URI, a name/value collection of the query parameters, an array of the relative path segments, a name/value collection of variables that were matched, the <xref:System.UriTemplate> instance used to perform the match, a string that contains any unmatched portion of the candidate URI (used when the template has a wildcard), and an object that is associated with the template.  
  
> [!NOTE]
>  The <xref:System.UriTemplate> class ignores the scheme and port number when matching a candidate URI to a template.  
  
 There are two methods that allow you to generate a URI from a template, <xref:System.UriTemplate.BindByName%28System.Uri%2CSystem.Collections.Specialized.NameValueCollection%29> and <xref:System.UriTemplate.BindByPosition%28System.Uri%2CSystem.String%5B%5D%29>. <xref:System.UriTemplate.BindByName%28System.Uri%2CSystem.Collections.Specialized.NameValueCollection%29> takes a base address and a name/value collection of parameters. These parameters are substituted for variables when the template is bound. <xref:System.UriTemplate.BindByPosition%28System.Uri%2CSystem.String%5B%5D%29> takes the name/value pairs and substitutes them left to right.  
  
 <xref:System.UriTemplate.ToString> returns the template string.  
  
 The <xref:System.UriTemplate.PathSegmentVariableNames%2A> property contains a collection of the names of the variables used within path segments in the template string.  
  
 <xref:System.UriTemplate.IsEquivalentTo%28System.UriTemplate%29> takes a <xref:System.UriTemplate> as a parameter and returns a Boolean value that specifies whether the two templates are equivalent. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the Template Equivalence section later in this topic.  
  
 <xref:System.UriTemplate> is designed to work with any URI scheme that conforms to the HTTP URI grammar. The following are examples of supported URI schemes.  
  
-   http://  
  
-   https://  
  
-   net.tcp://  
  
-   net.pipe://  
  
-   sb://  
  
 Schemes like file:// and urn:// do not conform to the HTTP URI grammar and cause unpredictable results when used with URI templates.  
  
### Template String Syntax  
 A template has three parts: a path, an optional query, and an optional fragment. For an example, see the following template:  
  
```  
"/weather/{state}/{city}?forecast={length)#frag1  
```  
  
 The path consists of "/weather/{state}/{city}", the query consists of "?forecast={length}, and the fragment consists of "#frag1".  
  
 Leading and trailing slashes are optional in the path expression. Both the query and fragment expressions can be omitted entirely. A path consists of a series of segments delimited by '/', each segment can have a literal value, a variable name (written in {curly braces}), or a wildcard (written as '\*'). In the previous template the "\weather\ segment is a literal value while "{state}" and "{city}" are variables. Variables take their name from the contents of their curly braces and they can later be replaced with a concrete value to create a *closed URI*. The wildcard is optional, but can only appear at the end of the URI, where it logically matches "the rest of the path".  
  
 The query expression, if present, specifies a series of unordered name/value pairs delimited by '&'. Elements of the query expression can either be literal pairs (x=2) or a variable pair (x={var}). Only the right side of the query can have a variable expression. ({someName} = {someValue} is not allowed. Unpaired values (?x) are not permitted. There is no difference between an empty query expression and a query expression consisting of just a single '?' (both mean "any query").  
  
 The fragment expression can consist of a literal value, no variables are allowed.  
  
 All template variable names within a template string must be unique. Template variable names are case-insensitive.  
  
 Examples of valid template strings:  
  
-   ""  
  
-   "/shoe"  
  
-   "/shoe/*"  
  
-   "{shoe}/boat"  
  
-   "{shoe}/{boat}/bed/{quilt}"  
  
-   "shoe/{boat}"  
  
-   "shoe/{boat}/*"  
  
-   "shoe/boat?x=2"  
  
-   "shoe/{boat}?x={bed}"  
  
-   "shoe/{boat}?x={bed}&y=band"  
  
-   "?x={shoe}"  
  
-   "shoe?x=3&y={var}  
  
 Examples of invalid template strings:  
  
-   "{shoe}/{SHOE}/x=2" – Duplicate variable names.  
  
-   "{shoe}/boat/?bed={shoe}" – Duplicate variable names.  
  
-   "?x=2&x=3" – Name/value pairs within a query string must be unique, even if they are literals.  
  
-   "?x=2&" – Query string is malformed.  
  
-   "?2&x={shoe}" – Query string must be name/value pairs.  
  
-   "?y=2&&X=3" – Query string must be name value pairs, names cannot start with '&'.  
  
### Compound Path Segments  
 Compound path segments allow a single URI path segment to contain multiple variables as well as variables combined with literals. The following are examples of valid compound path segments.  
  
-   /filename.{ext}/  
  
-   /{filename}.jpg/  
  
-   /{filename}.{ext}/  
  
-   /{a}.{b}someLiteral{c}({d})/  
  
 The following are examples of invalid path segments.  
  
-   /{} - Variables must be named.  
  
-   /{shoe}{boat} - Variables must be separated by a literal.  
  
### Matching and Compound Path Segments  
 Compound path segments allow you to define a UriTemplate that has multiple variables within a single path segment. For example, in the following template string: "Addresses/{state}.{city}" two variables (state and city) are defined within the same segment. This template would match a URL such as "http://example.com/Washington.Redmond" but it will also match an URL like "http://example.com/Washington.Redmond.Microsoft". In the latter case, the state variable will contain "Washington" and the city variable will contain "Redmond.Microsoft". In this case any text (except ‘/’) will match the {city} variable. If you want a template that will not match the "extra" text, place the variable in a separate template segment, for example: "Addresses/{state}/{city}.  
  
### Named Wildcard Segments  
 A named wildcard segment is any path variable segment whose variable name begins with the wildcard character ‘*’. The following template string contains a named wildcard segment named "shoe".  
  
```  
"literal/{*shoe}"  
```  
  
 Wildcard segments must follow the following rules:  
  
-   There can be at most one named wildcard segment for each template string.  
  
-   A named wildcard segment must appear at the right-most segment in the path.  
  
-   A named wildcard segment cannot coexist with an anonymous wildcard segment within the same template string.  
  
-   The name of a named wildcard segment must be unique.  
  
-   Named wildcard segments cannot have default values.  
  
-   Named wildcard segments cannot end with "/".  
  
### Default Variable Values  
 Default variable values allow you to specify default values for variables within a template. Default variables can be specified with the curly braces that declare the variable or as a collection passed to the UriTemplate constructor. The following template shows two ways to specify a <xref:System.UriTemplate> with variables with default values.  
  
```  
UriTemplate t = new UriTemplate("/test/{a=1}/{b=5}");  
```  
  
 This template declares a variable named `a` with a default value of `1` and a variable named `b` with a default value of `5`.  
  
> [!NOTE]
>  Only path segment variables are allowed to have default values. Query string variables, compound segment variables, and named wildcard variables are not permitted to have default values.  
  
 The following code shows how default variable values are handled when matching a candidate URI.  
  
```  
Uri baseAddress = new Uri("http://localhost:800   
Dictionary<string,string> defVals = new Dictionary<string,string> {{"a","1"}, {"b", "5"}};  
UriTemplate t = new UriTemplate("/test/{a}/{b}", defVals);0");  
UriTemplate t = new UriTemplate("/{state=WA}/{city=Redmond}/", true);  
Uri candidate = new Uri("http://localhost:8000/OR");  
  
UriTemplateMatch m1 = t.Match(baseAddress, candidate);  
  
// Display contents of BoundVariables  
foreach (string key in m1.BoundVariables.AllKeys)  
{  
    Console.WriteLine("\t\t{0}={1}", key, m1.BoundVariables[key]);  
}  
// The output of the above code is  
// Template: /{state=WA}/{city=Redmond}/  
// Candidate URI: http://localhost:8000/OR  
// BoundVariables:  
//      STATE=OR  
//       CITY=Redmond  
```  
  
> [!NOTE]
>  A URI such as http://localhost:8000/// does not match the template listed in the preceding code, however a URI such as http://localhost:8000/ does.  
  
 The following code shows how default variable values are handled when creating a URI with a template.  
  
```  
Uri baseAddress = new Uri("http://localhost:8000/");  
Dictionary<string,string> defVals = new Dictionary<string,string> {{"a","1"}, {"b", "5"}};  
UriTemplate t = new UriTemplate("/test/{a}/{b}", defVals);  
NameValueCollection vals = new NameValueCollection();  
vals.Add("a", "10");  
  
Uri boundUri = t.BindByName(baseAddress, vals);  
Console.WriteLine("BaseAddress: {0}", baseAddress);  
Console.WriteLine("Template: {0}", t.ToString());  
  
Console.WriteLine("Values: ");  
foreach (string key in vals.AllKeys)  
{  
    Console.WriteLine("\tKey = {0}, Value = {1}", key, vals[key]);  
}  
Console.WriteLine("Bound URI: {0}", boundUri);  
  
// The output of the preceding code is  
// BaseAddress: http://localhost:8000/  
// Template: /test/{a}/{b}  
// Values:  
//     Key = a, Value = 10  
// Bound URI: http://localhost:8000/test/10/5  
```  
  
 When a variable is given a default value of `null` there are some additional constraints. A variable can have a default value of `null` if the variable is contained within the right most segment of the template string or if all segments to the right of the segment have default values of `null`. The following are valid template strings with default values of `null`:  
  
-   ```  
    UriTemplate t = new UriTemplate("shoe/{boat=null}");  
    ```  
-   ```  
    UriTemplate t = new UriTemplate("{shoe=null}/{boat=null}");  
    ```  
  
-   ```  
    UriTemplate t = new UriTemplate("{shoe=1}/{boat=null}");  
    ```  
 The following are invalid template strings with  default values of `null`:  
  
-   ```  
    UriTemplate t = new UriTemplate("{shoe=null}/boat"); // null default must be in the right most path segment  
    ```  
  
-   ```  
    UriTemplate t = new UriTemplate("{shoe=null}/{boat=x}/{bed=null}"); // shoe cannot have a null default because boat does not have a default null value  
    ```  
### Default Values and Matching  
 When matching a candidate URI with a template that has default values, the default values are placed in the <xref:System.UriTemplateMatch.BoundVariables%2A> collection if values are not specified in the candidate URI.  
  
### Template Equivalence  
 Two templates are said to be *structurally equivalent* when all of the templates' literals match and they have variables in the same segments. For example the following templates are structurally equivalent:  
  
-   /a/{var1}/b b/{var2}?x=1&y=2  
  
-   a/{x}/b%20b/{var1}?y=2&x=1  
  
-   a/{y}/B%20B/{z}/?y=2&x=1  
  
 A few things to notice:  
  
-   If a template contains leading slashes, only the first one is ignored.  
  
-   When comparing template strings for structural equivalence, case is ignored for variable names and path segments, query strings are case sensitive.  
  
-   Query strings are unordered.  
  
## UriTemplateTable  
 The <xref:System.UriTemplateTable> class represents an associative table of <xref:System.UriTemplate> objects bound to an object of the developer's choosing. A <xref:System.UriTemplateTable> must contain at least one <xref:System.UriTemplate> prior to calling <xref:System.UriTemplateTable.MakeReadOnly%28System.Boolean%29>. The contents of a <xref:System.UriTemplateTable> can be changed until <xref:System.UriTemplateTable.MakeReadOnly%28System.Boolean%29> is called. Validation is performed when <xref:System.UriTemplateTable.MakeReadOnly%28System.Boolean%29> is called. The type of validation performed depends upon the value of the `allowMultiple` parameter to <xref:System.UriTemplateTable.MakeReadOnly%28System.Boolean%29>.  
  
 When <xref:System.UriTemplateTable.MakeReadOnly%28System.Boolean%29> is called passing in `false`, the <xref:System.UriTemplateTable> checks to make sure there are no templates in the table. If it finds any structurally equivalent templates, it throws an exception. This is used in conjunction with <xref:System.UriTemplateTable.MatchSingle%28System.Uri%29> when you want to ensure only one template matches an incoming URI.  
  
 When <xref:System.UriTemplateTable.MakeReadOnly%28System.Boolean%29> is called passing in `true`, <xref:System.UriTemplateTable> allows multiple, structurally-equivalent templates to be contained within a <xref:System.UriTemplateTable>.  
  
 If a set of <xref:System.UriTemplate> objects added to a <xref:System.UriTemplateTable> contain query strings they must not be ambiguous. Identical query strings are allowed.  
  
> [!NOTE]
>  While the <xref:System.UriTemplateTable> allows base addresses that use schemes other than HTTP, the scheme and port number are ignored when matching candidate URIs to templates.  
  
### Query String Ambiguity  
 Templates that share an equivalent path contain ambiguous query strings if there is a URI that matches more than one template.  
  
 The following sets of query strings are unambiguous within themselves:  
  
-   ?x=1  
  
-   ?x=2  
  
-   ?x=3  
  
-   ?x=1&y={var}  
  
-   ?x=2&z={var}  
  
-   ?x=3  
  
-   ?x=1  
  
-   ?  
  
-   ? x={var}  
  
-   ?  
  
-   ?m=get&c=rss  
  
-   ?m=put&c=rss  
  
-   ?m=get&c=atom  
  
-   ?m=put&c=atom  
  
 The following sets of query string templates are ambiguous within themselves:  
  
-   ?x=1  
  
-   ?x={var}  
  
 "x=1" - Matches both templates.  
  
-   ?x=1  
  
-   ?y=2  
  
 "x=1&y=2" matches both templates. This is because a query string may contain more query string variables then the template it matches.  
  
-   ?x=1  
  
-   ?x=1&y={var}  
  
 "x=1&y=3" matches both templates.  
  
-   ?x=3&y=4  
  
-   ?x=3&z=5  
  
> [!NOTE]
>  The characters á and Á are considered to be different characters when they appear as part of a URI path or <xref:System.UriTemplate> path segment literal (but the characters a and A are considered to be the same). The characters á and Á are considered to be the same characters when they appear as part of a <xref:System.UriTemplate> {variableName} or a query string (and a and A are also considered to be the same characters).  
  
## See Also  
 [WCF Web HTTP Programming Model Overview](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model-overview.md)  
 [WCF Web HTTP Programming Object Model](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-object-model.md)  
 [UriTemplate](../../../../docs/framework/wcf/samples/uritemplate-sample.md)  
 [UriTemplate Table](../../../../docs/framework/wcf/samples/uritemplate-table-sample.md)  
 [UriTemplate Table Dispatcher](../../../../docs/framework/wcf/samples/uritemplate-table-dispatcher-sample.md)
