using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.DataAccess
{
    [Table("element_to_property_list")]
    public class ElementToPropertyList
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("element_id")]
        public int ElementId { get; set; }

        [ForeignKey("ElementId")]
        public virtual Element Element { get; set; }

        [Column("property_list_id")]
        public int PropertyListId { get; set; }

        [ForeignKey("PropertyListId")]
        public virtual PropertyList PropertyList { get; set; }
    }
}
