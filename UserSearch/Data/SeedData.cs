using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using UserSearch.Models;

namespace UserSearch.Data
{
    public class SeedData
    {
        public static void Initialize(UserSearchContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var random = new Random();
            var fakePhone = "555-555-5555";

            // Addresses from: https://www.randomlists.com/random-addresses
            // Names from: http://random-name-generator.info/
            var users = new User[]
            {
                new User { FirstName = "Theodore", LastName = "Simpson", Address = "53 Grove Street Hanover Park, IL 60133", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Stephen", LastName = "Moran", Address = "8545 Stonybrook Street Anchorage, AK 99504", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Chris", LastName = "Williamson", Address = "65 Pheasant St. Bluffton, SC 29910", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Roberto", LastName = "Kim", Address = "36 Tailwater Dr. Fort Lee, NJ 07024", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Angel", LastName = "Tate", Address = "920 Cedar Street Mount Vernon, NY 10550", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Pablo", LastName = "Ortega", Address = "854 North Road Nashville, TN 37205", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Stacey", LastName = "Griffin", Address = "272 Euclid Court Maspeth, NY 11378", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Michele", LastName = "Stokes", Address = "8774 Pierce St. Parsippany, NJ 07054", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Hazel", LastName = "Gonzalez", Address = "116 Edgewater St. Neenah, WI 54956", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Jan", LastName = "Craig", Address = "552 Madison Lane Waterbury, CT 06705", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Marie", LastName = "George", Address = "607 Glen Creek Drive Salt Lake City, UT 84119", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Eleanor", LastName = "Jimenez", Address = "875 Tallwood Street Aliquippa, PA 15001", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Jerald", LastName = "Flowers", Address = "69 Annadale St. Morton Grove, IL 60053", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Arlene", LastName = "Holland", Address = "697 Bishop Street Greenfield, IN 46140", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Jesse", LastName = "Webb", Address = "368 Bald Hill Lane West Islip, NY 11795", Age = random.Next(18, 86), Phone = fakePhone},
                new User { FirstName = "Joshua", LastName = "Dixon", Address = "8655 Summer Street Superior, WI 54880", Age = random.Next(18, 86), Phone = fakePhone}
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            // Media types: https://en.wikipedia.org/wiki/Media_type
            //var currentFolderPath = Assembly.GetEntryAssembly().Location;

            // Images from: https://na.finalfantasyxiv.com/lodestone/character/?all_search=&search_type=character&q=
            var userImage1 = new Media
            {
                FileName = "userImage1.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/bc8f2d564196c07719902441da2335db_ee738654add55c3d07ea92d8e108074cfc0_96x96.jpg?1518484910")
            };
            context.Media.Add(userImage1);

            var userImage2 = new Media
            {
                FileName = "userImage2.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/6a59731b6cf1a95ac1aa7be8158151c6_393eb74047bb90c8d80dea54218430eefc0_96x96.jpg?1518484786")
            };
            context.Media.Add(userImage2);

            var userImage3 = new Media
            {
                FileName = "userImage3.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/47fa1e28db601c0ead28d89498dc7cb4_2f698530a28d671d20278c8518c804c9fc0_96x96.jpg?1518485259")
            };
            context.Media.Add(userImage3);

            var userImage4 = new Media
            {
                FileName = "userImage4.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/d14fca8a547deca3cc3765a9a0282477_1f5fd239b885860b7c2bfc72ad1d97effc0_96x96.jpg?1518486304")
            };
            context.Media.Add(userImage4);

            var userImage5 = new Media
            {
                FileName = "userImage5.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/f4e879fd25fdfc6bbf219e3666d4c157_781d6b3603312f6be41670afa37282e0fc0_96x96.jpg?1518483216")
            };
            context.Media.Add(userImage5);

            var userImage6 = new Media
            {
                FileName = "userImage6.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/9cf1fa97e61ed04d5848556230c3fd12_134930215abb8a90ec37d6cc05b05e08fc0_96x96.jpg?1518485391")
            };
            context.Media.Add(userImage6);

            var userImage7 = new Media
            {
                FileName = "userImage7.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/41ccb8e4131296f612e39e0dcb89b135_7126768d768f6c6c7fed3eaee98c3a8afc0_96x96.jpg?1518486535")
            };
            context.Media.Add(userImage7);

            var userImage8 = new Media
            {
                FileName = "userImage8.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/f57dfee54aee6d6f6b07a212ccf7cb0d_410ddb5a66a2fcacf538bec5ea5d0291fc0_96x96.jpg?1518484961")
            };
            context.Media.Add(userImage8);

            var userImage9 = new Media
            {
                FileName = "userImage9.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/1ca5b813ad7b9d4a3de8bd9df4e617a6_b937560c841465f7c4bc8eb47ea7948afc0_96x96.jpg?1518483062")
            };
            context.Media.Add(userImage9);

            var userImage10 = new Media
            {
                FileName = "userImage10.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/bb204b1a8dff055a3dc333bd7b9da953_58a84e851e55175d22158ca97af58a1ffc0_96x96.jpg?1518486165")
            };
            context.Media.Add(userImage10);

            var userImage11 = new Media
            {
                FileName = "userImage11.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/466778300382f2fde4da61a25af53786_c514cdcdb619439df97d906d4434ccc6fc0_96x96.jpg?1518486210")
            };
            context.Media.Add(userImage11);

            var userImage12 = new Media
            {
                FileName = "userImage12.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/0f0954b2f2a9928946051549cac5d88e_57ae9ee5592123dd79c8912bf768cf99fc0_96x96.jpg?1518486383")
            };
            context.Media.Add(userImage12);

            var userImage13 = new Media
            {
                FileName = "userImage13.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/37db1766223d4d6db5cf3f453c478ca3_a91aae52cff9ef65932db06b150ffd47fc0_96x96.jpg?1518486416")
            };
            context.Media.Add(userImage13);

            var userImage14 = new Media
            {
                FileName = "userImage14.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/fc814decc9f2629c82d920941e1b381c_138751880f18161a907d7cf0faa43f07fc0_96x96.jpg?1518483300")
            };
            context.Media.Add(userImage14);

            var userImage15 = new Media
            {
                FileName = "userImage15.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/387218e62360ba4ec6fb96dcb7b864dd_8f82f937943b6baf4c565020d5eba0ccfc0_96x96.jpg?1518486449")
            };
            context.Media.Add(userImage15);

            var userImage16 = new Media
            {
                FileName = "userImage16.jpg",
                Type = "image/jpeg",
                Content = GetContentFromSite("https://img2.finalfantasyxiv.com/f/1a9fee6b173e20ff71e9a505a9d29e43_fce4949e615393e574f2d57134b31fc1fc0_96x96.jpg?1518484379")
            };
            context.Media.Add(userImage16);

            context.UserMedia.Add(new UserMedia { User = users[0] , Media = userImage1 });
            context.UserMedia.Add(new UserMedia { User = users[1], Media = userImage2 });
            context.UserMedia.Add(new UserMedia { User = users[2], Media = userImage3 });
            context.UserMedia.Add(new UserMedia { User = users[3], Media = userImage4 });
            context.UserMedia.Add(new UserMedia { User = users[4], Media = userImage5 });
            context.UserMedia.Add(new UserMedia { User = users[5], Media = userImage6 });
            context.UserMedia.Add(new UserMedia { User = users[6], Media = userImage7 });
            context.UserMedia.Add(new UserMedia { User = users[7], Media = userImage8 });
            context.UserMedia.Add(new UserMedia { User = users[8], Media = userImage9 });
            context.UserMedia.Add(new UserMedia { User = users[9], Media = userImage10 });
            context.UserMedia.Add(new UserMedia { User = users[10], Media = userImage11 });
            context.UserMedia.Add(new UserMedia { User = users[11], Media = userImage12 });
            context.UserMedia.Add(new UserMedia { User = users[12], Media = userImage13 });
            context.UserMedia.Add(new UserMedia { User = users[13], Media = userImage14 });
            context.UserMedia.Add(new UserMedia { User = users[14], Media = userImage15 });
            context.UserMedia.Add(new UserMedia { User = users[15], Media = userImage16 });
            context.SaveChanges();
        }

        public static byte[] GetContentFromSite(string urlString)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var content = client.DownloadDataTaskAsync(urlString).Result;
                    return content;
                }
                catch (Exception ex)
                {
                    var currentFolderPath = Assembly.GetEntryAssembly().Location;
                    string[] lines = { ex.Message, ex.Source, ex.InnerException.Message };
                    System.IO.File.WriteAllLines(currentFolderPath, lines);
                    return null;
                }
            }
        }
    }
}
