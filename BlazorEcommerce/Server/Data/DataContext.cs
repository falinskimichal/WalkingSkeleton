namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Star Wars Legion",
                    Url = "starwarslegion"
                },
                new Category
                {
                    Id = 2,
                    Name = "Movies",
                    Url = "movies"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                }
            );



            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Title = "Star Wars Legion: Ahsoka Tano Operative Expansion",
                Description = "The fan favorite Ahsoka Tano comes to Legion for the first time as a new Operative option for the Rebellion. As a key member of the resistance movement preceding the Rebel Alliance, Ahsoka took on the codename Fulcrum and worked tirelessly to supply vital intelligence to the burgeoning Rebel cells. Ahsoka brings both her potent skills with her lightsabers as well as her years of experience as a commander during the Clone Wars to the battlefield. In battle, Ahsoka uses her agility and prowess to help protect her fellow troops while she positions herself to strike down the most dangerous threats using her mastery of Jar’Kai. Combined with her four signature command cards, Ahsoka is sure to defend the Rebellion through its most vulnerable time",
                ImageUrl = "https://files.rebel.pl/products/106/1468/5442/_2009062/ashoka.jpg",
                Price = 94.95m,
                CategoryId = 1
            },
        new Product
        {
            Id = 2,
            Title = "Star Wars Legion: Clone Commander Cody",
            Description = "One of the Galactic Republic's most dependable Clone Commanders comes to Star Wars: Legion in this new Command Expansion! As the commander of the 7th Sky Corps, CC-2224, known as Cody, has developed a distinguished reputation as a skilled strategist and fierce fighter. This pack brings him to the tabletop with three miniatures that can be assembled in a variety of poses and with multiple weapon and head options. In addition to making use of Cody's skills on the battlefield, players can also alter their strategy with his three signature Command Cards.",
            ImageUrl = "https://files.rebel.pl/products/106/1468/5744/_2009063/star-wars-legion-clone-commander-cody-pudelko-front.jpg",
            Price = 149.95m,
            CategoryId = 1
        },
        new Product
        {
            Id = 3,
            Title = "Star Wars Legion: Clone Wars Starter Set",
            Description = "War has engulfed the galaxy. The vast forces of the Separatist Alliance, bolstered by seemingly endless ranks of battle droids, have pushed the Galactic Republic to the brink of dissolution and defeat. The Republic’s only hope is its army of elite clone troopers, led into battle by noble, Force-wielding Jedi Knights. The war between them is an epic struggle where every battle could turn the tide and change the fate of the galaxy. You can immerse yourself in this epic conflict, assembling your forces and leading them against your opponents in the legendary ground battles of Star Wars with the Star Wars: Legion - Clone Wars Core Set! Star Wars: Legion - Clone Wars Core Set invites you to enter a completely new era of infantry battles in the Star Wars galaxy, pitting the overwhelming Separatist droid forces against the Republic’s crack armies of clone troopers and Jedi Knights. As you do, you’ll assemble a force of the Clone Wars' most iconic heroes, villains, troopers, and vehicles, including Obi-Wan Kenobi and General Grievous. In addition to introducing the Galactic Republic and Separatist Alliance to the game, Star Wars: Legion - Clone Wars Core Set contains all the cards, tools and tokens you need to begin staging your own Star Wars battles right away, making this the perfect starting point to begin building your Star Wars: Legion collection!",
            ImageUrl = "https://files.rebel.pl/products/106/1468/5440/_110467/swl44_box_left.png",
            Price = 467.96m,
            CategoryId = 1
        },
        new
        {
            Id = 4,
            CategoryId = 2,
            Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
            Price = 4.99m,
            Title = "The Matrix"
        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                            Price = 3.99m,
                            Title = "Back to the Future"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
                            Price = 2.99m,
                            Title = "Toy Story"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                            Price = 49.99m,
                            Title = "Half-Life 2"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                            Price = 9.99m,
                            Title = "Diablo II"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                            Price = 14.99m,
                            Title = "Day of the Tentacle"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                            Price = 159.99m,
                            Title = "Xbox"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                            Price = 79.99m,
                            Title = "Super Nintendo Entertainment System"
                        }
        );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

