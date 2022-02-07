using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiPhone.DAL.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        T GetByID(object id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        bool Atualizar(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        bool Adicionar(T entity);
        bool Deletar(T entity);


    }
}
