using RoyalVilla.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Core.Entities.Villas;

public sealed class Villa
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public double Rate { get; set; }
    public int Sqft { get; set; }
    public int Occupancy { get; set; }
    public string ImageUrl { get; set; }
    public string Amenity { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
