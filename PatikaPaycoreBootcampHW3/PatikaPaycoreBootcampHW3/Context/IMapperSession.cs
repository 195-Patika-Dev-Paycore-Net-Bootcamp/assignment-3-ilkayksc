using PatikaPaycoreBootcampHW3.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaPaycoreBootcampHW3.Context
{
    public interface IMapperSession
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();

        // Container Class'ının Mapper Metot Tanımları
        void Save(Container entity);
        void Update(Container entity);
        void Delete(Container entity);

        // Vehicle Class'ının Mapper Metot tanımları
        void Save(Vehicle entity);
        void Update(Vehicle entity);
        void Delete(Vehicle entity);

        IQueryable<Container> Containers { get; }
        IQueryable<Vehicle> Vehicles { get; }
    }
}
