        // Implements the IWebEventCustomEvaluator.CanFire 
        // method. It is called by the ASP.NET if this custom
        // type is configured in the profile
        // element of the healthMonitoring section.
        public bool CanFire(
            System.Web.Management.WebBaseEvent e, 
            RuleFiringRecord rule)
        {

            bool fireEvent;
            string lastFired = rule.LastFired.ToString();
            string timesRaised = rule.TimesRaised.ToString();

            // Fire every other event raised.
            fireEvent =
                (rule.TimesRaised % 2 == 0) ? true : false;

            if (fireEvent)
            {
                firingRecordInfo =
                    string.Format("Event last fired: {0}",
                    lastFired) +
                    string.Format(". Times raised: {0}",
                    timesRaised);
            }
            else
                firingRecordInfo =
                  string.Format(
                   "Event not fired. Times raised: {0}",
                   timesRaised);

            return fireEvent;

        }