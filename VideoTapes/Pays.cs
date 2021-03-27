namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pays
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pays()
        {
            Provinces = new HashSet<Provinces>();
            Villes = new HashSet<Villes>();
        }

        [Key]
        public int Code_Pays { get; set; }

        [StringLength(255)]
        public string Nom_Pays { get; set; }

        [StringLength(255)]
        public string Zone { get; set; }

        [StringLength(255)]
        public string Devise { get; set; }

        [StringLength(255)]
        public string Drapeau { get; set; }

        [Column("Code Nic")]
        [StringLength(255)]
        public string Code_Nic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Provinces> Provinces { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Villes> Villes { get; set; }
    }
}
