// <snippet5>
// Create a custom control with two properties named Text and 
// FontSize that get their values from and set their values
// to the control's ViewState property.
using System;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;

namespace ViewStateSamples1
{
   public class ctlViewState1 : Control
   {
      public String Text
      {
         get
         {
            return (String) ViewState["Text"];
         }
         set
         {
            ViewState["Text"] = value;
         }
      }

      public int FontSize
      {
         get
         {
            return (int) ViewState["FontSize"];
         }
         set
         {
            ViewState["FontSize"] = value;
         }
      }
      // Because the Control.ViewState property is modified by the protected
      // keyword, this GetState function is required here so that the page
      // that contains this control can access the control's
      // view state. 
      public StateBag GetState()
      {
         return (StateBag)ViewState;
      }
   }
}
// </snippet5>