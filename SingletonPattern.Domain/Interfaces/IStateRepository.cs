using SingletonPattern.Domain.Entities;

namespace SingletonPattern.Domain.Interfaces
{
    public interface IStateRepository 
    {
        IEnumerable<State> GetAll();
        State GetById(int id);
        int Add(State entity);
        int Update(State entity);
        int Delete(int id);
        List<State> GetStatesByCountry(int countryId);
    }
}
