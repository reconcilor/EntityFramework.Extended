using EntityFramework.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.SqlCompact.Entities;

namespace Tracker.SqlCompact.EF6.NET45.Tests
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
