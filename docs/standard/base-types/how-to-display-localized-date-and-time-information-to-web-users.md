---
title: "How to: Display Localized Date and Time Information to Web Users"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "formatting [.NET Framework], dates"
  - "parsing strings [.NET Framework], date and time strings"
  - "localization [.NET Framework], date and time displays"
  - "formatting [.NET Framework], localized data"
  - "displaying date and time data"
  - "localized date displays [.NET Framework]"
ms.assetid: 377fe93c-32be-421a-a30a-be639a46ede8
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Display Localized Date and Time Information to Web Users
Because a Web page can be displayed anywhere in the world, operations that parse and format date and time values should not rely on a default format (which most often is the format of the Web server's local culture) when interacting with the user. Instead, Web forms that handle date and time strings input by the user should parse the strings using the user's preferred culture. Similarly, date and time data should be displayed to the user in a format that conforms to the user's culture. This topic shows how to do this.  
  
### To parse date and time strings input by the user  
  
1.  Determine whether the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> property is populated. If it is not, continue to step 6.  
  
2.  If the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property is populated, retrieve its first element. The first element indicates the user's default or preferred language and region.  
  
3.  Instantiate a <xref:System.Globalization.CultureInfo> object that represents the user's preferred culture by calling the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor.  
  
4.  Call either the `TryParse` or the `Parse` method of the <xref:System.DateTime> or <xref:System.DateTimeOffset> type to try the conversion. Use an overload of the `TryParse` or the `Parse` method with a `provider` parameter, and pass it either of the following:  
  
    -   The <xref:System.Globalization.CultureInfo> object created in step 3.  
  
    -   The <xref:System.Globalization.DateTimeFormatInfo> object that is returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A> property of the <xref:System.Globalization.CultureInfo> object created in step 3.  
  
5.  If the conversion fails, repeat steps 2 through 4 for each remaining element in the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property.  
  
6.  If the conversion still fails or if the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property is empty, parse the string by using the invariant culture, which is returned by the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property.  
  
### To parse the local date and time of the user's request  
  
1.  Add a <xref:System.Web.UI.WebControls.HiddenField> control to a Web form.  
  
2.  Create a JavaScript function that handles the `onClick` event of a `Submit` button by writing the current date and time and the local time zone's offset from Coordinated Universal Time (UTC) to the <xref:System.Web.UI.WebControls.HiddenField.Value%2A> property. Use a delimiter (such as a semicolon) to separate the two components of the string.  
  
3.  Use the Web form's <xref:System.Web.UI.Control.PreRender> event to inject the function into the HTML output stream by passing the text of the script to the <xref:System.Web.UI.ClientScriptManager.RegisterClientScriptBlock%28System.Type%2CSystem.String%2CSystem.String%2CSystem.Boolean%29?displayProperty=nameWithType> method.  
  
4.  Connect the event handler to the `Submit` button's `onClick` event by providing the name of the JavaScript function to the `OnClientClick` attribute of the `Submit` button.  
  
5.  Create a handler for the `Submit` button's <xref:System.Web.UI.WebControls.Button.Click> event.  
  
6.  In the event handler, determine whether the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> property is populated. If it is not, continue to step 14.  
  
7.  If the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property is populated, retrieve its first element. The first element indicates the user's default or preferred language and region.  
  
8.  Instantiate a <xref:System.Globalization.CultureInfo> object that represents the user's preferred culture by calling the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor.  
  
9. Pass the string assigned to the <xref:System.Web.UI.WebControls.HiddenField.Value%2A> property to the <xref:System.String.Split%2A> method to store the string representation of the user's local date and time and the string representation of the user's local time zone offset in separate array elements.  
  
10. Call either the <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> or <xref:System.DateTime.TryParse%28System.String%2CSystem.IFormatProvider%2CSystem.Globalization.DateTimeStyles%2CSystem.DateTime%40%29?displayProperty=nameWithType> method to convert the date and time of the user's request to a <xref:System.DateTime> value. Use an overload of the method with a `provider` parameter, and pass it either of the following:  
  
    -   The <xref:System.Globalization.CultureInfo> object created in step 8.  
  
    -   The <xref:System.Globalization.DateTimeFormatInfo> object that is returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A> property of the <xref:System.Globalization.CultureInfo> object created in step 8.  
  
11. If the parse operation in step 10 fails, go to step 13. Otherwise, call the <xref:System.UInt32.Parse%28System.String%29?displayProperty=nameWithType> method to convert the string representation of the user's time zone offset to an integer.  
  
12. Instantiate a <xref:System.DateTimeOffset> that represents the user's local time by calling the <xref:System.DateTimeOffset.%23ctor%28System.DateTime%2CSystem.TimeSpan%29?displayProperty=nameWithType> constructor.  
  
13. If the conversion in step 10 fails, repeat steps 7 through 12 for each remaining element in the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property.  
  
14. If the conversion still fails or if the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property is empty, parse the string by using the invariant culture, which is returned by the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property. Then repeat steps 7 through 12.  
  
 The result is a <xref:System.DateTimeOffset> object that represents the local time of the user of your Web page. You can then determine the equivalent UTC by calling the <xref:System.DateTimeOffset.ToUniversalTime%2A> method. You can also determine the equivalent date and time on your Web server by calling the <xref:System.TimeZoneInfo.ConvertTime%28System.DateTimeOffset%2CSystem.TimeZoneInfo%29?displayProperty=nameWithType> method and passing a value of <xref:System.TimeZoneInfo.Local%2A?displayProperty=nameWithType> as the time zone to convert the time to.  
  
## Example  
 The following example contains both the HTML source and the code for an ASP.NET Web form that asks the user to input a date and time value. A client-side script also writes information on the local date and time of the user's request and the offset of the user's time zone from UTC to a hidden field. This information is then parsed by the server, which returns a Web page that displays the user's input. It also displays the date and time of the user's request using the user's local time, the time on the server, and UTC.  
  
 [!code-aspx-csharp[Formatting.HowTo.ParseDateInput#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.ParseDateInput/cs/GetDateInfo.aspx#1)]
 [!code-aspx-vb[Formatting.HowTo.ParseDateInput#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.ParseDateInput/vb/GetDateInfo.aspx#1)]
  
 The client-side script calls the JavaScript `toLocaleString` method. This produces a string that follows the formatting conventions of the user's locale, which is more likely to be successfully parsed on the server.  
  
 The <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> property is populated from the culture names that are contained in `Accept-Language` headers included in an HTTP request. However, not all browsers include `Accept-Language` headers in their requests, and users can also suppress the headers completely. This makes it important to have a fallback culture when parsing user input. Typically the fallback culture is the invariant culture returned by <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType>. Users can also provide Internet Explorer with culture names that they input in a text box, which creates the possibility that the culture names may not be valid. This makes it important to use exception handling when instantiating a <xref:System.Globalization.CultureInfo> object.  
  
 When retrieved from an HTTP request submitted by Internet Explorer, the <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> array is populated in order of user preference. The first element in the array contains the name of the user's primary culture/region. If the array contains any additional items, Internet Explorer arbitrarily assigns them a quality specifier, which is delimited from the culture name by a semicolon. For example, an entry for the fr-FR culture might take the form `fr-FR;q=0.7`.  
  
 The example calls the <xref:System.Globalization.CultureInfo.%23ctor%2A> constructor with its `useUserOverride` parameter set to `false` to create a new <xref:System.Globalization.CultureInfo> object. This ensures that, if the culture name is the default culture name on the server, the new <xref:System.Globalization.CultureInfo> object created by the class constructor contains a culture's default settings and does not reflect any settings overridden by using the server's **Regional and Language Options** application. The values from any overridden settings on the server are unlikely to exist on the user's system or to be reflected in the user's input.  
  
 Because this example parses two string representations of a date and time (one input by the user, the other stored to the hidden field), it defines the possible <xref:System.Globalization.CultureInfo> objects that may be required in advance. It creates an array of <xref:System.Globalization.CultureInfo> objects that is one greater than the number of elements returned by the <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> property. It then instantiates a <xref:System.Globalization.CultureInfo> object for each language/region string, and also instantiates a <xref:System.Globalization.CultureInfo> object that represents <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType>.  
  
 Your code can call either the <xref:System.DateTime.Parse%2A> or the <xref:System.DateTime.TryParse%2A> method to convert the user's string representation of a date and time to a <xref:System.DateTime> value. Repeated calls to a parse method may be required for a single parsing operation. As a result, the <xref:System.DateTime.TryParse%2A> method is better because it returns `false` if a parse operation fails. In contrast, handling the repeated exceptions that may be thrown by the <xref:System.DateTime.Parse%2A> method can be a very expensive proposition in a Web application.  
  
## Compiling the Code  
 To compile the code, create an [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] Web page without a code-behind. Then copy the example into the Web page so that it replaces all the existing code. The [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] Web page should contain the following controls:  
  
-   A <xref:System.Web.UI.WebControls.Label> control, which is not referenced in code. Set its <xref:System.Web.UI.WebControls.TextBox.Text%2A> property to "Enter a Number:".  
  
-   A <xref:System.Web.UI.WebControls.TextBox> control named `DateString`.  
  
-   A <xref:System.Web.UI.WebControls.Button> control named `OKButton`. Set its <xref:System.Web.UI.WebControls.Button.Text%2A> property to "OK".  
  
-   A <xref:System.Web.UI.WebControls.HiddenField> control named `DateInfo`.  
  
## .NET Framework Security  
 To prevent a user from injecting script into the HTML stream, user input should never be directly echoed back in the server response. Instead, it should be encoded by using the <xref:System.Web.HttpServerUtility.HtmlEncode%2A?displayProperty=nameWithType> method.  
  
## See Also  
 [Performing Formatting Operations](../../../docs/standard/base-types/performing-formatting-operations.md)  
 [Standard Date and Time Format Strings](../../../docs/standard/base-types/standard-date-and-time-format-strings.md)  
 [Custom Date and Time Format Strings](../../../docs/standard/base-types/custom-date-and-time-format-strings.md)  
 [Parsing Date and Time Strings](../../../docs/standard/base-types/parsing-datetime.md)
