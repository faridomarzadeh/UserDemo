namespace UserDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedProcedure : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("UserReportsProcedure");
            CreateStoredProcedure("UserReportsProcedure",
                prameter => new
                {
                    PageNumber = prameter.Int(),
                    NumberOfRecordsToRetrieve = prameter.Int()
                },
                @"
                    DECLARE @offsetRows INT, @nextRows INT

                    IF(@PageNumber IS NOT NULL AND @NumberOfRecordsToRetrieve IS NOT NULL)
                    BEGIN
                        SET @offsetRows = (@PageNumber - 1) * @NumberOfRecordsToRetrieve;
                        SET @nextRows = @NumberOfRecordsToRetrieve;
                                END
                    ELSE
                    BEGIN
                        SET @offsetRows = 0;
                        SET @nextRows = 0;
                    END
    
                    ;with User_Login(UserId, LastLogin, TotalLogins)
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
                    INNER JOIN User_Login on Users.Id = User_Login.UserId

                    ORDER BY
                    Users.Id

                    OFFSET @offsetRows ROWS
                    FETCH NEXT @nextRows ROWS ONLY");
        }
        
        public override void Down()
        {
            DropStoredProcedure("UserReportsProcedure");
        }
    }
}
