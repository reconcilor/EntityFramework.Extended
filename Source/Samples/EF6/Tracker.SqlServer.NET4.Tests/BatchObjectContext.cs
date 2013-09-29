using System;
using EntityFramework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.SqlServer.Entities;

namespace Tracker.SqlServer.EF6.NET4.Tests
{
    [TestClass]
    public class BatchObjectContext
    {
        [TestMethod]
        public void Delete()
        {
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            int count = db.Users.Delete(u => u.Email.EndsWith(emailDomain));
        }

        [TestMethod]
        public void Update()
        {
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            int count = db.Users.Update(
                u => u.Email.EndsWith(emailDomain),
                u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }
    }
}
