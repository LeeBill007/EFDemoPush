namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class BaseRepository<T> where T : class, new()
    {
        private BaseDbContext _dbContext { get; set; }
        private DbSet<T> _dbSet { get; set; }

        public BaseRepository()
        {
            _dbContext = new BaseDbContext();
            _dbSet = _dbContext.Set<T>();
        }
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="whereLambda">查詢條件</param>
        /// <returns></returns>
        public List<T> Get(Expression<Func<T, bool>> whereLambda) => _dbSet.Where(whereLambda).ToList();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">要新增的Model</param>
        public void Add(T model) => _dbSet.Add(model);
        /// <summary>
        /// 單一條件刪除
        /// </summary>
        /// <param name="model">要刪除的Model</param>
        public void Delete(T model)
        {
            _dbSet.Attach(model);
            _dbSet.Remove(model);
        }
        /// <summary>
        /// 多筆刪除
        /// </summary>
        /// <param name="whereLambda">刪除條件</param>
        public void DeleteRange(Expression<Func<T, bool>> whereLambda) => _dbSet.RemoveRange(_dbSet.Where(whereLambda));
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">要修改的Model</param>
        /// <param name="proNames">要修改的欄位名稱</param>
        public void Edit(T model, params string[] proNames)
        {
            var entry = _dbContext.Entry(model);
            entry.State = EntityState.Unchanged;

            foreach (var prop in proNames)
            {
                entry.Property(prop).IsModified = true;
            }
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
