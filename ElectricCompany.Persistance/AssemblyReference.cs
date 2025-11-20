using System.Reflection;

namespace ElectricCompany.Persistance;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
