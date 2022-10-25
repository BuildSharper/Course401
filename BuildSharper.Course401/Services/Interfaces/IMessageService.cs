namespace BuildSharper.Course401.Services.Interfaces
{
    public interface IMessageService
    {
        string Name { get; }
        void Send(string message);
    }
}
