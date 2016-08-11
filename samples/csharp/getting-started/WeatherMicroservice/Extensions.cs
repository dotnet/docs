namespace WeatherMicroservice
{
    public static class Extensions
    {
        public static double? TryParse(this string input)
        {
            double result;
            if (double.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                return default(double?);
            }
        }
    }
}