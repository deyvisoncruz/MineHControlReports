using MineHControlReports.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MineHControlReports.Dao
{
    public static class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;
        private static Configuration configuration;
        private static HbmMapping mapping;

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                    sessionFactory = Configuration.BuildSessionFactory();

                return sessionFactory;

                
            }
        }

        public static Configuration Configuration
        {
            get
            {
                if (configuration == null)
                    configuration = CreateConfiguration();

                return configuration;
            }
        }

        public static HbmMapping Mapping
        {
            get
            {
                if (mapping == null)
                    mapping = CreateMapping();

                return mapping;
            }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddDeserializedMapping(Mapping, null);

            return configuration;
        }

        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(new List<System.Type> { typeof(kpisMap) });

            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}