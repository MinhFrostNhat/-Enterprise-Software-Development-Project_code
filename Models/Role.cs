namespace ESD_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            GroupMember = new HashSet<GroupMember>();
        }
        [Display(Name ="Role")]
        [StringLength(50 , ErrorMessage = "The character lenght can't be more than 50.")]
        public string RoleId { get; set; }

        [Display(Name ="Role Name")]
        [StringLength(100, ErrorMessage = "The character lenght can't be more than 100.")]
        public string Name { get; set; }

        public string Decription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupMember> GroupMember { get; set; }
    }
}
