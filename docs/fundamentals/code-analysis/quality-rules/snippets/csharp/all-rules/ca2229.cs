using System;
using System.Runtime.Serialization;

namespace ca2229
{
    //<snippet1>
    [Serializable]
    public class SerializationConstructorsRequired : ISerializable
    {
        private int n1;

        // This is a regular constructor.
        public SerializationConstructorsRequired()
        {
            n1 = -1;
        }
        // This is the serialization constructor.
        // Satisfies rule: ImplementSerializationConstructors.

        protected SerializationConstructorsRequired(
           SerializationInfo info,
           StreamingContext context)
        {
            n1 = (info.GetValue(nameof(n1), typeof(int)) != null) ?
                (int)info.GetValue(nameof(n1), typeof(int))! :
                -1;
        }

        // The following method serializes the instance.
        void ISerializable.GetObjectData(SerializationInfo info,
           StreamingContext context)
        {
            info.AddValue(nameof(n1), n1);
        }
    }
    //</snippet1>
}
