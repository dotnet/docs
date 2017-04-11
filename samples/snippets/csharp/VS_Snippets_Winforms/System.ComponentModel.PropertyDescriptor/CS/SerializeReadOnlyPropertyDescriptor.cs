// <snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.Text;

namespace ReadOnlyPropertyDescriptorTest
{
    // The SerializeReadOnlyPropertyDescriptor shows how to implement a 
    // custom property descriptor. It provides a read-only wrapper 
    // around the specified PropertyDescriptor. 
    internal sealed class SerializeReadOnlyPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor _pd = null;

        public SerializeReadOnlyPropertyDescriptor(PropertyDescriptor pd)
            : base(pd)
        {
            this._pd = pd;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return( AppendAttributeCollection(
                    this._pd.Attributes, 
                    ReadOnlyAttribute.Yes) );
            }
        }

        protected override void FillAttributes(IList attributeList)
        {
            attributeList.Add(ReadOnlyAttribute.Yes);
        }

        public override Type ComponentType
        {
            get
            {
                return this._pd.ComponentType;
            }
        }

        
        // The type converter for this property.
        // A translator can overwrite with its own converter.
        public override TypeConverter Converter
        {
            get
            {
                return this._pd.Converter;
            }
        }

        
        // Returns the property editor 
        // A translator can overwrite with its own editor.
        public override object GetEditor(Type editorBaseType)
        {
            return this._pd.GetEditor(editorBaseType);
        }

        // Specifies the property is read only.
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return this._pd.PropertyType;
            }
        }

        public override bool CanResetValue(object component)
        {
            return this._pd.CanResetValue(component);
        }

     
        public override object GetValue(object component)
        {
            return this._pd.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            this._pd.ResetValue(component);
        }

        public override void SetValue(object component, object val)
        {
            this._pd.SetValue(component, val);
        }

        // Determines whether a value should be serialized.
        public override bool ShouldSerializeValue(object component)
        {
            bool result = this._pd.ShouldSerializeValue(component);

            if (!result)
            {
                DefaultValueAttribute dva = (DefaultValueAttribute)_pd.Attributes[typeof(DefaultValueAttribute)];
                if (dva != null)
                {
                    result = !Object.Equals(this._pd.GetValue(component), dva.Value);
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

        // The following Utility methods create a new AttributeCollection
        // by appending the specified attributes to an existing collection.
        static public AttributeCollection AppendAttributeCollection(
            AttributeCollection existing, 
            params Attribute[] newAttrs)
        {
            return new AttributeCollection(AppendAttributes(existing, newAttrs));
        }

        
        static public Attribute[] AppendAttributes(
            AttributeCollection existing, 
            params Attribute[] newAttrs)
        {
            if (existing == null)
            {
                throw new ArgumentNullException("existing");
            }

            if (newAttrs == null)
            {
                newAttrs = new Attribute[0];
            }

            Attribute[] attributes;

            Attribute[] newArray = new Attribute[existing.Count + newAttrs.Length];
            int actualCount = existing.Count;
            existing.CopyTo(newArray, 0);

            for (int idx = 0; idx < newAttrs.Length; idx++)
            {
                if (newAttrs[idx] == null)
                {
                    throw new ArgumentNullException("newAttrs");
                }

                // Check if this attribute is already in the existing
                // array.  If it is, replace it.
                bool match = false;
                for (int existingIdx = 0; existingIdx < existing.Count; existingIdx++)
                {
                    if (newArray[existingIdx].TypeId.Equals(newAttrs[idx].TypeId))
                    {
                        match = true;
                        newArray[existingIdx] = newAttrs[idx];
                        break;
                    }
                }

                if (!match)
                {
                    newArray[actualCount++] = newAttrs[idx];
                }
            }

            // If some attributes were collapsed, create a new array.
            if (actualCount < newArray.Length)
            {
                attributes = new Attribute[actualCount];
                Array.Copy(newArray, 0, attributes, 0, actualCount);
            }
            else
            {
                attributes = newArray;
            }

            return attributes;
        }
    }
}
// </snippet1>