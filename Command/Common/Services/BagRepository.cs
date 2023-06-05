using command.Common.DataStores;
using command.Common.Models;

namespace command.Common.Services
{
    public class BagRepository
    {
        public Bag GetById(int id)
        {
            return BagsDataStore.Bags.Where(i => i.Id == id).FirstOrDefault();
        }
    }
}
