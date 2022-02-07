using ApiPhone.DAL.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiPhone.DAL.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private IContexto _context;
        DbSet<T> _dbSet;

        public Repositorio(IContexto contexto)
        {
            _context = contexto;
            _dbSet = _context.Set<T>();
        }

        public bool Adicionar(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }

        }

        public bool Atualizar(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
               
                return true;
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }

        public bool Deletar(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }

        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }
            return _dbSet.AsQueryable();
        }

        public T GetByID(object id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
