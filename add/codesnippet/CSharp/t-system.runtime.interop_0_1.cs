 interface Baz {
  void SetColor([ComAliasName("stdole.OLE_COLOR")] int cl);
  [return: ComAliasName("stdole.OLE_COLOR")] int GetColor();
 }