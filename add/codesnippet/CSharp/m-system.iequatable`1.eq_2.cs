public class TestIEquatable
{
   public static void Main()
   {
      // Create a Person object for each job applicant.
      Person applicant1 = new Person("Jones", "099-29-4999");
      Person applicant2 = new Person("Jones", "199-29-3999");
      Person applicant3 = new Person("Jones", "299-49-6999");

      // Add applicants to a List object.
      List<Person> applicants = new List<Person>();
      applicants.Add(applicant1);
      applicants.Add(applicant2);
      applicants.Add(applicant3);

       // Create a Person object for the final candidate.
       Person candidate = new Person("Jones", "199-29-3999");
       if (applicants.Contains(candidate))
          Console.WriteLine("Found {0} (SSN {1}).", 
                             candidate.LastName, candidate.SSN);
      else
         Console.WriteLine("Applicant {0} not found.", candidate.SSN);

      // Call the shared inherited Equals(Object, Object) method.
      // It will in turn call the IEquatable(Of T).Equals implementation.
      Console.WriteLine("{0}({1}) already on file: {2}.",  
                        applicant2.LastName, 
                        applicant2.SSN, 
                        Person.Equals(applicant2, candidate)); 
   }
}
// The example displays the following output:
//       Found Jones (SSN 199-29-3999).
//       Jones(199-29-3999) already on file: True.