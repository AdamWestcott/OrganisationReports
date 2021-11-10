using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IOrganisationRepository
    {
        public Task<OrganisationDTO> CreateOrganisation(OrganisationDTO organisationDTO);
        public Task<OrganisationDTO> UpdateOrganisation(string organisationId, OrganisationDTO organisationDTO);
        public Task<OrganisationDTO> GetOrganisation(string organisationId);
        public Task<int> DeleteOrganisation(string organisationId);
        public Task<IEnumerable<OrganisationDTO>> GetAllOrganisations();
        public Task<OrganisationDTO> IsOrganisationUnique(string name);
    }
}
