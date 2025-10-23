namespace DesignPattern_Creational.Services.Singleton;

public interface ICounterService
{
    int Value { get; }
    Guid InstanceId { get; }
    void Increment();
    void Reset();
}