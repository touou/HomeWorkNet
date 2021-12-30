using System.ComponentModel.DataAnnotations;

namespace Hw10IQueryable.Models
{
    public class ExpressionModel
    {
        [Key]
        public string Expression { get; set; }
        [Required]
        public int Value { get; set; }
    }
}