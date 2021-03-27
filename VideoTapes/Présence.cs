namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Présence
    {
        [Key]
        public int Code { get; set; }

        public int? Code_Séquence { get; set; }

        public int? Personne { get; set; }

        public virtual Personne Personne1 { get; set; }

        public virtual Shots Shots { get; set; }
    }
}
