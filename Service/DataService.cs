using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Data;
using Model;

namespace Service;

public class DataService
{
    private RedditContext db { get; }

    public DataService(RedditContext db)
    {
        this.db = db;
    }
    /// <summary>
    /// Seeder noget nyt data i databasen hvis det er nødvendigt.
    /// </summary>
    public void SeedData()
    {

        User user = db.Users.FirstOrDefault()!;
        if (user == null)
        {
            user = new User { Username = "Kristian" };
            db.Users.Add(user);
            db.Users.Add(new User { Username = "Søren" });
            db.Users.Add(new User { Username = "Mette" });
        }

        Post post = db.Posts.FirstOrDefault()!;
        if (post == null)
        {
            db.Posts.Add(new Post { Title = "Det skete", Content = "Det gik for stærkt og jeg kørte galt", User = user });
            db.Posts.Add(new Post { Title = "Brug for hjælp", Content = "Jeg har længe haft dette problem", User = user });
            db.Posts.Add(new Post { Title = "Hvordan gør man", Content = "Jeg har længe forsøgt at investere men har brug for hjælp", User = user });
        }


        db.SaveChanges();
    }

    public List<Post> GetPost()
    {
        return db.Posts.Include(b => b.User).ToList();
    }

    public List<Comments> GetComments()
    {
        return db.Comments.Include(b => b.User).ToList();
    }

    public Post SeePost(int id)
    {
        return db.Posts.Include(b => b.User).FirstOrDefault(b => b.PostId == id);
    }

    public List<User> GetUsers()
    {
        return db.Users.ToList();
    }

    public User GetUser(int id)
    {
        return db.Users.Include(a => a.Username).FirstOrDefault(a => a.UserId == id);
    }

    public string CreatePost(string content, int userId, string title)
    {
        User user = db.Users.FirstOrDefault(a => a.UserId == userId);
        db.Posts.Add(new Post { Title = title, Content = content, User = user });
        db.SaveChanges();
        return "Post created";
    }

}