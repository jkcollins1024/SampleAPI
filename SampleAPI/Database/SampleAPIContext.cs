using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAPI.Domains.Surveys.Entities;
using System.Reflection.Metadata;

namespace SampleAPI.Database
{
    public class SampleAPIContext : DbContext
    {
        public SampleAPIContext(DbContextOptions<SampleAPIContext> options) : base(options) { }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyParticipant> SurveyParticipants { get; set;}
        public DbSet<ParticipantResponse> ParticipantResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SurveysConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SurveyQuestionsConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SurveyParticipantsConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ParticipantResponsesConfiguration).Assembly);
        }
    }

    //configuration can be put in separate file - leaving here for now for ease
    public class SurveysConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder
                .HasMany(s => s.Participants)
                .WithOne(p => p.Survey)
                .HasForeignKey(p => p.SurveyId);

            builder
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyId);
        }
    }

    public class SurveyQuestionsConfiguration : IEntityTypeConfiguration<SurveyQuestion>
    {
        public void Configure(EntityTypeBuilder<SurveyQuestion> builder)
        {
            builder
                .HasOne(q => q.Survey)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SurveyId);

            builder
                .HasMany(q => q.Responses)
                .WithOne(r => r.Question)
                .HasForeignKey(r => r.SurveyQuestionId);
        }
    }

    public class SurveyParticipantsConfiguration : IEntityTypeConfiguration<SurveyParticipant>
    {
        public void Configure(EntityTypeBuilder<SurveyParticipant> builder)
        {
            builder
                .HasOne(p => p.Survey)
                .WithMany(s => s.Participants)
                .HasForeignKey(p => p.SurveyId);

            builder
                .HasMany(p => p.Responses)
                .WithOne(r => r.Participant)
                .HasForeignKey(r => r.SurveyParticipantId);
        }
    }

    public class ParticipantResponsesConfiguration : IEntityTypeConfiguration<ParticipantResponse>
    {
        public void Configure(EntityTypeBuilder<ParticipantResponse> builder)
        {
            builder
                .HasOne(r => r.Question)
                .WithMany(q => q.Responses)
                .HasForeignKey(r => r.SurveyQuestionId);

            builder
                .HasOne(r => r.Participant)
                .WithMany(p => p.Responses)
                .HasForeignKey(r => r.SurveyParticipantId);
        }
    }
}
