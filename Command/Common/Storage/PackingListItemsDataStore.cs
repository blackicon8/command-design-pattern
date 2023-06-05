using command.Common.Models;

namespace command.Common.DataStores
{
    public class PackingListItemsDataStore
    {
        public static IList<PackingListItem> PackingListItems { get; set; } = new List<PackingListItem>();
    }
}
