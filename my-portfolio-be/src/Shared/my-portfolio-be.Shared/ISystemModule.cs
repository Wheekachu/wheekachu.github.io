using Autofac;

namespace my_portfolio_be.Shared;

public interface ISystemModule
{
    void Load(ContainerBuilder builder);
}
