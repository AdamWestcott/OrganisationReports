using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
   public class CarbonDBItemsRepository : ICarbonDbItemsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CarbonDBItemsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarbonDbItemsDTO>> GetAllCarbonDbItems()
        {
            try
            {
                IEnumerable<CarbonDbItemsDTO> CarbonDbItemsDTOS =
                    _mapper.Map<IEnumerable<CarbonDbItems>, IEnumerable<CarbonDbItemsDTO>>(_db.CarbonMitigations);
                return CarbonDbItemsDTOS;

            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
