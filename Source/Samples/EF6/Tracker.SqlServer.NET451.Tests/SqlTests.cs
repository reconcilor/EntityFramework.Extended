using System.Data.Entity.Infrastructure;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.SqlServer.CodeFirst;

#if NET4
namespace Tracker.SqlServer.EF6.NET4.Tests
#elif NET45
namespace Tracker.SqlServer.EF6.NET45.Tests
#elif NET451
namespace Tracker.SqlServer.EF6.NET451.Tests
#endif
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
