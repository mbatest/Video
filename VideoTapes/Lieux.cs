namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lieux
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lieux()
        {
            Scenes = new HashSet<Scenes>();
            Shots = new HashSet<Shots>();
        }

        [Key]
        public int Code_Lieu { get; set; }

        [StringLength(50)]
        public string Lieu { get; set; }

        public int? Code_Ville { get; set; }

        [StringLength(100)]
        public string CommentaireLieu { get; set; }

        [StringLength(50)]
        public string Latitude { get; set; }

        [StringLength(50)]
        public string Longitude { get; set; }

        [StringLength(50)]
        public string Altitude { get; set; }

        public virtual Villes Villes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Scenes> Scenes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shots> Shots { get; set; }
    }
}
