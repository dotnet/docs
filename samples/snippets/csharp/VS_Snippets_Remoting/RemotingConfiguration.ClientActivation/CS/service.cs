// <Snippet3>
using System;

public class HelloServiceClass : MarshalByRefObject {

    static int n_instance;

    public HelloServiceClass() {
        n_instance++;
        Console.WriteLine(this.GetType().Name + " has been created.  Instance # = {0}", n_instance);
    }


    ~HelloServiceClass() {
        Console.WriteLine("Destroyed instance {0} of HelloServiceClass.", n_instance);
        n_instance --;
    }


    public String HelloMethod(String name) {

        // Reports that the method was called.
        Console.WriteLine();
        Console.WriteLine("Called HelloMethod on instance {0} with the '{1}' parameter.", 
                             n_instance, name);

        // Calculates and returns the result to the client.
        return "Hi there " + name + ".";
    }
}
// </Snippet3>