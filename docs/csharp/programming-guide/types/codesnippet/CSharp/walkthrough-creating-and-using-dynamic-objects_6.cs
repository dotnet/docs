        // Implement the TryGetMember method of the DynamicObject class for dynamic member calls.
        public override bool TryGetMember(GetMemberBinder binder,
                                          out object result) 
        {
            result = GetPropertyValue(binder.Name);
            return result == null ? false : true;
        }