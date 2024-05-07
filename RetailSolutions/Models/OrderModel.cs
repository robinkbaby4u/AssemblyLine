using System.ComponentModel.DataAnnotations;

namespace RetailSolutions.Models
{
    public class OrderModel
    {
        [Required]
        [Display(Name ="Customer Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Number of Smaller Items")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int SmallItemCount { get; set; }

        [Required]
        [Display(Name = "Number of  Medium Items")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int MediumItemCount { get; set; }

        [Required]
        [Display(Name = "Number of Large Items")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int LargeItemCount { get; set; }
    }
}
