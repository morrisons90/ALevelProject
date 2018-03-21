DECLARE @i int = 2
WHILE @i < 300 
BEGIN
    SET @i = @i + 1
    INSERT INTO Products (ProductId, ProductName, Type, Colour, Range, Date) VALUES (CONCAT('MM', @i), 'Test Product 2', 'Test Type', 'Black', 'Test Range', 'Date')
END