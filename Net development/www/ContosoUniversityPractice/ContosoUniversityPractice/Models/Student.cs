using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityPractice.Models
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(60,MinimumLength =3)]
        [Required]
        public string LastName { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirstMidName { get; set; }

        [Display(Name="Enrollment Date")]
        [DataType(DataType.Date)]

        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment>? Enrollments { get;set; }

        public string Email { get; set; }
        public string Name { get { return FirstMidName + ' ' + LastName; } }
    }
}
