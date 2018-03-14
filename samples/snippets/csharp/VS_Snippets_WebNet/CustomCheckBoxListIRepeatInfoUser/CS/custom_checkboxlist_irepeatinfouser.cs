// <Snippet2>
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = 
        AspNetHostingPermissionLevel.Minimal)]
    public class CustomCheckBoxListIRepeatInfoUser : CheckBoxList
    {
        private bool hasFooter;
        private bool hasHeader;
        private bool hasSeparators;
        private int repeatedItemCount;
        private Style itemStyleItem;

        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base class's OnPreRender method
            base.OnPreRender(e);

            // Get a self-referencing IRepeatInfoUser object
            IRepeatInfoUser repeatInfoUser = (IRepeatInfoUser)this;

            // Get the IRepeatInfoUser members values.
            hasFooter = repeatInfoUser.HasFooter;
            hasHeader = repeatInfoUser.HasHeader;
            hasSeparators = repeatInfoUser.HasSeparators;
            repeatedItemCount = repeatInfoUser.RepeatedItemCount;
            itemStyleItem = repeatInfoUser.GetItemStyle(ListItemType.Item, 0);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            // Create and setup a RepeatInfo class.
            RepeatInfo repeatInfo = new RepeatInfo();
            repeatInfo.RepeatColumns = 0;
            repeatInfo.RepeatDirection = RepeatDirection.Horizontal;
            repeatInfo.RepeatLayout = RepeatLayout.Table;

            // Get a self-referencing IRepeatInfoUser object
            IRepeatInfoUser repeatInfoUser = (IRepeatInfoUser)this;

            // Render the items using the above RepeatInfo class.
            repeatInfoUser.RenderItem(ListItemType.Item, 0, repeatInfo, writer);
            repeatInfoUser.RenderItem(ListItemType.Item, 1, repeatInfo, writer);
            repeatInfoUser.RenderItem(ListItemType.Item, 2, repeatInfo, writer);
            repeatInfoUser.RenderItem(ListItemType.Item, 3, repeatInfo, writer);
            repeatInfoUser.RenderItem(ListItemType.Item, 4, repeatInfo, writer);
            repeatInfoUser.RenderItem(ListItemType.Item, 5, repeatInfo, writer);
        }
    }
}
// </Snippet2>
