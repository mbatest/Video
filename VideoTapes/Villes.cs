namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Villes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Villes()
        {
            Lieux = new HashSet<Lieux>();
        }

        [Key]
        public int Code_Ville { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Nom_Chinois { get; set; }

        public int? Code_Province { get; set; }

        public int? Code_Pays { get; set; }

        public int? Code_Departement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lieux> Lieux { get; set; }

        public virtual Pays Pays { get; set; }

        public virtual Provinces Provinces { get; set; }
    }
}
