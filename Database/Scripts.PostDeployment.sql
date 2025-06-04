IF NOT EXISTS (SELECT 1 FROM [dbo].[Product])
BEGIN 
    :r ./dbo.Product.Insert.sql
END

GO