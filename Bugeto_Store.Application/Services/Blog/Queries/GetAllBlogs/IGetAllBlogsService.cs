using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Blog.Queries.GetAllBlogs
{
    public interface IGetAllBlogsService
    {
        ResultDto<List<AllBlogsDto>> Execute();

    }


    public class GetAllBlogsService : IGetAllBlogsService
    {

        private readonly IDataBaseContext _context;

        public GetAllBlogsService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllBlogsDto>> Execute()
        {

            
            throw new NotImplementedException();
        }
    }



    public class AllBlogsDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
