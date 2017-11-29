namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignProjectToUserTblCreate : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignProject_tbl", "UserID", "dbo.user_tbl");
            DropForeignKey("dbo.AssignProject_tbl", "ProjectID", "dbo.Project_tbl");
            DropIndex("dbo.AssignProject_tbl", new[] { "ProjectID" });
            DropIndex("dbo.AssignProject_tbl", new[] { "UserID" });
            DropTable("dbo.AssignProject_tbl");
        }
    }
}
