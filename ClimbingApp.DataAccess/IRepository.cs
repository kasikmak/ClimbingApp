using ClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.DataAccess;

public interface IRepository<T> where T : EntityBase
{
    IEnumerable<T> GetAll();

    T GetById(int id);

    void Insert(T entity);

    void Update(T entity);

    void Delete(int id);

    /*Task<List<T>> GetAll();

    Task<T> GetById(int id);

    Task Insert(T entity);

    Task Update(T entity);

    Task Delete(int id);*/
}
