namespace ESD_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [Display(Name ="Code")]
        public int CommentId { get; set; }

        [Column("Comment")]
        [Display(Name ="Comment Content")]
        public string Comment1 { get; set; }

        [Display(Name ="Date Send")]
        public DateTime? DateOfComment { get; set; }

        public int? UserId { get; set; }

        public int? PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
