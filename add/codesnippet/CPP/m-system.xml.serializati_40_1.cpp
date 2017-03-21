public ref class Group
{
public:

   // The XmlSerializer ignores this field.

   [XmlIgnore]
   String^ Comment;

   // The XmlSerializer serializes this field.
   String^ GroupName;
};
