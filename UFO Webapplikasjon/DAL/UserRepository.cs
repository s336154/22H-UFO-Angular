using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Cryptography;
using UFO_Webapplikasjon.Controllers;
using UFO_Webapplikasjon.Model;


namespace UFO_Webapplikasjon.DAL
{
    public class UserRepository : InUserRepository
    {
        private readonly Context _db;
        private ILogger<UserController> _log;

        public UserRepository(Context db, ILogger<UserController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<bool> CreateUser(User innUser)
        {
            try
            {
                var newUserRow = new Users();

                newUserRow.Username = innUser.Username;
        //        newUserRow.Password = innUser.Password;
                newUserRow.Firstname = innUser.Firstname;
                newUserRow.Lastname = innUser.Lastname;

                _db.Users.Add(newUserRow);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<User>?> ReadAllUsers()
        {
            try
            {
                List<User> everyUsers = await _db.Users.Select(k => new User
                {
                    Id = k.Id,
                    Username = k.Username,
          //          Password = k.Password,
                    Firstname = k.Firstname,
                    Lastname = k.Lastname,
                }).ToListAsync();

                return everyUsers;
            }
            catch
            {
                return null;
            }
        }

        // Reversed order of ReadAll() based on Id and get a single Object
        public async Task<User> ReadLatestUser()
        {
            try
            {
                List<User> everyUsers = await _db.Users.Select(k => new User
                {
                    Id = k.Id,
                    Username = k.Username,
           //         Password = k.Password,
                    Firstname = k.Firstname,
                    Lastname = k.Lastname,
                }).OrderByDescending(x => x.Id).ToListAsync();

                var latestRecord = everyUsers.FirstOrDefault();

                return latestRecord;
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> ReadOneUser(int Id)
        {
            Users singleUser = await _db.Users.FindAsync(Id);
            var hentetKunde = new User()
            {
                Id = singleUser.Id,
                Username = singleUser.Username,
       //         Password = singleUser.Password,
                Firstname = singleUser.Firstname,
                Lastname = singleUser.Lastname,
            };
            return hentetKunde;
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                Users singleDBUser = await _db.Users.FindAsync(id);
                _db.Users.Remove(singleDBUser);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(User updateUser)
        {
            try
            {
                var updateObjekt = await _db.Users.FindAsync(updateUser.Id);
                updateObjekt.Username = updateUser.Username;
       //         updateObjekt.Password = updateUser.Password;
                updateObjekt.Firstname = updateUser.Firstname;
                updateObjekt.Lastname = updateUser.Lastname;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static byte[] doHash(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                                password: password,
                                salt: salt,
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 1000,
            numBytesRequested: 32);
        }

        public static byte[] doSalt()
        {
            var csp = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csp.GetBytes(salt);
            return salt;
        }

        public async Task<bool> LogIn(User user)
        {
            try
            {
                Users foundUser = await _db.Users.FirstOrDefaultAsync(b => b.Username == user.Username);
                // sjekk passordet
                byte[] hash = doHash(user.Password, foundUser.Salt);
                bool ok = hash.SequenceEqual(foundUser.Password);
                if (ok)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }


    }
}
