using MOS_Management.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public class UriRepository :IUriRepository
    {
        private readonly MOS_Communes_DbContext mos_Communes_DbContext;

        public UriRepository(MOS_Communes_DbContext c)
        {
            this.mos_Communes_DbContext = c;
        }
    }
}
