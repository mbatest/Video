namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Scenes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Scenes()
        {
            KeywordScene = new HashSet<KeywordScene>();
            SequenceScene = new HashSet<SequenceScene>();
        }

        [Key]
        public int Code_Scene { get; set; }

        public int? Code_Bande { get; set; }

        public int? StartFrame { get; set; }

        public int? EndFrame { get; set; }

        public DateTime? DateDebut { get; set; }

        [StringLength(250)]
        public string Commentaire { get; set; }
        [StringLength(50)]
        public string Titre { get; set; }

        public int? Code_Lieu { get; set; }

        public int? NbSequences { get; set; }

        public byte[] Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KeywordScene> KeywordScene { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrésenceScène> PrésenceScène { get; set; }


        public virtual Lieux Lieux { get; set; }

        public virtual Videos Videos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SequenceScene> SequenceScene { get; set; }
    }
}
