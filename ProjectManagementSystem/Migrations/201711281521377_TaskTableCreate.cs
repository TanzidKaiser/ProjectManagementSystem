namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskTableCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task_tbl",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        TaskDescription = c.String(),
                        TaskDueDate = c.String(),
                        Priority = c.String(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Project_tbl", t => t.ProjectID, cascadeDelete: false)
                .ForeignKey("dbo.user_tbl", t => t.UserID, cascadeDelete: false)
                .Index(t => t.ProjectID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task_tbl", "UserID", "dbo.user_tbl");
            DropForeignKey("dbo.Task_tbl", "ProjectID", "dbo.Project_tbl");
            DropIndex("dbo.Task_tbl", new[] { "UserID" });
            DropIndex("dbo.Task_tbl", new[] { "ProjectID" });
            DropTable("dbo.Task_tbl");
        }
    }
}
