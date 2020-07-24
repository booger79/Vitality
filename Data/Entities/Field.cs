using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Field:BaseEntity
    {
        public Field()
        {
            Employees = new List<Employee>();
        }

        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }

    }
}
