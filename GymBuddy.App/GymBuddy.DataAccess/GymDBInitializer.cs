using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBuddy.DataAccess
{
    public class GymDBInitializer : DropCreateDatabaseIfModelChanges<GymContext>
    {
        protected override void Seed(GymContext context)
        {
            base.Seed(context);
        }
    }
}
