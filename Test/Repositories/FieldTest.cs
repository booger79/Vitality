using System;
using System.Linq;
using Data.Entities;
using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Repositories
{
    [TestClass]
    public class FieldTest
    {
        [TestMethod]
        public void AddFieldTest()
        {
            FieldRepository fieldRepository = new FieldRepository(new Data.Entities.VitalityDatabase());
            Field field = new Field();
            field.Name = "Deniz";
            Assert.IsTrue(fieldRepository.Insert(field));
        }


        [TestMethod]
        public void UpdateFieldTest()
        {
            FieldRepository fieldRepository = new FieldRepository(new Data.Entities.VitalityDatabase());
            var fieldList =fieldRepository.GetAll();
           
            if (fieldList.Count>0)
            {
                Field field1 = fieldList.First();
                field1.Name = "DokuzEylül";
                Assert.IsTrue(fieldRepository.Update(field1));
            }

           
        }

        [TestMethod]
        public void DeleteFieldTest()
        {
            FieldRepository fieldRepository = new FieldRepository(new Data.Entities.VitalityDatabase());
            var fieldList = fieldRepository.GetAll();

            if (fieldList.Count > 0)
            {
                Field field1 = fieldList.First();
                Assert.IsTrue(fieldRepository.Delete(field1));
            }


        }
    }
}
