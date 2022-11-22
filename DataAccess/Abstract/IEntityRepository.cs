using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

	//Generic constraint (generic kısıt)
	//class = referans tip olmak zorunda (int vs. yazamaz)
	//IEntity = T ya IEntity olabilir yada ondan impelemente olan bir şey olabilir.
	//new = new'lenebilir olmalı
	public interface IEntityRepository<T> where T : class,IEntity,new()
	{
		List<T> GetAll(Expression<Func<T,bool>> filter = null);
		T Get(Expression<Func<T,bool>> filter);
		void Add(T Entity);
		void Delete(T Entity);
		void Update(T Entity);

	}
}
