namespace rocket_elevator_ui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batteries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TypeBuilding = c.String(),
                        Status = c.String(),
                        DateCommissioning = c.DateTime(),
                        DateLastInspection = c.DateTime(),
                        CertificateOperations = c.String(),
                        Information = c.String(),
                        Notes = c.String(),
                        BuildingId = c.Long(),
                        EmployeeId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AdmContactFullName = c.String(),
                        AdmContactEmail = c.String(),
                        AdmContactPhone = c.String(),
                        TechContactFullName = c.String(),
                        TechContactEmail = c.String(),
                        TechContactPhone = c.String(),
                        CustomerId = c.Long(),
                        AddressId = c.Long(),
                        Addresses_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Addresses_Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.CustomerId)
                .Index(t => t.AddressId)
                .Index(t => t.Addresses_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TypeAddress = c.String(),
                        Status = c.String(),
                        Entity = c.String(),
                        NumberStreet = c.String(),
                        SuiteApt = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Notes = c.String(),
                        BuildingId = c.Long(),
                        CustomerId = c.Long(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Customers_Id = c.Long(),
                        Buildings_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .ForeignKey("dbo.Customers", t => t.Customers_Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Buildings", t => t.Buildings_Id)
                .Index(t => t.BuildingId)
                .Index(t => t.CustomerId)
                .Index(t => t.Customers_Id)
                .Index(t => t.Buildings_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateCreate = c.DateTime(),
                        CompanyName = c.String(),
                        CpyContactFullName = c.String(),
                        CpyContactPhone = c.String(),
                        CpyContactEmail = c.String(),
                        CpyDescription = c.String(),
                        TechAuthorityServiceFullName = c.String(),
                        TechAuthorityServicePhone = c.String(),
                        TechManagerServiceEmail = c.String(),
                        UserId = c.Long(),
                        AddressId = c.Long(),
                        LeadId = c.Long(),
                        Leads_Id = c.Long(),
                        Addresses_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Leads", t => t.Leads_Id)
                .ForeignKey("dbo.Leads", t => t.LeadId)
                .ForeignKey("dbo.Addresses", t => t.Addresses_Id)
                .Index(t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.LeadId)
                .Index(t => t.Leads_Id)
                .Index(t => t.Addresses_Id);
            
            CreateTable(
                "dbo.Interventions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartInterv = c.String(),
                        StopInterv = c.String(),
                        Result = c.String(),
                        Reports = c.String(),
                        Status = c.String(),
                        EmployeeId = c.String(),
                        Author = c.Long(),
                        CustomerId = c.Long(),
                        BuildingId = c.Long(),
                        BatteryId = c.Long(),
                        ColumnId = c.Long(),
                        ElevatorId = c.Long(),
                        AuthorNavigation_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AuthorNavigation_Id)
                .ForeignKey("dbo.Batteries", t => t.BatteryId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .ForeignKey("dbo.Elevators", t => t.ElevatorId)
                .ForeignKey("dbo.Columns", t => t.ColumnId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.BuildingId)
                .Index(t => t.BatteryId)
                .Index(t => t.ColumnId)
                .Index(t => t.ElevatorId)
                .Index(t => t.AuthorNavigation_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Function = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        UserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        EncryptedPassword = c.String(),
                        ResetPasswordToken = c.String(),
                        Admin = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Columns",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TypeBuilding = c.String(),
                        NumberFloorsServed = c.Int(),
                        Status = c.String(),
                        Information = c.String(),
                        Notes = c.String(),
                        BatteryId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batteries", t => t.BatteryId)
                .Index(t => t.BatteryId);
            
            CreateTable(
                "dbo.Elevators",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        Model = c.String(),
                        TypeBuilding = c.String(),
                        Status = c.String(),
                        DateCommissioning = c.DateTime(),
                        DateLastInspection = c.DateTime(),
                        CertificateInspection = c.String(),
                        Information = c.String(),
                        Notes = c.String(),
                        ColumnId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Columns", t => t.ColumnId)
                .Index(t => t.ColumnId);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        CompanyName = c.String(),
                        ProjectName = c.String(),
                        Department = c.String(),
                        ProjectDescription = c.String(),
                        Message = c.String(),
                        FileAttachment = c.Binary(),
                        Filename = c.String(),
                        CustomerId = c.Long(),
                        created_at = c.DateTime(nullable: false),
                        Customers_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Customers", t => t.Customers_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Customers_Id);
            
            CreateTable(
                "dbo.BuildingDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InfoKey = c.String(),
                        Value = c.String(),
                        BuildingId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildingDetails", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Batteries", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Addresses", "Buildings_Id", "dbo.Buildings");
            DropForeignKey("dbo.Buildings", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "Addresses_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Leads", "Customers_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "LeadId", "dbo.Leads");
            DropForeignKey("dbo.Customers", "Leads_Id", "dbo.Leads");
            DropForeignKey("dbo.Leads", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Interventions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Interventions", "ColumnId", "dbo.Columns");
            DropForeignKey("dbo.Interventions", "ElevatorId", "dbo.Elevators");
            DropForeignKey("dbo.Elevators", "ColumnId", "dbo.Columns");
            DropForeignKey("dbo.Columns", "BatteryId", "dbo.Batteries");
            DropForeignKey("dbo.Interventions", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Interventions", "BatteryId", "dbo.Batteries");
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Interventions", "AuthorNavigation_Id", "dbo.Employees");
            DropForeignKey("dbo.Batteries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Buildings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Addresses", "Customers_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Buildings", "Addresses_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.BuildingDetails", new[] { "BuildingId" });
            DropIndex("dbo.Leads", new[] { "Customers_Id" });
            DropIndex("dbo.Leads", new[] { "CustomerId" });
            DropIndex("dbo.Elevators", new[] { "ColumnId" });
            DropIndex("dbo.Columns", new[] { "BatteryId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Interventions", new[] { "AuthorNavigation_Id" });
            DropIndex("dbo.Interventions", new[] { "ElevatorId" });
            DropIndex("dbo.Interventions", new[] { "ColumnId" });
            DropIndex("dbo.Interventions", new[] { "BatteryId" });
            DropIndex("dbo.Interventions", new[] { "BuildingId" });
            DropIndex("dbo.Interventions", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "Addresses_Id" });
            DropIndex("dbo.Customers", new[] { "Leads_Id" });
            DropIndex("dbo.Customers", new[] { "LeadId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Addresses", new[] { "Buildings_Id" });
            DropIndex("dbo.Addresses", new[] { "Customers_Id" });
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            DropIndex("dbo.Addresses", new[] { "BuildingId" });
            DropIndex("dbo.Buildings", new[] { "Addresses_Id" });
            DropIndex("dbo.Buildings", new[] { "AddressId" });
            DropIndex("dbo.Buildings", new[] { "CustomerId" });
            DropIndex("dbo.Batteries", new[] { "EmployeeId" });
            DropIndex("dbo.Batteries", new[] { "BuildingId" });
            DropTable("dbo.BuildingDetails");
            DropTable("dbo.Leads");
            DropTable("dbo.Elevators");
            DropTable("dbo.Columns");
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
            DropTable("dbo.Interventions");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
            DropTable("dbo.Buildings");
            DropTable("dbo.Batteries");
        }
    }
}
