using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PatriciaEdgarAndDonEdgar.Datahandler
{
    public class DatahandlerContext : DbContext
    {
        public DatahandlerContext()
            : base("DefaultConnection")
        {
        }
    }
}