namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Swipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpAddress = c.String(),
                        StudentId = c.String(),
                        EventTime = c.DateTime(nullable: false),
                        Direction = c.String(),
                        Terminal_IP = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Terminals", t => t.Terminal_IP)
                .Index(t => t.Terminal_IP);
            
            CreateTable(
                "dbo.Terminals",
                c => new
                    {
                        IP = c.String(nullable: false, maxLength: 128),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.IP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Swipes", "Terminal_IP", "dbo.Terminals");
            DropIndex("dbo.Swipes", new[] { "Terminal_IP" });
            DropTable("dbo.Terminals");
            DropTable("dbo.Swipes");
        }
    }
}
