namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SequenceScene")]
    public partial class SequenceScene
    {
        [Key]
        public int Code_Shot_Scene { get; set; }

        public int? Code_Séquence { get; set; }

        public int? Code_Scene { get; set; }

        public virtual Scenes Scenes { get; set; }

        public virtual Shots Shots { get; set; }
    }
}
