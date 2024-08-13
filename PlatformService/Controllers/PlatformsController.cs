using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper){
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms(){
            Console.WriteLine("--> Getting Platforms... ");
            
            var platformItems = _platformRepository.GetAllPlatforms();
            
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));  
        }

        [HttpGet("{id}", Name ="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id){
            Console.WriteLine($"--> Getting platform by id {id}");
            var platform = _platformRepository.GetPlaformById(id);
            if(platform == null){
                return NotFound();
            }

            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }
        
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto){
            Console.WriteLine("--> Creating new platform");

            if(platformCreateDto == null){
                return BadRequest();
            }
            var newPlatform = _mapper.Map<Platform>(platformCreateDto);
            _platformRepository.CreatePltform(newPlatform);
            _platformRepository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(newPlatform);

            return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDto.Id }, platformReadDto);    
        }
    }
}