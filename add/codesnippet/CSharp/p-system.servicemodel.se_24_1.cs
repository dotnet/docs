            WSFederationHttpBinding binding = new WSFederationHttpBinding();
            binding.Security.Message.ClaimTypeRequirements.Add
               (new ClaimTypeRequirement
               ("http://schemas.microsoft.com/ws/2005/05/identity/claims/EmailAddress"));
            binding.Security.Message.ClaimTypeRequirements.Add
               (new ClaimTypeRequirement
               ("http://schemas.microsoft.com/ws/2005/05/identity/claims/UserName", true));
            ClaimTypeRequirement cr = new ClaimTypeRequirement
               ("http://schemas.microsoft.com/ws/2005/05/identity/claims/UserName", true);
            Console.WriteLine(cr.ClaimType);
            Console.WriteLine(cr.IsOptional);