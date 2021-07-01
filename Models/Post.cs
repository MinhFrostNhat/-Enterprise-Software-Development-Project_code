namespace ESD_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comment = new HashSet<Comment>();
            Chart = new HashSet<Chart>();
        }

        [Key]
        [Display(Name ="Post Code")]
        public int PostId { get; set; }

        [Display(Name="Post Title")]
        [StringLength(50, ErrorMessage = "The character lenght can't be more than 50.")]
        public string Name { get; set; }

        public string Desciption { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(500)]
        public string File { get; set; }

        [Display(Name ="Date of Submission")]
        [DataType(DataType.Date)]
        public DateTime? DateOfSubmission { get; set; }

        public int? UserId { get; set; }

        public int? MajorId { get; set; }

        public int? TopicId { get; set; }

        public int? AcademicYearId { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chart> Chart { get; set; }

        public virtual Major Major { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual User User { get; set; }
    }
}
