using Microsoft.Practices.Unity;
using UserDemo.App_Data;
using UserDemo.Models;
using UserDemo.Services;

namespace UserDemo.App_Start
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserService, UserService>(new TransientLifetimeManager());
            container.RegisterType<UserContext> (new TransientLifetimeManager());
        }
    }
}