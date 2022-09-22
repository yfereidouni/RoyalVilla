﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalVilla.Core.Entities.Common;

namespace RoyalVilla.Core.Entities.Villas;

public class VillaNumber : BaseEntity
{
    //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int VillaNo { get; set; }

    [ForeignKey("Villa")]
    public int VillaId { get; set; }
    public Villa Villa { get; set; }

    public string SpecialDetails { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
