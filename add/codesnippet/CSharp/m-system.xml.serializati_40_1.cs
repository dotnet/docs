public class Group
{
   // The XmlSerializer ignores this field.
   [XmlIgnore]
   public string Comment;

   // The XmlSerializer serializes this field.
   public string GroupName;
}
   