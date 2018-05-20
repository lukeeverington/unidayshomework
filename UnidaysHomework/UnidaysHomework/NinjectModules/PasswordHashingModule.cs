using Ninject.Modules;
using UnidaysHomework.PasswordHashing;

namespace UnidaysHomework.NinjectModules
{
    public class PasswordHashingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPasswordHasher>().To<BCryptPasswordHasher>();
        }
    }
}