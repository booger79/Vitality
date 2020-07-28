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


        [TestMethod]
        public void InsertListCollegeTest()
        {
            List<College> colleges = new List<College>();
            College college = new College();
            college.City = "İstanbul";
            college.Name = "İstanbul Üniversitesi";
            colleges.Add(college);

            College college2 = new College();
            college2.City = "İzmir";
            college2.Name = "Ege Üniversitesi";
            colleges.Add(college2);

            VitalityDatabase vitalityDatabase = new VitalityDatabase();
            CollegeRepository collegeRepository = new CollegeRepository(new VitalityDatabase());


            Assert.IsTrue(collegeRepository.Insert(colleges));


        }

        [TestMethod]
        public void UpdateListCollegeTest()
        {
            List<College> colleges = new List<College>();
            College college = new College();
            College college2 = new College();

            college.Name = "İstanbul Üniversitesi";
            college.City = "İstanbul";

            college2.Name = "Ege Üniversitesi";
            college2.City = "İstanbul";

            colleges.Add(college);
            colleges.Add(college2);

            CollegeRepository collegeRepository = new CollegeRepository(new VitalityDatabase());

            collegeRepository.Insert(colleges);



            foreach (var item in colleges)
            {
                item.City = "İzmir";
            }

            Assert.IsTrue(collegeRepository.Update(colleges));

        }

       /* [TestMethod]
        public void UpdateListCollegeTest()
        {
            CollegeRepository collegeRepository = new CollegeRepository(new VitalityDatabase());
            College college = new College();
            College college2 = new College();
        }*/

        [TestMethod]
        public void DeleteListCollegeTest()
        {
            CollegeRepository collegeRepository = new CollegeRepository(new VitalityDatabase());
            /*College college = new College();
            College college2 = new College();
            colleges.Add(college);
            colleges.Add(college2);*/

            List<College> colleges = new List<College>();
            colleges = collegeRepository.GetAll();
            

            if (colleges.Count > 0)
            {
                Assert.IsTrue(collegeRepository.Delete(colleges));
            }
        }

    }
}
