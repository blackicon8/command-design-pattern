using command.Common.Interfaces;
using command.Common.Structures;

namespace command.Common.Services
{
    public class CommandManager
    {
        // Note: Dropout stack limits the number of undo/redo steps.
        private DropoutStack<ICommand> _undoCommands;
        private DropoutStack<ICommand> _redoCommands;

        public CommandManager(int undoSteps)
        {
            _undoCommands = new DropoutStack<ICommand>(undoSteps);
            _redoCommands = new DropoutStack<ICommand>(undoSteps);
        }

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                _undoCommands.Push(command);
                command.Execute();
            }
        }

        public void Undo()
        {
            if (_undoCommands.Count > 0)
            {
                var command = _undoCommands.Pop();
                command.Undo();
                _redoCommands.Push(command);
            }
        }

        public void Redo()
        {
            if (_redoCommands.Count > 0)
            {
                var command = _redoCommands.Pop();
                Invoke(command);
            }
        }

        public void Undo(int steps)
        {
            if (_undoCommands.Count - steps >= 0)
            {
                for (int i = 1; i <= steps; i++)
                {
                    var command = _undoCommands.Pop();
                    command.Undo();
                    _redoCommands.Push(command);
                }
            }
        }

        public void Redo(int steps)
        {
            if (_redoCommands.Count - steps > 0)
            {
                for (int i = 1; i <= steps; i++)
                {
                    var command = _redoCommands.Pop();
                    Invoke(command);
                }
            }
        }

        public void UndoAll()
        {
            if (_undoCommands.Count > 0)
            {
                while (_undoCommands.Count > 0)
                {
                    var command = _undoCommands.Pop();
                    command.Undo();
                    _redoCommands.Push(command);
                }
            }
        }

        public void RedoAll()
        {
            if (_redoCommands.Count > 0)
            {
                while (_redoCommands.Count > 0)
                {
                    var command = _redoCommands.Pop();
                    Invoke(command);
                }
            }
        }
    }
}
