using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class VitalityDatabase : DbContext

    {
        public VitalityDatabase():base("VitalityConnectionString")
        {

        }
        public virtual DbSet<Employee> Employees { get; set;}
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
    }
}
