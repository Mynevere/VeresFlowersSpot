using FlowrSpotPovio.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Context
{
    public class Seed
    {
        public static async Task SeedData(FlowrSpotPovioContext context, UserManager<User> userManager)
        {

            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Id = "58811272-a612-4c75-926e-0bcf34279cc3",
                        UserName = "verehyseni",
                        Email = "myneverehyseni@gmail.com"
                    },
                    new User
                    {
                        Id = "699284a4-f0db-4bd0-a299-ae2dc068107c",
                        UserName = "userhyseni",
                        Email = "userhyseni@gmail.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Flowers.Any())
            {
                var flowers = new List<Flower>
                {
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "CARNATIONS",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/CARNATIONS.jpg",
                        Description = "These ruffly flowers are perfect for the romantic on a budget."+
                                        "White and pink carnations are popular amongst high schoolers" + 
                                        "during Valentine's Day for their low price and sweet sentiment." +
                                        "They stand for new love and have a cheerful blossom. " +
                                        "When purchasing carnations, stick with solid pink and white colors, " +
                                        "as mixed or yellow carnations symbolize disdain. "
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "IRISES",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/IRISES.jfif",
                        Description = "Purple is the color of royalty, so it's no wonder that" +
                                       " these flowers stand for faith and hope. While the most" +
                                       " popular color of the Iris flower is blue, they also come " +
                                       "in white and yellow.The Iris is named after the Greek Goddess," +
                                       " Iris who was thought to link the heavens with the earth and was" +
                                       " often personified as a rainbow. These flowers were placed next to" +
                                       " graves to help the deceased pass on to the next life before becoming" +
                                       " the flower of France, and the Fleur-de-lis.Irises grow naturally all" +
                                       " over the world and are an excellent gift for someone you admire. "
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "LAVENDER",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/LAVENDER.jpg",
                        Description = "This sweet-smelling flower is given to others as a sign" +
                                        " of devotion. The scent is calming and is also great for" +
                                        " anyone who needs calming or stress relief. There is no " +
                                        "surprise that these are a popular flower, with their " +
                                        "unique look and therapeutic qualities. This is a great flower" +
                                        " to plant in your garden and backyard so that you can enjoy the lovely aroma. "
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "LILACS",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/LILACS.jfif",
                        Description = "Lilacs bloom in spring, often making them associated with the Easter holiday. For this reason, they symbolize rebirth and renewal. They also stand for confidence, making" +
                        " them a great gift for anyone starting a new job, or graduating."
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "ROSES",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/ROSES.jpg",
                        Description = "Red roses are Valentine's Day and Anniversary celebration staples due to their symbol of love and beauty. They've symbolized such perfection since ancient times, as the Ancient Romans and Greeks associated roses with the goddesses of love, Venus and Aphrodite. " +
                        "These flowers are can also be pricey, which makes them feel even more special.  "
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "TULIPS",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/TULIPS.jpeg",
                        Description = "Often associated with spring and Easter, these flowers reflect perfect love with their small, simple layered bloom. They originated in Persia and Turkey, where they were used in wedding ceremonies. The red tulips " +
                        "are most associated with this idea of perfect love and unity. "
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "SUNFLOWERS",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/SUNFLOWERS.jpg",
                        Description = "These bright flowers reflect warmth, loyalty, and happiness. These flowers grow towards the sun, getting nourishment from its warmth and light. These are a great gift for anyone who needs their day brightened, " +
                        "or to show someone how much they warm your life. "
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "GARDENIAS",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/GARDENIAS.jfif",
                        Description = "These beautiful white and fragrant flowers signify purity and joy. They are a bit expensive but make a perfect gift for the Christmas Holidays. They are also very " +
                        "popular for wedding celebrations with their pure connotations. "
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "ORCHIDS",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/ORCHIDS.jpg",
                        Description = "This exotic flower represents strength, luxury, and beauty. With over 20,000 different species, the orchid comes in many different types and colors. While the pink and purple orchid are the most popular, yellow orchards represent " +
                        "new beginnings and are a great gift for the beginning of a new romance. "
                    },
                    new Flower
                    {
                        Id = new Guid(),
                        Name = "DAISIES",
                        Image = "C:Users/Mynev/Source/Repos/FlowrSpotPovio/FlowersImages/DAISIES.jpg",
                        Description = "Daises are typically associated with youth, innocence, and purity. These flowers are often gifted to new mothers. Daisies can also be eaten, and are often made into daisy tea which can assist with respiratory issues. They can be made" +
                        " into oils or lotions and assist in healing irritated skin and wounds. "
                    }
                };


                await context.Flowers.AddRangeAsync(flowers);
                await context.SaveChangesAsync();
            }
        }
    }
}
