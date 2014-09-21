using System;
using System.Linq;
using System.Linq.Expressions;
using Employee.Core;
using Should;

namespace Employee.Tests
{
    public class PersistenceTest : UnitTest
    {
        protected void SaveAndSelect<TObject>(TObject entity, Expression<Func<TObject, bool>> findExpression ) where TObject : class
        {
            using (var context = new EmployeeContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Set<TObject>().Add(entity);
                    context.SaveChanges();
                    var singleQueried = context.Set<TObject>().Single(findExpression);
                    Compare(entity, singleQueried).ShouldEqual(0);
                    transaction.Rollback();
                }
            }
        }
    }
}
