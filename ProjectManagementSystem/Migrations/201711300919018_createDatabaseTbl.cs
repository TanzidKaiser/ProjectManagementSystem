namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDatabaseTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignProject_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project_tbl", t => t.ProjectID, cascadeDelete: false)
                .ForeignKey("dbo.user_tbl", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Project_tbl",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectCode = c.String(),
                        Description = c.String(),
                        ProjectStartDate = c.String(),
                        ProjectEndDate = c.String(),
                        ProjectDurationDays = c.String(),
                        file = c.Binary(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.Comment_tbl",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        TaskID = c.Int(nullable: false),
                        Description = c.String(),
                        CommentBy = c.String(),
                        DateTiem = c.String(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Project_tbl", t => t.ProjectID, cascadeDelete: false)
                .ForeignKey("dbo.Task_tbl", t => t.TaskID, cascadeDelete: false)
                .Index(t => t.ProjectID)
                .Index(t => t.TaskID);
            
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
                        AssignedBy = c.String(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Project_tbl", t => t.ProjectID, cascadeDelete: false)
                .ForeignKey("dbo.user_tbl", t => t.UserID, cascadeDelete: false)
                .Index(t => t.ProjectID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.user_tbl",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        Status = c.String(),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task_tbl", "UserID", "dbo.user_tbl");
            DropForeignKey("dbo.AssignProject_tbl", "UserID", "dbo.user_tbl");
            DropForeignKey("dbo.Task_tbl", "ProjectID", "dbo.Project_tbl");
            DropForeignKey("dbo.Comment_tbl", "TaskID", "dbo.Task_tbl");
            DropForeignKey("dbo.Comment_tbl", "ProjectID", "dbo.Project_tbl");
            DropForeignKey("dbo.AssignProject_tbl", "ProjectID", "dbo.Project_tbl");
            DropIndex("dbo.Task_tbl", new[] { "UserID" });
            DropIndex("dbo.Task_tbl", new[] { "ProjectID" });
            DropIndex("dbo.Comment_tbl", new[] { "TaskID" });
            DropIndex("dbo.Comment_tbl", new[] { "ProjectID" });
            DropIndex("dbo.AssignProject_tbl", new[] { "ProjectID" });
            DropIndex("dbo.AssignProject_tbl", new[] { "UserID" });
            DropTable("dbo.user_tbl");
            DropTable("dbo.Task_tbl");
            DropTable("dbo.Comment_tbl");
            DropTable("dbo.Project_tbl");
            DropTable("dbo.AssignProject_tbl");
        }
    }
}
