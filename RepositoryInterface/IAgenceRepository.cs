using MOS_Management.Models.TypeDonnées.Complexes.Complexes_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public interface IAgenceRepository
    {
        Task<IEnumerable<Agence>> GetAgences();
        Task<Agence> GetAgence(string id);
        Task<Agence> UpdateAgence(Agence a);
        Task<Agence> DeleteAgence(Agence a);
        Task<Agence> AddAgence(Agence a);

        List<Agence> GetAgences_();
        Agence GetAgence_(string id);
        Agence UpdateAgence_(Agence a);
        Agence DeleteAgence_(Agence a);
        Agence AddAgence_(Agence a);
    }
}
