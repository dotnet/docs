        public override IPermission Union(IPermission target)
        {
#if(debug)
            Console.WriteLine ("************* Entering Union *********************");
#endif
            if (target == null)
            {
                return this;
            }
#if(debug)
            Console.WriteLine ("This is = " + (( NameIdPermission)this).Name);
            Console.WriteLine ("Target is " + (( NameIdPermission)target).m_Name);
#endif
            if (!VerifyType(target))
            {
                throw new ArgumentException (String.Format ("Argument_WrongType", this.GetType ().FullName));
            }

             NameIdPermission operand = ( NameIdPermission)target;

            if (operand.IsSubsetOf (this)) return this.Copy ();
            else if (this.IsSubsetOf (operand)) return operand.Copy ();
            else
                return null;
        }