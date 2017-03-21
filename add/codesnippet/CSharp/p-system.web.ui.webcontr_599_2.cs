public class MovieLibrary
{
    string[] _availableGenres = { "Comedy", "Drama", "Romance" };

    public MovieLibrary()
    {
    }

    public string[] AvailableGenres
    {
        get
        {
            return _availableGenres;
        }
    }
}