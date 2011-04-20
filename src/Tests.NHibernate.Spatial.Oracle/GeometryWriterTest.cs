using System;
using System.Collections.Generic;
using System.Text;
using GeoAPI.Geometries;
using GisSharpBlog.NetTopologySuite.Geometries;
using GisSharpBlog.NetTopologySuite.IO;
using NHibernate.Spatial.Type;
using NUnit.Framework;

namespace Tests.NHibernate.Spatial
{
    [TestFixture]
    public class GeometryWriterTest
    {
        [Test]
        public void DeepCopy_Point2D_SamePoint()
        {
            Point expected = new Point(6,7);
            OracleGeometryType OGT = new OracleGeometryType();
            var result = (Point)OGT.DeepCopy(expected);
            Assert.AreEqual(expected,result);
        }

        [Test]
        public void DeepCopy_Point3D_SamePoint()
        {
            Point expected = new Point(6, 7,8);
            OracleGeometryType OGT = new OracleGeometryType();
            var result = (Point)OGT.DeepCopy(expected);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DeepCopy_MultiPoint2D_SamePoint()
        {
            MultiPoint expected = new MultiPoint(new[] { new Point(6, 7), new Point(19, 10) });
            OracleGeometryType OGT = new OracleGeometryType();
            var result = (MultiPoint)OGT.DeepCopy(expected);
            Assert.AreEqual(expected.ToText(), result.ToText());
        }

        [Test]
        public void DeepCopy_MultiPoint3D_SamePoint()
        {
            MultiPoint expected = new MultiPoint(new []{new Point(6, 7, 8),new Point(19,10,11)});
            OracleGeometryType OGT = new OracleGeometryType();
            var result = (MultiPoint)OGT.DeepCopy(expected);
            Assert.AreEqual(expected.ToText(), result.ToText());
        }

        [Test]
        public void DeepCopy_Line2D_SameLine()
        {
            var wktReader = new WKTReader();
            var expected =  wktReader.Read("LINESTRING(3 4,10 50,20 25)");
            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DeepCopy_Line3D_SameLine()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("LINESTRING(3 4 5,10 50 7,20 25 8)");
            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void DeepCopy_MultiLine2D_SameLine()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("MULTILINESTRING((3 4,10 50,20 25),(6 4,1 5,2 2))");
            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [Test]
        public void DeepCopy_MultiLine3D_SameLine()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("MULTILINESTRING((3 4 5,10 50 7,20 25 8),(1 1 5,11 15 7,23 2 8))");
            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [Test]
        public void DeepCopy_SimplePolygon2D_SamePolygon()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("POLYGON((2 2,2 3,3 3,3 2,2 2))");
            OracleGeometryType OGT = new OracleGeometryType();
         
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DeepCopy_ComplexPolygon2D_SamePolygon()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("POLYGON((1 1,5 1,5 5,1 5,1 1),(2 2,2 3,3 3,3 2,2 2))");

            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DeepCopy_SimplePolygon3D_SamePolygon()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("POLYGON ((2 2 5,2 3 5,3 3 5,3 2 5,2 2 5))");
            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DeepCopy_ComplexPolygon3D_SamePolygon()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("POLYGON((1 1 5,5 1 5,5 5 5,1 5 5,1 1 5),(2 2 5,2 3 5,3 3 5,3 2 5,2 2 5))");

            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DeepCopy_SimpleMultiPolygon2D_SamePolygon()
        {
            var wktReader = new WKTReader();
            var expected =
                wktReader.Read("MULTIPOLYGON(((1 1,5 1,5 5,1 5,1 1)),((6 3,9 2,9 4,6 3)))");

            OracleGeometryType OGT = new OracleGeometryType();

            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [Test]
        public void DeepCopy_ComplexMultiPolygon2D_SamePolygon()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("MULTIPOLYGON(((1 1,5 1,5 5,1 5,1 1),(2 2,2 3,3 3,3 2,2 2)),((6 3,9 2,9 4,6 3)))");

            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [Test]
        public void DeepCopy_SimpleMultiPolygon3D_SamePolygon()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("MULTIPOLYGON(((1 1 3,5 1 3,5 5 3,1 5 3,1 1 3)),((6 3 5,9 2 6,9 4 8,6 3 5)))");
            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [Test]
        public void DeepCopy_ComplexMultiPolygon3D_SamePolygon()
        {
            var wktReader = new WKTReader();
            var expected = wktReader.Read("MULTIPOLYGON(((1 1 5,5 1 5,5 5 5,1 5 5,1 1 5),(2 2 5,2 3 5,3 3 5,3 2 5,2 2 5)),((6 3 5,9 2 5,9 4 5,6 3 5)))");

            OracleGeometryType OGT = new OracleGeometryType();
            var result = OGT.DeepCopy(expected);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
    }
}
