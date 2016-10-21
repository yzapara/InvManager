using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.DataAccess
{
    [Table("property")]
    public class Property
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("datatype_id")]
        public int DatatypeId { get; set; }

        [ForeignKey("DatatypeId")]
        public virtual Datatype Datatype { get; set; }
    }
}
