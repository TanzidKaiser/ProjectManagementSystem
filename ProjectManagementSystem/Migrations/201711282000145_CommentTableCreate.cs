namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentTableCreate : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Project_tbl", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Task_tbl", t => t.TaskID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment_tbl", "TaskID", "dbo.Task_tbl");
            DropForeignKey("dbo.Comment_tbl", "ProjectID", "dbo.Project_tbl");
            DropIndex("dbo.Comment_tbl", new[] { "TaskID" });
            DropIndex("dbo.Comment_tbl", new[] { "ProjectID" });
            DropTable("dbo.Comment_tbl");
        }
    }
}
