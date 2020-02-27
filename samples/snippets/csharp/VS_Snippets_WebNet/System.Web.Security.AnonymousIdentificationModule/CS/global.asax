<script language="C#" runat="server">

//<Snippet1>
public void AnonymousIdentification_Creating(object sender, 
                                             AnonymousIdentificationEventArgs args)
{
  args.AnonymousID = Samples.AspNet.Security.MyIdClass.GetAnonymousId();
  Samples.AspNet.Security.MyIdClass.LogAnonymousId(args.AnonymousID);
}
//</Snippet1>
</script>