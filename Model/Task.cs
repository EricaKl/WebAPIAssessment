using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAssessment.Model
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskStatus { get; set; }
        
        public string TaskDescription { get; set; }

    }
}
