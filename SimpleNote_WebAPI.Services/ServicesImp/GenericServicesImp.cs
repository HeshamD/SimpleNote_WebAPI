
using SimpleNote_WebAPI.Infrastructure.IRepositories;

namespace SimpleNote_WebAPI.Services.ServicesImp
{
    public class GenericServicesImp<TDto, TE> : IGenericServices<TDto,TE> where TDto : class where TE : class
    {
        protected IGenericRepo<TE> _baseRepository;
        protected IMapper _mapper;

        public GenericServicesImp(IGenericRepo<TE> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        //public TDto Create(TDto dto)
        //{
            
        //    var _mapperEntity = _mapper.Map<TE>(source: TDto);

        //    _baseRepository.Add(_mapperEntity);

        //    var _mapperDto = _mapper.Map<TDto>(_mapperEntity);


        //    return _mapperDto;
        //}

        //public async Task<TDto> CreateAsync(TDto TT)
        //{
        //    var _mapperEntity = _mapper.Map<TE>(source: TDto);

        //    await _baseRepository.AddAsync(_mapperEntity);

        //    var _mapperDto = _mapper.Map<TDto>(_mapperEntity);


        //    return _mapperDto;
        //}

        public void Delete(Guid id)
        {
            _baseRepository.DeleteById(id);
        }

        public void DeleteAsync(Guid id)
        {
            _baseRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {

            var entityT = await _baseRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TDto>>(entityT);
        }

        public TDto GetById(Guid id)
        {
            var entityT = _baseRepository.GetById(id);
            return _mapper.Map<TDto>(entityT);
        }

        public TDto GetById(Guid? id)
        {
            var entityT = _baseRepository.GetById(id);
            return _mapper.Map<TDto>(entityT);
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            var entityT = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entityT);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entityT = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entityT);
        }

        public IEnumerable<TDto> GetAll()
        {
            var entityT =  _baseRepository.GetAll();

            return _mapper.Map<IEnumerable<TDto>>(entityT);
        }

        //public async Task<TDto> UpdateByIdAsync(TDto obj, int id)
        //{
        //    var TE = await _baseRepository.GetByIdAsync(id);

        //    var _mapperEntity = _mapper.Map<T>(obj);

        //    return await _baseRepository.UpdateAsync(_mapperEntity);
        //}

        public async void DeleteByIdAsync(int id)
        { 
            await _baseRepository.GetByIdAsync(id);
            await _baseRepository.DeleteByIdAsync(id);
        }
    }
}
