using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthTestUser.Entities
{
    public class User
    {
        [Key]
        public Guid User_ID { get; set; }
        [MaxLength(200)]
        [Required]
        public string User_Code { get; set; }
        [MaxLength(200)]
        [Required]
        public string User_Pass { get; set; }

        public Guid ApplicationUserId { get; set; }
        [MaxLength(300)]
        [Required]
        public string User_FullName { get; set; }
        public string User_Role { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }

        //Cannot use table 'Users' for entity type 'User' since it is being used for entity type 'ApplicationUser' and potentially other entity types, but there is no linking relationship. Add a foreign key to 'User' on the primary key properties and pointing to the primary key on another entity type mapped to 'Users'.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers"); // نام جدول مرتبط با ApplicationUser را تغییر می‌دهیم
    modelBuilder.Entity<User>().ToTable("Users"); // نام جدول مرتبط با User را تغییر می‌دهیم

    // تعریف رابطه بین ApplicationUser و User
    modelBuilder.Entity<ApplicationUser>()
        .HasOne(u => u.User)
        .WithOne(user => user.ApplicationUser)
        .HasForeignKey<User>(user => user.ApplicationUserId);
} 

    }
}
