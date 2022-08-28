using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaPaycoreBootcampHW3.Model
{
  
    public class Container
    {
        [Required]
        public virtual System.Int64 Id { get; set; }

        [StringLength(maximumLength: 50)]
        [Required]
        public virtual string ContainerName { get; set; }

        [Required]
        public virtual double Latitude { get; set; }

        [Required]
        public virtual double Longitude { get; set; }

        [Required]
        public virtual System.Int64 VehicleId { get; set; }
    }
}
