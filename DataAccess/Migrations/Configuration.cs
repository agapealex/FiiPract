namespace DataAccess.Migrations
{
    using DataAccess.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    // o migrare este o clasa c# care e folosita pt a crea tabela in baza de date

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //populam baza de date din cod si evita duplicatele
        protected override void Seed(DataAccess.Context.ApplicationDbContext context)
        {
            var locality1 = new Locality
            {
                LocalityName = "Buftea",
                County = "Ifov",
                Latitude = 44M,
                Longitude = 25M,
            };
            var locality2 = new Locality
            {
                LocalityName = "Buciumeni",
                County = "Ifov",
                Latitude = 44M,
                Longitude = 25M,
            };


            var person1 = new TablePerson
            {
                FirstName = "George",
                LastName = "Macovei",
                Email = "george_macovei@gmail.com",
                DateOfBirth = DateTime.Now,
                PhotoPath = "223.jpg",
                IsDeleted = false,
                LocalityId = 1,
                TestResult = 0
            };
            var person2 = new TablePerson
            {
                FirstName = "Ana",
                LastName = "Macovei",
                Email = "ana_macovei@gmail.com",
                DateOfBirth = DateTime.Now,
                PhotoPath = "default.jpg",
                IsDeleted = false,
                LocalityId = 2,
                TestResult = 0
            };

            var person3 = new TablePerson
            {
                FirstName = "Raed",
                LastName = "Gorgiu",
                Email = "raed@gmail.com",
                DateOfBirth = DateTime.Now,
                PhotoPath = "default.jpg",
                IsDeleted = false,
                LocalityId = 2,
                TestResult = 0
            };
            var question1 = new Question
            {
                QuestionId = Guid.NewGuid(),
                Sentence = "Cate continente are Terra?",
                AnswerA = "5",
                AnswerB = "7",
                AnswerC = "3",
                CorrectAnswer = "B"
            };
            var question2 = new Question
            {
                QuestionId = Guid.NewGuid(),
                Sentence = "Cate degete are o mana?",
                AnswerA = "5",
                AnswerB = "7",
                AnswerC = "3",
                CorrectAnswer = "A"
            };
            var question3 = new Question
            {
                QuestionId = Guid.NewGuid(),
                Sentence = "Cate oceance are Terra?",
                AnswerA = "5",
                AnswerB = "7",
                AnswerC = "3",
                CorrectAnswer = "A"
            };

            context.Localities.Add(locality1);
            context.Localities.Add(locality2);
            context.TablePersons.Add(person1);
            context.TablePersons.Add(person2);
            context.TablePersons.Add(person3);
            context.Questions.Add(question1);
            context.Questions.Add(question2);
            context.Questions.Add(question3);
        }
    }
}
