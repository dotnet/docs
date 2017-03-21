   static char GetFirstCharacter(String s)
   {
      if (String.IsNullOrEmpty(s)) 
         return '\u0000';
      else   
         return s[0];
   }