using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.DataAccess
{
    [Table("element")]
    public class Element
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("parent_type_id")]
        public int? ParentTypeId { get; set; }

        [ForeignKey("ParentTypeId")]
        public virtual Element ParentType { get; set; }
    }
}
