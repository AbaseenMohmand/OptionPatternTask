using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace OptionPatternTask.Models
{
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        [ValidateNever]
        public virtual List<Student>? Students { get; set; }
    }
}
