using System.Threading;

namespace DesignPattern_Creational.Services.Singleton;

public sealed class CounterService : ICounterService
{
    private int _value;
    public Guid InstanceId { get; } = Guid.NewGuid();

    public int Value => _value;

    public void Increment()
    {
        Interlocked.Increment(ref _value);
    }

    public void Reset()
    {
        Interlocked.Exchange(ref _value, 0);
    }
}