using System.ComponentModel.DataAnnotations;
namespace PatikaPaycoreBootcampHW3.Model
{
    public class Vehicle
    {
        [Required]
        public virtual System.Int64 Id { get; set; }

        [StringLength(maximumLength:50)]
        [Required]
        public virtual string VehicleName { get; set; }

        [StringLength(maximumLength: 10)]
        [Required]
        public virtual string VehiclePlate { get; set; }
    }
}
