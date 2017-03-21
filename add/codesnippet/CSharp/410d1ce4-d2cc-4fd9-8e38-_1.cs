            class Package
            {
                public string Company { get; set; }
                public double Weight { get; set; }
            }

            public static void SumEx3()
            {
                List<Package> packages =
                    new List<Package> 
                        { new Package { Company = "Coho Vineyard", Weight = 25.2 },
                          new Package { Company = "Lucerne Publishing", Weight = 18.7 },
                          new Package { Company = "Wingtip Toys", Weight = 6.0 },
                          new Package { Company = "Adventure Works", Weight = 33.8 } };

                // Calculate the sum of all package weights.
                double totalWeight = packages.AsQueryable().Sum(pkg => pkg.Weight);

                Console.WriteLine("The total weight of the packages is: {0}", totalWeight);
            }

            /*
                This code produces the following output:

                The total weight of the packages is: 83.7
            */
