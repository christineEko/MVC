namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerID2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Customers", "ID", "Id");
        }
        
        public override void Down()
        {
        }
    }
}
