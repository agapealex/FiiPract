namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Locality_Question_TablePerson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalityName = c.String(nullable: false),
                        County = c.String(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 8, scale: 4),
                        Longitude = c.Decimal(nullable: false, precision: 8, scale: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Guid(nullable: false),
                        Sentence = c.String(nullable: false),
                        AnswerA = c.String(nullable: false),
                        AnswerB = c.String(nullable: false),
                        AnswerC = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.TablePersons",
                c => new
                    {
                        TablePersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhotoPath = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        LocalityId = c.Int(),
                        TestResult = c.Double(),
                    })
                .PrimaryKey(t => t.TablePersonId);
            
            CreateTable(
                "dbo.TablePersonsToQuestions",
                c => new
                    {
                        TablePersonId = c.Int(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TablePersonId, t.QuestionId })
                .ForeignKey("dbo.TablePersons", t => t.TablePersonId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.TablePersonId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TablePersonsToQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.TablePersonsToQuestions", "TablePersonId", "dbo.TablePersons");
            DropIndex("dbo.TablePersonsToQuestions", new[] { "QuestionId" });
            DropIndex("dbo.TablePersonsToQuestions", new[] { "TablePersonId" });
            DropTable("dbo.TablePersonsToQuestions");
            DropTable("dbo.TablePersons");
            DropTable("dbo.Questions");
            DropTable("dbo.Localities");
        }
    }
}
