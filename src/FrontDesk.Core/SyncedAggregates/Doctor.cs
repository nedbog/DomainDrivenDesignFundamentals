using SharedKernel.Interfaces;
using SharedKernel;

namespace FrontDesk.Core.SyncedAggregates;

public class Doctor : BaseEntity<int>, IAggregateRoot
{
    public Doctor(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Doctor() // EF required
    { }

    public string Name { get; private set; }

    public override string ToString()
    {
        return Name.ToString();
    }
}