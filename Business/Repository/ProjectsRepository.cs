using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
   public class ProjectsRepository: IProjectsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProjectsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProjectsDTO> CreateProject(ProjectsDTO projectseDTO)
        {
            Projects project = _mapper.Map<ProjectsDTO, Projects>(projectseDTO);
            var addedProject = await _db.Carbon.AddAsync(project);
            await _db.SaveChangesAsync();
            return _mapper.Map<Projects, ProjectsDTO>(addedProject.Entity);
        }

        public async Task<int> DeleteProject(string projectID)
        {
            var projectDetails = await _db.Carbon.FindAsync(projectID);
            if (projectDetails != null)
            {
                _db.Carbon.Remove(projectDetails);
                return await _db.SaveChangesAsync();
            }

            return 0;

        }

        public async Task<IEnumerable<ProjectsDTO>> GetAllProjects(string organisationID)
        {
            try
            {
                IEnumerable<ProjectsDTO> projectDTOS =
                    _mapper.Map<IEnumerable<Projects>, IEnumerable<ProjectsDTO>>(_db.Carbon);

                return projectDTOS.Where(x=>x.OrganisationID == organisationID);
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProjectsDTO>> GetAllCarbonProjectsOfType(string organisationID, string CarbonType)
        {
            try
            {
                IEnumerable<ProjectsDTO> projectDTOS =
                    _mapper.Map<IEnumerable<Projects>, IEnumerable<ProjectsDTO>>(_db.Carbon);

                projectDTOS = projectDTOS.Where(x => x.OrganisationID == organisationID);
                projectDTOS = projectDTOS.Where(x => x.CarbonType == CarbonType);

                return projectDTOS;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ProjectsDTO> GetProject(string projectID)
        {
            try
            {
                ProjectsDTO project = _mapper.Map<Projects, ProjectsDTO>(
                await _db.Carbon.FirstOrDefaultAsync(x => x.CarbonID == projectID));

                return project;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ProjectsDTO> IsProjectUnique(string name)
        {
            try
            {
                ProjectsDTO projects = _mapper.Map<Projects, ProjectsDTO>(
                await _db.Carbon.FirstOrDefaultAsync(x => x.CarbonName.ToLower() == name.ToLower()));

                return projects;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ProjectsDTO> UpdateProject(string projectId, ProjectsDTO projectDTO)
        {
            try
            {
                if (projectId == projectDTO.CarbonID)
                {
                    //valid
                    Projects projecteDetails = await _db.Carbon.FindAsync(projectId);
                    Projects project = _mapper.Map<ProjectsDTO, Projects>(projectDTO, projecteDetails);
                    var updatedProject = _db.Carbon.Update(project);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Projects, ProjectsDTO>(updatedProject.Entity);
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
