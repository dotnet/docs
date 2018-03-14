// Counter.cs
// <snippet0>
using System;

public class Counter : MarshalByRefObject {

  private int count = 0;

  public int Count { get {
    return(count++);
  } }

}
// </snippet0>
