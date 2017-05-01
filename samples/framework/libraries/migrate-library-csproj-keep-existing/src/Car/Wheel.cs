using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Car
{
    public class Wheel
    {
        [JsonIgnore]
        public ConcurrentBag<string> Repairs { get; } = new ConcurrentBag<string>();

        public Wheel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public async Task RepairAsync(string repair)
        {
            Repairs.Add(repair);
            await Task.Delay(TimeSpan.FromMilliseconds(1000));
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
