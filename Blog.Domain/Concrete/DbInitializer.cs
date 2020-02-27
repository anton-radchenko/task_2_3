using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
    class DbInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var reviews = new List<Review>
            {
                new Review { Author = "Author1", Date = DateTime.Now, Text = "wbersvdfsdvfwevfdsvfsvtsddsfvgdsv" },
                new Review {Author = "Author2", Date = DateTime.Now, Text = "zxvzxvxczvzxvwevfdsvfsvtsddsfvgdsv" },
                new Review { Author = "Author3", Date = DateTime.Now, Text = "uyiyuiyuiyuiyuivfdsvfsvtsddsfvgdsv" }
            };
            reviews.ForEach(x => context.Reviews.Add(x));
            context.SaveChanges();
            var keywords = new List<Keyword>
            {
               new Keyword {Name = "Linux"},
                new Keyword {Name = "operating system"},
                new Keyword {Name = "kernel"},
                new Keyword {Name = "OS"},
                new Keyword {Name = "Android"},
                new Keyword {Name = "system"},
                new Keyword {Name = "mobile"},
                new Keyword {Name = "Windows"},
                new Keyword {Name = "Microsoft"},
                new Keyword {Name = "Mac OS"},
                new Keyword {Name = "Apple"}
                //new Keyword {Name = ""},
                //new Keyword {Name = ""},
                //new Keyword {Name = ""},
                //new Keyword {Name = ""},
                //new Keyword {Name = ""},
                //new Keyword {Name = ""}
            };
            keywords.ForEach(x => context.Keywords.Add(x));
            context.SaveChanges();
            var articles = new List<Article>
            {
               new Article {Name = "Linux kernel", Date= new DateTime(2018,11,19), Keywords = new List<Keyword>(){ keywords[0], keywords[1], keywords[2], keywords[3]}, Text ="The Linux kernel is a free and open-source, monolithic, Unix-like operating system kernel. The Linux family of operating systems is based on this kernel and deployed on both traditional computer systems such as personal computers and servers, usually in the form of Linux distributions, and on various embedded devices such as routers, wireless access points, PBXes, set-top boxes, FTA receivers, smart TVs, PVRs, and NAS appliances. While the adoption of the Linux kernel in desktop computer operating system is low, Linux-based operating systems dominate nearly every other segment of computing, from mobile devices to mainframes. Since November 2017, all of the world's 500 most powerful supercomputers run Linux. The Android operating system for tablet computers, smartphones, and smartwatches also uses the Linux kernel."},
               new Article {Name = "Android", Date = new DateTime(2019,7,11), Keywords = new List<Keyword>(){keywords[4], keywords[5], keywords[6] },  Text ="Android is a mobile operating system based on a modified version of the Linux kernel and other open source software, designed primarily for touchscreen mobile devices such as smartphones and tablets. Android is developed by a consortium of developers known as the Open Handset Alliance, with the main contributor and commercial marketer being Google.nitially developed by Android Inc., which Google bought in 2005, Android was unveiled in 2007, with the first commercial Android device launched in September 2008. The current stable version is Android 10, released on September 3, 2019. The core Android source code is known as Android Open Source Project (AOSP), which is primarily licensed under the Apache License. This has allowed variants of Android to be developed on a range of other electronics, such as game consoles, digital cameras, PCs and others, each with a specialized user interface. Some well known derivatives include Android TV for televisions and Wear OS for wearables, both developed by Google."},
               new Article {Name = "Windows", Date = new DateTime(2019,1,17), Keywords = new List<Keyword>(){keywords[3], keywords[7], keywords[8] }, Text = "Microsoft Windows, commonly referred to as Windows, is a group of several proprietary graphical operating system families, all of which are developed and marketed by Microsoft. Each family caters to a certain sector of the computing industry. Active Microsoft Windows families include Windows NT and Windows IoT; these may encompass subfamilies, e.g. Windows Server or Windows Embedded Compact (Windows CE). Defunct Microsoft Windows families include Windows 9x, Windows Mobile and Windows Phone.Microsoft introduced an operating environment named Windows on November 20, 1985, as a graphical operating system shell for MS - DOS in response to the growing interest in graphical user interfaces(GUIs)"},
               new Article{Name = "Mac OS", Date = new DateTime(2020,1,10), Keywords = new List<Keyword>(){keywords[3], keywords[9], keywords[10] },Text = "previously Mac OS X and later OS X) is a series of proprietary graphical operating systems developed and marketed by Apple Inc. since 2001. It is the primary operating system for Apple's Mac computers. Within the market of desktop, laptop and home computers, and by web usage, it is the second most widely used desktop OS, after Microsoft Windows.macOS is the second major series of Macintosh operating systems. The first is colloquially called the classic Mac OS, which was introduced in 1984, and the final release of which was Mac OS 9 in 1999. The first desktop version, Mac OS X 10.0, was released in March 2001, with its first update, 10.1, arriving later that year. After this, Apple began naming its releases after big cats, which lasted until OS X 10.8 Mountain Lion. Since OS X 10.9 Mavericks, releases have been named after locations in California.Apple shortened the name to or their other operating systems"},
               new Article{Name ="Deleted Article", Date = new DateTime(2020, 1,25), Keywords = new List<Keyword>(){keywords[1], keywords[2]}, Text = "This article was deleted", IsDeleted = true}
            };
            articles.ForEach(x => context.Articles.Add(x));
            context.SaveChanges();

            var answers = new List<Answer>
            {
                new Answer{Text = "Excellent", Amount = 3},
                new Answer{Text = "Good", Amount = 5},
                new Answer{Text = "Bad", Amount = 4},
                new Answer{Text = "Awful", Amount = 2}
            };
            answers.ForEach(x => context.Answers.Add(x));
            context.SaveChanges();

            var polls = new List<Poll>
            {
                new Poll{Title = "How is My Site?", Answers = new List<Answer>(){ answers[0], answers[1], answers[2], answers[3] } }
            };
            polls.ForEach(x => context.Polls.Add(x));
            context.SaveChanges();
        }
    }
}
