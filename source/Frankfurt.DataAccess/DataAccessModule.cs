using Autofac;
using Frankfurt.DataAccess.Repository;

namespace Frankfurt.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces();
            builder.RegisterType<AccountRepository>().AsImplementedInterfaces();
        }
    }
}
