// <snippet5>
namespace Samples.AspNet.CS {

    using System.Security.Permissions;
    using System.Web;
    using System.Web.UI;

    [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
    public class MyPageAdapter : System.Web.UI.Adapters.PageAdapter {

        public override PageStatePersister GetStatePersister() {
            return new Samples.AspNet.CS.StreamPageStatePersister(Page);
        }
    }
}
// </snippet5>

// <snippet6>
// C:\>csc /t:library /out:C:\inetpub\wwwroot\bin\Samples.AspNet.CS.dll MyPageAdapter.cs TextFilePageStatePersister.cs
//
// C:\>
// </snippet6>
