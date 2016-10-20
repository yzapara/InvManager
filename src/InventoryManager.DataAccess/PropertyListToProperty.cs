using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.DataAccess
{
    [Table("property_list_to_property")]
    public class PropertyListToProperty
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("property_id")]
        public int PropertyId { get; set; }

        [Column("property_list_id")]
        public int PropertyListId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }

        [ForeignKey("PropertyListId")]
        public virtual PropertyList PropertyList { get; set; }
    }
}
