using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using NUnit.Framework;
using Tracker.SqlServer.CodeFirst;
using Tracker.SqlServer.CodeFirst.Entities;

namespace Tracker.SqlServer.Test
{
    [TestFixture]
    public class BatchDbContext
    {
        [Test]
        public void Delete()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            int count = db.Users
                .Delete(u => u.EmailAddress.EndsWith(emailDomain));
        }

        [Test]
        public void DeleteWhere()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";

            //var user = db.Users.Select(u => new User { FirstName = u.FirstName, LastName = u.LastName });

            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain))
                .Delete();
        }

        [Test]
        public void DeleteWithExpressionContainingNullParameter()
        {
            // This test verifies that the delete is processed correctly when the where expression uses a parameter with a null parameter
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            string optionalComparisonString = null;

            int count = db.Users
                .Delete(u => u.EmailAddress.EndsWith(emailDomain) && (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString));
        }
        
        [Test]
        public void DeleteWhereWithExpressionContainingNullParameter()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            string optionalComparisonString = null;

            // This test verifies that the delete is processed correctly when the where expression uses a parameter with a null parameter
            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain) && (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString))
                .Delete();
        }

        [Test]
        public void Update()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            int count = db.Users.Update(
                u => u.EmailAddress.EndsWith(emailDomain),
                u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }

        [Test]
        public void UpdateWithExpressionContainingNullParameter()
        {
            // This test verifies that the update is interpreted correctly when the where expression uses a parameter with a null parameter
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            string optionalComparisonString = null;

            int count = db.Users.Update(
                u => u.EmailAddress.EndsWith(emailDomain) && (string.IsNullOrEmpty(optionalComparisonString) || u.AvatarType == optionalComparisonString),
                u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }

        [Test]
        public void UpdateAppend()
        {
            var db = new TrackerContext();

            string emailDomain = "@test.com";
            string newComment = " New Comment";

            int count = db.Users.Update(
                u => u.EmailAddress.EndsWith(emailDomain),
                u => new User { LastName = u.LastName + newComment });
        }

        [Test]
        public void UpdateAppendAndNull()
        {
            var db = new TrackerContext();

            string emailDomain = "@test.com";
            string newComment = " New Comment";

            int count = db.Users.Update(
                u => u.EmailAddress.EndsWith(emailDomain),
                u => new User
                {
                    FirstName = "Test",
                    LastName = u.LastName + newComment,
                    Comment = null
                });
        }

        [Test]
        public void UpdateJoin()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            string space = " ";

            int count = db.Users.Update(
                u => u.EmailAddress.EndsWith(emailDomain),
                u => new User { LastName = u.FirstName + space + u.LastName });
        }

        [Test]
        public void UpdateCopy()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            string space = " ";

            int count = db.Users.Update(
                u => u.EmailAddress.EndsWith(emailDomain),
                u => new User { Comment = u.LastName });
        }

    }

    public class TempUser
    {
        public string Name { get; set; }
    }
}
