-- =============================================
-- Author:		<Author,,Relly>
-- Create date: <Create Date,,2009-10-14>
-- Description:	<Description,,Clear the log of all applications>
-- =============================================
CREATE PROCEDURE [dbo].[Durados_LogClear] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	truncate table Durados_Log;
END

