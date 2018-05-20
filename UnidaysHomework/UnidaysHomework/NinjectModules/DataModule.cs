using Ninject.Modules;
using System.Configuration;
using System.Data.SqlClient;
using UnidaysHomework.Data;

namespace UnidaysHomework.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserStore>().To<UserStore>();

            var connectionString = ConfigurationManager.ConnectionStrings["UniDaysDatabase"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Bind<SqlConnection>().ToConstant(sqlConnection).InSingletonScope();
        }
    }
}
