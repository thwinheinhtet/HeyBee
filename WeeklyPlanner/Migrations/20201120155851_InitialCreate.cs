using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeeklyPlanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklyPlanner_ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanner_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanner_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanner_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanner_Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanner_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanner_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanner_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanner_UserClaims_WeeklyPlanner_ApplicationUsers_User~",
                        column: x => x.UserId,
                        principalTable: "WeeklyPlanner_ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanner_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanner_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_WeeklyPlanner_UserLogins_WeeklyPlanner_ApplicationUsers_User~",
                        column: x => x.UserId,
                        principalTable: "WeeklyPlanner_ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanner_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanner_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_WeeklyPlanner_UserTokens_WeeklyPlanner_ApplicationUsers_User~",
                        column: x => x.UserId,
                        principalTable: "WeeklyPlanner_ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanner_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanner_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanner_RoleClaims_WeeklyPlanner_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "WeeklyPlanner_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanner_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanner_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_WeeklyPlanner_UserRoles_WeeklyPlanner_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "WeeklyPlanner_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanner_UserRoles_WeeklyPlanner_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "WeeklyPlanner_ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "WeeklyPlanner_ApplicationUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "WeeklyPlanner_ApplicationUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanner_RoleClaims_RoleId",
                table: "WeeklyPlanner_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "WeeklyPlanner_Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanner_UserClaims_UserId",
                table: "WeeklyPlanner_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanner_UserLogins_UserId",
                table: "WeeklyPlanner_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanner_UserRoles_RoleId",
                table: "WeeklyPlanner_UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyPlanner_RoleClaims");

            migrationBuilder.DropTable(
                name: "WeeklyPlanner_UserClaims");

            migrationBuilder.DropTable(
                name: "WeeklyPlanner_UserLogins");

            migrationBuilder.DropTable(
                name: "WeeklyPlanner_UserRoles");

            migrationBuilder.DropTable(
                name: "WeeklyPlanner_Users");

            migrationBuilder.DropTable(
                name: "WeeklyPlanner_UserTokens");

            migrationBuilder.DropTable(
                name: "WeeklyPlanner_Roles");

            migrationBuilder.DropTable(
                name: "WeeklyPlanner_ApplicationUsers");
        }
    }
}
