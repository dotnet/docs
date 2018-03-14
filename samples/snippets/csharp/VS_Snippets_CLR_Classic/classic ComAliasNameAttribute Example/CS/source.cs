using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

/*
*/

// <Snippet2>
 interface Baz {
  void SetColor([ComAliasName("stdole.OLE_COLOR")] int cl);
  [return: ComAliasName("stdole.OLE_COLOR")] int GetColor();
 }
// </Snippet2>
