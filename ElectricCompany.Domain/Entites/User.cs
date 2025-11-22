using ElectricCompany.Domain.Abstractions;

namespace ElectricCompany.Domain.Entites
{
    public sealed class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<string> Roles { get; set; }
        public string Username { get; set; }
    }
}
