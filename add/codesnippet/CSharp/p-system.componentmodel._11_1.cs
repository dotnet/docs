    public class MyFontList : BindingList<Font>
    {

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            // Ignore the prop value and search by family name.
            for (int i = 0; i < Count; ++i)
            {
                if (Items[i].FontFamily.Name.ToLower() == ((string)key).ToLower())
                    return i;

            }
            return -1;
        }


    }
  
}