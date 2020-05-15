namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chang_modify_TestResult_TablePerson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TablePersons", "TestResult", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TablePersons", "TestResult", c => c.Int(nullable: false));
        }
    }
}
