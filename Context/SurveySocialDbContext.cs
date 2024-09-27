using Microsoft.EntityFrameworkCore;
using SocialSurvey.Models;

namespace SocialSurvey.Context
{
    public class SurveySocialDbContext : DbContext
    {
        public SurveySocialDbContext(DbContextOptions<SurveySocialDbContext> options) : base(options) {  }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация промежуточной таблицы SurveyQuestion
            modelBuilder.Entity<SurveyQuestion>()
                .HasKey(sq => new { sq.SurveyId, sq.QuestionId });

            modelBuilder.Entity<SurveyQuestion>()
                .HasOne(sq => sq.Survey)
                .WithMany(s => s.SurveyQuestions)
                .HasForeignKey(sq => sq.SurveyId);

            modelBuilder.Entity<SurveyQuestion>()
                .HasOne(sq => sq.Question)
                .WithMany(q => q.SurveyQuestions)
                .HasForeignKey(sq => sq.QuestionId);

            // Конфигурация промежуточной таблицы QuestionAnswer
            modelBuilder.Entity<QuestionAnswer>()
                .HasKey(qa => new { qa.QuestionId, qa.AnswerId });

            modelBuilder.Entity<QuestionAnswer>()
                .HasOne(qa => qa.Question)
                .WithMany(q => q.QuestionAnswers)
                .HasForeignKey(qa => qa.QuestionId);

            modelBuilder.Entity<QuestionAnswer>()
                .HasOne(qa => qa.Answer)
                .WithMany(a => a.QuestionAnswers)
                .HasForeignKey(qa => qa.AnswerId);

            // Конфигурация отношений Result с Interview, Question и Answer
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Interview)
                .WithMany(i => i.Results)
                .HasForeignKey(r => r.InterviewId);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Question)
                .WithMany(q => q.Results)
                .HasForeignKey(r => r.QuestionId);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Answer)
                .WithMany(a => a.Results)
                .HasForeignKey(r => r.AnswerId)
                .IsRequired(false); // AnswerId может быть null для текстовых вопросов

            modelBuilder.Entity<Survey>().HasData(
           new Survey { Id = 1, Title = "Анкета о здоровье", Description = "Ваше здоровье - наш приоритет.", CreatedDate = DateTime.Now },
           new Survey { Id =2, Title = "Анкета о спорте", Description="Спортивная нация.", CreatedDate= DateTime.Now}
       );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "Как вы оцениваете свое здоровье?" },
                new Question { Id = 2, Text = "Вы любите сладкое?" },
                new Question { Id = 3, Text = "Сколько раз в неделю вы занимаетесь спортом?" }
            );

            modelBuilder.Entity<Answer>().HasData(
                new Answer { Id = 1, Text = "Отлично" },
                new Answer { Id = 2, Text = "Хорошо" },
                new Answer { Id = 3, Text = "Неплохо" },
                new Answer { Id = 4, Text = "Плохо" }
            );
            modelBuilder.Entity<Answer>().HasData(
                new Answer { Id = 5, Text = "1 раз" },
                new Answer { Id = 6, Text = "2 раза" },
                new Answer { Id = 7, Text = "3 раза" },
                new Answer { Id = 8, Text = "4 раза" }
            );
            modelBuilder.Entity<Answer>().HasData(
                new Answer { Id = 9, Text = "да" },
                new Answer { Id = 10, Text = "немного" },
                new Answer { Id = 11, Text = "обожаю" },
                new Answer { Id = 12, Text = "нет" }
            );

            modelBuilder.Entity<SurveyQuestion>().HasData(
                new SurveyQuestion { SurveyId = 1, QuestionId = 1, Order = 1 },
                new SurveyQuestion { SurveyId = 1, QuestionId = 2, Order = 2 },
                new SurveyQuestion { SurveyId = 2, QuestionId = 3, Order = 1 }
            );

            modelBuilder.Entity<QuestionAnswer>().HasData(
                new QuestionAnswer { QuestionId = 1, AnswerId = 1 },
                new QuestionAnswer { QuestionId = 1, AnswerId = 2 },
                new QuestionAnswer { QuestionId = 1, AnswerId = 3 },
                new QuestionAnswer { QuestionId = 1, AnswerId = 4 }
            );
            modelBuilder.Entity<QuestionAnswer>().HasData(
                new QuestionAnswer { QuestionId = 3, AnswerId = 5 },
                new QuestionAnswer { QuestionId = 3, AnswerId = 6 },
                new QuestionAnswer { QuestionId = 3, AnswerId = 7 },
                new QuestionAnswer { QuestionId = 3, AnswerId = 8 }
            );
            modelBuilder.Entity<QuestionAnswer>().HasData(
                new QuestionAnswer { QuestionId = 2, AnswerId = 9 },
                new QuestionAnswer { QuestionId = 2, AnswerId = 10 },
                new QuestionAnswer { QuestionId = 2, AnswerId = 11 },
                new QuestionAnswer { QuestionId = 2, AnswerId = 12 }
            );
        }
    }
}
