using Ninject.Modules;
using UniDaysHomework.Services;
using UniDaysHomework.Services.Validation;

namespace UnidaysHomework.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();

            // Validation
            Bind<IModelValidator<CreateUserParameters>>().To<CreateUserValidator>();
            Bind<IEmailAddressValidator>().To<StandardEmailAddressValidator>();
            Bind<IPasswordValidator>().To<StandardPasswordValidator>();
        }
    }
}
