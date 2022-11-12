using System.Threading.Tasks;

namespace SharedKernal.DataRepositories
{
    public interface IGenericRepository<TEntity, PrimaryKey> : IInsertRepository<TEntity, PrimaryKey>,
                                                            IUpdatingRepository<TEntity, PrimaryKey>,
                                                            IDeleteRepository<TEntity, PrimaryKey>,
                                                            IRetrievingRepository<TEntity, PrimaryKey>
                                                            where TEntity : class
    {


    }
}