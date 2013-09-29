using EntityFramework.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.SqlCompact.Entities;

#if NET4
namespace Tracker.SqlCompact.EF6.NET4.Tests
#elif NET45
namespace Tracker.SqlCompact.EF6.NET45.Tests
#elif NET451
namespace Tracker.SqlCompact.EF6.NET451.Tests
#endif
{
    /// <summary>
    /// Summary description for MappingObjectContext
    /// </summary>
    [TestClass]
    public class MappingObjectContext
    {
        [TestMethod]
        [Ignore]
        public void GetEntityMap()
        {
            var db = new TrackerEntities();
            var metadata = db.MetadataWorkspace;

            var map = db.Tasks.GetEntityMap<Task>();

        }

    }


}
