namespace codigonaveia.services.cursos.Repositories.Base
{
    public interface IBaseRepository<T> where T: class
    {
        Task insert(T entity);  
        Task update(int Id,T entity);
        Task delete(int Id);
        Task<IEnumerable<T>> getall();
        Task<T> GetById(int Id);

    }
}
