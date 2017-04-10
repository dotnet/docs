//C:\_ricka08\code\DD\Walk\DataType\App_Code\Customer.cs
// C:\sdtree\Orcas\Web.NET\System.ComponentModel.DataAnnotations2

// <snippet1>
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

[MetadataType(typeof(CustomerMetaData))]
public partial class Customer {
}

public class CustomerMetaData {

    [ScaffoldColumn(false)]
    public object PasswordHash { get; set; }

    [ScaffoldColumn(false)]
    public object PasswordSalt { get; set; }

    [DataTypeAttribute(DataType.Date)]
    public object ModifiedDate { get; set; }

    [DataTypeAttribute(DataType.EmailAddress)]
    public object EmailAddress { get; set; }

    [DataTypeAttribute(DataType.Url)]
    public object SalesPerson { get; set; }

    [DisplayName("Last")]
    [DataTypeAttribute("BoldRed")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", 
        ErrorMessage = "Characters are not allowed.")]

    public object LastName { get; set; }
} 
// </snippet1>



/*
 *     [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\S]*$",

//Alias      Meaning Equivalent Character Class 
\d Matches a digit [0-9] 
\D Matches a non-digit [^0-9] 
\w Matches a word character, alphanumeric [a-zA-Z0-9] 
\W Matches a non-word character, non-alphanumeric    [^a-zA-Z0-9] 
\s Matches a whitespace character [ \t\r\n\f] 
\S Matches a non-whitespace character [^ \t\r\n\f] 

*/