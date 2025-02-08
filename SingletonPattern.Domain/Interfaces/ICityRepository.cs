using SingletonPattern.Domain.Entities;

namespace SingletonPattern.Domain.Interfaces
{
    public interface ICityRepository 
    {
        IEnumerable<City> GetAll();
        City GetById(int id);
        int Add(City entity);
        int Update(City entity);
        int Delete(int id);
        List<City> GetStatesByCountry(int stateId);
    }
}
