﻿using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DbSet<T> entities;
        private VitalityDatabase _vitalityDatabase;

        public Repository(VitalityDatabase vitalityDatabase)
        {
            _vitalityDatabase = vitalityDatabase;
            entities = _vitalityDatabase.Set<T>();
        }

        public int Commit()
        {
          return _vitalityDatabase.SaveChanges();
        }

        public bool Delete(T entity)
        {
            entities.Remove(entity);
            Commit();
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            this.entities.RemoveRange(entities);
            Commit();
            return true;
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(Guid id)
        {
            return entities.Find(id);
        }

        public bool Insert(T entity)
        {
            this.entities.Add(entity);
            Commit();
            return true;

        }

        public bool Insert(IEnumerable<T> entities)
        {
            this.entities.AddRange(entities);
            Commit();
            return true;
        }

        public bool Update(T entity)
        {
            _vitalityDatabase.Entry(entity).State = EntityState.Modified;  
            Commit();
            return true;
        }

        public bool Update(IEnumerable<T> entities)
        {
            _vitalityDatabase.Entry(entities).State = EntityState.Modified;
            Commit();
            return true;
        }
    }
}
