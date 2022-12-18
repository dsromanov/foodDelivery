using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using foodDelivery.Entity.Models;

namespace foodDelivery.Entity;
public class Context : DbContext
{ 
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Types

        builder.Entity<Types>().ToTable("types");
        builder.Entity<Types>().HasKey(x => x.Id);

        #endregion

        #region Admins

        builder.Entity<Admin>().ToTable("admins");
        builder.Entity<Admin>().HasKey(x => x.Id);

        #endregion

        #region Cities

        builder.Entity<City>().ToTable("cities");
        builder.Entity<City>().HasKey(x => x.Id);

        #endregion

        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);
        builder.Entity<User>().HasOne(x => x.City)
                                    .WithMany(x => x.Users)
                                    .HasForeignKey(x => x.CityId)
                                    .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");

        #endregion

        #region Facilities

        builder.Entity<Facility>().ToTable("facilities");
        builder.Entity<Facility>().HasKey(x => x.Id);
        builder.Entity<Facility>().HasOne(x => x.City)
                                    .WithMany(x => x.Facilities)
                                    .HasForeignKey(x => x.CityId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Facility>().HasOne(x => x.Type)
                                    .WithMany(x => x.Facilities)
                                    .HasForeignKey(x => x.TypeId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region FacilityToUsers

        builder.Entity<FacilityToUser>().ToTable("facility_to_users");
        builder.Entity<FacilityToUser>().HasKey(x => x.Id);
        builder.Entity<FacilityToUser>().HasOne(x => x.User)
                                    .WithMany(x => x.FacilityToUsers)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<FacilityToUser>().HasOne(x => x.Facility)
                                    .WithMany(x => x.FacilityToUsers)
                                    .HasForeignKey(x => x.FacilityId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

    }
}