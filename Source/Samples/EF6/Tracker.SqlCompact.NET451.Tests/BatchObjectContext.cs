using System;
using EntityFramework.Extensions;
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
    [TestClass]
    public class BatchObjectContext
    {
        [TestMethod]
        [Ignore]
        public void Delete()
        {
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            int count = db.Users.Delete(u => u.Email.Contains(emailDomain));
        }

        [TestMethod]
        [Ignore]
        public void Update()
        {
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            int count = db.Users.Update(
                u => u.Email.Contains(emailDomain),
                u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }
    }
}
