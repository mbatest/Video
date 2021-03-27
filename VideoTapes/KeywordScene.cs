namespace VideoTapes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KeywordScene")]
    public partial class KeywordScene
    {
        [Key]
        public int Code { get; set; }
        public int? Code_Keyword { get; set; }
        public int? Code_Scene { get; set; }
        public virtual Keywords Keywords { get; set; }
        public virtual Scenes Scenes { get; set; }
    }
}
