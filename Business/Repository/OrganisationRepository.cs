using AutoMapper;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repository.IRepository;
using Business.Repository;

namespace Business.Repository
{
   public class OrganisationRepository : IOrganisationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public OrganisationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OrganisationDTO> CreateOrganisation(OrganisationDTO organisationDTO)
        {
            Organisation organisation = _mapper.Map<OrganisationDTO, Organisation>(organisationDTO);
            var addedOrganisation = await _db.Organisation.AddAsync(organisation);
            await _db.SaveChangesAsync();
            return _mapper.Map<Organisation, OrganisationDTO>(addedOrganisation.Entity);
        }

        public async Task<int> DeleteOrganisation(string organisationId)
        {
            var organisationDetails = await _db.Organisation.FindAsync(organisationId);
            IEnumerable<Projects> Projects = _db.Carbon;
            IEnumerable<Social> Social = _db.Social;
            if (organisationDetails != null)
            {
                foreach(Projects project in Projects)
                {
                    if(project.OrganisationID == organisationId)
                    {
                        var projectdetails = await _db.Carbon.FindAsync(project.CarbonID);
                        _db.Carbon.Remove(projectdetails);
                        await _db.SaveChangesAsync();
                    }

                }

                foreach (Social project in Social)
                {
                    if (project.OrganisationID == organisationId)
                    {
                        var projectdetails = await _db.Social.FindAsync(project.SocialID);
                        _db.Social.Remove(projectdetails);
                        await _db.SaveChangesAsync();
                    }

                }

                _db.Organisation.Remove(organisationDetails);
                return await _db.SaveChangesAsync();
            }


            return 0;

        }

        public async Task<IEnumerable<OrganisationDTO>> GetAllOrganisations()
        {

                IEnumerable<OrganisationDTO> organisationDTOS =
                    _mapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationDTO>>(_db.Organisation);
                return organisationDTOS;
        }

        public async Task<OrganisationDTO> GetOrganisation(string organisationID)
        {
            try
            {
                OrganisationDTO organisation = _mapper.Map<Organisation, OrganisationDTO>(
                await _db.Organisation.FirstOrDefaultAsync(x => x.OrganisationID == organisationID));

                return organisation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrganisationDTO> IsOrganisationUnique(string name)
        {
            try
            {
                OrganisationDTO organisation = _mapper.Map<Organisation, OrganisationDTO>(
                await _db.Organisation.FirstOrDefaultAsync(x => x.OrganisationName.ToLower() == name.ToLower()));

                return organisation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrganisationDTO> UpdateOrganisation(string organisationId, OrganisationDTO organisationDTO)
        {
            try
            {
                if (organisationId == organisationDTO.OrganisationID)
                {
                    //valid
                    Organisation organisationDetails = await _db.Organisation.FindAsync(organisationId);
                    Organisation organisation = _mapper.Map<OrganisationDTO, Organisation>(organisationDTO, organisationDetails);
                    var updatedOrganisation = _db.Organisation.Update(organisation);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Organisation, OrganisationDTO>(updatedOrganisation.Entity);
                }
                else
                {
                    //invalid
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
