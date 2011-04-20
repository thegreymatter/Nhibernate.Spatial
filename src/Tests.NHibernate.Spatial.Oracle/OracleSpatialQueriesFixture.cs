using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using Tests.NHibernate.Spatial.RandomGeometries;

namespace Tests.NHibernate.Spatial
{
    [TestFixture]
    public class OracleSpatialQueriesFixture : SpatialQueriesFixture
    {

        protected override void Configure(Configuration configuration)
        {
            TestConfiguration.Configure(configuration);
        }

        protected override string SqlLineStringFilter(string filterString)
        {
            throw new NotImplementedException();
        }

        protected override string SqlPolygonFilter(string filterString)
        {
            throw new NotImplementedException();
        }

        protected override string SqlMultiLineStringFilter(string filterString)
        {
            throw new NotImplementedException();
        }

        protected override string SqlOvelapsLineString(string filterString)
        {
            throw new NotImplementedException();
        }

        protected override string SqlIntersectsLineString(string filterString)
        {
            throw new NotImplementedException();
        }

        protected override ISQLQuery SqlIsEmptyLineString(ISession session)
        {
            throw new NotImplementedException();
        }

        protected override ISQLQuery SqlIsSimpleLineString(ISession session)
        {
            throw new NotImplementedException();
        }

        protected override ISQLQuery SqlAsBinaryLineString(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
