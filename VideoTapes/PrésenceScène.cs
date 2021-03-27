using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoTapes
{
    [Table("PrésenceScène")]
    public partial class PrésenceScène
    {
        [Key]
        public int Code_Présence { get; set; }

        public int? Code { get; set; }

        public int? Code_Scene { get; set; }

        public virtual Personne Personnes { get; set; }

        public virtual Scenes Scenes { get; set; }
    }
}
