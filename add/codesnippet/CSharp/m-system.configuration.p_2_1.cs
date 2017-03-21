                // Determine if the Validator can validate
                // the type it contains.
                valBase = customValAttr.ValidatorInstance;
                if (valBase.CanValidate(resultTimeSpan.GetType()))
                {
                    // Validate the TimeSpan using a
                    // custom PositiveTimeSpanValidator.
                    valBase.Validate(resultTimeSpan);
                }