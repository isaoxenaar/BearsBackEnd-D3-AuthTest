namespace SignalRWebpack.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context){
            _context = context;
        }

        public User Create(User user) {
            Console.WriteLine(user.Id);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetByEmail(string email) {

            return _context.Users.FirstOrDefault(user => user.Email == email);
        }

        public User GetById(int id) {

            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

    }
}

