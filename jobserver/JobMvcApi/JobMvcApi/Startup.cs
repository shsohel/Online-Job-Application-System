using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using JobMvcApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JobMvcApi.Startup))]

namespace JobMvcApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("Super Admin"))
            {
                // first we create Admin rool
                var role = new IdentityRole();
                role.Name = "Super Admin";
                roleManager.Create(role);
            }
            if (roleManager.RoleExists("Super Admin"))
            {
                var userName = userManager.FindByName("shsohel20");
                if (userName == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = "shsohel20";
                    user.Email = "shsohel20@gmail.com";
                    string userPWD = "Shs@12320";
                    var chkUser = userManager.Create(user, userPWD);

                    //Add default User to Role Admin
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Super Admin");
                        var personalDetail = new PersonalDetail();
                        var education = new Education();
                        var experience = new Experience();
                        var address = new Address();
                        var skill = new Skill();
                        var training = new Training();

                        personalDetail.UserName = user.UserName;
                        personalDetail.Email = user.Email;
                        personalDetail.UserId = user.Id;
                        education.PersonalDetailID = personalDetail.PersonalDetailID;
                        experience.PersonalDetailID = personalDetail.PersonalDetailID;
                        address.PersonalDetailID = personalDetail.PersonalDetailID;
                        skill.PersonalDetailID = personalDetail.PersonalDetailID;
                        training.PersonalDetailID = personalDetail.PersonalDetailID;


                        context.PersonalDetails.Add(personalDetail);
                        context.Educations.Add(education);
                        context.Experiences.Add(experience);
                        context.Addresses.Add(address);
                        context.Skills.Add(skill);
                        context.Trainings.Add(training);
                        context.SaveChanges();

                    }
                }
            }
            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            //Here we create a Admin super user who will maintain the website				
            if (roleManager.RoleExists("Admin"))
            {
                var userName = userManager.FindByName("shsohel");
                if (userName == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = "shsohel";
                    user.Email = "shsohel.tc@gmail.com";
                    string userPWD = "Shs@123";
                    var chkUser = userManager.Create(user, userPWD);

                    //Add default User to Role Admin
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Admin");
                        var personalDetail = new PersonalDetail();
                        var education = new Education();
                        var experience = new Experience();
                        var address = new Address();
                        var skill = new Skill();
                        var training = new Training();

                        personalDetail.UserName = user.UserName;
                        personalDetail.Email = user.Email;
                        personalDetail.UserId = user.Id;
                        education.PersonalDetailID = personalDetail.PersonalDetailID;
                        experience.PersonalDetailID = personalDetail.PersonalDetailID;
                        address.PersonalDetailID = personalDetail.PersonalDetailID;
                        skill.PersonalDetailID = personalDetail.PersonalDetailID;
                        training.PersonalDetailID = personalDetail.PersonalDetailID;


                        context.PersonalDetails.Add(personalDetail);
                        context.Educations.Add(education);
                        context.Experiences.Add(experience);
                        context.Addresses.Add(address);
                        context.Skills.Add(skill);
                        context.Trainings.Add(training);
                        context.SaveChanges();

                    }
                }
            }
            // creating Creating Employee role 
            if (!roleManager.RoleExists("Employer"))
            {
                var role = new IdentityRole();
                role.Name = "Employer";
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("Jobseeker"))
            {
                var role = new IdentityRole();
                role.Name = "Jobseeker";
                roleManager.Create(role);

            }
        }
    }
}
