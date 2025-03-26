using Microsoft.EntityFrameworkCore;

public class UserRepository
{
    private readonly StudentDbContext _context;

    public UserRepository(StudentDbContext context)
    {
        _context = context;
    }

    public Users GetUserByUsername(string username)
    {
        return _context.Users.SingleOrDefault(u => u.Username == username);
    }

   
}