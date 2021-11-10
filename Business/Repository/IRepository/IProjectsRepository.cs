using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IProjectsRepository
    {
        public Task<ProjectsDTO> CreateProject(ProjectsDTO projectsDTO);
        public Task<ProjectsDTO> UpdateProject(string projectsId, ProjectsDTO projectsDTO);
        public Task<ProjectsDTO> GetProject(string projectsId);
        public Task<int> DeleteProject(string projectsId);
        public Task<IEnumerable<ProjectsDTO>> GetAllProjects(string OrganisationID);
        public Task<IEnumerable<ProjectsDTO>> GetAllCarbonProjectsOfType(string OrganisationID, string CarbonType);
        public Task<ProjectsDTO> IsProjectUnique(string name);
    }
}
