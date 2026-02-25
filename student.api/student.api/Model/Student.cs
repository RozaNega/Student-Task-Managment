using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student.api.Model
{
    [Table("studentMaster")]
    public class Student
    {
        internal object?[]? studentId;

        public int Id { get; set; }
        [Required]
        public string studentName { get; set; }= string.Empty;
        [Required,MaxLength(10)]
        public string mobileNo { get; set; }=string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string pincode { get; set; } = string.Empty;
        public string addressLine1 { get; set; } = string.Empty;
        public string addressLine2 { get; set; } = string.Empty;

    }
}
