using Observables.Example;

BaggageHandler provider = new();
ArrivalsMonitor observer1 = new("BaggageClaimMonitor1");
ArrivalsMonitor observer2 = new("SecurityExit");

provider.BaggageStatus(712, "Detroit", 3);
observer1.Subscribe(provider);

provider.BaggageStatus(712, "Kalamazoo", 3);
provider.BaggageStatus(400, "New York-Kennedy", 1);
provider.BaggageStatus(712, "Detroit", 3);
observer2.Subscribe(provider);

provider.BaggageStatus(511, "San Francisco", 2);
provider.BaggageStatus(712);
observer2.Unsubscribe();

provider.BaggageStatus(400);
provider.LastBaggageClaimed();

// Sample output:
//   Arrivals information from BaggageClaimMonitor1
//   Detroit                712    3
//   
//   Arrivals information from BaggageClaimMonitor1
//   Detroit                712    3
//   Kalamazoo              712    3
//   
//   Arrivals information from BaggageClaimMonitor1
//   Detroit                712    3
//   Kalamazoo              712    3
//   New York-Kennedy       400    1
//   
//   Arrivals information from SecurityExit
//   Detroit                712    3
//   
//   Arrivals information from SecurityExit
//   Detroit                712    3
//   Kalamazoo              712    3
//   
//   Arrivals information from SecurityExit
//   Detroit                712    3
//   Kalamazoo              712    3
//   New York-Kennedy       400    1
//   
//   Arrivals information from BaggageClaimMonitor1
//   Detroit                712    3
//   Kalamazoo              712    3
//   New York-Kennedy       400    1
//   San Francisco          511    2
//   
//   Arrivals information from SecurityExit
//   Detroit                712    3
//   Kalamazoo              712    3
//   New York-Kennedy       400    1
//   San Francisco          511    2
//   
//   Arrivals information from BaggageClaimMonitor1
//   New York-Kennedy       400    1
//   San Francisco          511    2
//   
//   Arrivals information from SecurityExit
//   New York-Kennedy       400    1
//   San Francisco          511    2
//   
//   Arrivals information from BaggageClaimMonitor1
//   San Francisco          511    2
