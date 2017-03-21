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