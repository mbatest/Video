namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shots
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shots()
        {
            Présence = new HashSet<Présence>();
            SequenceScene = new HashSet<SequenceScene>();
        }

        [Key]
        public int Code_Sequence { get; set; }

        public int? Code_Bande { get; set; }

        public int? Number { get; set; }

        public int? StartFrame { get; set; }

        public int? EndFrame { get; set; }

        public DateTime? DateShot { get; set; }

        [StringLength(15)]
        public string Codec { get; set; }

        public int? FrameCount { get; set; }

        public int? Code_Lieu { get; set; }

        [StringLength(255)]
        public string Commentaire { get; set; }

        [StringLength(255)]
        public string Fichier { get; set; }

        public int? Hauteur { get; set; }

        public int? Largeur { get; set; }
        public string FichierImage { get; set; }
        public byte[] Image { get; set; }

        public virtual Lieux Lieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Présence> Présence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SequenceScene> SequenceScene { get; set; }

        public virtual Videos Videos { get; set; }
    }
}
