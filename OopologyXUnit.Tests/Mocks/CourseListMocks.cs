using Oopology.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oopology.Data;

namespace OopologyXUnit.Tests
{
    public class CourseListMocks
    {
        internal static readonly OopologyContext Object;
        private readonly List<Course> _courses;

        public CourseListMocks()
        {
            _courses = new List<Course>
            {
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
                    }
            };

        }

        public IEnumerable<Course> ListCourses()
        {
            var courseList = _courses;
            return courseList;
        }



    }
}
