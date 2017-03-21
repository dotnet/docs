        // Throws an exception if the specified name does not contain 
        // all valid character types.
        public void ValidateName(string name)
        {
            for(int i = 0; i < name.Length; i++)
            {
                char ch = name[i];
                UnicodeCategory uc = Char.GetUnicodeCategory(ch);
                switch (uc) 
                {
                    case UnicodeCategory.UppercaseLetter:       
                    case UnicodeCategory.LowercaseLetter:     
                    case UnicodeCategory.TitlecaseLetter:                                                  
                    case UnicodeCategory.DecimalDigitNumber:                         
                        break;
                    default:
                        throw new Exception("The name '"+name+"' is not a valid identifier.");                
                }
            }
        }