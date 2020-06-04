using Microsoft.EntityFrameworkCore;
using MOS_Management.API.Models;
using MOS_Management.Models.TypeDonnées.Complexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public class CodeRepository :ICodeRepository
    {
        private readonly MOS_Communes_DbContext mos_Communes_DbContext;

        public CodeRepository(MOS_Communes_DbContext c)
        {
            this.mos_Communes_DbContext = c;
        }

        public async Task<IEnumerable<Code>> GetCodes()
        {
            return await mos_Communes_DbContext.Codes.ToListAsync();
        }

        public async Task<Code> GetCode(string id)
        {
            return await mos_Communes_DbContext.Codes.FirstOrDefaultAsync(e => e.CodeId == id);
        }

        public List<Code> GetCodes_(string nomenclatureId)
        {
            throw new NotImplementedException();
        }

        public async Task<Code> DeleteCode(Code a)
        {
            var result = await mos_Communes_DbContext.Codes.FirstOrDefaultAsync(e => e.CodeId == a.CodeId);
            if (result != null)
            {
                mos_Communes_DbContext.Remove(result);
                await mos_Communes_DbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }


        public async Task<Code> UpdateCode(Code a)
        {
            var result = await mos_Communes_DbContext.Codes.FirstOrDefaultAsync(e => e.CodeId == a.CodeId);
            if (result != null)
            {
                result.Affichage = a.Affichage;
                //result.Langue = a.Langue;
                result.CodeId = a.CodeId;
                result.NomenclatureId = a.NomenclatureId;
                await mos_Communes_DbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<Code> AddCode(Code a)
        {
            var result = await mos_Communes_DbContext.Codes.AddAsync(a);
            await mos_Communes_DbContext.SaveChangesAsync();
            return result.Entity;
        }

        public List<Code> GetCodes_()
        {
            return mos_Communes_DbContext.Codes.ToList();
        }

        public Task<IEnumerable<Code>> GetCodes(string nomenclatureId)
        {
            throw new NotImplementedException();
        }

        public Code GetCode_(string id)
        {
            return mos_Communes_DbContext.Codes.FirstOrDefault(e => e.CodeId == id);
        }

        public Code UpdateCode_(Code a)
        {
            var result = mos_Communes_DbContext.Codes.FirstOrDefault(e => e.CodeId == a.CodeId);
            if (result != null)
            {
                result.Affichage = a.Affichage;
                //result.Langue = a.Langue;
                result.CodeId = a.CodeId;
                result.NomenclatureId = a.NomenclatureId;
                mos_Communes_DbContext.SaveChanges();
                return result;
            }
            return result;
        }

        public Code DeleteCode_(Code a)
        {
            var result = mos_Communes_DbContext.Codes.FirstOrDefault(e => e.CodeId == a.CodeId);
            if (result != null)
            {
                mos_Communes_DbContext.Remove(result);
                mos_Communes_DbContext.SaveChanges();
                return result;
            }
            return result;
        }

        public Code AddCode_(Code a)
        {
            var result = mos_Communes_DbContext.Codes.Add(a);
            mos_Communes_DbContext.SaveChanges();
            return result.Entity;
        }
        
     
    }
}
