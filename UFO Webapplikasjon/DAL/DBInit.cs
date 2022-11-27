using UFO_Webapplikasjon.DAL;

namespace UFO_Webapplikasjon.Model
{
    public static class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
                var serviceScope = app.ApplicationServices.CreateScope();
                var context = serviceScope.ServiceProvider.GetService<Context>();

                // må slette og opprette databasen hver gang når den skal initieres (seed`es)
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var kunde1 = new Sightings { City = "Oslo", Country = "Norway", Duration = "2 hours", Dateposted = "03/12/2022", Datetime = "02/12/2022", Comments = "Just testing this application" };
                var kunde2 = new Sightings { City = "Kobenhagen", Country = "Denmark", Duration = "3 min", Dateposted = "11/11/2011", Datetime = "14/02/2007", Comments = "Nothing really happened" };

                context.Sightings.Add(kunde1);
                context.Sightings.Add(kunde2);

                // lag en påoggingsbruker
                var user = new Users();
                user.Username = "Admin";
                var password = "Test11";
                byte[] salt = UserRepository.doSalt();
                byte[] hash = UserRepository.doHash(password, salt);
                user.Password = hash;
                user.Salt = salt;
                context.Users.Add(user);

                context.SaveChanges();
            
        }
    }
}
