using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateApplicationMVC.Models
{
    public class StartNHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            //configuration.AddAssembly("NHibernateApplicationMVC");
            var configurationPath = HttpContext.Current.Server.MapPath
            (@"~/NhibernateConfiguration/Nhibernate.Configuration.xml");
            configuration.Configure(configurationPath);
            var employeeConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~/NhibernateConfiguration/EmployeeDetails.Mapping.hbm.xml");
            configuration.AddFile(employeeConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}