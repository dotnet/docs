        public override bool IsSubsetOf(IPermission target)
        {
#if(debug)
            Console.WriteLine ("************* Entering IsSubsetOf *********************");
#endif
            if (target == null)
            {
                Console.WriteLine ("IsSubsetOf: target == null");
                return false;
            }
#if(debug)

            Console.WriteLine ("This is = " + (( NameIdPermission)this).Name);
            Console.WriteLine ("Target is " + (( NameIdPermission)target).m_Name);
#endif
            try
            {
                 NameIdPermission operand = ( NameIdPermission)target;

                // The following check for unrestricted permission is only included as an example for
                // permissions that allow the unrestricted state. It is of no value for this permission.
                if (true == operand.m_Unrestricted)
                {
                    return true;
                }
                else if (true == this.m_Unrestricted)
                {
                    return false;
                }

                if (this.m_Name != null)
                {
                    if (operand.m_Name == null) return false;

                    if (this.m_Name == "") return true;
                }

                if (this.m_Name.Equals (operand.m_Name)) return true;
                else
                {
                    // Check for wild card character '*'.
                    int i = operand.m_Name.LastIndexOf ("*");

                    if (i > 0)
                    {
                        string prefix = operand.m_Name.Substring (0, i);

                        if (this.m_Name.StartsWith (prefix))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException (String.Format ("Argument_WrongType", this.GetType ().FullName));
            }
        }