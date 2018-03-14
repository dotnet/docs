// <snippet1>
namespace Samples.AspNet.CS {

    using System.Web.UI;

    public class MyPageAdapter : System.Web.UI.Adapters.PageAdapter {

        public override PageStatePersister GetStatePersister() {
            return new SessionPageStatePersister(Page);
        }
    }
}
// </snippet1>