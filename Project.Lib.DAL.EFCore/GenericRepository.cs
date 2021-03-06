﻿using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Project.Lib.DAL.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Lib.DAL.EFCore
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ProjectDbContext _dbContext;


        public GenericRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        private DbSet<T> DbSet
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }


        public virtual SaveResult<T> Add(T entity)
        {
            var output = new SaveResult<T>()
            {                                       // MEU
                IsSuccess = true                    // MEU
            };

            if (entity.Id != default)
                throw new Exception("la entidad ya tiene id");

            entity.Id = Guid.NewGuid();
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            output.IsSuccess = true;
            output.Entity = entity;

            return output;
        }

        public T Find(Guid id)   //Funciona OK !!
        {

            return _dbContext.Set<T>().Find(id); 

        }

        public IQueryable<T> QueryAll()
        {
            return DbSet.AsQueryable();
        }




        public virtual SaveResult<T> Update(T entity)   //Actualizado meu. Funciona OK
        {
            var output = new SaveResult<T>();

            if (entity.Id == default(Guid))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede actualizar una entidad sin Id");
            }

            if (entity.Id != default(Guid) && !DbSet.Any(x => x.Id == entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No existe una entity con ese id");
            }

            if (output.IsSuccess || DbSetContainsKey(entity.Id))
            {

                _dbContext.Set<T>().Update(entity);  
                _dbContext.SaveChanges();
                output.IsSuccess = true;  
            }

            return output;
        }



        public virtual SaveResult<T> Delete(T entity)   //MEU Funciona OK
        {
            var output = new SaveResult<T>()
            {
                IsSuccess = true
            };

            
            if (DbSetContainsKey(entity.Id))   //Meu Funciona OK
            {
                _dbContext.Set<T>().Remove(entity); 
                _dbContext.SaveChanges();

                
                output.IsSuccess = true;
            }

            else
            {
                output.IsSuccess = false;
            }

            return output;
        }

        public bool DbSetContainsKey(Guid id)  //Meu funciona OK
        {
            if (DbSet.Any(x => x.Id == id))  
                return true;
            else
                return false;
        }
    }
}
