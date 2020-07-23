using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>,IEmployeeRepository

    {
        public EmployeeRepository(VitalityDatabase vitalityDatabase) : base(vitalityDatabase)
        {
        }
    }
}
