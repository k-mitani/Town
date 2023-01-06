using VContainer;
using VContainer.Unity;

public class MainLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<Unit>();
        builder.RegisterComponentInHierarchy<Pointer>();
        builder.RegisterComponentInHierarchy<GameManager>();
        builder.RegisterComponentInHierarchy<UIManager>();
        builder.RegisterEntryPoint<Testing>();


    }
}
