namespace command.Common.Interfaces
{
    public interface ICommand
    {
        public bool CanExecute();
        public void Execute();
        public void Undo();
    }
}
