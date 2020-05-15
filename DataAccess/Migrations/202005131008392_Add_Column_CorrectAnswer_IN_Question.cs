namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Column_CorrectAnswer_IN_Question : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "CorrectAnswer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "CorrectAnswer");
        }
    }
}
