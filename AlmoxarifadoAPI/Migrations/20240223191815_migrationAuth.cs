using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmoxarifadoAPI.Migrations
{
    public partial class migrationAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: false),
                    descricao = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__CD54BC5A9FEB8E65", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    id_departamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departam__64F37A1628CE144E", x => x.id_departamento);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    id_fornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: false),
                    descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Forneced__6C477092D75AF5CD", x => x.id_fornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    id_item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: false),
                    descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Itens__87C9438B7F895D57", x => x.id_item);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    cargo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    id_departamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Funciona__6FBD69C45922D40F", x => x.id_funcionario);
                    table.ForeignKey(
                        name: "FK__Funcionar__id_de__4CA06362",
                        column: x => x.id_departamento,
                        principalTable: "Departamentos",
                        principalColumn: "id_departamento");
                });

            migrationBuilder.CreateTable(
                name: "Emails_Fornecedor",
                columns: table => new
                {
                    id_email = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    id_fornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emails_F__F3B378DF81DD98D1", x => x.id_email);
                    table.ForeignKey(
                        name: "FK__Emails_Fo__id_fo__4316F928",
                        column: x => x.id_fornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "id_fornecedor");
                });

            migrationBuilder.CreateTable(
                name: "Enderecos_Fornecedor",
                columns: table => new
                {
                    id_endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logadouro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    bairro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    complemento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    cidade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    pais = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    id_fornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Endereco__324B959EBD7889B3", x => x.id_endereco);
                    table.ForeignKey(
                        name: "FK__Enderecos__id_fo__3D5E1FD2",
                        column: x => x.id_fornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "id_fornecedor");
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores_Categorias",
                columns: table => new
                {
                    id_fornecedor = table.Column<int>(type: "int", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Fornecedo__id_ca__3A81B327",
                        column: x => x.id_categoria,
                        principalTable: "Categorias",
                        principalColumn: "id_categoria");
                    table.ForeignKey(
                        name: "FK__Fornecedo__id_fo__398D8EEE",
                        column: x => x.id_fornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "id_fornecedor");
                });

            migrationBuilder.CreateTable(
                name: "Telefones_Fornecedor",
                columns: table => new
                {
                    id_telefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    id_fornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Telefone__28CD6834DD66F230", x => x.id_telefone);
                    table.ForeignKey(
                        name: "FK__Telefones__id_fo__403A8C7D",
                        column: x => x.id_fornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "id_fornecedor");
                });

            migrationBuilder.CreateTable(
                name: "Itens_Categorias",
                columns: table => new
                {
                    id_item = table.Column<int>(type: "int", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Itens_Cat__id_ca__47DBAE45",
                        column: x => x.id_categoria,
                        principalTable: "Categorias",
                        principalColumn: "id_categoria");
                    table.ForeignKey(
                        name: "FK__Itens_Cat__id_it__46E78A0C",
                        column: x => x.id_item,
                        principalTable: "Itens",
                        principalColumn: "id_item");
                });

            migrationBuilder.CreateTable(
                name: "Emails_Funcionario",
                columns: table => new
                {
                    id_email = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emails_F__F3B378DFC9606086", x => x.id_email);
                    table.ForeignKey(
                        name: "FK__Emails_Fu__id_fu__52593CB8",
                        column: x => x.id_funcionario,
                        principalTable: "Funcionarios",
                        principalColumn: "id_funcionario");
                });

            migrationBuilder.CreateTable(
                name: "Telefones_Funcionario",
                columns: table => new
                {
                    id_telefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Telefone__28CD68344465013D", x => x.id_telefone);
                    table.ForeignKey(
                        name: "FK__Telefones__id_fu__4F7CD00D",
                        column: x => x.id_funcionario,
                        principalTable: "Funcionarios",
                        principalColumn: "id_funcionario");
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    id_transacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_transacao = table.Column<DateTime>(type: "date", nullable: false),
                    tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    motivo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transaco__0FBBF773C9520717", x => x.id_transacao);
                    table.ForeignKey(
                        name: "FK__Transacoe__id_fu__5535A963",
                        column: x => x.id_funcionario,
                        principalTable: "Funcionarios",
                        principalColumn: "id_funcionario");
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    id_entrada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_entrada = table.Column<DateTime>(type: "date", nullable: false),
                    condicao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    nota = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    id_transacao = table.Column<int>(type: "int", nullable: false),
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Entradas__167CD61B38494657", x => x.id_entrada);
                    table.ForeignKey(
                        name: "FK__Entradas__id_fun__59FA5E80",
                        column: x => x.id_funcionario,
                        principalTable: "Funcionarios",
                        principalColumn: "id_funcionario");
                    table.ForeignKey(
                        name: "FK__Entradas__id_tra__59063A47",
                        column: x => x.id_transacao,
                        principalTable: "Transacoes",
                        principalColumn: "id_transacao");
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    id_lote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preco_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    quantidade_entrada = table.Column<int>(type: "int", nullable: false),
                    quantidade_atual = table.Column<int>(type: "int", nullable: false),
                    data_validade = table.Column<DateTime>(type: "date", nullable: true),
                    localizacao = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: false),
                    id_entrada = table.Column<int>(type: "int", nullable: false),
                    id_item = table.Column<int>(type: "int", nullable: false),
                    id_fornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lotes__9A00048670755C62", x => x.id_lote);
                    table.ForeignKey(
                        name: "FK__Lotes__id_entrad__5CD6CB2B",
                        column: x => x.id_entrada,
                        principalTable: "Entradas",
                        principalColumn: "id_entrada");
                    table.ForeignKey(
                        name: "FK__Lotes__id_fornec__5EBF139D",
                        column: x => x.id_fornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "id_fornecedor");
                    table.ForeignKey(
                        name: "FK__Lotes__id_item__5DCAEF64",
                        column: x => x.id_item,
                        principalTable: "Itens",
                        principalColumn: "id_item");
                });

            migrationBuilder.CreateTable(
                name: "Saidas",
                columns: table => new
                {
                    id_saida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_saida = table.Column<DateTime>(type: "date", nullable: false),
                    condicao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    quantidade_saida = table.Column<int>(type: "int", nullable: false),
                    nota = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    id_transacao = table.Column<int>(type: "int", nullable: false),
                    id_lote = table.Column<int>(type: "int", nullable: false),
                    id_funcionario_responsavel = table.Column<int>(type: "int", nullable: false),
                    id_funcionario_receptor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Saidas__6F9AC3B4724E51F3", x => x.id_saida);
                    table.ForeignKey(
                        name: "FK__Saidas__id_funci__6383C8BA",
                        column: x => x.id_funcionario_responsavel,
                        principalTable: "Funcionarios",
                        principalColumn: "id_funcionario");
                    table.ForeignKey(
                        name: "FK__Saidas__id_funci__6477ECF3",
                        column: x => x.id_funcionario_receptor,
                        principalTable: "Funcionarios",
                        principalColumn: "id_funcionario");
                    table.ForeignKey(
                        name: "FK__Saidas__id_lote__628FA481",
                        column: x => x.id_lote,
                        principalTable: "Lotes",
                        principalColumn: "id_lote");
                    table.ForeignKey(
                        name: "FK__Saidas__id_trans__619B8048",
                        column: x => x.id_transacao,
                        principalTable: "Transacoes",
                        principalColumn: "id_transacao");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_Fornecedor_id_fornecedor",
                table: "Emails_Fornecedor",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_Funcionario_id_funcionario",
                table: "Emails_Funcionario",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_Fornecedor_id_fornecedor",
                table: "Enderecos_Fornecedor",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_id_funcionario",
                table: "Entradas",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_id_transacao",
                table: "Entradas",
                column: "id_transacao");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_Categorias_id_categoria",
                table: "Fornecedores_Categorias",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_Categorias_id_fornecedor",
                table: "Fornecedores_Categorias",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_id_departamento",
                table: "Funcionarios",
                column: "id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Categorias_id_categoria",
                table: "Itens_Categorias",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Categorias_id_item",
                table: "Itens_Categorias",
                column: "id_item");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_id_entrada",
                table: "Lotes",
                column: "id_entrada");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_id_fornecedor",
                table: "Lotes",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_id_item",
                table: "Lotes",
                column: "id_item");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_id_funcionario_receptor",
                table: "Saidas",
                column: "id_funcionario_receptor");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_id_funcionario_responsavel",
                table: "Saidas",
                column: "id_funcionario_responsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_id_lote",
                table: "Saidas",
                column: "id_lote");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_id_transacao",
                table: "Saidas",
                column: "id_transacao");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_Fornecedor_id_fornecedor",
                table: "Telefones_Fornecedor",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_Funcionario_id_funcionario",
                table: "Telefones_Funcionario",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_id_funcionario",
                table: "Transacoes",
                column: "id_funcionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Emails_Fornecedor");

            migrationBuilder.DropTable(
                name: "Emails_Funcionario");

            migrationBuilder.DropTable(
                name: "Enderecos_Fornecedor");

            migrationBuilder.DropTable(
                name: "Fornecedores_Categorias");

            migrationBuilder.DropTable(
                name: "Itens_Categorias");

            migrationBuilder.DropTable(
                name: "Saidas");

            migrationBuilder.DropTable(
                name: "Telefones_Fornecedor");

            migrationBuilder.DropTable(
                name: "Telefones_Funcionario");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
