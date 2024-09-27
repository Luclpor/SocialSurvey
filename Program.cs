
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
            // ���������, ��� ���� ������ �������
            context.Database.EnsureCreated();

            // ��������, ���� �� ��� ������
            if (context.Surveys.Any())
            {
                return; // ���� ������ ��� �������� ������
            }

            // �������� �������� ������
            var survey1 = new Survey
            {
                Title = "������ � ��������",
                Description = "���� �������� - ��� ���������.",
                CreatedDate = DateTime.Now
            };

            var question1 = new Question
            {
                Text = "��� �� ���������� ���� ��������?",
            };

            var question2 = new Question
            {
                Text = "������� ��� � ������ �� ����������� �������?",
            };

            var answer1 = new Answer
            {
                Text = "�������"
            };

            var answer2 = new Answer
            {
                Text = "������"
            };

            var answer3 = new Answer
            {
                Text = "�������"
            };

            var answer4 = new Answer
            {
                Text = "�����"
            };

            // ����� �������� � ��������
            question1.QuestionAnswers = new List<QuestionAnswer>
        {
            new QuestionAnswer { Question = question1, Answer = answer1 },
            new QuestionAnswer { Question = question1, Answer = answer2 },
            new QuestionAnswer { Question = question1, Answer = answer3 },
            new QuestionAnswer { Question = question1, Answer = answer4 },
        };

            // ����� �������� � �������
            survey1.SurveyQuestions = new List<SurveyQuestion>
        {
            new SurveyQuestion { Survey = survey1, Question = question1, Order = 1 },
            new SurveyQuestion { Survey = survey1, Question = question2, Order = 2 }
        };

            // ��������� ������, ������� � ������ � ��������
            context.Surveys.Add(survey1);
            context.Questions.Add(question1);
            context.Questions.Add(question2);
            context.Answers.Add(answer1);
            context.Answers.Add(answer2);
            context.Answers.Add(answer3);
            context.Answers.Add(answer4);

            // ���������� ��������� � ���� ������
            context.SaveChanges();
        }

    }

    

}
