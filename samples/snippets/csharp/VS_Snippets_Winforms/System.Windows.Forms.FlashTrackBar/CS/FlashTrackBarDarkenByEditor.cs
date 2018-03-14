// <snippet10>
namespace Microsoft.Samples.WinForms.Cs.FlashTrackBar {
   using System;
   using System.ComponentModel;
   using System.ComponentModel.Design;
   using System.Diagnostics;
   using System.Drawing;
   using System.Drawing.Drawing2D;
   using System.Drawing.Design;
   using System.Windows.Forms;
   using System.Windows.Forms.ComponentModel;
   using System.Windows.Forms.Design;

   public class FlashTrackBarDarkenByEditor : FlashTrackBarValueEditor {
       protected override void SetEditorProps(FlashTrackBar editingInstance, FlashTrackBar editor) {
           base.SetEditorProps(editingInstance, editor);
           editor.Min = 0;
           editor.Max = byte.MaxValue;
       }
   }
}

// </snippet10>