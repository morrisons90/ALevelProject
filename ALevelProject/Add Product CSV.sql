BULK
INSERT Stock
FROM 'C:\Users\Josh\Desktop\stock.csv'
WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO