

namespace SimpleNote_WebAPI.Services.IServices
{
    public interface IAttributiesServices : IGenericServices<AttributeDto,AttributiesEntity>
    {
        public Task<int> GetAttributeNoteCounts();
        public Task<int> GetNullAttributeNoteCounts();
    }
}
