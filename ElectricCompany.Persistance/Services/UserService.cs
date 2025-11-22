using AutoMapper;
using ElectricCompany.Application.Abstraction.Services;
using ElectricCompany.Application.Features.UserFeatures.Commands.Register;
using ElectricCompany.Domain.DTOS;
using ElectricCompany.Domain.Entites;
using ElectricCompany.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ElectricCompany.Persistance.Services
{
    public sealed class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateUserAsync(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);
            user.Roles = new List<string>() { "Adminastrator", "Moderator", "ContentManager" };
            user.PasswordHash = Convert.ToBase64String(new System.Security.Cryptography.HMACSHA512().ComputeHash(Encoding.UTF8.GetBytes(request.Password)));
            
            await _context.Set<User>().AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserDto>> GetAllUserAsync()
        {
            List<User> result = await _context.Set<User>().AsNoTracking().ToListAsync();

            List<UserDto> resultForReturn = new List<UserDto>();
            
            foreach(User user in result)
            {
                resultForReturn.Add(new UserDto() { Email = user.Email, FullName = $"{user.Name} {user.Surname}", Roles = user.Roles });
            }

            return resultForReturn;
        }
    }
}
