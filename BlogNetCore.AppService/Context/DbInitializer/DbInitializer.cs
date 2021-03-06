﻿using BlogNetCore.AppService.Domain;
using BlogNetCore.AppService.Identity;
using BlogNetCore.AppService.Identity.Manager;
using BlogNetCore.AppService.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BlogNetCore.AppService.Context.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DLUserManager userManager;
        private readonly DLRoleManager roleManager;
        private readonly BlogDbContext context;

        public DbInitializer(DLUserManager userManager, DLRoleManager roleManager, BlogDbContext _context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = _context;
        }

        public void Initialize()
        {
            context.Database.Migrate();

            if (!this.roleManager.Roles.Any(x => x.Name == "Admin" || x.Name == "User"))
            {
                this.roleManager.CreateAsync(new Role { Name = "Admin" }).Wait();
                this.roleManager.CreateAsync(new Role { Name = "User" }).Wait();

                var category = new Category()
                {
                    Name = "IT",
                    Description = "Information technology (IT) is the use of computers to store, retrieve, transmit, and manipulate data, or information, often in the context of a business or other enterprise.",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                };

                var category1 = new Category()
                {
                    Name = "Sport",
                    Description = "Sport is generally recognised as system of activities which are based in physical athleticism or physical dexterity.",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                };
                var category2 = new Category()
                {
                    Name = "Cryptocurrency",
                    Description = "A cryptocurrency (or crypto currency) is a digital asset designed to work as a medium of exchange that uses strong cryptography to secure financial transactions, control the creation of additional units, and verify the transfer of assets. Cryptocurrencies are a kind of alternative currency and digital currency (of which virtual currency is a subset). Cryptocurrencies use decentralized control as opposed to centralized digital currency and central banking systems.",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                };
                context.Add(category);
                context.Add(category1);
                context.Add(category2);

                var post1 = new Post
                {
                    Title = "Bitcoin falls below $5,000",
                    CategoryId = category2.Id,
                    Slug = RegexHelper.CreateSlug("Bitcoin falls below $5,000"),
                    Description = "The value of Bitcoin has fallen below $5,000 (£3,889) for the first time since October 2017.",
                    Content = "<h3>The value of Bitcoin has fallen below $5,000 (£3,889) for the first time since October 2017.</h3><p>The fall brought the total value of all Bitcoin in existence to below $87bn.&nbsp;</p><p>On Thursday, 15 November, Bitcoin Cash - an offshoot of Bitcoin - split into two different crypto-currencies, which are now in competition with each other.&nbsp;</p><p>And some observers have blamed this for creating turmoil in the crypto-currency markets, with many of the digital assets experiencing falls.&nbsp;</p><p>Bitcoin exchange Kraken said in a blog post that it regarded one of the two new Bitcoin Cash crypto-currencies - Bitcoin SV - as \"an extremely risky investment\".&nbsp;</p><p>Bitcoin is a notoriously volatile crypto-currency.&nbsp;</p><p>At its peak, in November 2017, it briefly hit $19,783 - which means the price has fallen by about 75%.&nbsp;</p>",
                    ImagePath = "~/images/post-img/init_post_img_1.jpg",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                };

                var comment = new Comment
                {
                    Content = "Bitcoin is worse everyday!",
                    Post = post1,
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                };

                var post2 = new Post
                {
                    Title = "Instagram targets fake likes and comments",
                    CategoryId = category.Id,
                    Slug = RegexHelper.CreateSlug("Instagram targets fake likes and comments"),
                    Description = "Photo-sharing platform Instagram has announced a new initiative that will target fake likes and comments.",
                    Content = "<h3>Photo-sharing platform Instagram has announced a new initiative that will target fake likes and comments.</h3><p>The fall brought the total value of all Bitcoin in existence to below $87bn.&nbsp;</p><p>The company say they have developed tools that can identify accounts that use third-party services and apps to artificially boost their popularity.&nbsp;</p><p>Any accounts violating will be warned and told to change their password.&nbsp;</p><p>Since its launch in 2010, Instagram has become a tool for online influencers to amass large followings and often, in turn, get paid to market products.&nbsp;</p><p>Payment for this form of advertising is often scaled by the size of the influencers online audience and engagements but an online investigation by marketing agency Mediakiz last year showed just how easy it is to become a fake influencer.&nbsp;</p><p>Some popular apps utilised by users to boost their followings have been recently shut down, but others that pay monthly subscription fees are still available, website Techcrunch reports.&nbsp;</p>",
                    ImagePath = "~/images/post-img/init_post_img_2.jpg",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                };

                var post3 = new Post
                {
                    Title = "Blackout for thousands of dark web pages",
                    CategoryId = category.Id,
                    Slug = RegexHelper.CreateSlug("Blackout for thousands of dark web pages"),
                    Description = "Hackers have deleted more than 6,500 sites being held on a popular dark web server.",
                    Content = "<h3>Hackers have deleted more than 6,500 sites being held on a popular dark web server.</h3><p>Called Daniel's Hosting, the site was sitting on the hidden Tor network and many people used it to host pages they did not want to publish on the wider web.</p><p>Administrator Daniel Winzen said no back-ups were kept of the pages it hosted.</p><p>He said the site should be back in service in December.</p><p>\"Around 6,500 hidden services were hosted on the server,\" wrote Mr Winzen in a message put on the welcome page of the web companion to the site.</p><p>\"There is no way to recover from this breach, all data is gone.\"</p><p>Tor, or The Onion Router, is a way of organising web-like pages so it is hard to work out where the information is located and who is running them.</p><p>Web pages sited on the Tor network get a .onion suffix.</p><p>The Tor browser also lets people browse the web in a way that conceals their location and obscures their identity.</p><p>Daniel's Hosting became one of the most popular sites for .onion site owners after the previously biggest host went offline in early 2017.</p>",
                    ImagePath = "~/images/post-img/init_post_img_3.png",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                };

                context.Add(post1);
                context.Add(comment);
                context.Add(post2);
                context.Add(post3);
                context.SaveChangesWithoutAudit();
            }

            var defaultAdminAccount = this.userManager.FindByNameAsync("admin").Result;
            if (defaultAdminAccount == null)
            {
                var user = new User { UserName = "admin", Email = "admin@gmail.com" };
                this.userManager.CreateAsync(user, "Duy@123").Wait();
                this.userManager.AddToRoleAsync(user, "Admin").Wait();
            }

        }
    }
}
