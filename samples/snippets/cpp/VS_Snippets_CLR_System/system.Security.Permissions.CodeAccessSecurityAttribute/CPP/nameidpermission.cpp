#define debug
//#define debug
// This custom permission is intended only for the purposes of illustration.
// The following code shows how to create a custom permission that inherits
// from CodeAccessPermission. The code implements all required overrides.
// A wildcard character ('*') is implemented for the Name property.
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::IO;
using namespace System::Security::Policy;
using namespace System::Collections;
using namespace System::Text;
// Use the command line option '/keyfile' or appropriate project settings to sign this assembly.
[assembly:System::Security::AllowPartiallyTrustedCallersAttribute()];

namespace MyPermission
{
    [Serializable()]
    public ref class NameIdPermission sealed : CodeAccessPermission, IUnrestrictedPermission
    {
    private:
            String^ m_Name;
            bool m_Unrestricted;

    public:
        NameIdPermission(String^ name)
        {
            m_Name = name;
        }

        NameIdPermission(PermissionState^ state)
        {
            if (state == PermissionState::None)
            {
                m_Name = "";
            }
            else if (state == PermissionState::Unrestricted)
            {
                throw gcnew ArgumentException("Unrestricted state is not allowed for identity permissions.");
            }
            else throw gcnew ArgumentException("Invalid permission state.");
        }

        property String^ Name
        {
            String^ get()
            {
                return m_Name;
            }

            void set( String^ value )
            {
                m_Name = value;
            }
        }
        virtual IPermission^ Copy() override
        {
            String^ name = m_Name;
            return gcnew NameIdPermission( name );
        }

        virtual bool IsUnrestricted()
        {
            // Always false, unrestricted state is not allowed.
            return m_Unrestricted;
        }

        bool VerifyType(IPermission^ target)
        {
            return (target->GetType() == NameIdPermission::typeid);
        }

        virtual bool IsSubsetOf(IPermission^ target) override
        {
#ifdef debug
            Console::WriteLine ("************* Entering IsSubsetOf *********************");
#endif
            if (target == nullptr)
            {
                Console::WriteLine ("IsSubsetOf: target == null");
                return false;
            }
#ifdef debug

            Console::WriteLine ("This is = " + (( NameIdPermission^)this)->Name);
            Console::WriteLine ("Target is " + (( NameIdPermission^)target)->m_Name);
#endif
            try
            {
                 NameIdPermission^ operand = ( NameIdPermission^)target;

                // The following check for unrestricted permission is only included as an example for
                // permissions that allow the unrestricted state. It is of no value for this permission.
                if (true == operand->m_Unrestricted)
                {
                    return true;
                }
                else if (true == this->m_Unrestricted)
                {
                    return false;
                }

                if (this->m_Name != nullptr)
                {
                    if (operand->m_Name == nullptr) return false;

                    if (this->m_Name == "") return true;
                }

                if (this->m_Name->Equals (operand->m_Name)) return true;
                else
                {
                    // Check for wild card character '*'.
                    int i = operand->m_Name->LastIndexOf("*");

                    if (i > 0)
                    {
                        String^ prefix = operand->m_Name->Substring(0, i);

                        if (this->m_Name->StartsWith(prefix))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (InvalidCastException^)
            {
                throw gcnew ArgumentException(String::Format ("Argument_WrongType", this->GetType()->FullName));
            }
        }

        virtual IPermission^ Intersect(IPermission^ target) override
        {
            Console::WriteLine ("************* Entering Intersect *********************");
            if (target == nullptr)
            {
                return nullptr;
            }
#ifdef debug
            Console::WriteLine ("This is = " + (( NameIdPermission^)this)->Name);
            Console::WriteLine ("Target is " + (( NameIdPermission^)target)->m_Name);
#endif
            if (!VerifyType(target))
            {
                throw gcnew ArgumentException( String::Format("Argument is wrong type.", this->GetType()->FullName));
            }

             NameIdPermission^ operand = (NameIdPermission ^)target;

            if (operand->IsSubsetOf (this)) return operand->Copy ();
            else if (this->IsSubsetOf (operand)) return this->Copy ();
            else
                return nullptr;
        }

        virtual IPermission^ Union(IPermission^ target) override
        {
#ifdef debug
            Console::WriteLine ("************* Entering Union *********************");
#endif
            if (target == nullptr)
            {
                return this;
            }
#ifdef debug
            Console::WriteLine ("This is = " + (( NameIdPermission^)this)->Name);
            Console::WriteLine ("Target is " + (( NameIdPermission^)target)->m_Name);
#endif
            if (!VerifyType(target))
            {
                throw gcnew ArgumentException(String::Format ("Argument_WrongType", this->GetType()->FullName));
            }

             NameIdPermission^ operand = (NameIdPermission^)target;

            if (operand->IsSubsetOf(this)) return this->Copy();
            else if (this->IsSubsetOf(operand)) return operand->Copy();
            else
                return nullptr;
        }

       virtual void FromXml(SecurityElement^ e) override
        {
            // The following code for unrestricted permission is only included as an example for
            // permissions that allow the unrestricted state. It is of no value for this permission.
            String^ elUnrestricted = e->Attribute("Unrestricted");
            if (nullptr != elUnrestricted)
            {
                m_Unrestricted = bool::Parse(elUnrestricted);
                return;
            }

            String^ elName = e->Attribute( "Name" );
            m_Name = elName == nullptr ? nullptr : elName;
        }

        virtual SecurityElement^ ToXml() override
        {
            // Use the SecurityElement class to encode the permission to XML.
            SecurityElement^ esd = gcnew SecurityElement("IPermission");
            String^ name = NameIdPermission::GetType()->AssemblyQualifiedName;
            esd->AddAttribute("class", name);
            esd->AddAttribute("version", "1.0");

            // The following code for unrestricted permission is only included as an example for
            // permissions that allow the unrestricted state. It is of no value for this permission.
            if (m_Unrestricted)
            {
                esd->AddAttribute("Unrestricted", bool::TrueString);
            }
            if (m_Name != nullptr) esd->AddAttribute( "Name", m_Name );
            return esd;
        }

     };
}
