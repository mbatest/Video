namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Videos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Videos()
        {
            Scenes = new HashSet<Scenes>();
            Shots = new HashSet<Shots>();
        }
        [Key]
        public int Code_Bande { get; set; }
        public int Ordre { get; set; }
        [StringLength(50)]
        public string Titre { get; set; }
        [StringLength(10)]
        public string Codec { get; set; }
        [StringLength(50)]
        public string Periode { get; set; }
        [StringLength(255)]
        public string Commentaire { get; set; }
        public int? Largeur { get; set; }
        public int? Hauteur { get; set; }
        public int? NombreShots { get; set; }
        public int? NombreScènes { get; set; }
        public int? NombreFrames { get; set; }
        [StringLength(255)]
        public string Directory { get; set; }
        [StringLength(255)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Scenes> Scenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shots> Shots { get; set; }
    }
}
