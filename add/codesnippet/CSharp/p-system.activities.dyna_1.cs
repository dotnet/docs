            // Variables
            var iterationVariable = new DelegateInArgument<int>() { Name = "iterationVariable" };
            var accumulator = new Variable<int>() { Default = 0, Name = "accumulator" };

            // Define the Input and Output arguments that the DynamicActivity binds to
            var numbers = new InArgument<List<int>>();
            var average = new OutArgument<double>();
            
            var result = new Variable<double>() { Name = "result" };

            return new DynamicActivity()
            {
                DisplayName = "Find average",
                Properties = 
                {
                    // Input argument
                    new DynamicActivityProperty
                    {
                        Name = "Numbers",
                        Type = typeof(InArgument<List<int>>),
                        Value = numbers
                    },
                    // Output argument
                    new DynamicActivityProperty
                    {
                        Name = "Average",
                        Type = typeof(OutArgument<double>),
                        Value = average
                    }
                },
                Implementation = () =>
                    new Sequence
                    {
                        Variables = { result, accumulator },
                        Activities =
                        {
                            new ForEach<int>
                            {
                                Values =  new ArgumentValue<IEnumerable<int>> { ArgumentName = "Numbers" },                                
                                Body = new ActivityAction<int>
                                {
                                    Argument = iterationVariable,
                                    Handler = new Assign<int>
                                    {
                                        To = accumulator,
                                        Value = new InArgument<int>(env => iterationVariable.Get(env) +  accumulator.Get(env))
                                    }
                                }
                            },

                            // Calculate the average and assign to the output argument.
                            new Assign<double>
                            {
                                To = new ArgumentReference<double> { ArgumentName = "Average" },
                                Value = new InArgument<double>(env => accumulator.Get(env) / numbers.Get(env).Count<int>())
                            },
                        }
                    }