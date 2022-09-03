using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Services.AutoMapper
{
    public class ProjectsProfile:Profile
    {
        public ProjectsProfile()
        {
            CreateMap<ProjectsEntity,ProjectsDto>().ReverseMap();
        }
    }
}
