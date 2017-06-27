namespace Navicon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescripionToCustomerClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Description", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Description");
        }
    }
}
