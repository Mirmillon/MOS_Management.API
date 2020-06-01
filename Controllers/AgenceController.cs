using Microsoft.AspNetCore.Mvc;
using MOS_Management.API.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.Controllers
{
    public class AgenceController :Controller
    {
        private readonly IAgenceRepository agenceRepository;

        public AgenceController(IAgenceRepository r)
        {
            this.agenceRepository = r;
        }
    }
}
