using Clean_Arch___UnitOFWork.Application.Interface;
using System.ComponentModel.DataAnnotations;

namespace Clean_Arch___UnitOFWork.Core.Domain
{
    public class Magazine : IBorrow
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Magazine Name")]
        public string Name { get; set; }

        [Display(Name = "Magazine Description")]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The field Copies must be greater than 0.")]
        public int Copies { get; set; }

        public bool BorrowItem()
        {
            if (this.Copies > 0)
            {
                this.Copies--;
                return true;
            }
            return false;
        }
        public bool ReturnItem()
        {
            this.Copies++;
            return true;
        }
    }
}
