using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace ex02.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;

        private readonly IMapper _map;
       public CategoryController(ICategoryService categoryServices, IMapper map) {

            _categoryServices = categoryServices;
            _map = map;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            IEnumerable<Category> categories = await _categoryServices.GetAllCategories();
            IEnumerable<CategoryDto> categoryDtos = _map.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }
    }
}
