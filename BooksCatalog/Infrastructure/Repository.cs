﻿using System.Data.Entity;
using System.Linq;
using BooksCatalog.Models;

namespace BooksCatalog.Infrastructure
{
    /// <summary>
    /// Provides method for working with entities
    /// </summary>
    public class Repository<T>:IRepository<T> where T: class, IModel
    {
        private BooksContext _context;

        public Repository()
        {
            _context = new BooksContext();
        }

        public Repository(BooksContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Access to models and quering
        /// </summary>
        public IQueryable<T> Entities
        {
            get { return _context.Set<T>(); }
        }

        /// <summary>
        /// Find entity with specific id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insert new entity to DB
        /// </summary>
        /// <param name="entity">new entity</param>
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update existing model
        /// </summary>
        /// <param name="entity">updated entity</param>
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _context.Entry(entity).State= EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}