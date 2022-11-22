using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfProductDal : IProductDal
	{
		public void Add(Product Entity)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				var addedEntity = context.Entry(Entity);
				addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
				context.SaveChanges();	
			}
		}

		public void Delete(Product Entity)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				var deletedEntity = context.Entry(Entity);
				deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public Product Get(Expression<Func<Product, bool>> filter)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				return context.Set<Product>().SingleOrDefault(filter);
			}
		}

		public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				return filter == null 
					? context.Set<Product>().ToList() 
					: context.Set<Product>().Where(filter).ToList();
			}
		}

		public void Update(Product Entity)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				var updatedEntity = context.Entry(Entity);
				updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
