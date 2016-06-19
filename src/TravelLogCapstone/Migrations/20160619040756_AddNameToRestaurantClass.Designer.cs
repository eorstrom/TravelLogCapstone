using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelLogCapstone.Models;

namespace TravelLogCapstone.Migrations
{
    [DbContext(typeof(TravelLogContext))]
    [Migration("20160619040756_AddNameToRestaurantClass")]
    partial class AddNameToRestaurantClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelLogCapstone.Models.AppUsers", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int?>("RestaurantsRestaurantId");

                    b.Property<string>("Username");

                    b.HasKey("AppUserId");

                    b.HasIndex("RestaurantsRestaurantId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("TravelLogCapstone.Models.Cities", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("CityId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TravelLogCapstone.Models.Restaurants", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("CityId");

                    b.Property<int>("CleanlinessRating");

                    b.Property<string>("DrinksConsumed");

                    b.Property<string>("FoodCategory");

                    b.Property<string>("FoodEaten");

                    b.Property<string>("Name");

                    b.Property<int>("OverallRating");

                    b.Property<int>("ServiceRating");

                    b.Property<string>("UserNotes");

                    b.HasKey("RestaurantId");

                    b.HasIndex("CityId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("TravelLogCapstone.Models.AppUsers", b =>
                {
                    b.HasOne("TravelLogCapstone.Models.Restaurants")
                        .WithMany()
                        .HasForeignKey("RestaurantsRestaurantId");
                });

            modelBuilder.Entity("TravelLogCapstone.Models.Cities", b =>
                {
                    b.HasOne("TravelLogCapstone.Models.AppUsers")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelLogCapstone.Models.Restaurants", b =>
                {
                    b.HasOne("TravelLogCapstone.Models.Cities")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
