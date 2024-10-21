using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {

       [Key]
       public required int Id { get; set; }
       public required string Name { get; set; }
       public int DisplayOrder { get; set; }
    }
}
