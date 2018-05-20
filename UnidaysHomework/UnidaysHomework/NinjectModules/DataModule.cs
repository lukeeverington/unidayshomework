using Ninject.Modules;
using UnidaysHomework.Data;

namespace UnidaysHomework.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserStore>().To<UserStore>();
        }
    }
}
