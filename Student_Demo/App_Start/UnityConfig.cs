using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Student_Demo.IServices;
using Student_Demo.Service;

namespace Student_Demo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IStudent,StudentRepo>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}