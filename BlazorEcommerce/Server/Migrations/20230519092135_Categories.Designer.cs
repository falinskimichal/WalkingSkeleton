﻿// <auto-generated />
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230519092135_Categories")]
    partial class Categories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorEcommerce.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Star Wars Legion",
                            Url = "starwarslegion"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Board Games",
                            Url = "boardgames"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Card Games",
                            Url = "cardgames"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "The fan favorite Ahsoka Tano comes to Legion for the first time as a new Operative option for the Rebellion. As a key member of the resistance movement preceding the Rebel Alliance, Ahsoka took on the codename Fulcrum and worked tirelessly to supply vital intelligence to the burgeoning Rebel cells. Ahsoka brings both her potent skills with her lightsabers as well as her years of experience as a commander during the Clone Wars to the battlefield. In battle, Ahsoka uses her agility and prowess to help protect her fellow troops while she positions herself to strike down the most dangerous threats using her mastery of Jar’Kai. Combined with her four signature command cards, Ahsoka is sure to defend the Rebellion through its most vulnerable time",
                            ImageUrl = "https://files.rebel.pl/products/106/1468/5442/_2009062/ashoka.jpg",
                            Price = 94.95m,
                            Title = "Star Wars Legion: Ahsoka Tano Operative Expansion"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "One of the Galactic Republic's most dependable Clone Commanders comes to Star Wars: Legion in this new Command Expansion! As the commander of the 7th Sky Corps, CC-2224, known as Cody, has developed a distinguished reputation as a skilled strategist and fierce fighter. This pack brings him to the tabletop with three miniatures that can be assembled in a variety of poses and with multiple weapon and head options. In addition to making use of Cody's skills on the battlefield, players can also alter their strategy with his three signature Command Cards.",
                            ImageUrl = "https://files.rebel.pl/products/106/1468/5744/_2009063/star-wars-legion-clone-commander-cody-pudelko-front.jpg",
                            Price = 149.95m,
                            Title = "Star Wars Legion: Clone Commander Cody"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "War has engulfed the galaxy. The vast forces of the Separatist Alliance, bolstered by seemingly endless ranks of battle droids, have pushed the Galactic Republic to the brink of dissolution and defeat. The Republic’s only hope is its army of elite clone troopers, led into battle by noble, Force-wielding Jedi Knights. The war between them is an epic struggle where every battle could turn the tide and change the fate of the galaxy. You can immerse yourself in this epic conflict, assembling your forces and leading them against your opponents in the legendary ground battles of Star Wars with the Star Wars: Legion - Clone Wars Core Set! Star Wars: Legion - Clone Wars Core Set invites you to enter a completely new era of infantry battles in the Star Wars galaxy, pitting the overwhelming Separatist droid forces against the Republic’s crack armies of clone troopers and Jedi Knights. As you do, you’ll assemble a force of the Clone Wars' most iconic heroes, villains, troopers, and vehicles, including Obi-Wan Kenobi and General Grievous. In addition to introducing the Galactic Republic and Separatist Alliance to the game, Star Wars: Legion - Clone Wars Core Set contains all the cards, tools and tokens you need to begin staging your own Star Wars battles right away, making this the perfect starting point to begin building your Star Wars: Legion collection!",
                            ImageUrl = "https://files.rebel.pl/products/106/1468/5440/_110467/swl44_box_left.png",
                            Price = 467.96m,
                            Title = "Star Wars Legion: Clone Wars Starter Set"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.HasOne("BlazorEcommerce.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
