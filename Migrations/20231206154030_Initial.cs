using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JPW.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    CompanyEmail = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    CompanyPhone = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyAddress = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyDescription = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobSeekerId = table.Column<string>(type: "text", nullable: true),
                    InterviewDate = table.Column<string>(type: "text", nullable: true),
                    InterviewTime = table.Column<string>(type: "text", nullable: false),
                    InterviewLocation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSeeker",
                columns: table => new
                {
                    JobSeekerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobSeekerName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Skills = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Password = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeeker", x => x.JobSeekerId);
                });

            migrationBuilder.CreateTable(
                name: "JobPosting",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobTitle = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    JobDescription = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: true),
                    JobExperienceLevel = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    JobSkillSet = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    JobPayScale = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    JobLocation = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobPosti__056690C2FFF0EF52", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JobPosting_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobSeekerId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    MessageText = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeeker",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplyforJobs",
                columns: table => new
                {
                    AppliedJobId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobSeekerId = table.Column<int>(type: "integer", nullable: false),
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    Resume = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Applyfor__AF19BB4BF50E342A", x => x.AppliedJobId);
                    table.ForeignKey(
                        name: "FK_ApplyforJobs_JobPosting",
                        column: x => x.JobId,
                        principalTable: "JobPosting",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplyforJobs_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeeker",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobMatch",
                columns: table => new
                {
                    JobMatchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobSeekerId = table.Column<int>(type: "integer", nullable: false),
                    JobId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobMatch", x => x.JobMatchId);
                    table.ForeignKey(
                        name: "FK_JobMatch_JobPosting",
                        column: x => x.JobId,
                        principalTable: "JobPosting",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobMatch_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeeker",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Admin__A9D105346811502C",
                table: "Admin",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplyforJobs_JobId",
                table: "ApplyforJobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyforJobs_JobSeekerId",
                table: "ApplyforJobs",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "UQ__Company__A1DB68DBF04BE8FE",
                table: "Company",
                column: "CompanyEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobMatch_JobId",
                table: "JobMatch",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobMatch_JobSeekerId",
                table: "JobMatch",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosting_CompanyId",
                table: "JobPosting",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UQ__JobSeeke__A9D10534B78294B6",
                table: "JobSeeker",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_CompanyId",
                table: "Message",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_JobSeekerId",
                table: "Message",
                column: "JobSeekerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ApplyforJobs");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "JobMatch");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "JobPosting");

            migrationBuilder.DropTable(
                name: "JobSeeker");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
