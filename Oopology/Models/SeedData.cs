using Microsoft.EntityFrameworkCore;
using Oopology.Data;

namespace Oopology.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OopologyContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<OopologyContext>>()))
            {
                //Look for any courses
                if (context.Course.Any())
                    {
                        return; // DB has been seeded
                    }

                context.Course.AddRange(
                    new Course
                    {
                        Title = "Oopology 101: First Steps to a New Life",
                        Description =
                            "Includes foreword by Chief Enlightenment Officer Peter Pennywhacker! This entry level book takes you on a journey out of the blind-alley of functional programming. OOP as revealed by the Oopology method is a truly life-enriching experience",
                        ImageThumbnailUrl = "images/Opology-101.png",
                        ThumbnailBack = "images/author101.png",
                        Price = 180.99
                    },

                    new Course
                    {
                        Title = "Oopology 102: How our rubber ducks can save you £££s with this neat trick!",
                        Description =
                            "Includes foreword by Chief Enlightenment Officer Peter Pennywhacker! Now that you have moved up a level, you finally will encapsulate your object state data, while explaining the truth as revealed by dear leader Peter PennyWhacker to a rubber duck (sold separately)",
                        ImageThumbnailUrl = "images/Opology-102.png",
                        ThumbnailBack = "images/author102.png",
                        Price = 899.99
                    },

                    new Course
                    {
                        Title = "Oopology 201: Fight back against the evil procedural apostates",
                        Description =
                            "Includes foreword by Chief Enlightenment Officer Peter Pennywhacker! You are blessed, for you are now on the righteous path for building a new world. This essential book and electronic download will prepare you for a scoped dependency injection, setting you onto the righteous path of loosely-coupled code.",
                        ImageThumbnailUrl = "images/Opology-201.png",
                        ThumbnailBack = "images/author201.png",
                        Price = 2280.99
                    },

                    new Course
                    {
                        Title = "Oopology 202: Stopping the OOP-deniers and haters of truth",
                        Description =
                            "Includes foreword by Chief Enlightenment Officer Peter Pennywhacker! Witness the wonderful secrets of dependency injection as revealed by beloved leader Peter PennyWhacker, whose own methods outshine the world. Do not listen to other so-called adherents of OOP, as you will learn Oopology is a highly-evolved version of primitive OOP methods. Your Dependency Injection container will be the secret of a happier life.",
                        ImageThumbnailUrl = "images/Opology-202.png",
                        ThumbnailBack = "images/author202.png",
                        Price = 5480.99
                    },

                    new Course
                    {
                        Title = "Building the 21st Century Human (and how nuclear jetpacks will liberate mankind)",
                        Description =
                            "A masterpiece from 1967 now back in print. Peter Pennywhacker as a young man was at the cutting edge of computer science, social comment and philosophy in the late 1960s. He sets out a vision of the future in which Britain's public transportation crisis is averted through investment into personal nuclear-powered jetpacks. While narrow-minded British governments failed to grasp this vision, Pennywhacker's critiques still hold up in the 2020s. While Oopology would only be invented 30-years later, many of its ideas are present within the book. The world still has a chance to read this book and to avert disaster. Britain still has time to abandon expensive commitments to military, education and healthcare and to instead put all investment into a zero-gravity vortex machine. The novelty of existing entirely within zero-gravity would surely negate the need of all wars. This book is essential reading for all committed Oopologists.",
                        ImageThumbnailUrl = "images/Oopology21st.png",
                        ThumbnailBack = "images/author21st.png",
                        Price = 8660.99
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
