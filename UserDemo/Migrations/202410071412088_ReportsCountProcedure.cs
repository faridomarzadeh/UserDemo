namespace UserDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportsCountProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("UserReportsCountProcedure",
                @"
                    with UserLoginCounts AS 
                    (
                    SELECT LoginReports.UserId as UserId, COUNT(LoginReports.UserId) As Count
                    from LoginReports
                    Group by LoginReports.UserId
                    )

                    Select Count(UserId) AS Count
                    FROM UserLoginCounts;
                ");
        }
        
        public override void Down()
        {
            DropStoredProcedure("UserReportsCountProcedure");
        }
    }
}
