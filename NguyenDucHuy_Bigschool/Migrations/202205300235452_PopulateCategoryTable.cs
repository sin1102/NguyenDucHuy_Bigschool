namespace NguyenDucHuy_Bigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into categories (id, name) values (1, 'Devolopment')");
            Sql("insert into categories (id, name) values (2, 'Business')");
            Sql("insert into categories (id, name) values (3, 'Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
