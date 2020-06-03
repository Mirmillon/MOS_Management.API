using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOS_Management.API.RepositoryInterface;
using MOS_Management.Models.TypeDonnées.Complexes.Complexes_;
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

        [HttpGet]
        public async Task<ActionResult> GetAgences()
        {
            try
            {
                return Ok(await agenceRepository.GetAgences());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database"); ;
            }
        }

        public  List<Agence> GetAgences_()
        {
            try
            {
                return agenceRepository.GetAgences_();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Agence GetAgence_(string i)
        {
            try
            {
                return agenceRepository.GetAgence_(i);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Agence UpdateAgence_(Agence a)
        {
            try
            {
                return agenceRepository.UpdateAgence_(a);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Agence DeleteAgence_(Agence a)
        {
            try
            {
                return agenceRepository.DeleteAgence_(a);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Agence AddAgence_(Agence a)
        {
            try
            {
                return agenceRepository.AddAgence_(a);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
