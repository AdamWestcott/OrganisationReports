using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Net5.BlazorIntegrationDemo
{
    public class StoredItems
    {
        //Stored Instance of CarbonReudctionInfoDTO
        private CarbonReductionInfoDTO CarbonReductionInfoModel { get; set; } = new CarbonReductionInfoDTO();
        //Stored Instance of SocialReudctionInfoDTO
        private SocialReductionInfoDTO SocialReductionInfoModel { get; set; } = new SocialReductionInfoDTO();
        //Stored Instance of OrganisationDTO
        private OrganisationDTO OrganisationModel { get; set; } = new OrganisationDTO();
        public event Action onChange;
        //boolean that checks if a organisation has been selected
        private static bool isSelected;
        //boolean that checks if a organisation is selected and if it is and then is edited it will set a new instance of 
        //OrganisationModel
        private static bool isOrgEdited;


        //Getters and setters
        public void setIsSelected()
        {
            isSelected = true;
            NotifyStateChanged();
        }

        public bool getIsSelected()
        {
            return isSelected;
        }

        public void setIsOrgEdited(bool isedited)
        {
            isOrgEdited = isedited;
            NotifyStateChanged();
        }

        public bool getIsOrgEdited()
        {
            return isOrgEdited;
        }

        public CarbonReductionInfoDTO getCarbonReductionInfoList()
        {
            return CarbonReductionInfoModel;
        }

        public void setCarbonReductionInfoList(CarbonReductionInfoDTO carbonModel)
        {
            CarbonReductionInfoModel = carbonModel;
            NotifyStateChanged();
        }

        public SocialReductionInfoDTO getSocialReductionInfoList()
        {
            return SocialReductionInfoModel;
        }

        public void setSocialReductionInfoList(SocialReductionInfoDTO socialModel)
        {
            SocialReductionInfoModel = socialModel;
            NotifyStateChanged();
        }

        public OrganisationDTO getOrganisation()
        {
            return OrganisationModel;
        }

        public void setOrganisation(OrganisationDTO org)
        {
            OrganisationModel = org;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            onChange?.Invoke();
        }

    }

}
