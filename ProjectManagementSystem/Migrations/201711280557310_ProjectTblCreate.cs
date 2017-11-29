namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectTblCreate : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Project_tbl");
        }
    }
}
