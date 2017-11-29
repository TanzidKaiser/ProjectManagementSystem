namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userTblCreate : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.user_tbl");
        }
    }
}
