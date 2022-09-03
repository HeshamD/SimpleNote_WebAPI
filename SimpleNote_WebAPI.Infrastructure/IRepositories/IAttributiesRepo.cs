using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Infrastructure.IRepositories
{
    public interface IAttributiesRepo: IGenericRepo<AttributiesEntity>
    {
        public Task<int> GetAttributeNoteCounts();
        public Task<int> GetNullAttributeNoteCounts();
    }
}
