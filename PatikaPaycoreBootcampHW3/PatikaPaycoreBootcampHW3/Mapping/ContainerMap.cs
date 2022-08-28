using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PatikaPaycoreBootcampHW3.Model;

namespace PatikaPaycoreBootcampHW3.Mapping
{
    public class ContainerMap : ClassMapping<Container>
    {   // Container tablosu map işlemleri
        public ContainerMap()
        {   // Primary key olduğu için property yerine id kullanıldı.
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
            });

            Property(b => b.ContainerName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("containerName");
            });
            Property(b => b.Latitude, x =>
            {
                x.Precision(10);
                x.Scale(6);
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
                x.Column("latitude");
            });
            Property(b => b.Longitude, x =>
            {
                x.Precision(10);
                x.Scale(6);
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
                x.Column("longitude");
            });
            Property(b => b.VehicleId, x =>
            {
                x.Length(10);
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
                x.Column("vehicleId");
            });
            
            Table("container");
            
        }
    }
}