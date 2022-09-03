


namespace SimpleNote_WebAPI.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotesEntity>().HasOne(n => n.Project).WithMany(p => p.Notes).HasForeignKey(n => n.Project_ID_FK);
            modelBuilder.Entity<NotesEntity>().HasOne(n => n.Attributies).WithMany(p => p.Notes).HasForeignKey(n => n.Attribute_Id_FK);
            modelBuilder.Entity<NotesEntity>().HasOne(n => n.Users).WithMany(p => p.Notes).HasForeignKey(n => n.User_Id_FK);


            //Data Seeding 


            modelBuilder.Entity<NotesEntity>().HasData(
                new NotesEntity()
                {
                    Note_Id = 1,
                    Project_ID_FK = null,
                    Attribute_Id_FK = null,
                    Note = "first note",
                    Completed = false,
                    User_Id_FK = 1

                },
                new NotesEntity()
                {
                    Note_Id = 2,
                    Project_ID_FK = 1,
                    Attribute_Id_FK = null,
                    Note = "second note",
                    Completed = false,
                    User_Id_FK = 1

                },
                new NotesEntity()
                {
                    Note_Id = 3,
                    Project_ID_FK = null,
                    Attribute_Id_FK = 1,
                    Note = "third note",
                    Completed = false,
                    User_Id_FK = 1

                },
                new NotesEntity()
                {
                    Note_Id = 4,
                    Project_ID_FK = 1,
                    Attribute_Id_FK = 1,
                    Note = "fourth note",
                    Completed = false,
                    User_Id_FK = 1

                }

                );

            //Projects

            modelBuilder.Entity<ProjectsEntity>().HasData(
                new ProjectsEntity()
                {
                    Project_Id = 1,
                    Title = "first project",
                    Completed = false,
                }

                );

            //Attributies

            modelBuilder.Entity<AttributiesEntity>().HasData(
                new AttributiesEntity()
                {
                    Attribute_Id= 1,
                    Name = "first attributies",
                }

                );

            //Users
            modelBuilder.Entity<UsersEntity>().HasData(
                new UsersEntity()
                {
                    User_Id = 1,
                    UserName = "first userName",
                    Password = "firstPass",
                    Creation_Date = DateTime.Now,
                    Last_Login_Date = DateTime.Now
                },
                new UsersEntity()
                {
                    User_Id= 2,
                    UserName="user",
                    Password="guess",
                    Creation_Date= DateTime.Now,
                    Last_Login_Date= DateTime.Now
                }
                );

        }

        //Create the dbset for the tables in the db
        public DbSet<NotesEntity> Notes { get; set; }
        public DbSet<AttributiesEntity> Attributies { get; set; }
        public DbSet<ProjectsEntity> Projects { get; set; }
        public DbSet<UsersEntity> Users { get; set; }


    }
}
