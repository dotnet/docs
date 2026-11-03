namespace AnyKeyExamples;

// <ICache>
public interface ICache
{
    string GetData(string key);
    void SetData(string key, string value);
}
// </ICache>
