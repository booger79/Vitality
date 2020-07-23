using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Repositories
{
    public class EmployeeTest
    {
        [TestMethod]
        public void AddEmployeeTest()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(new Data.Entities.VitalityDatabase());
            Employee employee = new Employee();
            employee.FirstName = "Aybars";
            Assert.IsTrue(employeeRepository.Insert(employee));
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(new Data.Entities.VitalityDatabase());
            var employeeList = employeeRepository.GetAll();

            if (employeeList.Count > 0)
            {
                Employee employee = employeeList.First();
                employee.FirstName = "Kaan";
                Assert.IsTrue(employeeRepository.Update(employee));
            }

        }

        [TestMethod]
        public void DeleteCollegeTest()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(new Data.Entities.VitalityDatabase());
            var employeeList = employeeRepository.GetAll();

            if (employeeList.Count > 0)
            {
                Employee employee = employeeList.First();
                Assert.IsTrue(employeeRepository.Delete(employee));
            }


        }
    }
}
