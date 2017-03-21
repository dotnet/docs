private void PrintBindingMemberInfo()
{
   Console.WriteLine("\n BindingMemberInfo");
   foreach(Control thisControl in this.Controls)
   {
      foreach(Binding thisBinding in thisControl.DataBindings)
      {
         BindingMemberInfo bInfo = thisBinding.BindingMemberInfo;
         Console.WriteLine("\t BindingPath: " + bInfo.BindingPath);
         Console.WriteLine("\t BindingField: " + bInfo.BindingField);
         Console.WriteLine("\t BindingMember: " + 
         bInfo.BindingMember);
         Console.WriteLine();
      }   
   }
}