using command.Common.Interfaces;
using command.Common.Models;
using command.Common.Services;

namespace command.Commands
{
    internal class DeletePackingListItemCommand : ICommand
    {
        private readonly PackingListItem _packingListItem;
        private readonly PackingListItemRepository _packingListItemRepository;

        public DeletePackingListItemCommand(PackingListItem packingListItem, PackingListItemRepository packingListItemRepository)
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
            Console.WriteLine($"{ _packingListItem.Name } has been removed from the list.");
            _packingListItemRepository.Delete(_packingListItem.Id);
        }

        public void Undo()
        {
            Console.WriteLine($"Removal of { _packingListItem.Name.ToLower() } has been undone.");
            _packingListItemRepository.Create(_packingListItem);
        }
    }
}
