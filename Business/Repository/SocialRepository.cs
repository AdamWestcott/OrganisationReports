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
   public class SocialRepository : ISocialRepository
    {  
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public SocialRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SocialDTO> CreateSocial(SocialDTO socialDTO)
        {
            Social social = _mapper.Map<SocialDTO, Social>(socialDTO);
            var addedSocial = await _db.Social.AddAsync(social);
            await _db.SaveChangesAsync();
            return _mapper.Map<Social, SocialDTO>(addedSocial.Entity);
        }

        public async Task<int> DeleteSocial(string socialId)
        {
            var socialDetails = await _db.Social.FindAsync(socialId);
            if (socialDetails != null)
            {
                _db.Social.Remove(socialDetails);
                return await _db.SaveChangesAsync();
            }

            return 0;

        }

        public async Task<IEnumerable<SocialDTO>> GetAllSocials(string organisationID)
        {
            try
            {
                IEnumerable<SocialDTO> socialDTOs =
                    _mapper.Map<IEnumerable<Social>, IEnumerable<SocialDTO>>(_db.Social);

                return socialDTOs.Where(x => x.OrganisationID == organisationID);
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<SocialDTO>> GetAllSocialsOfType(string organisationID, string socialType)
        {
            try
            {
                IEnumerable<SocialDTO> socialDTOS =
                    _mapper.Map<IEnumerable<Social>, IEnumerable<SocialDTO>>(_db.Social);

            socialDTOS = socialDTOS.Where(x => x.OrganisationID == organisationID);
            socialDTOS = socialDTOS.Where(x => x.SocialType == socialType);

                return socialDTOS;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SocialDTO> GetSocial(string socialID)
        {
            try
            {
                SocialDTO social = _mapper.Map<Social, SocialDTO>(
                await _db.Social.FirstOrDefaultAsync(x => x.SocialID == socialID));

                return social;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SocialDTO> IsSocialUnique(string name)
        {
            try
            {
                SocialDTO socials = _mapper.Map<Social, SocialDTO>(
                await _db.Social.FirstOrDefaultAsync(x => x.SocialName.ToLower() == name.ToLower()));

                return socials;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SocialDTO> UpdateSocial(string socialID, SocialDTO SocialDTO)
        {
            try
            {
                if (socialID == SocialDTO.SocialID)
                {
                    //valid
                    Social socialDetails = await _db.Social.FindAsync(socialID);
                    Social social = _mapper.Map<SocialDTO, Social>(SocialDTO, socialDetails);
                    var updatedSocial = _db.Social.Update(social);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Social, SocialDTO>(updatedSocial.Entity);
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
