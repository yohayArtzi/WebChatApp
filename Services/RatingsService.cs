using WebChat.Models;

namespace WebChat.Services
{
    public class RatingsService : IRatingsService 
    {
        private static List<Rating> ratings = new List<Rating>();
        public List<Rating> GetAll()
        {
            return ratings;
        }

        public Rating Get(int id)
        {
            return ratings.Find(x => x.Id == id);
        }

        public void Create(int rate, string comment, string name, string date)
        {
            int nextId = 0;
            if (ratings.Count > 0)
            {
                nextId = ratings.Max(x => x.Id) + 1;
            }
            ratings.Add(new Rating() { Id = nextId, Rate = rate, Comment = comment, Name = name, Date = date });
        }

        public void Edit(int id, int rate, string comment, string name)
        {
            Rating rating = Get(id);
            rating.Rate = rate;
            rating.Comment = comment;
            rating.Name = name;
        }
        public void Delete(int id)
        {
            ratings.Remove(Get(id));
        }
    }
}
