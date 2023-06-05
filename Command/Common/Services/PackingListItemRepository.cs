using command.Common.DataStores;
using command.Common.Models;

namespace command.Common.Services
{
    public class PackingListItemRepository
    {
        public void Create(PackingListItem packingListItem)
        {
            PackingListItemsDataStore.PackingListItems.Add(packingListItem);
        }

        public PackingListItem Delete(int id)
        {
            var packingListItem = PackingListItemsDataStore.PackingListItems.First(i => i.Id == id);
            PackingListItemsDataStore.PackingListItems.Remove(packingListItem);
            return packingListItem;
        }
    }
}
