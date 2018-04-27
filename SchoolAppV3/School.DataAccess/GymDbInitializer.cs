using School.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{

    public class GymDBInitializer : DropCreateDatabaseIfModelChanges<GymContext>
    {

        protected override void Seed(GymContext context)
        {
            base.Seed(context);
        }
    }

}
