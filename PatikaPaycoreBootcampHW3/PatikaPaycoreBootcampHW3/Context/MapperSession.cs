using NHibernate;
using PatikaPaycoreBootcampHW3.Model;
using System.Linq;


namespace PatikaPaycoreBootcampHW3.Context
{
    public class MapperSession : IMapperSession
    {
        private readonly ISession session;
        private ITransaction transaction;

        public MapperSession(ISession session)
        {
            this.session = session;
        }

        public IQueryable<Container> Containers => session.Query<Container>();
        public IQueryable<Vehicle> Vehicles => session.Query<Vehicle>();


        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }
        // Container Class'ının Metotları
        public void Save(Container entity)
        {
            session.Save(entity);
        }
        public void Update(Container entity)
        {
            session.Update(entity);
        }
        public void Delete(Container entity)
        {
            session.Delete(entity);
        }
       

        // Vehicle Class'ınınn Metotları
        public void Save(Vehicle entity)
        {
            session.Save(entity);
        }
        public void Update(Vehicle entity)
        {
            session.Update(entity);
        }
        public void Delete(Vehicle entity)
        {
            session.Delete(entity);
        }
    }
}
