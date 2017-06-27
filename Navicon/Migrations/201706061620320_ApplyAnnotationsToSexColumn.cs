namespace Navicon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToSexColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Sex", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Sex", c => c.String());
        }
    }
}
