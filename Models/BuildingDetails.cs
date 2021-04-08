using System;
using System.Collections.Generic;

namespace buildingapi.Model
{
    public partial class BuildingDetails
    {
        public long Id { get; set; }
        public string InfoKey { get; set; }
        public string Value { get; set; }
        public long? BuildingId { get; set; }

        public virtual Buildings Building { get; set; }
    }
}
