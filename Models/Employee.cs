using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skelton.WpfMahAppsPrismReactiveProperty.Models
{
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        public long CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public bool HasName { get { return !string.IsNullOrEmpty(Name); } }
    }
}