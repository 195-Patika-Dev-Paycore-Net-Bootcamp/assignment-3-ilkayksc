using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PatikaPaycoreBootcampHW3.Model;

namespace PatikaPaycoreBootcampHW3.Mapping
{
    public class VehicleMap : ClassMapping<PatikaPaycoreBootcampHW3.Model.Vehicle>
    {    // Vehicle tablosu map işlemleri
        public VehicleMap()
        {   // Primary key olduğu için property yerine id kullanıldı.
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
                x.UnsavedValue(0);
                
            });

            Property(b => b.VehicleName, x =>
            {
                x.Column("vehicleName");
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.VehiclePlate, x =>
            {
                x.Column("vehiclePlate");
                x.Length(14);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            
            Table("Vehicle");
        }
    }
}