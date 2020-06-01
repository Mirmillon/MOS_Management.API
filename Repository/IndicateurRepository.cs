using MOS_Management.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public class IndicateurRepository :IIndicateurRepository
    {
        private readonly MOS_Communes_DbContext mos_Communes_DbContext;

        public IndicateurRepository(MOS_Communes_DbContext c)
        {
            this.mos_Communes_DbContext = c;
        }
    }
}
