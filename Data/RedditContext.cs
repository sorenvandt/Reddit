using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;

namespace Data
{
    public class RedditContext : DbContext
    {
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comments> Comments => Set<Comments>();
        public DbSet<User> Users => Set<User>();

        public RedditContext(DbContextOptions<RedditContext> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}