using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using BAL;
namespace API
{
    public static class ConfigIOC
    {
        public static IContainer Container { get; set; }

        public static void ConfigureIOC()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ScheduleIoC>().As<ScheduleIoC>();
            Container = builder.Build();
        }

        public static T GetInstance<T>(){
            return Container.Resolve<T>();
        }

        public static T GetInstance<T>(object entity)
        {
            return Container.Resolve<T>(new NamedParameter("entity",entity));
        }

    }

}