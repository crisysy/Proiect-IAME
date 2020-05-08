using Proiect_IAME.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proiect_IAME.SqlViews
{
    [Table("DurateServicii")]
    public class DurateServicii
    {
        [Key]
        public Guid Id { get; set; }

        public Serviciu Serviciu { get; set; }

        public int Ore { get; set; }
    }
}