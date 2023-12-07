﻿using Common.Entities.Base;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _db;
        private DbSet<T> table;

        public Repository(AppDbContext db)
        {
            _db = db;
            table = _db.Set<T>();
        }
        public async Task Create(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }
    }
}
