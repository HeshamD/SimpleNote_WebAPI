using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Services.ServicesImp
{
    public class AttributiesServicesImp : GenericServicesImp<AttributeDto,AttributiesEntity>, IAttributiesServices
    {
        private readonly IAttributiesRepo attributiesRepo;
        public AttributiesServicesImp(IGenericRepo<AttributiesEntity> baseRepository, IAttributiesRepo _attributiesRepo, IMapper mapper) : base(baseRepository, mapper)
        {
            attributiesRepo = _attributiesRepo;
        }

        public Task<int> GetAttributeNoteCounts()
        {
            return attributiesRepo.GetAttributeNoteCounts();
        }

        public Task<int> GetNullAttributeNoteCounts()
        {
            return attributiesRepo.GetNullAttributeNoteCounts();
        }
    }
}
