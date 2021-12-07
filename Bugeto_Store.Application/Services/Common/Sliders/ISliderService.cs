using Bugeto_Store.Application.Services.Common.Queries.GetSlider;
using Bugeto_Store.Common.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Common.Sliders
{
    public interface ISliderService
    {

        ResultDto<List<SliderDto>> GetAll();

        ResultDto Add(IFormFile file, string Link);
        ResultDto Delete(long id);

        ResultDto Update(SliderDto sliderDto);

    }
}
