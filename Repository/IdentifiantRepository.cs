using MOS_Management.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public class IdentifiantRepository
    {
        private readonly MOS_Communes_DbContext mos_Communes_DbContext;

        public IdentifiantRepository(MOS_Communes_DbContext c)
        {
            this.mos_Communes_DbContext = c;
        }
    }
}
