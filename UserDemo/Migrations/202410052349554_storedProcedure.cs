namespace UserDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storedProcedure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RegistrationDate", c => c.DateTime(nullable: false));
            CreateStoredProcedure("UserReportsProcedure",
                @"
                    with User_Login(UserId, LastLogin, TotalLogins)
                    AS
                    (
                        SELECT LoginReports.UserId as UserId,
                        MAX(LoginReports.LoginDate) as LastLogin,
                        Count(LoginReports.Id) as TotalLogins
                        FROM LoginReports
                        GROUP BY(UserId)
                    )
                    select Users.FirstName, Users.LastName, Users.RegistrationDate, User_Login.LastLogin, User_Login.TotalLogins
                    from Users
                    INNER JOIN User_Login on Users.Id = User_Login.UserId");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RegistrationDate");
            DropStoredProcedure("UserReportsProcedure");
        }
    }
}