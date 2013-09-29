using System;
using System.Transactions;
using EntityFramework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.SqlServer.Entities;

#if NET4
namespace Tracker.SqlServer.EF6.NET4.Tests
#elif NET45
namespace Tracker.SqlServer.EF6.NET45.Tests
#elif NET451
namespace Tracker.SqlServer.EF6.NET451.Tests
#endif
{
    [TestClass]
    public class ExtensionTest
    {
        [TestMethod]
        public void BeginTransactionObjectContext()
        {
            using (var db = new TrackerEntities())
            using (var tx = db.BeginTransaction())
            {
                string emailDomain = "@test.com";

                int count = db.Users.Update(
                    u => u.Email.EndsWith(emailDomain),
                    u => new User { IsApproved = false, LastActivityDate = DateTime.Now });

                count = db.Users.Delete(u => u.Email.EndsWith(emailDomain));

                tx.Commit();
            }
        }

        [TestMethod]
        public void NoTransactionObjectContext()
        {
            using (var db = new TrackerEntities())
            {
                string emailDomain = "@test.com";

                int count = db.Users.Update(
                    u => u.Email.EndsWith(emailDomain),
                    u => new User { IsApproved = false, LastActivityDate = DateTime.Now });

                count = db.Users.Delete(u => u.Email.EndsWith(emailDomain));

            }
        }

        [TestMethod]
        public void TransactionScopeObjectContext()
        {
            using (var tx = new TransactionScope())
            using (var db = new TrackerEntities())
            {
                string emailDomain = "@test.com";

                int count = db.Users.Update(
                    u => u.Email.EndsWith(emailDomain),
                    u => new User { IsApproved = false, LastActivityDate = DateTime.Now });

                count = db.Users.Delete(u => u.Email.EndsWith(emailDomain));

                tx.Complete();
            }
        }

    }
}
