using SingletonPattern.Domain.Entities;

namespace SingletonPattern.Domain.Interfaces
{
    public interface ICountryRepository  
    {
        IEnumerable<Country> GetAll();
        Country GetById(int id);
        int Add(Country entity);
        int Update(Country entity);
        int Delete(int id);

    }
}
