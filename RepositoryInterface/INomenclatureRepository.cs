using MOS_Management.Models.TypeDonnées.Complexes.Complexes_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public interface INomenclatureRepository
    {
        Task<IEnumerable<Nomenclature>> GetNomenclatures();
        Task<Nomenclature> GetNomenclature(string id);
        Task<Nomenclature> UpdateNomenclature(Nomenclature a);
        Task<Nomenclature> DeleteNomenclature(Nomenclature a);
        Task<Nomenclature> AddNomenclature(Nomenclature a);

        List<Nomenclature> GetNomenclatures_();
        Nomenclature GetNomenclature_(string id);
        Nomenclature UpdateNomenclature_(Nomenclature a);
        Nomenclature DeleteNomenclature_(Nomenclature a);
        Nomenclature AddNomenclature_(Nomenclature a);
    }
}
