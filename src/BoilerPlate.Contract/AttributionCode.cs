using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoilerPlate.Contract
{
    [Table("AttributionCode", Schema = "Entity")]
    public class AttributionCode
    {
        [Key]
        public int ID { get; set; }
    }
}