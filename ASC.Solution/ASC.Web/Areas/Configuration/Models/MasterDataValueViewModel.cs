using System.ComponentModel.DataAnnotations;

namespace ASC.Web.Areas.Configuration.Models
{
    // 7 references
    public class MasterDataValueViewModel
    {
        // 3 references
        public string RowKey { get; set; }
        [Required]
        [Display(Name = "Partition Key")]
        // 2 references
        public string PartitionKey { get; set; }
        // 1 reference
        public bool IsActive { get; set; }
        [Required]
        // 2 references
        public string Name { get; set; }
    }
}