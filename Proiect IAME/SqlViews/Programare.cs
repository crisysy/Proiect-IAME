using Proiect_IAME.Models;
using Proiect_IAME.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proiect_IAME.SqlViews
{
    [Table("Programari")]
    public class Programare
    {
        [Key]
        public Guid Id { get; set; }

        public string IdUtilizator { get; set; }

        [ForeignKey("IdUtilizator")]
        public virtual ApplicationUser User { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        public Interval? Interval { get; set; }

        public Serviciu Serviciu { get; set; }
    }
}