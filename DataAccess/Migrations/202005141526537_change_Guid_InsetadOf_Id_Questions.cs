namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_Guid_InsetadOf_Id_Questions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TablePersonsToQuestions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.TablePersonsToQuestions", new[] { "QuestionId" });
            DropPrimaryKey("dbo.Questions");
            DropPrimaryKey("dbo.TablePersonsToQuestions");
            AlterColumn("dbo.Questions", "QuestionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.TablePersonsToQuestions", "QuestionId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Questions", "QuestionId");
            AddPrimaryKey("dbo.TablePersonsToQuestions", new[] { "TablePersonId", "QuestionId" });
            CreateIndex("dbo.TablePersonsToQuestions", "QuestionId");
            AddForeignKey("dbo.TablePersonsToQuestions", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TablePersonsToQuestions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.TablePersonsToQuestions", new[] { "QuestionId" });
            DropPrimaryKey("dbo.TablePersonsToQuestions");
            DropPrimaryKey("dbo.Questions");
            AlterColumn("dbo.TablePersonsToQuestions", "QuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "QuestionId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TablePersonsToQuestions", new[] { "TablePersonId", "QuestionId" });
            AddPrimaryKey("dbo.Questions", "QuestionId");
            CreateIndex("dbo.TablePersonsToQuestions", "QuestionId");
            AddForeignKey("dbo.TablePersonsToQuestions", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}
