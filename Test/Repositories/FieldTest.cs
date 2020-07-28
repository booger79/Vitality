using System;
using System.Collections.Generic;
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
        public void InsertFieldTest()
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

        [TestMethod]
        public void InsertListFieldTest()
        {
             
            List<Field> fields = new List<Field>();
            Field field = new Field();
            Field field2 = new Field();


            field.Name = "Yazılım";
            field2.Name = "Mühendis";

            fields.Add(field);
            fields.Add(field2);

            VitalityDatabase vitalityDatabase = new VitalityDatabase();

            FieldRepository fieldRepository = new FieldRepository(vitalityDatabase);
            Assert.IsTrue(fieldRepository.Insert(fields));

        }

        [TestMethod]
        public void UpdateListFieldTest()
        {
            List<Field> fields = new List<Field>();
            Field field = new Field();
            Field field2 = new Field();
            Field field3 = new Field();

            //field.Name();

        }


        [TestMethod]
        public void FilterFieldTest()
        {

            FieldRepository fieldRepository = new FieldRepository(new Data.Entities.VitalityDatabase());
            Field field = new Field();
            field.Name = "Deniz";
            fieldRepository.Insert(field);
            var fieldList = fieldRepository.GetListByFilter( x => x.Name == "Deniz").ToList();
            Assert.IsTrue(fieldList.Count > 0);
        }

        [TestMethod]
        public void DeleteListFieldTest()
        {

            FieldRepository fieldRepository = new FieldRepository(new VitalityDatabase());
            List<Field> fields = new List<Field>();

            fields = fieldRepository.GetAll();


            if (fields.Count > 0)
            {
                Assert.IsTrue(fieldRepository.Delete(fields));
            }
        }
    }
}
