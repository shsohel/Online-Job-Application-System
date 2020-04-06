using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JobMvcApi.Models.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            this._db = db;
        }
        public TEntity AddMe(TEntity model)
        {
            _db.Set<TEntity>().Add(model);
            _db.SaveChanges();
            return model;
        }

        public List<TEntity> AddRange(List<TEntity> models)
        {
            _db.Set<TEntity>().AddRange(models);
            _db.SaveChanges();
            return models;
        }

        public TEntity Delete(object Id)
        {
            TEntity entity = _db.Set<TEntity>().Find(Id);
            _db.Set<TEntity>().Remove(entity);
            _db.SaveChanges();
            return entity;
        }

        public List<TEntity> DeleteRange(List<TEntity> models)
        {
            _db.Set<TEntity>().RemoveRange(models);
            _db.SaveChanges();
            return models;
        }

        public TEntity Get(object Id)
        {
            return _db.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity model)
        {
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return model;
        }
        public List<TEntity> UpdateRange(List<TEntity> entities)
        {
            _db.Entry(entities).State = EntityState.Modified;
            _db.SaveChanges();
            return entities;
        }
    }
}