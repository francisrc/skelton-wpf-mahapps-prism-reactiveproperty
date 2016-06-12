using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skelton.WpfMahAppsPrismReactiveProperty.Models
{
    public class Company
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}