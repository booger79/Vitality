using Data.Entities;
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
    public class CollegeTest
    {
        [TestMethod]
        public void UpdateCollegeTest()
        {
            CollegeRepository collegeRepository = new CollegeRepository(new Data.Entities.VitalityDatabase());
            var collegeList = collegeRepository.GetAll();

            if (collegeList.Count > 0)
            {
                College college = collegeList.First();
                college.Name = "DokuzEylül";
                Assert.IsTrue(collegeRepository.Update(college));
            }

        }

        [TestMethod]
        public void InsertCollegeTest()
        {
            CollegeRepository collegeRepository = new CollegeRepository(new Data.Entities.VitalityDatabase());
            College college1 = new College();
            college1.City = "İstanbul";
            Assert.IsTrue(collegeRepository.Update(college1));

        }

        [TestMethod]
        public void DeleteCollegeTest()
        {

            CollegeRepository collegeRepository = new CollegeRepository(new Data.Entities.VitalityDatabase());
            
            var collegeList = collegeRepository.GetAll();
            College college = collegeList.First();
          
            Assert.IsTrue(collegeRepository.Delete(college));

        }

    }
}
