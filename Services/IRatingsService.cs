using WebChat.Models;

namespace WebChat.Services
{
    public interface IRatingsService
    {
        public List<Rating> GetAll();

        public Rating Get(int id);
        public void Create(int rate, string comment, string name, string date);
        public void Edit(int id, int rate, string comment, string name);
        public void Delete(int id);
    }
}
