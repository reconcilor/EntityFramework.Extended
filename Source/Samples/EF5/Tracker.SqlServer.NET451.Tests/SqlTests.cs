using System.Data.Entity.Infrastructure;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.SqlServer.CodeFirst;

namespace Tracker.SqlServer.EF5.NET451.Tests
{
    [TestClass]
    public class SqlTests
    {
        [TestMethod]
        [Ignore]
        public void SelectByKey()
        {
            var db = new TrackerContext();
            var contextAdapter = db as IObjectContextAdapter;
            var objectContext = contextAdapter.ObjectContext;

            var sql = "SELECT VALUE U.EmailAddress FROM TrackerContext.Users AS U WHERE U.Id = 1";

            var q = objectContext.CreateQuery<object>(sql);
            var list = q.FirstOrDefault();

            list.Should().NotBeNull();


        }
    }
}
