﻿using System.Data.Entity;

namespace Claims.Data.Initializers
{
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {

        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            // initial configuration will go here
        }
    }
}
