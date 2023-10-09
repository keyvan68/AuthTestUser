using AuthTestUser.Entities;
using AuthTestUser.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AuthTestUser.Context;
using System.Web;
//using DomainClasses.Constants;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthTestUser.GenericRepository
{

    public class GenericRepository<TEntity, TKey> : IDisposable, IRepository<TEntity, TKey>
        where TEntity : class where TKey : struct
    {
        protected readonly ApplicationDbContext _ApplicatiobContex;
        protected readonly DbSet<TEntity> _dbset;

        public GenericRepository(ApplicationDbContext ApplicatiobContex)
        {
            _ApplicatiobContex = ApplicatiobContex;
            _dbset =_ApplicatiobContex.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public void AddRange(IList<TEntity> entites)
        {
            _dbset.AddRange(entites);

        }

        public void Attach(TEntity entity)
        {
            _dbset.Attach(entity);
        }

        public void Detach(TEntity entity)
        {
            _ApplicatiobContex.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public void Dispose()
        {
            
        }

        public TEntity Find(TKey id)
        {
            return _dbset.Find(id);
        }


        
        public void Remove(TEntity entity)
        {
            _dbset.Attach(entity);

            _dbset.Remove(entity);

        }

        public void Remove(TKey id)
        {
            var obj = _dbset.Find(id);

            Remove(obj);
        }

        public void SetNewValue(TEntity OldEntity, TEntity NewEntity)
        {
            _ApplicatiobContex.Entry(OldEntity).CurrentValues.SetValues(NewEntity);

            //if (NewEntity.GetType() != typeof(Log_tbl))
            //{
            //    LogRepository logRepository = new LogRepository(_ApplicatiobContex);
            //    logRepository.AddLog(NewEntity, Guid.Parse(ConstIDs.Const_EventLogType_Update));
                
            //}

        }

        private object GetSummery(TEntity entity)
        {
            List<Type> L = new List<Type>();
            L.Add(typeof(int));
            L.Add(typeof(string));
            L.Add(typeof(decimal));
            L.Add(typeof(Boolean));


            var members = typeof(TEntity).GetProperties()
                    .Where(x => x.MemberType == MemberTypes.Property)
                    .Where(x =>L.Contains(x.PropertyType));


            //dynamic MyDynamic = new System.Dynamic.ExpandoObject();

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            foreach (var item in members)
            {
                var Value = entity.GetType()
                    .GetProperty(item.Name)
                    .GetValue(entity, null);


                keyValuePairs.Add(item.Name, Convert.ToString(Value));
            }

            return keyValuePairs;
        }

        public void Update(TEntity entity)
        {
            var EntityState = _ApplicatiobContex.Entry(entity).State;


            if (_ApplicatiobContex.Entry(entity).State != Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                _ApplicatiobContex.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


                //if (entity.GetType() != typeof(Log_tbl))
                //{
                //    LogRepository logRepository = new LogRepository(_ApplicatiobContex);
                //    logRepository.AddLog(GetSummery(entity), Guid.Parse(ConstIDs.Const_EventLogType_Update), null);
                //}

            }
        }

        public IQueryable<TEntity> GetAllWithOutCond()
        {
            
            return _dbset;
        }

    }

}
