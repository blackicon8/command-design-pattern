using command.Common.Models;
using System;

namespace command.Common.DataStores
{
    public class BagsDataStore
    {
        public static IList<Bag> Bags { get; set; } = new List<Bag>()
        {
            new Bag()
            {
                Id = 1,
                Name = "Backpack"
            }
        };
    }
}
