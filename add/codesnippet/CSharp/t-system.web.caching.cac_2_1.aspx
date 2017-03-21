<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="c#" runat="server">
    public void Page_Load(Object sender, EventArgs e) {
        String connectionString;
        connectionString = "Data Source=localhost;Integrated Security=SSPI";
        Cache.Insert("DSN", connectionString, null, DateTime.Now.AddMinutes(2), TimeSpan.Zero, CacheItemPriority.High, null);
    }
</script>