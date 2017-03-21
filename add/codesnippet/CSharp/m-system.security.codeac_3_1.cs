        public override IPermission Intersect(IPermission target)
        {
            Console.WriteLine ("************* Entering Intersect *********************");
            if (target == null)
            {
                return null;
            }
#if(debug)
            Console.WriteLine ("This is = " + (( NameIdPermission)this).Name);
            Console.WriteLine ("Target is " + (( NameIdPermission)target).m_Name);
#endif
            if (!VerifyType(target))
            {
                throw new ArgumentException (String.Format ("Argument is wrong type.", this.GetType ().FullName));
            }

             NameIdPermission operand = ( NameIdPermission)target;

            if (operand.IsSubsetOf (this)) return operand.Copy ();
            else if (this.IsSubsetOf (operand)) return this.Copy ();
            else
                return null;
        }