using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.DataAccess
{
    [Table("datatype")]
    public class Datatype
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("dbname")]
        public string DbName { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
