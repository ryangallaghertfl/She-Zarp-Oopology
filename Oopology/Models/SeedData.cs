//using Microsoft.EntityFrameworkCore;
//using Oopology.Data;

//namespace Oopology.Models
//{
//    public static class SeedData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new OopologyContext(
//                       serviceProvider.GetRequiredService<
//                           DbContextOptions<OopologyContext>>()))
//            {
//                // Look for any courses
//                if (context.Course.Any())
//                {
//                    return; // DB has been seeded
//                }

//                context.Course.AddRange(
//                    new Course
//                    {
//                        Title = "Oopology 101: First Steps to a New Life",
//                        Description =
//                            "Includes foreword by Chief Enlightenment Officer Peter Pennywhacker! This entry level book takes you on a journey out of the blind-alley of functional programming. OOP as revealed by the Oopology method is a truly life-enriching experience",
//                        Price = 180.99
//                    },

//                    new Course
//                    {
//                        Title = "Oopology 102: How our rubber ducks can save you £££s with this neat trick!",
//                        Description =
//                            "Includes foreword by Chief Enlightenment Officer Peter Pennywhacker! Now that you have moved up a level, you finally will encapsulate your object state data, while explaining the truth as revealed by dear leader Peter PennyWhacker to a rubber duck (sold separately)",
//                        Price = 899.99
//                    },

//                    new Course
//                    {
//                        Title = "Oopology 201: Fight back against the evil procedural apostates",
//                        Description =
//                            "Includes foreword by Chief Enlightenment Officer Peter Pennywhacker! You are blessed, for you now on the righteous path for building a new world. This essential book and electronic download will prepare you for a future dependency injection",
//                        Price = 2280.99
//                    },

//                    new Course
//                    {
//                        Title = "Oopology 202: Stopping the OOP-deniers and haters of truth",
//                        Description =
//                            "Includes foreword by Chief Enlightenment Officer Peter Pennywhacker! Witness the wonderful secrets of dependency injection as revealed by beloved leader Peter PennyWhacker, whose own methods outshine the world. Do not listen to other so-called adherents of OOP, as you will learn Oopology is highly-evolved version of primitive OOP methods. Your Dependency Injection container will be the secret of a happier life.",
//                        Price = 5480.99
//                    }
//                );
//                context.SaveChanges();
//            }
//        }
//    }
//}
