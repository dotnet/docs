<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"/>
        <div>
            <h3>dateTimeFormat.[FormatType] field of Sys.CultureInfo.CurrentCulture object</h3>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
<!-- <Snippet2> -->
<script type="text/javascript">
// <Snippet3>
    // Create the CurrentCulture object
    var cultureObject = Sys.CultureInfo.CurrentCulture;
// </Snippet3>
// <Snippet4>
    // Get the name field of the CurrentCulture object
    var cultureName = cultureObject.name;
// </Snippet4>
// <Snippet5>
    // Get the dateTimeFormat object from the CurrentCulture object
    var dtfObject = cultureObject.dateTimeFormat;
// </Snippet5>
    // Create an array of format types
    var myArray = ['AMDesignator', 'Calendar', 'DateSeparator', 'FirstDayOfWeek',
                   'CalendarWeekRule', 'FullDateTimePattern', 'LongDatePattern', 
                   'LongTimePattern', 'MonthDayPattern', 'PMDesignator', 'RFC1123Pattern', 
                   'ShortDatePattern', 'ShortTimePattern', 'SortableDateTimePattern', 
                   'TimeSeparator', 'UniversalSortableDateTimePattern', 'YearMonthPattern', 
                   'AbbreviatedDayNames', 'ShortestDayNames', 'DayNames', 
                   'AbbreviatedMonthNames', 'MonthNames', 'IsReadOnly',
                   'NativeCalendarName', 'AbbreviatedMonthGenitiveNames', 
                   'MonthGenitiveNames'];

    var result = 'Culture Name: ' + cultureName;
    for (var i = 0, l = myArray.length; i < l; i++) {
        var arrayVal = myArray[i];
        if (typeof(arrayVal) !== 'undefined') {
            result += "<tr><td>" + arrayVal + "</td><td>" + eval("dtfObject." + arrayVal) + '</td></tr>';
        }
    }
    var resultHeader = "<tr><td><b>FormatType</b></td><td><b>FormatValue</b></td></tr>"
    $get('Label1').innerHTML = "<table border=1>" + resultHeader + result +"</table>";

    var d = new Date();
    $get('Label2').innerHTML = "<p/><h3>dateTimeFormat Example: </h3>" + 
    d.localeFormat(Sys.CultureInfo.CurrentCulture.dateTimeFormat.FullDateTimePattern);
 </script>
<!-- </Snippet2> -->
<!-- </Snippet1> -->
