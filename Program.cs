
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SocialSurvey.Context;
using SocialSurvey.Models;
using SocialSurvey.Repository;

namespace SocialSurvey
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("SocialSurvey")!;
            // Add services to the container.
            builder.Services.AddDbContext<SurveySocialDbContext>(o => o.UseSqlServer(connectionString));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepositoryContext, RepositoryContext>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SurveySocialDbContext>();
                //Initialize(context);
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();
            app.Run();
        }
        public static void Initialize(SurveySocialDbContext context)
        {
            // Убедитесь, что база данных создана
            context.Database.EnsureCreated();

            // Проверка, есть ли уже данные
            if (context.Surveys.Any())
            {
                return; // База данных уже содержит данные
            }

            // Создание тестовых данных
            var survey1 = new Survey
            {
                Title = "Анкета о здоровье",
                Description = "Ваше здоровье - наш приоритет.",
                CreatedDate = DateTime.Now
            };

            var question1 = new Question
            {
                Text = "Как вы оцениваете свое здоровье?",
            };

            var question2 = new Question
            {
                Text = "Сколько раз в неделю вы занимаетесь спортом?",
            };

            var answer1 = new Answer
            {
                Text = "Отлично"
            };

            var answer2 = new Answer
            {
                Text = "Хорошо"
            };

            var answer3 = new Answer
            {
                Text = "Неплохо"
            };

            var answer4 = new Answer
            {
                Text = "Плохо"
            };

            // Связь вопросов с ответами
            question1.QuestionAnswers = new List<QuestionAnswer>
        {
            new QuestionAnswer { Question = question1, Answer = answer1 },
            new QuestionAnswer { Question = question1, Answer = answer2 },
            new QuestionAnswer { Question = question1, Answer = answer3 },
            new QuestionAnswer { Question = question1, Answer = answer4 },
        };

            // Связь вопросов с анкетой
            survey1.SurveyQuestions = new List<SurveyQuestion>
        {
            new SurveyQuestion { Survey = survey1, Question = question1, Order = 1 },
            new SurveyQuestion { Survey = survey1, Question = question2, Order = 2 }
        };

            // Добавляем анкеты, вопросы и ответы в контекст
            context.Surveys.Add(survey1);
            context.Questions.Add(question1);
            context.Questions.Add(question2);
            context.Answers.Add(answer1);
            context.Answers.Add(answer2);
            context.Answers.Add(answer3);
            context.Answers.Add(answer4);

            // Сохранение изменений в базе данных
            context.SaveChanges();
        }

    }

    

}
