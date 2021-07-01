namespace ESD_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            Post = new HashSet<Post>();
        }

        [Key]
        [Display(Name = "Topic Code")]
        public int TopicId { get; set; }

        [Display(Name = "Topic Name")]
        [StringLength(200, ErrorMessage = "The character lenght can't be more than 200.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name ="Deadline")]
        [DataType(DataType.Date)]
        public DateTime? ClosureDate { get; set; }

        public int? UserId { get; set; }

        public int? MajorId { get; set; }

        public virtual Major Major { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Post { get; set; }

        public virtual User User { get; set; }
    }
}
