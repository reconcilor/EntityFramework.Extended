using System.Data.Entity;

namespace Tracker.SqlServer.CodeFirst
{
    public partial class TrackerContext
    {
        protected void InitializeMapping(DbModelBuilder modelBuilder)
        {

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}