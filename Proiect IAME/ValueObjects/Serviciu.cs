using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proiect_IAME.ValueObjects
{
    public enum Serviciu
    {
        [Display(Name = "Tuns - păr lung")]
        TunsLung = 1,
        [Display(Name = "Tuns - păr mediu")]
        TunsMediu = 2,
        [Display(Name = "Tuns - păr scurt")]
        TunsScurt = 3,
        [Display(Name = "Vopsit - păr lung")]
        VopsitLung = 4,
        [Display(Name = "Vopsit - păr mediu")]
        VopsitMediu = 5,
        [Display(Name = "Vopsit - păr scurt")]
        VopsitScurt = 6
    }
}