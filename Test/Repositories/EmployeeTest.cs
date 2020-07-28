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
        public void InsertEmployeeTest()

        {
           
            CollegeRepository collegeRepository = new CollegeRepository(new VitalityDatabase());
            FieldRepository fieldRepository = new FieldRepository(new VitalityDatabase());
            EmployeeRepository employeeRepository = new EmployeeRepository(new Data.Entities.VitalityDatabase());
           

            Employee employee = new Employee();
            Field field = new Field();
            College college = new College();
            field.Name = "Yazılım";
            college.Name = "İstanbul Üniversitesi";

            employee.FirstName = "Aybars";
            employee.LastName = "Agcabuga";

            fieldRepository.Insert(field);
            collegeRepository.Insert(college);

            employee.FieldId = field.Id;
            employee.CollegeId = college.Id;

            

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
            EmployeeRepository employeeRepository = new EmployeeRepository(new VitalityDatabase());
            Employee employee = new Employee();
            Employee employee2 = new Employee();
            List<Employee> employees = new List<Employee>(); 

            CollegeRepository collegeRepository = new CollegeRepository(new VitalityDatabase());
           
            College college = new College();
            College college2 = new College();
            FieldRepository fieldRepository = new FieldRepository(new VitalityDatabase());
            Field field = new Field();
            Field field2 = new Field();



            employee.FieldId = field.Id;
            employee.CollegeId = college.Id;
            employee.FirstName = "Aybars";
            employee.LastName = "Agcabuga";
            employees.Add(employee);

            employee2.FieldId = field2.Id;
            employee2.CollegeId = college2.Id;
            employee2.FirstName = "Kaan";
            employee2.LastName = "Agcabuga";
            employees.Add(employee2);


            foreach (var item in employees)
            {
                item.LastName = "Ağcabuğa";
            }

            Assert.IsTrue(employeeRepository.Update(employees));

        }

        [TestMethod]
        public void FilterEmployeeTest()
        {


            EmployeeRepository employeeRepository = new EmployeeRepository(new VitalityDatabase());
            CollegeRepository collegeRepository = new CollegeRepository(new VitalityDatabase());
            Employee employee = new Employee();
            College college = new College();
            FieldRepository fieldRepository = new FieldRepository(new VitalityDatabase());
            Field field = new Field();

            field.Name = "Yazılım";

            fieldRepository.Insert(field);


            college.Name = "9 Eylül";
            employee.FirstName = "Aybars";
            employee.LastName = "Agacabuga";

            collegeRepository.Insert(college);
            employee.CollegeId = college.Id;
            employee.FieldId = field.Id;
            
        
            employeeRepository.Insert(employee);

            var fieldList = employeeRepository.GetListByFilter(x => x.College.Name == "9 Eylül").ToList();

           // var name = fieldList[0].College.Name;
         //   Assert.IsTrue(name == "9 Eylül");
        }

    }
}
