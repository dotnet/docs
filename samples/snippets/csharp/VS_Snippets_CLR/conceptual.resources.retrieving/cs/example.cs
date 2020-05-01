// <Snippet6>
using System;

[Serializable] public struct PersonTable
{
   public readonly int nColumns;
   public readonly string column1;
   public readonly string column2;
   public readonly string column3;
   public readonly int width1;
   public readonly int width2;
   public readonly int width3;

   public PersonTable(string column1, string column2, string column3,
                  int width1, int width2, int width3)
   {
      this.column1 = column1;
      this.column2 = column2;
      this.column3 = column3;
      this.width1 = width1;
      this.width2 = width2;
      this.width3 = width3;
      this.nColumns = typeof(PersonTable).GetFields().Length / 2;
   }
}
// </Snippet6>
