using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoAPI.Data;
public class ApplicationContext : IdentityDbContext<IdentityUser>
{
    //Adicionei de db_almoxarifadoContext.cs
    public virtual DbSet<Categoria> Categorias { get; set; } = null!;
    public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
    public virtual DbSet<EmailsFornecedor> EmailsFornecedors { get; set; } = null!;
    public virtual DbSet<EmailsFuncionario> EmailsFuncionarios { get; set; } = null!;
    public virtual DbSet<EnderecosFornecedor> EnderecosFornecedors { get; set; } = null!;
    public virtual DbSet<Entrada> Entradas { get; set; } = null!;
    public virtual DbSet<Fornecedore> Fornecedores { get; set; } = null!;
    public virtual DbSet<FornecedoresCategoria> FornecedoresCategorias { get; set; } = null!;
    public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
    public virtual DbSet<Iten> Itens { get; set; } = null!;
    public virtual DbSet<ItensCategoria> ItensCategorias { get; set; } = null!;
    public virtual DbSet<Lote> Lotes { get; set; } = null!;
    public virtual DbSet<Saida> Saidas { get; set; } = null!;
    public virtual DbSet<TelefonesFornecedor> TelefonesFornecedors { get; set; } = null!;
    public virtual DbSet<TelefonesFuncionario> TelefonesFuncionarios { get; set; } = null!;
    public virtual DbSet<Transaco> Transacoes { get; set; } = null!;
    //

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    //Adicionei de db_almoxarifadoContext.cs

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        if (!optionsBuilder.IsConfigured)
    //        {
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //            optionsBuilder.UseSqlServer("Data Source=PC03LAB2524\\SENAI;Initial Catalog=db_almoxarifado; User Id=sa; Password=senai.123");
    //        }
    //    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Adicionei de db_almoxarifadoContext.cs
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria)
                .HasName("PK__Categori__CD54BC5A9FEB8E65");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

            entity.Property(e => e.Descricao)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("descricao");

            entity.Property(e => e.Nome)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento)
                .HasName("PK__Departam__64F37A1628CE144E");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<EmailsFornecedor>(entity =>
        {
            entity.HasKey(e => e.IdEmail)
                .HasName("PK__Emails_F__F3B378DF81DD98D1");

            entity.ToTable("Emails_Fornecedor");

            entity.Property(e => e.IdEmail).HasColumnName("id_email");

            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

            entity.HasOne(d => d.IdFornecedorNavigation)
                .WithMany(p => p.EmailsFornecedors)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Emails_Fo__id_fo__4316F928");
        });

        modelBuilder.Entity<EmailsFuncionario>(entity =>
        {
            entity.HasKey(e => e.IdEmail)
                .HasName("PK__Emails_F__F3B378DFC9606086");

            entity.ToTable("Emails_Funcionario");

            entity.Property(e => e.IdEmail).HasColumnName("id_email");

            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

            entity.HasOne(d => d.IdFuncionarioNavigation)
                .WithMany(p => p.EmailsFuncionarios)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Emails_Fu__id_fu__52593CB8");
        });

        modelBuilder.Entity<EnderecosFornecedor>(entity =>
        {
            entity.HasKey(e => e.IdEndereco)
                .HasName("PK__Endereco__324B959EBD7889B3");

            entity.ToTable("Enderecos_Fornecedor");

            entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");

            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bairro");

            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cidade");

            entity.Property(e => e.Complemento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("complemento");

            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estado");

            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

            entity.Property(e => e.Logadouro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("logadouro");

            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero");

            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais");

            entity.HasOne(d => d.IdFornecedorNavigation)
                .WithMany(p => p.EnderecosFornecedors)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enderecos__id_fo__3D5E1FD2");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.IdEntrada)
                .HasName("PK__Entradas__167CD61B38494657");

            entity.Property(e => e.IdEntrada).HasColumnName("id_entrada");

            entity.Property(e => e.Condicao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("condicao");

            entity.Property(e => e.DataEntrada)
                .HasColumnType("date")
                .HasColumnName("data_entrada");

            entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

            entity.Property(e => e.IdTransacao).HasColumnName("id_transacao");

            entity.Property(e => e.Nota)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("nota");

            entity.HasOne(d => d.IdFuncionarioNavigation)
                .WithMany(p => p.Entrada)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Entradas__id_fun__59FA5E80");

            entity.HasOne(d => d.IdTransacaoNavigation)
                .WithMany(p => p.Entrada)
                .HasForeignKey(d => d.IdTransacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Entradas__id_tra__59063A47");
        });

        modelBuilder.Entity<Fornecedore>(entity =>
        {
            entity.HasKey(e => e.IdFornecedor)
                .HasName("PK__Forneced__6C477092D75AF5CD");

            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");

            entity.Property(e => e.Nome)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<FornecedoresCategoria>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("Fornecedores_Categorias");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

            entity.HasOne(d => d.IdCategoriaNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fornecedo__id_ca__3A81B327");

            entity.HasOne(d => d.IdFornecedorNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fornecedo__id_fo__398D8EEE");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario)
                .HasName("PK__Funciona__6FBD69C45922D40F");

            entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdDepartamentoNavigation)
                .WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Funcionar__id_de__4CA06362");
        });

        modelBuilder.Entity<Iten>(entity =>
        {
            entity.HasKey(e => e.IdItem)
                .HasName("PK__Itens__87C9438B7F895D57");

            entity.Property(e => e.IdItem).HasColumnName("id_item");

            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");

            entity.Property(e => e.Nome)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<ItensCategoria>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("Itens_Categorias");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

            entity.Property(e => e.IdItem).HasColumnName("id_item");

            entity.HasOne(d => d.IdCategoriaNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Itens_Cat__id_ca__47DBAE45");

            entity.HasOne(d => d.IdItemNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Itens_Cat__id_it__46E78A0C");
        });

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasKey(e => e.IdLote)
                .HasName("PK__Lotes__9A00048670755C62");

            entity.Property(e => e.IdLote).HasColumnName("id_lote");

            entity.Property(e => e.DataValidade)
                .HasColumnType("date")
                .HasColumnName("data_validade");

            entity.Property(e => e.IdEntrada).HasColumnName("id_entrada");

            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

            entity.Property(e => e.IdItem).HasColumnName("id_item");

            entity.Property(e => e.Localizacao)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("localizacao");

            entity.Property(e => e.PrecoUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preco_unitario");

            entity.Property(e => e.QuantidadeAtual).HasColumnName("quantidade_atual");

            entity.Property(e => e.QuantidadeEntrada).HasColumnName("quantidade_entrada");

            entity.HasOne(d => d.IdEntradaNavigation)
                .WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdEntrada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lotes__id_entrad__5CD6CB2B");

            entity.HasOne(d => d.IdFornecedorNavigation)
                .WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lotes__id_fornec__5EBF139D");

            entity.HasOne(d => d.IdItemNavigation)
                .WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lotes__id_item__5DCAEF64");
        });

        modelBuilder.Entity<Saida>(entity =>
        {
            entity.HasKey(e => e.IdSaida)
                .HasName("PK__Saidas__6F9AC3B4724E51F3");

            entity.Property(e => e.IdSaida).HasColumnName("id_saida");

            entity.Property(e => e.Condicao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("condicao");

            entity.Property(e => e.DataSaida)
                .HasColumnType("date")
                .HasColumnName("data_saida");

            entity.Property(e => e.IdFuncionarioReceptor).HasColumnName("id_funcionario_receptor");

            entity.Property(e => e.IdFuncionarioResponsavel).HasColumnName("id_funcionario_responsavel");

            entity.Property(e => e.IdLote).HasColumnName("id_lote");

            entity.Property(e => e.IdTransacao).HasColumnName("id_transacao");

            entity.Property(e => e.Nota)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("nota");

            entity.Property(e => e.QuantidadeSaida).HasColumnName("quantidade_saida");

            entity.HasOne(d => d.IdFuncionarioReceptorNavigation)
                .WithMany(p => p.SaidaIdFuncionarioReceptorNavigations)
                .HasForeignKey(d => d.IdFuncionarioReceptor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Saidas__id_funci__6477ECF3");

            entity.HasOne(d => d.IdFuncionarioResponsavelNavigation)
                .WithMany(p => p.SaidaIdFuncionarioResponsavelNavigations)
                .HasForeignKey(d => d.IdFuncionarioResponsavel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Saidas__id_funci__6383C8BA");

            entity.HasOne(d => d.IdLoteNavigation)
                .WithMany(p => p.Saida)
                .HasForeignKey(d => d.IdLote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Saidas__id_lote__628FA481");

            entity.HasOne(d => d.IdTransacaoNavigation)
                .WithMany(p => p.Saida)
                .HasForeignKey(d => d.IdTransacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Saidas__id_trans__619B8048");
        });

        modelBuilder.Entity<TelefonesFornecedor>(entity =>
        {
            entity.HasKey(e => e.IdTelefone)
                .HasName("PK__Telefone__28CD6834DD66F230");

            entity.ToTable("Telefones_Fornecedor");

            entity.Property(e => e.IdTelefone).HasColumnName("id_telefone");

            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone");

            entity.HasOne(d => d.IdFornecedorNavigation)
                .WithMany(p => p.TelefonesFornecedors)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Telefones__id_fo__403A8C7D");
        });

        modelBuilder.Entity<TelefonesFuncionario>(entity =>
        {
            entity.HasKey(e => e.IdTelefone)
                .HasName("PK__Telefone__28CD68344465013D");

            entity.ToTable("Telefones_Funcionario");

            entity.Property(e => e.IdTelefone).HasColumnName("id_telefone");

            entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone");

            entity.HasOne(d => d.IdFuncionarioNavigation)
                .WithMany(p => p.TelefonesFuncionarios)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Telefones__id_fu__4F7CD00D");
        });

        modelBuilder.Entity<Transaco>(entity =>
        {
            entity.HasKey(e => e.IdTransacao)
                .HasName("PK__Transaco__0FBBF773C9520717");

            entity.Property(e => e.IdTransacao).HasColumnName("id_transacao");

            entity.Property(e => e.DataTransacao)
                .HasColumnType("date")
                .HasColumnName("data_transacao");

            entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

            entity.Property(e => e.Motivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("motivo");

            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdFuncionarioNavigation)
                .WithMany(p => p.Transacos)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacoe__id_fu__5535A963");
        });

        //OnModelCreatingPartial(modelBuilder);
        //

        base.OnModelCreating(modelBuilder);
    }
}
