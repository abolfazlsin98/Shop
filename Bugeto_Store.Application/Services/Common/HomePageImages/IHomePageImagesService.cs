using Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages;
using Bugeto_Store.Application.Services.HomePages.AddHomePageImages;
using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Common.HomePageImages
{
    public interface IHomePageImagesService
    {

        ResultDto<List<HomePageImagesDto>> GetAll();


        ResultDto Delete(long id);

        ResultDto Update(HomePageImagesDto homePageImagesDto);
        // ResultDto Add(requestAddHomePageImagesDto request);
    }
}
