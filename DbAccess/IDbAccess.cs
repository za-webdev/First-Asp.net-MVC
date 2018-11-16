using FisrtAspMVC.Models;

namespace DbAccess
{
    public interface IDbAccess
    {
        Admin Select(string command, string connectionString);
    }
}