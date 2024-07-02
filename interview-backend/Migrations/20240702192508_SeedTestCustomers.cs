using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace interview_backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "FirstName", "LastName", "Email", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { "John", "Doe", "john.doe@example.com", DateTime.Now, DateTime.Now },
                    { "Jane", "Smith", "jane.smith@example.com", DateTime.Now, DateTime.Now },
                    { "Michael", "Johnson", "michael.johnson@example.com", DateTime.Now, DateTime.Now },
                    { "Chris", "Lee", "chris.lee@example.com", DateTime.Now, DateTime.Now },
                    { "Sara", "Walker", "sara.walker@example.com", DateTime.Now, DateTime.Now },
                    { "Paul", "Harris", "paul.harris@example.com", DateTime.Now, DateTime.Now },
                    { "Emily", "Brown", "emily.brown@example.com", DateTime.Now, DateTime.Now },
                    { "Daniel", "Miller", "daniel.miller@example.com", DateTime.Now, DateTime.Now },
                    { "Sophia", "Wilson", "sophia.wilson@example.com", DateTime.Now, DateTime.Now },
                    { "James", "Moore", "james.moore@example.com", DateTime.Now, DateTime.Now },
                    { "Anna", "Taylor", "anna.taylor@example.com", DateTime.Now, DateTime.Now },
                    { "David", "Anderson", "david.anderson@example.com", DateTime.Now, DateTime.Now },
                    { "Lucas", "Thomas", "lucas.thomas@example.com", DateTime.Now, DateTime.Now },
                    { "Olivia", "Jackson", "olivia.jackson@example.com", DateTime.Now, DateTime.Now },
                    { "Ethan", "White", "ethan.white@example.com", DateTime.Now, DateTime.Now },
                    { "Mia", "Lewis", "mia.lewis@example.com", DateTime.Now, DateTime.Now },
                    { "Ryan", "Young", "ryan.young@example.com", DateTime.Now, DateTime.Now },
                    { "Ella", "King", "ella.king@example.com", DateTime.Now, DateTime.Now },
                    { "Liam", "Scott", "liam.scott@example.com", DateTime.Now, DateTime.Now },
                    { "Grace", "Green", "grace.green@example.com", DateTime.Now, DateTime.Now }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
