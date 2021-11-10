using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ISocialRepository
    {
        public Task<SocialDTO> CreateSocial(SocialDTO sociallDTO);
        public Task<SocialDTO> UpdateSocial(string projectsId, SocialDTO sociallDTO);
        public Task<SocialDTO> GetSocial(string socialId);
        public Task<int> DeleteSocial(string socialId);
        public Task<IEnumerable<SocialDTO>> GetAllSocials(string organisationID);
        public Task<IEnumerable<SocialDTO>> GetAllSocialsOfType(string organisationID, string socialType);
        public Task<SocialDTO> IsSocialUnique(string name);
    }
}
