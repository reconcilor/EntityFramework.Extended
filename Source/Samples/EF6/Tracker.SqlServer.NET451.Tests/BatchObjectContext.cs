using System;
using System.Linq;
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
    public class BatchObjectContext
    {

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            int count = db.Users.Delete(u => u.Email.EndsWith(emailDomain));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DeleteWithExpressionContainingNullParameter()
        {
            // This test verifies that the delete is processed correctly when the where expression uses a parameter with a null parameter
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            string optionalComparisonString = null;


            int count = db.Users.Delete(u => u.Email.EndsWith(emailDomain) && (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DeleteWhereWithExpressionContainingNullParameter()
        {
            // This test verifies that the delete is processed correctly when the where expression uses a parameter with a null parameter
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            string optionalComparisonString = null;

            int count = db.Users
                .Where(u => (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString) && u.Email.EndsWith(emailDomain))
                .Delete();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Update()
        {
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            int count = db.Users.Update(
                u => u.Email.EndsWith(emailDomain),
                u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UpdateWithExpressionContainingNullParameter()
        {
            // This test verifies that the update is interpreted correctly when the where expression uses a parameter with a null parameter
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            string optionalComparisonString = null;


            int count = db.Users.Update(
                u => u.Email.EndsWith(emailDomain) && (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString),
                u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }

    }
}
