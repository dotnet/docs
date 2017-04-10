// Types:System.Security.IPermission Vendor:Richter
// Types:System.Security.ISecurityEncodable Vendor:Richter
//<snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Reflection;

// Enumerated type for permission states.
[Serializable]
public enum class SoundPermissionState
{
    NoSound = 0,
    PlaySystemSounds = 1,
    PlayAnySound = 2
};

// Derive from CodeAccessPermission to gain implementations of the following
// sealed IStackWalk methods: Assert, Demand, Deny, and PermitOnly.
// Implement the following abstract IPermission methods: 
// Copy, Intersect, and IsSubSetOf.
// Implementing the Union method of the IPermission class is optional.
// Implement the following abstract ISecurityEncodable methods: 
// FromXml and ToXml.
// Making the class 'sealed' is optional.

public ref class SoundPermission sealed : public CodeAccessPermission, 
    public IPermission, public IUnrestrictedPermission, 
    public ISecurityEncodable, public ICloneable
{
private:
    bool specifiedAsUnrestricted;
private:
    SoundPermissionState stateFlags;

    // This constructor creates and initializes 
    // a permission with generic access.
public:
    SoundPermission(PermissionState^ state)
    {
        specifiedAsUnrestricted = (state == PermissionState::Unrestricted);
    }

    // This constructor creates and initializes 
    // a permission with specific access.
public:
    SoundPermission(SoundPermissionState flags)
    {
        if (flags < SoundPermissionState::NoSound ||
            flags > SoundPermissionState::PlayAnySound)
        {
            throw gcnew ArgumentException("The value of \"flags\" is not" +
                " valid for the SoundPermissionState enumerated type");
        }
        stateFlags = flags;
    }

    // For debugging, return the state of this object as XML.
public:
    virtual String^ ToString() override
    {
        return ToXml()->ToString();
    }

    // Private method to cast (if possible) an IPermission to the type.
private:
    SoundPermission^ VerifyTypeMatch(IPermission^ target)
    {
        if (GetType() != target->GetType())
        {
            throw gcnew ArgumentException(String::Format(
                "The variable \"target\" must be of the {0} type",
                GetType()->FullName));
        }
        return (SoundPermission^) target;
    }

    // This is the Private Clone helper method.
private:
    SoundPermission^ Clone(bool specifiedAsUnrestricted, 
        SoundPermissionState flags)
    {
        SoundPermission^ soundPerm = (SoundPermission^) Clone();
        soundPerm->specifiedAsUnrestricted = specifiedAsUnrestricted;
        soundPerm->stateFlags = specifiedAsUnrestricted ? 
            SoundPermissionState::PlayAnySound : flags;
        return soundPerm;
    }

    #pragma region IPermission^ Members
    //<snippet2>
    // Return a new object that contains the intersection 
    // of 'this' and 'target'.
public:
    virtual IPermission^ Intersect(IPermission^ target) override
    {
        // If 'target' is null, return null.
        if (target == nullptr)
        {
            return nullptr;
        }

        // Both objects must be the same type.
        SoundPermission^ soundPerm = VerifyTypeMatch(target);

        // If 'this' and 'target' are unrestricted, 
        // return a new unrestricted permission.
        if (specifiedAsUnrestricted && soundPerm->specifiedAsUnrestricted)
        {
            return Clone(true, SoundPermissionState::PlayAnySound);
        }

        // Calculate the intersected permissions. 
        // If there are none, return null.
        SoundPermissionState minimumPermission = (SoundPermissionState)
            Math::Min((int) stateFlags, (int) soundPerm->stateFlags);
        if ((int)minimumPermission == 0)
        {
            return nullptr;
        }

        // Return a new object with the intersected permission value.
        return Clone(false, minimumPermission);
    }
    //</snippet2>

    //<snippet3>
    // Called by the Demand method: returns true 
    // if 'this' is a subset of 'target'.
public:
    virtual bool IsSubsetOf(IPermission^ target) override
    {
        // If 'target' is null and this permission allows nothing, 
        // return true.
        if (target == nullptr)
        {
            return (int)stateFlags == 0;
        }

        // Both objects must be the same type.
        SoundPermission^ soundPerm = VerifyTypeMatch(target);

        // Return true if the permissions of 'this' 
        // is a subset of 'target'.
        return stateFlags <= soundPerm->stateFlags;
    }
    //</snippet3>

    //<snippet4>
    // Return a new object that matches 'this' object's permissions.
public:
    virtual IPermission^ Copy () override sealed
    {
        return (IPermission^) Clone();
    }
    //</snippet4>

    //<snippet5>
    // Return a new object that contains the union of 'this' and 'target'.
    // Note: You do not have to implement this method. 
    // If you do not, the version
    // in CodeAccessPermission does this:
    //    1. If target is not null, a NotSupportedException is thrown.
    //    2. If target is null, then Copy is called and 
    //       the new object is returned.
public:
    virtual IPermission^ Union(IPermission^ target) override
    {
        // If 'target' is null, then return a copy of 'this'.
        if (target == nullptr)
        {
            return Copy();
        }

        // Both objects must be the same type.
        SoundPermission^ soundPerm = VerifyTypeMatch(target);

        // If 'this' or 'target' are unrestricted, 
        // return a new unrestricted permission.
        if (specifiedAsUnrestricted || soundPerm->specifiedAsUnrestricted)
        {
            return Clone(true, SoundPermissionState::PlayAnySound);
        }

        // Return a new object with the calculated, unioned permission value.
        return Clone(false, (SoundPermissionState)
            Math::Max((int) stateFlags, (int) soundPerm->stateFlags));
    }
    //</snippet5>
    #pragma endregion

    #pragma region ISecurityEncodable^ Members
    //<snippet6>
    // Populate the permission's fields from XML.
public:
    virtual void FromXml(SecurityElement^ element) override
    {
        specifiedAsUnrestricted = false;
        stateFlags = (SoundPermissionState)0;

        // If XML indicates an unrestricted permission, 
        // make this permission unrestricted.
        String^ attributeString = 
            (String^) element->Attributes["Unrestricted"];
        if (attributeString != nullptr)
        {
            specifiedAsUnrestricted = Convert::ToBoolean(attributeString);
            if (specifiedAsUnrestricted)
            {
                stateFlags = SoundPermissionState::PlayAnySound;
            }
        }

        // If XML indicates a restricted permission, parse the flags.
        if (!specifiedAsUnrestricted)
        {
            attributeString = (String^) element->Attributes["Flags"];
            if (attributeString != nullptr)
            {
                stateFlags = (SoundPermissionState) Convert::ToInt32(
                    Enum::Parse(SoundPermissionState::typeid, 
                    attributeString, true));
            }
        }
    }
    //</snippet6>

    //<snippet7>
    // Produce XML from the permission's fields.
public:
    virtual SecurityElement^ ToXml() override
    {
        // These first three lines create an element with the required format.
        SecurityElement^ element = gcnew SecurityElement("IPermission");
        // Replace the double quotation marks () 
        // with single quotation marks ()
        // to remain XML compliant when the culture is not neutral.
        element->AddAttribute("class", 
            GetType()->AssemblyQualifiedName->Replace('\"', '\''));
        element->AddAttribute("version", "1");

        if (!specifiedAsUnrestricted)
        {
            element->AddAttribute("Flags", 
                Enum::Format(SoundPermissionState::typeid, stateFlags, "G"));
        }   
        else
        {
            element->AddAttribute("Unrestricted", "true");
        }
        return element;
    }
    //</snippet7>
    #pragma endregion

    #pragma region IUnrestrictedPermission^ Members
    //<snippet8>
    // Returns true if permission is effectively unrestricted.
public:
    virtual bool IsUnrestricted()
    {
        // This means that the object is unrestricted at runtime.
        return stateFlags == SoundPermissionState::PlayAnySound;
    }
    //</snippet8>
    #pragma endregion

    #pragma region ICloneable^ Members

    // Return a copy of the permission.
public:
    virtual Object^ Clone()
    {
        return MemberwiseClone();
    }

    #pragma endregion
};
//</snippet1>
