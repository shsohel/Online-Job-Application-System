using JobMvcApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMvcApi.Models.Repository
{
 public   interface IRepository <TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(Object Id);
        TEntity AddMe(TEntity model);
        List<TEntity> AddRange(List<TEntity> models);
        TEntity Update( TEntity model);
        List<TEntity> UpdateRange(List<TEntity> models);
        TEntity Delete(Object Id);
        List<TEntity> DeleteRange(List<TEntity> models);
       
    }
}

