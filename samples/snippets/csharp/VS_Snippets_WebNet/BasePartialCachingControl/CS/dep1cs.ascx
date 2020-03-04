<%@ debug="true" language="c#" %>
<%@ OutputCache Duration="100" varybyparam="none" %>

<script runat="server">
// <snippet1>
void Page_Load(Object sender, EventArgs ev) {
    BasePartialCachingControl c = Parent as BasePartialCachingControl;
    if (c != null) {
// <snippet2>  
      c.Dependency = new CacheDependency(MapPath("dep1.txt"));
// </snippet2>
    }
}
// </snippet1>
</script>

The date and time on the user control is: <%= DateTime.Now %><br />
