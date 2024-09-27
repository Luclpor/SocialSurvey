﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialSurvey.Context;

#nullable disable

namespace SocialSurvey.Migrations
{
    [DbContext(typeof(SurveySocialDbContext))]
    [Migration("20240927124723_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialSurvey.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Text")
                        .IsUnique();

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "Отлично"
                        },
                        new
                        {
                            Id = 2,
                            Text = "Хорошо"
                        },
                        new
                        {
                            Id = 3,
                            Text = "Неплохо"
                        },
                        new
                        {
                            Id = 4,
                            Text = "Плохо"
                        },
                        new
                        {
                            Id = 5,
                            Text = "1 раз"
                        },
                        new
                        {
                            Id = 6,
                            Text = "2 раза"
                        },
                        new
                        {
                            Id = 7,
                            Text = "3 раза"
                        },
                        new
                        {
                            Id = 8,
                            Text = "4 раза"
                        },
                        new
                        {
                            Id = 9,
                            Text = "да"
                        },
                        new
                        {
                            Id = 10,
                            Text = "немного"
                        },
                        new
                        {
                            Id = 11,
                            Text = "обожаю"
                        },
                        new
                        {
                            Id = 12,
                            Text = "нет"
                        });
                });

            modelBuilder.Entity("SocialSurvey.Models.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("SocialSurvey.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "Как вы оцениваете свое здоровье?"
                        },
                        new
                        {
                            Id = 2,
                            Text = "Вы любите сладкое?"
                        },
                        new
                        {
                            Id = 3,
                            Text = "Сколько раз в неделю вы занимаетесь спортом?"
                        });
                });

            modelBuilder.Entity("SocialSurvey.Models.QuestionAnswer", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId", "AnswerId");

                    b.HasIndex("AnswerId");

                    b.ToTable("QuestionAnswers");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            AnswerId = 1
                        },
                        new
                        {
                            QuestionId = 1,
                            AnswerId = 2
                        },
                        new
                        {
                            QuestionId = 1,
                            AnswerId = 3
                        },
                        new
                        {
                            QuestionId = 1,
                            AnswerId = 4
                        },
                        new
                        {
                            QuestionId = 3,
                            AnswerId = 5
                        },
                        new
                        {
                            QuestionId = 3,
                            AnswerId = 6
                        },
                        new
                        {
                            QuestionId = 3,
                            AnswerId = 7
                        },
                        new
                        {
                            QuestionId = 3,
                            AnswerId = 8
                        },
                        new
                        {
                            QuestionId = 2,
                            AnswerId = 9
                        },
                        new
                        {
                            QuestionId = 2,
                            AnswerId = 10
                        },
                        new
                        {
                            QuestionId = 2,
                            AnswerId = 11
                        },
                        new
                        {
                            QuestionId = 2,
                            AnswerId = 12
                        });
                });

            modelBuilder.Entity("SocialSurvey.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("InterviewId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("InterviewId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("SocialSurvey.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 9, 27, 15, 47, 23, 397, DateTimeKind.Local).AddTicks(4406),
                            Description = "Ваше здоровье - наш приоритет.",
                            Title = "Анкета о здоровье"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 9, 27, 15, 47, 23, 397, DateTimeKind.Local).AddTicks(4415),
                            Description = "Спортивная нация.",
                            Title = "Анкета о спорте"
                        });
                });

            modelBuilder.Entity("SocialSurvey.Models.SurveyQuestion", b =>
                {
                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("SurveyId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("SurveyQuestions");

                    b.HasData(
                        new
                        {
                            SurveyId = 1,
                            QuestionId = 1,
                            Order = 1
                        },
                        new
                        {
                            SurveyId = 1,
                            QuestionId = 2,
                            Order = 2
                        },
                        new
                        {
                            SurveyId = 2,
                            QuestionId = 3,
                            Order = 1
                        });
                });

            modelBuilder.Entity("SocialSurvey.Models.Interview", b =>
                {
                    b.HasOne("SocialSurvey.Models.Survey", null)
                        .WithMany("Interviews")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialSurvey.Models.QuestionAnswer", b =>
                {
                    b.HasOne("SocialSurvey.Models.Answer", "Answer")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialSurvey.Models.Question", "Question")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SocialSurvey.Models.Result", b =>
                {
                    b.HasOne("SocialSurvey.Models.Answer", "Answer")
                        .WithMany("Results")
                        .HasForeignKey("AnswerId");

                    b.HasOne("SocialSurvey.Models.Interview", "Interview")
                        .WithMany("Results")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialSurvey.Models.Question", "Question")
                        .WithMany("Results")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Interview");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SocialSurvey.Models.SurveyQuestion", b =>
                {
                    b.HasOne("SocialSurvey.Models.Question", "Question")
                        .WithMany("SurveyQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialSurvey.Models.Survey", "Survey")
                        .WithMany("SurveyQuestions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("SocialSurvey.Models.Answer", b =>
                {
                    b.Navigation("QuestionAnswers");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("SocialSurvey.Models.Interview", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("SocialSurvey.Models.Question", b =>
                {
                    b.Navigation("QuestionAnswers");

                    b.Navigation("Results");

                    b.Navigation("SurveyQuestions");
                });

            modelBuilder.Entity("SocialSurvey.Models.Survey", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("SurveyQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
