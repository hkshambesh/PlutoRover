namespace PlutoRover.Interfaces
{
    public interface ICommandFactory
    {
        ICommandExecute GetCommandHandler(string command);
    }
}