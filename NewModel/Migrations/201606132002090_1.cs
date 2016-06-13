namespace NewModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Application",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ParticipantId = c.String(nullable: false, maxLength: 13),
            //            OrgCode = c.String(nullable: false, maxLength: 8),
            //            TrainName = c.String(nullable: false, maxLength: 50),
            //            TrainDate = c.DateTime(nullable: false, storeType: "date"),
            //            CompA = c.Boolean(nullable: false),
            //            CompB = c.Boolean(nullable: false),
            //            CompC = c.Boolean(nullable: false),
            //            CompD = c.Boolean(nullable: false),
            //            Dob = c.DateTime(nullable: false, storeType: "date"),
            //            BirthCity = c.String(nullable: false, maxLength: 50),
            //            Ssn5 = c.String(nullable: false, maxLength: 5),
            //            Education = c.Int(nullable: false),
            //            Foreign = c.Int(nullable: false),
            //            AaEce = c.Boolean(nullable: false),
            //            AaEd = c.Boolean(nullable: false),
            //            AaBus = c.Boolean(nullable: false),
            //            AaOther = c.Boolean(nullable: false),
            //            BaEce = c.Boolean(nullable: false),
            //            BaEd = c.Boolean(nullable: false),
            //            BaBus = c.Boolean(nullable: false),
            //            BaOther = c.Boolean(nullable: false),
            //            MaEce = c.Boolean(nullable: false),
            //            MaEd = c.Boolean(nullable: false),
            //            MaBus = c.Boolean(nullable: false),
            //            MaOther = c.Boolean(nullable: false),
            //            DocEce = c.Boolean(nullable: false),
            //            DocEd = c.Boolean(nullable: false),
            //            DocBus = c.Boolean(nullable: false),
            //            DocOther = c.Boolean(nullable: false),
            //            Permit = c.Int(nullable: false),
            //            CredNone = c.Boolean(nullable: false),
            //            CredAdmin = c.Boolean(nullable: false),
            //            CredBilingual = c.Boolean(nullable: false),
            //            CredClinical = c.Boolean(nullable: false),
            //            CredEarly = c.Boolean(nullable: false),
            //            CredMultiple = c.Boolean(nullable: false),
            //            CredPupil = c.Boolean(nullable: false),
            //            CredReading = c.Boolean(nullable: false),
            //            CredSchool = c.Boolean(nullable: false),
            //            CredSingle = c.Boolean(nullable: false),
            //            CredSpec = c.Boolean(nullable: false),
            //            CredSpeech = c.Boolean(nullable: false),
            //            CredOther = c.Boolean(nullable: false),
            //            Setting = c.Int(nullable: false),
            //            SettingSpecify = c.String(maxLength: 50),
            //            Position = c.Int(nullable: false),
            //            PositionSpecify = c.String(maxLength: 50),
            //            FccPosition = c.Int(nullable: false),
            //            FccSpecify = c.String(maxLength: 50),
            //            WorkCity = c.String(nullable: false, maxLength: 50),
            //            WorkCounty = c.String(nullable: false, maxLength: 50),
            //            WorkZip = c.String(nullable: false, maxLength: 5),
            //            TenureEce = c.Int(nullable: false),
            //            TenureEmploy = c.Int(nullable: false),
            //            TenurePosition = c.Int(nullable: false),
            //            HoursWeek = c.Int(nullable: false),
            //            MonthsYear = c.Int(nullable: false),
            //            TotalKids = c.Int(nullable: false),
            //            LessThanOne = c.Int(nullable: false),
            //            OneYear = c.Int(nullable: false),
            //            TwoYears = c.Int(nullable: false),
            //            ThreeYears = c.Int(nullable: false),
            //            FourYears = c.Int(nullable: false),
            //            SchoolAge = c.Int(nullable: false),
            //            Dll = c.Int(nullable: false),
            //            IsfpIep = c.Int(nullable: false),
            //            ZeroToThirtySixMonths = c.Int(nullable: false),
            //            SalaryHour = c.Decimal(precision: 18, scale: 2),
            //            SalaryMonth = c.Decimal(precision: 18, scale: 2),
            //            SalaryYear = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Gender = c.String(nullable: false, maxLength: 6),
            //            Race = c.Int(nullable: false),
            //            RaceSpecify = c.String(maxLength: 50),
            //            PlEnglish = c.Boolean(nullable: false),
            //            PlMandarin = c.Boolean(nullable: false),
            //            PlRussian = c.Boolean(nullable: false),
            //            PlSpanish = c.Boolean(nullable: false),
            //            PlTagalog = c.Boolean(nullable: false),
            //            PlViet = c.Boolean(nullable: false),
            //            PlHmong = c.Boolean(nullable: false),
            //            PlOther = c.Boolean(nullable: false),
            //            PlSpecify = c.String(maxLength: 50),
            //            FlEnglish = c.Boolean(nullable: false),
            //            FlMandarin = c.Boolean(nullable: false),
            //            FlRussian = c.Boolean(nullable: false),
            //            FlSpanish = c.Boolean(nullable: false),
            //            FlTagalog = c.Boolean(nullable: false),
            //            FlViet = c.Boolean(nullable: false),
            //            FlHmong = c.Boolean(nullable: false),
            //            FlOther = c.Boolean(nullable: false),
            //            FlSpecify = c.String(maxLength: 50),
            //            Registry = c.Boolean(nullable: false),
            //            RegistryId = c.String(nullable: false, maxLength: 9),
            //            FirstName = c.String(nullable: false, maxLength: 50),
            //            LastName = c.String(nullable: false, maxLength: 50),
            //            MailingAddress = c.String(nullable: false, maxLength: 50),
            //            MailingCity = c.String(nullable: false, maxLength: 50),
            //            MailingState = c.String(nullable: false, maxLength: 50),
            //            MailingZip = c.String(nullable: false, maxLength: 5),
            //            Email = c.String(nullable: false, maxLength: 50),
            //            HomePhone = c.String(nullable: false, maxLength: 50),
            //            WorkPhone = c.String(nullable: false, maxLength: 50),
            //            CellPhone = c.String(maxLength: 50),
            //            EmployerName = c.String(nullable: false, maxLength: 100),
            //            DirectorFirstName = c.String(nullable: false, maxLength: 50),
            //            DirectorLastName = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.ParticipantId, unique: true);
            
            //CreateTable(
            //    "dbo.Component",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Education",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.FccPosition",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Foreign",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Permit",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Position",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Race",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Setting",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.YesNoDontKnow",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Application", new[] { "ParticipantId" });
            DropTable("dbo.YesNoDontKnow");
            DropTable("dbo.Setting");
            DropTable("dbo.Race");
            DropTable("dbo.Position");
            DropTable("dbo.Permit");
            DropTable("dbo.Foreign");
            DropTable("dbo.FccPosition");
            DropTable("dbo.Education");
            DropTable("dbo.Component");
            DropTable("dbo.Application");
        }
    }
}
