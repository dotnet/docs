using Microsoft.Extensions.VectorData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorDataAI
{
    internal class CloudService
    {
        [VectorStoreRecordKey]
        public int Key { get; set; }

        [VectorStoreRecordData]
        public string Name { get; set; }

        [VectorStoreRecordData]
        public string Description { get; set; }

        [VectorStoreRecordVector(384, DistanceFunction.CosineSimilarity)]
        public ReadOnlyMemory<float> Vector { get; set; }
    }
}
