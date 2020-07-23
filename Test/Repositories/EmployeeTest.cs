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
    [TestClass]
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
        [TestMethod]
        public void DeleteListCollegeTest()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(new Data.Entities.VitalityDatabase());
            var employeeList = employeeRepository.GetAll();

            if (employeeList.Count > 0)
            {
                Assert.IsTrue(employeeRepository.Delete(employeeList));
            }


        }

        [TestMethod]
        public void InsertListEmployeeTest()         
        {

            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee();
            Field field = new Field();
            field.Name = "Computer Science";
            College college = new College();
            college.Name = "İstanbul Üniversitesi";


            FieldRepository fieldRepository = new FieldRepository(new VitalityDatabase());
            fieldRepository.Insert(field);

            CollegeRepository collegeRepository = new CollegeRepository(new VitalityDatabase());
            collegeRepository.Insert(college);


            employee.FirstName = "Deniz";
            employee.LastName = "Doğan";
            employee.FieldId = field.Id;
            employee.CollegeId = college.Id;
            employees.Add(employee);
            Employee employee2 = new Employee();
            employee2.CollegeId = college.Id;
            employee2.FieldId = field.Id;
            employee2.FirstName = "Deniz2";
            employee2.LastName = "Doğan2";
            employees.Add(employee2);

            VitalityDatabase vitalityDatabase = new VitalityDatabase();

            EmployeeRepository employeeRepository = new EmployeeRepository(vitalityDatabase);
            Assert.IsTrue(employeeRepository.Insert(employees));


        }


        [TestMethod]
        public void UpdateListEmployeeTest()
        {
           

        }
    }
}
