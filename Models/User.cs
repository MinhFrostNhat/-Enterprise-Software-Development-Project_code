namespace ESD_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            AcademicYear = new HashSet<AcademicYear>();
            Comment = new HashSet<Comment>();
            Chart = new HashSet<Chart>();
            Post = new HashSet<Post>();
            Topic = new HashSet<Topic>();
        }
        [Display(Name = "User Code")]
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="This field can't be blank.")]
        [StringLength(100, ErrorMessage = "The character lenght can't be more than 100.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The character lenght can't be more than 100.")]
        [EmailAddress(ErrorMessage = "Please enter the valid email.")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The character lenght can't be more than 50.")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The character lenght can't be more than 50.")]
        public string Password { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage ="Please enter the valid phone number")]
        public int? Phone { get; set; }

        [StringLength(200, ErrorMessage = "The character lenght can't be more than 200.")]
        public string Address { get; set; }

        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string GroupId { get; set; }

        public int? MajorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AcademicYear> AcademicYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chart> Chart { get; set; }

        public virtual GroupMember GroupMember { get; set; }

        public virtual Major Major { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topic { get; set; }
    }
}
