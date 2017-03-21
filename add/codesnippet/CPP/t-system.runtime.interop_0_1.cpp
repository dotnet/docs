interface class Baz
{
   void SetColor( [ComAliasName("stdole.OLE_COLOR")]int cl );

   [returnvalue:ComAliasName("stdole.OLE_COLOR")]
   int GetColor();
};
