using VContainer;
using VContainer.Unity;

public class MainLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<Pointer>();
        builder.RegisterEntryPoint<Testing>();


    }
}
