using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShowRoomProject.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ModelCar",
                columns: table => new
                {
                    ModelCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelCarName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelCar", x => x.ModelCarId);
                });

            migrationBuilder.CreateTable(
                name: "PictureCar",
                columns: table => new
                {
                    PictureCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureOne = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PictureTwo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PictureThree = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureCar", x => x.PictureCarId);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionCar",
                columns: table => new
                {
                    TransmissionCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionCarName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionCar", x => x.TransmissionCarId);
                });

            migrationBuilder.CreateTable(
                name: "TypeEngine",
                columns: table => new
                {
                    TypeEngineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEngineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEngine", x => x.TypeEngineId);
                });

            migrationBuilder.CreateTable(
                name: "YearRelease",
                columns: table => new
                {
                    YearReleaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearReleaseName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearRelease", x => x.YearReleaseId);
                });

            migrationBuilder.CreateTable(
                name: "BrandCar",
                columns: table => new
                {
                    BrandCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandCarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCar", x => x.BrandCarId);
                    table.ForeignKey(
                        name: "FK_BrandCar_ModelCar_ModelCarId",
                        column: x => x.ModelCarId,
                        principalTable: "ModelCar",
                        principalColumn: "ModelCarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    EngineCapacity = table.Column<float>(type: "real", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    TypeEngineId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_BrandCar_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BrandCar",
                        principalColumn: "BrandCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_PictureCar_PictureId",
                        column: x => x.PictureId,
                        principalTable: "PictureCar",
                        principalColumn: "PictureCarId");
                    table.ForeignKey(
                        name: "FK_Car_TransmissionCar_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "TransmissionCar",
                        principalColumn: "TransmissionCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_TypeEngine_TypeEngineId",
                        column: x => x.TypeEngineId,
                        principalTable: "TypeEngine",
                        principalColumn: "TypeEngineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_YearRelease_YearId",
                        column: x => x.YearId,
                        principalTable: "YearRelease",
                        principalColumn: "YearReleaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookedCar",
                columns: table => new
                {
                    BookedCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedCar", x => x.BookedCarId);
                    table.ForeignKey(
                        name: "FK_BookedCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedCar_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedCar_CarId",
                table: "BookedCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedCar_ClientId",
                table: "BookedCar",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandCar_ModelCarId",
                table: "BrandCar",
                column: "ModelCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandId",
                table: "Car",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_PictureId",
                table: "Car",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TransmissionId",
                table: "Car",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TypeEngineId",
                table: "Car",
                column: "TypeEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_YearId",
                table: "Car",
                column: "YearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "BookedCar");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "BrandCar");

            migrationBuilder.DropTable(
                name: "PictureCar");

            migrationBuilder.DropTable(
                name: "TransmissionCar");

            migrationBuilder.DropTable(
                name: "TypeEngine");

            migrationBuilder.DropTable(
                name: "YearRelease");

            migrationBuilder.DropTable(
                name: "ModelCar");
        }
    }
}
