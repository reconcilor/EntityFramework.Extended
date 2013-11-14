using System;
using System.Linq;
using NUnit.Framework;
using EntityFramework.Extensions;
using Tracker.SqlServer.Entities;

namespace Tracker.SqlServer.Test
{
    [TestFixture]
    public class BatchObjectContext
    {
        [Test]
        public void Delete()
        {
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            int count = db.Users.Delete(u => u.EmailAddress.EndsWith(emailDomain));
        }

        [Test]
        public void DeleteWithExpressionContainingNullParameter()
        {
            // This test verifies that the delete is processed correctly when the where expression uses a parameter with a null parameter
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            string optionalComparisonString = null;

            int count = db.Users.Delete(u => u.EmailAddress.EndsWith(emailDomain) && (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString));
        }

        [Test]
        public void DeleteWhereWithExpressionContainingNullParameter()
        {
            // This test verifies that the delete is processed correctly when the where expression uses a parameter with a null parameter
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            string optionalComparisonString = null; 
            
            int count = db.Users
                .Where(u => (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString) && u.EmailAddress.EndsWith(emailDomain))
                .Delete();
        }

        [Test]
        public void Update()
        {
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            int count = db.Users.Update(
                u => u.EmailAddress.EndsWith(emailDomain),
                u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }

        [Test]
        public void UpdateWithExpressionContainingNullParameter()
        {
            // This test verifies that the update is interpreted correctly when the where expression uses a parameter with a null parameter
            var db = new TrackerEntities();
            string emailDomain = "@test.com";
            string optionalComparisonString = null;

            int count = db.Users.Update(
                u => u.EmailAddress.EndsWith(emailDomain) && (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString),
                u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }
    }
}
