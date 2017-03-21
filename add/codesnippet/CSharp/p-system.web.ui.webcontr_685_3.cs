public class CustomerLogic
{

    public List<Customer> GetSubsetOfEmployees(int startRows, int maxRows)
    {
        NorthwindDataContext ndc = new NorthwindDataContext();
        var customerQuery = 
            from c in ndc.Customers
            select c;

        return customerQuery.Skip(startRows).Take(maxRows).ToList<Customer>();
    }

    public int GetEmployeeCount()
    {
        object cachedCount = HttpRuntime.Cache["TotalEmployeeCount"];
        if (cachedCount != null)
        {
            return int.Parse(cachedCount.ToString());
        }
        else
        {
            NorthwindDataContext ndc = new NorthwindDataContext();
            var totalNumberQuery =
                from c in ndc.Customers
                select c;
            
            int employeeCount = totalNumberQuery.Count();
            HttpRuntime.Cache.Add("TotalEmployeeCount", employeeCount, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            return employeeCount;
        }
    }
}