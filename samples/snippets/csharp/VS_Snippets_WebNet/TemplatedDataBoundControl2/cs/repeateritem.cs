//<snippet4>
using System;
using System.Collections;
using System.Web;
using System.Web.UI;

namespace TemplateControlSamples {

    public class RepeaterItem : Control, INamingContainer {

        private int itemIndex;
        private object dataItem;

        public RepeaterItem(int itemIndex, object dataItem) {
            this.itemIndex = itemIndex;
            this.dataItem = dataItem;
        }

        public object DataItem {
            get {
                return dataItem;
            }
        }

        public int ItemIndex {
            get {
                return itemIndex;
            }
        }
    }
}
//</snippet4>
  