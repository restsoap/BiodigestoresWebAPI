using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Models;
using UserService.Repositories;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
        }

        [HttpGet("{id}")]
        public ActionResult<UserCreationDTOs> GetUser(string id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserCreationDTOs>(user));
        }

        [HttpPost]
        public ActionResult<UserCreationDTOs> createUser(UserCreationDTOs userCreationDTOs)
        {

            // Validar el modelo manualmente
            if (!TryValidateModel(userCreationDTOs))
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<User>(userCreationDTOs);
            _userRepository.createUser(user);
            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, _mapper.Map<UserCreationDTOs>(user));
        }
    }
}