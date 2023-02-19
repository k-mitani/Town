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
        builder.RegisterComponentInHierarchy<DialogsManager>();
        builder.RegisterComponentInHierarchy<ButtonsPanel>();
        builder.RegisterComponentInHierarchy<NotificationPanel>();
        builder.RegisterComponentInHierarchy<TimePanel>();
        builder.RegisterComponentInHierarchy<TimerPanel>();
        builder.RegisterComponentInHierarchy<TopPanel>();
        builder.RegisterComponentInHierarchy<XPPanel>();
        builder.RegisterEntryPoint<Testing>();


    }
}
