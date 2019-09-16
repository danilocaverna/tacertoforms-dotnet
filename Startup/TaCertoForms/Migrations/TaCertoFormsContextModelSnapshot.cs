﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaCertoForms.Models;

namespace TaCertoForms.Migrations
{
    [DbContext(typeof(TaCertoFormsContext))]
    partial class TaCertoFormsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("TaCertoForms")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaCertoForms.Models.Atividade", b =>
                {
                    b.Property<int>("IdAtividade")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataFim");

                    b.Property<string>("DataInicio");

                    b.Property<int>("IdTurmaDisciplinaProfessor");

                    b.Property<bool>("IsAleatorio");

                    b.Property<bool>("IsProva");

                    b.Property<int>("NumeroTentativas");

                    b.HasKey("IdAtividade");

                    b.ToTable("Atividade");
                });

            modelBuilder.Entity("TaCertoForms.Models.AtividadeRespostaAluno", b =>
                {
                    b.Property<int>("IdAtividadeRespostaAluno")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataEnvio");

                    b.Property<int>("IdAluno");

                    b.Property<int>("IdAtividade");

                    b.Property<float>("Nota");

                    b.Property<string>("TempoTotal");

                    b.HasKey("IdAtividadeRespostaAluno");

                    b.ToTable("AtividadeRespostaAluno");
                });

            modelBuilder.Entity("TaCertoForms.Models.Disciplina", b =>
                {
                    b.Property<int>("IdDisciplina")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("IdDisciplina");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("TaCertoForms.Models.DisciplinaProfessor", b =>
                {
                    b.Property<int>("IdDisciplinaProfessor")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDisciplina");

                    b.Property<int>("IdPessoa");

                    b.HasKey("IdDisciplinaProfessor");

                    b.ToTable("DisciplinaProfessor");
                });

            modelBuilder.Entity("TaCertoForms.Models.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<string>("Numero");

                    b.Property<string>("Pais");

                    b.Property<string>("Rua");

                    b.Property<string>("UF");

                    b.HasKey("IdEndereco");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("TaCertoForms.Models.Instituicao", b =>
                {
                    b.Property<int>("IdInstituicao")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ");

                    b.Property<int>("IdEnderecoCobranca");

                    b.Property<int>("IdEnderecoPrincipal");

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial");

                    b.HasKey("IdInstituicao");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("TaCertoForms.Models.Licenca", b =>
                {
                    b.Property<int>("IdLicenca")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdInstituicao");

                    b.Property<int>("NumeroDeLinceca");

                    b.Property<string>("ValidadeLicenca");

                    b.HasKey("IdLicenca");

                    b.ToTable("Licenca");
                });

            modelBuilder.Entity("TaCertoForms.Models.LogLogin", b =>
                {
                    b.Property<int>("IdLogLoggin")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeviceId");

                    b.Property<string>("HoraAcesso");

                    b.Property<int>("IdPessoa");

                    b.Property<string>("Plataforma");

                    b.HasKey("IdLogLoggin");

                    b.ToTable("LogLogin");
                });

            modelBuilder.Entity("TaCertoForms.Models.Midia", b =>
                {
                    b.Property<int>("IdMidia")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho");

                    b.Property<string>("Extensao");

                    b.Property<int>("IdEntidade");

                    b.Property<int>("Ordem");

                    b.Property<string>("TipoEntidade");

                    b.HasKey("IdMidia");

                    b.ToTable("Midia");
                });

            modelBuilder.Entity("TaCertoForms.Models.Perfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("TaCertoForms.Models.PerfilPessoa", b =>
                {
                    b.Property<int>("IdPerfilPessoa")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPerfil");

                    b.Property<int>("IdPessoa");

                    b.HasKey("IdPerfilPessoa");

                    b.ToTable("PerfilPessoa");
                });

            modelBuilder.Entity("TaCertoForms.Models.Pessoa", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<string>("Email");

                    b.Property<int>("IdInstituicao");

                    b.Property<int>("IdPessoaLicenca");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("IdPessoa");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("TaCertoForms.Models.PessoaLicenca", b =>
                {
                    b.Property<int>("IdPessoaLicenca")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdLicenca");

                    b.Property<int>("IdPessoa");

                    b.Property<bool>("IsAtivo");

                    b.HasKey("IdPessoaLicenca");

                    b.ToTable("PessoaLicenca");
                });

            modelBuilder.Entity("TaCertoForms.Models.Questao", b =>
                {
                    b.Property<int>("IdQuestao")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Enunciado");

                    b.Property<int>("IdAtividade");

                    b.Property<int>("IdTipoQuestao");

                    b.Property<string>("JsonQuestao");

                    b.Property<int>("PesoNota");

                    b.Property<string>("Titulo");

                    b.HasKey("IdQuestao");

                    b.ToTable("Questao");
                });

            modelBuilder.Entity("TaCertoForms.Models.QuestaoRespostaAluno", b =>
                {
                    b.Property<int>("IdQuestaoRespostaAluno")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAtividadeRespostaAluno");

                    b.Property<int>("IdQuestao");

                    b.Property<string>("JsonResposta");

                    b.Property<float>("Nota");

                    b.Property<int>("NumAcerto");

                    b.Property<int>("NumErro");

                    b.Property<string>("Tempo");

                    b.HasKey("IdQuestaoRespostaAluno");

                    b.ToTable("QuestaoRespostaAluno");
                });

            modelBuilder.Entity("TaCertoForms.Models.TipoQuestao", b =>
                {
                    b.Property<int>("IdTipoQuestao")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("IdTipoQuestao");

                    b.ToTable("TipoQuestao");
                });

            modelBuilder.Entity("TaCertoForms.Models.Turma", b =>
                {
                    b.Property<int>("IdTurma")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano");

                    b.Property<int>("IdInstituicao");

                    b.Property<string>("Periodo");

                    b.Property<string>("Serie");

                    b.HasKey("IdTurma");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("TaCertoForms.Models.TurmaAluno", b =>
                {
                    b.Property<int>("IdTurmaAluno")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPessoa");

                    b.Property<int>("IdTurma");

                    b.HasKey("IdTurmaAluno");

                    b.ToTable("TurmaAluno");
                });

            modelBuilder.Entity("TaCertoForms.Models.TurmaDisciplinaProfessor", b =>
                {
                    b.Property<int>("IdTurmaDisciplinaProfessor")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDisciplinaProfessor");

                    b.Property<int>("IdTurma");

                    b.HasKey("IdTurmaDisciplinaProfessor");

                    b.ToTable("TurmaDisciplinaProfessor");
                });
#pragma warning restore 612, 618
        }
    }
}
