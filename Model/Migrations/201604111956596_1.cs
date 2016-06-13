namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.tblRaceEthnicity", "ApplicationId", "dbo.tblParticipant");
            //DropIndex("dbo.tblRaceEthnicity", new[] { "ApplicationId" });
            //CreateTable(
            //    "dbo.AppEthnicities",
            //    c => new
            //        {
            //            ApplicationId = c.Int(nullable: false),
            //            EthnicityId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.ApplicationId, t.EthnicityId })
            //    .ForeignKey("dbo.tblParticipant", t => t.ApplicationId, cascadeDelete: true)
            //    .ForeignKey("dbo.tblRaceEthnicity", t => t.EthnicityId, cascadeDelete: true)
            //    .Index(t => t.ApplicationId)
            //    .Index(t => t.EthnicityId);
            
            //DropColumn("dbo.tblRaceEthnicity", "ApplicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblRaceEthnicity", "ApplicationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AppEthnicities", "EthnicityId", "dbo.tblRaceEthnicity");
            DropForeignKey("dbo.AppEthnicities", "ApplicationId", "dbo.tblParticipant");
            DropIndex("dbo.AppEthnicities", new[] { "EthnicityId" });
            DropIndex("dbo.AppEthnicities", new[] { "ApplicationId" });
            DropTable("dbo.AppEthnicities");
            CreateIndex("dbo.tblRaceEthnicity", "ApplicationId");
            AddForeignKey("dbo.tblRaceEthnicity", "ApplicationId", "dbo.tblParticipant", "ID");
        }
    }
}
