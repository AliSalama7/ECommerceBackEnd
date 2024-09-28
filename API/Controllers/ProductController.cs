using API.DTOS;
using API.Helpers;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _brandRepository;
        private readonly IGenericRepository<ProductType> _typeRepository;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> brandRepository
            , IGenericRepository<ProductType> typeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _typeRepository = typeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetAll([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productRepository.CountAsync(countSpec);

            var products = await _productRepository.GetWithIncludesAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex 
                , productParams.PageSize , totalItems , data));   
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetById(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productRepository.GetBySpecAsync(spec);
            return _mapper.Map<Product , ProductToReturnDto>(product);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<ProductBrand>> GetBrands()
        {
            return Ok(await _brandRepository.GetAllAsync());
        }
        [HttpGet("Types")]
        public async Task<ActionResult<ProductBrand>> GetTypes()
        {
            return Ok(await _typeRepository.GetAllAsync());
        }
        [HttpGet("Error")]
        public IActionResult Error()
        {
            throw new Exception("What the fuck !!");
        }
    }
}
