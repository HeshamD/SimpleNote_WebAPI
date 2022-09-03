

namespace SimpleNote_WebAPI.Services.IServices
{
    public interface IGenericServices<TDto, TE> where TDto : class where TE : class
    {
        //public TDto Create(TDto TT);
        //public Task<TDto> CreateAsync(TDto TT);
        public void Delete(Guid id);
        public void DeleteAsync(Guid id);
        public void DeleteByIdAsync(int id);
        public IEnumerable<TDto> GetAll();
        public TDto GetById(Guid id);
        public TDto GetById(Guid? id);
        public Task<IEnumerable<TDto>> GetAllAsync();
        public Task<TDto> GetByIdAsync(Guid id);
        //public Task<TDto> UpdateByIdAsync(TDto obj, Guid id);
        public Task<TDto> GetByIdAsync(int id);

    }
}
