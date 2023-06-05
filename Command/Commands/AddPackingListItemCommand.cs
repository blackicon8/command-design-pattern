using command.Common.Interfaces;
using command.Common.Models;
using command.Common.Services;

namespace command.Commands
{
    internal class AddPackingListItemCommand : ICommand
    {
        private readonly PackingListItem _packingListItem;
        private readonly PackingListItemRepository _packingListItemRepository;

        public AddPackingListItemCommand(PackingListItem packingListItem, PackingListItemRepository packingListItemRepository)
        {
            _packingListItem = packingListItem;
            _packingListItemRepository = packingListItemRepository;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            Console.WriteLine($"{ _packingListItem.Name } has been added to the list.");
            _packingListItemRepository.Create(_packingListItem);
        }

        public void Undo()
        {
            Console.WriteLine($"Addition of { _packingListItem.Name.ToLower() } has been undone.");
            _packingListItemRepository.Delete(_packingListItem.Id);
        }
    }
}
