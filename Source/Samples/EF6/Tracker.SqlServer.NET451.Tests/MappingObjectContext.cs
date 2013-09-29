using EntityFramework.Extensions;
using EntityFramework.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.SqlServer.CodeFirst;
using Tracker.SqlServer.CodeFirst.Entities;
using Tracker.SqlServer.Entities;
using Task = Tracker.SqlServer.Entities.Task;

#if NET4
namespace Tracker.SqlServer.EF6.NET4.Tests
#elif NET45
namespace Tracker.SqlServer.EF6.NET45.Tests
#elif NET451
namespace Tracker.SqlServer.EF6.NET451.Tests
#endif
{
    /// <summary>
    /// Summary description for MappingObjectContext
    /// </summary>
    [TestClass]
    public class MappingObjectContext
    {
        [TestMethod]
        public void GetEntityMapTask()
        {
            var db = new TrackerEntities();
            var metadata = db.MetadataWorkspace;

            var map = db.Tasks.GetEntityMap<Task>();

            Assert.AreEqual("[dbo].[Task]", map.TableName);
        }


        [TestMethod]
        public void GetEntityMapAuditData()
        {
            var db = new TrackerContext();

            var map = db.Audits.ToObjectQuery().GetEntityMap<AuditData>();

            Assert.AreEqual("[dbo].[Audit]", map.TableName);
        }

    }


}
