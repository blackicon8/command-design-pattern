using command.Commands;
using command.Common.Models;
using command.Common.Services;

var bagRepository = new BagRepository();
var backpack = bagRepository.GetById(1);

var toothBrush = 
    new PackingListItem()
    {
        Id = 1,
        Name = "Toothbrush",
        Quantity = 1,
        Unit = "piece",
        Bag = backpack
    };

var socks = 
    new PackingListItem()
    {
        Id = 2,
        Name = "Socks",
        Quantity = 4,
        Unit = "pair",
        Bag = backpack
    };

var packingListItemRepository = new PackingListItemRepository();

var addToothBrushToPackingListCommand = 
    new AddPackingListItemCommand(toothBrush, packingListItemRepository);

var addSocksToPackingListCommand =
    new AddPackingListItemCommand(socks, packingListItemRepository);

var deleteSocksFromPackingListCommand = 
    new DeletePackingListItemCommand(socks, packingListItemRepository);

var commandManager = new CommandManager(undoSteps: 3);

commandManager.Invoke(addToothBrushToPackingListCommand);
commandManager.Invoke(addSocksToPackingListCommand);
commandManager.Invoke(deleteSocksFromPackingListCommand);
commandManager.Undo(2);
commandManager.RedoAll();