using Microsoft.EntityFrameworkCore;
using MOS_Management.API.Models;
using MOS_Management.Models.TypeDonnées.Complexes.Complexes_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public class NomenclatureRepository:INomenclatureRepository
    {
        private readonly MOS_Communes_DbContext mos_Communes_DbContext;

        public NomenclatureRepository(MOS_Communes_DbContext c)
        {
            this.mos_Communes_DbContext = c;
        }

        public async Task<IEnumerable<Nomenclature>> GetNomenclatures()
        {
            return await mos_Communes_DbContext.Nomenclatures.ToListAsync();
        }

        public async Task<Nomenclature> GetNomenclature(string id)
        {
            return await mos_Communes_DbContext.Nomenclatures.FirstOrDefaultAsync(e => e.NomenclatureId == id);
        }

        public async Task<Nomenclature> DeleteNomenclature(Nomenclature a)
        {
            var result = await mos_Communes_DbContext.Nomenclatures.FirstOrDefaultAsync(e => e.NomenclatureId == a.NomenclatureId);
            if (result != null)
            {
                mos_Communes_DbContext.Remove(result);
                await mos_Communes_DbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }


        public async Task<Nomenclature> UpdateNomenclature(Nomenclature a)
        {
            var result = await mos_Communes_DbContext.Nomenclatures.FirstOrDefaultAsync(e => e.NomenclatureId == a.NomenclatureId);
            if (result != null)
            {
                result.Nom = a.Nom;
                result.Version = a.Version;
                result.Uri = a.Uri;
                await mos_Communes_DbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<Nomenclature> AddNomenclature(Nomenclature a)
        {
            var result = await mos_Communes_DbContext.Nomenclatures.AddAsync(a);
            await mos_Communes_DbContext.SaveChangesAsync();
            return result.Entity;
        }

        public List<Nomenclature> GetNomenclatures_()
        {
            return mos_Communes_DbContext.Nomenclatures.ToList();
        }

        public Nomenclature GetNomenclature_(string id)
        {
            return mos_Communes_DbContext.Nomenclatures.FirstOrDefault(e => e.NomenclatureId == id);
        }

        public Nomenclature UpdateNomenclature_(Nomenclature a)
        {
            var result = mos_Communes_DbContext.Nomenclatures.FirstOrDefault(e => e.NomenclatureId == a.NomenclatureId);
            if (result != null)
            {
                result.Nom = a.Nom;
                result.Version = a.Version;
                result.Uri = a.Uri;
                mos_Communes_DbContext.SaveChanges();
                return result;
            }
            return result;
        }

        public Nomenclature DeleteNomenclature_(Nomenclature a)
        {
            var result = mos_Communes_DbContext.Nomenclatures.FirstOrDefault(e => e.NomenclatureId == a.NomenclatureId);
            if (result != null)
            {
                mos_Communes_DbContext.Remove(result);
                mos_Communes_DbContext.SaveChanges();
                return result;
            }
            return result;
        }

        public Nomenclature AddNomenclature_(Nomenclature a)
        {
            var result = mos_Communes_DbContext.Nomenclatures.Add(a);
            mos_Communes_DbContext.SaveChanges();
            return result.Entity;
        }
       
    }
}
