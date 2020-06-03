using Microsoft.EntityFrameworkCore;
using MOS_Management.API.Models;
using MOS_Management.Models.TypeDonnées.Complexes.Complexes_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_Management.API.RepositoryInterface
{
    public class AgenceRepository : IAgenceRepository
    {
        private readonly MOS_Communes_DbContext mos_Communes_DbContext;

        public AgenceRepository(MOS_Communes_DbContext c)
        {
            this.mos_Communes_DbContext = c;
        }

        public async Task<IEnumerable<Agence>> GetAgences()
        {
            return await mos_Communes_DbContext.Agences.ToListAsync();
        }

        public async Task<Agence> GetAgence(string id)
        {
            return await mos_Communes_DbContext.Agences.FirstOrDefaultAsync(e => e.AgenceId == id);
        }

        public async Task<Agence> DeleteAgence(Agence a)
        {
            var result = await mos_Communes_DbContext.Agences.FirstOrDefaultAsync(e => e.AgenceId == a.AgenceId);
            if (result != null)
            {
                mos_Communes_DbContext.Remove(result);
                await mos_Communes_DbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }


        public async Task<Agence> UpdateAgence(Agence a)
        {
            var result = await mos_Communes_DbContext.Agences.FirstOrDefaultAsync(e => e.AgenceId == a.AgenceId);
            if (result != null)
            {
                result.Acronyme = a.Acronyme;
                result.Label = a.Label;
                await mos_Communes_DbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<Agence> AddAgence(Agence a)
        {
            var result = await mos_Communes_DbContext.Agences.AddAsync(a);
            await mos_Communes_DbContext.SaveChangesAsync();
            return result.Entity;
        }

        public List<Agence> GetAgences_()
        {
            return  mos_Communes_DbContext.Agences.ToList();
        }

        public Agence GetAgence_(string id)
        {
            return mos_Communes_DbContext.Agences.FirstOrDefault(e => e.AgenceId == id);
        }

        public Agence UpdateAgence_(Agence a)
        {
            var result = mos_Communes_DbContext.Agences.FirstOrDefault(e => e.AgenceId == a.AgenceId);
            if (result != null)
            {
                result.Acronyme = a.Acronyme;
                result.Label = a.Label;
                mos_Communes_DbContext.SaveChanges();
                return result;
            }
            return result;
        }

        public Agence DeleteAgence_(Agence a)
        {
            var result = mos_Communes_DbContext.Agences.FirstOrDefault(e => e.AgenceId == a.AgenceId);
            if (result != null)
            {
                mos_Communes_DbContext.Remove(result);
                mos_Communes_DbContext.SaveChanges();
                return result;
            }
            return result;
        }

        public Agence AddAgence_(Agence a)
        {
            var result = mos_Communes_DbContext.Agences.Add(a);
            mos_Communes_DbContext.SaveChanges();
            return result.Entity;
        }
    }
}
