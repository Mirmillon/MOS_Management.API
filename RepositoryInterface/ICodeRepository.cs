using MOS_Management.Models.TypeDonnées.Complexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public interface ICodeRepository
    {
        Task<IEnumerable<Code>> GetCodes();
        Task<IEnumerable<Code>> GetCodes(string nomenclatureId);
        Task<Code> GetCode(string id);
        Task<Code> UpdateCode(Code a);
        Task<Code> DeleteCode(Code a);
        Task<Code> AddCode(Code a);

        List<Code> GetCodes_();
        List<Code> GetCodes_(string nomenclatureId);
        Code GetCode_(string id);
        Code UpdateCode_(Code a);
        Code DeleteCode_(Code a);
        Code AddCode_(Code a);
    }
}
