using RoyalVilla.Core.Contracts.Common;
using RoyalVilla.Core.Entities.Villas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Core.Contracts.Villas;

public interface IVillaRepository : IBaseRepository<Villa>
{
    Task<Villa> UpdateAsync(Villa entity);
}
