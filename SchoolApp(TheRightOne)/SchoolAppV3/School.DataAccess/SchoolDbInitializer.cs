using School.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseIfModelChanges{School.DataAccess.SchoolContext}" />
    public class SchoolDBInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {

        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(SchoolContext context)
        {
            base.Seed(context);
        }
    }

}
